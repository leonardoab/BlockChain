﻿using AutoMapper;
using BlockChain.Application.BlockChain.Dto;
using BlockChain.Domain.BlockChain;
using BlockChain.Domain.BlockChain.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Service
{
    public class CarteiraService : ICarteiraService
    {
        private readonly ICarteiraRepository carteiraRepository;
        private readonly IHistoricoRepository historicoRepository;
        private readonly IGenericService genericService;
        private readonly IMapper mapper;

        public CarteiraService(ICarteiraRepository CarteiraRepository, IHistoricoRepository HistoricoRepository, IGenericService GenericService, IMapper mapper)
        {
            this.carteiraRepository = CarteiraRepository;
            this.historicoRepository = HistoricoRepository;
            this.genericService = GenericService;
            this.mapper = mapper;
        }

        public async Task<CarteiraOutputDto> Criar(CarteiraInputCreateDto dto)
        {
            var Carteira = this.mapper.Map<Domain.BlockChain.Carteira>(dto);

            await this.carteiraRepository.Save(Carteira);

            return this.mapper.Map<CarteiraOutputDto>(Carteira);

        }

        public async Task<CarteiraOutputDto> Deletar(CarteiraInputDeleteDto dto)
        {
            var Carteira = this.mapper.Map<Domain.BlockChain.Carteira>(dto);

            await this.carteiraRepository.Delete(Carteira);

            return this.mapper.Map<CarteiraOutputDto>(Carteira);

        }

        public async Task<CarteiraOutputDto> Atualizar(CarteiraInputUpdateDto dto)
        {
            var Carteira = this.mapper.Map<Domain.BlockChain.Carteira>(dto);

            await this.carteiraRepository.Update(Carteira);

            return this.mapper.Map<CarteiraOutputDto>(Carteira);

        }


        public async Task<List<CarteiraOutputDto>> ObterTodos()
        {
            var Carteira = await this.carteiraRepository.ObterTodasCarteiras();

            return this.mapper.Map<List<CarteiraOutputDto>>(Carteira);
        }


        public async Task<string> AtualizarCarteiras()
        {

            IList<String> linhasTabela = await genericService.BuscarTabela("https://bscscan.com/token/tokenholderchart/0x6dd60afb2586d31bf390450adf5e6a9659d48c4a?range=500");

            linhasTabela.RemoveAt(497);

            IList<Carteira> carteiras = (IList<Carteira>)await this.carteiraRepository.ObterTodasCarteiras();

            IList<String> listaCarteirasAtualizadas = new List<String>();

            float diferenca = 0;

            for (int i = 0; i < linhasTabela.Count; i++)
            {

                IList<String> campos = await genericService.ConverterLinhaEmCampos(linhasTabela[i]);

                listaCarteirasAtualizadas.Add(campos[1]);

                var result = carteiras.Where(x => x.CodigoCarteira.Equals(campos[1]));



                if (result.Count() > 0)
                {
                    Carteira carteiraEncontrada = new Carteira();
                    carteiraEncontrada = result.First();

                    if (carteiraEncontrada.Saldo != float.Parse(campos[2]))
                    {
                        diferenca = float.Parse(campos[2]) - carteiraEncontrada.Saldo;
                        carteiraEncontrada.Saldo = float.Parse(campos[2]);
                        carteiraEncontrada.DataVerificacao = DateTime.Now;
                        carteiraEncontrada.Rank = 1;

                        Historico historico = new Historico(carteiraEncontrada);
                        historico.Diferenca = diferenca;
                        await this.historicoRepository.Save(historico);

                        carteiraEncontrada.Historicos.Add(historico);
                        await this.carteiraRepository.Update(carteiraEncontrada);
                    }


                }

                else
                {

                    Carteira carteiraNova = new Carteira();
                    carteiraNova.CodigoCarteira = campos[1];
                    carteiraNova.DataVerificacao = DateTime.Now;
                    carteiraNova.Saldo = float.Parse(campos[2]);
                    carteiraNova.Rank = 1;
                    carteiraNova.NumeroTransacoes = 0;
                    carteiraNova.TipoCarteira = "Privada";

                    await this.carteiraRepository.Save(carteiraNova);

                    Historico historico = new Historico(carteiraNova);
                    historico.Diferenca = carteiraNova.Saldo;

                    await this.historicoRepository.Save(historico);

                    carteiraNova.Historicos.Add(historico);

                    await this.carteiraRepository.Update(carteiraNova);

                }



            }

            IList<Carteira> carteirasFora = new List<Carteira>();

            for (int i = 0; i < carteiras.Count; i++)
            {

                var result = listaCarteirasAtualizadas.Contains(carteiras[i].CodigoCarteira);

                if (!result)
                {
                    carteiras[i].Rank = 0;
                    await this.carteiraRepository.Update(carteiras[i]);
                    carteirasFora.Add(carteiras[i]);

                }


            }

            await BuscarSaldosCarteirasAPI(carteirasFora);


            return "Sucesso";
        }


        public async Task<string> BuscarSaldosCarteirasAPI(IList<Carteira> carteiras)
        {
            //string uri = "https://api.bscscan.com/api?module=account&action=tokenbalance&contractaddress=0x6Dd60AFB2586D31Bf390450aDf5E6A9659d48c4A&address=0xdbd8e899c2b2aa8c1da54c824fea17d58e082465&tag=latest&apikey=MPQA8WX7TMPXWCCBM16HSZDPIP2YQNXHQA";

            string uriBase = "https://api.bscscan.com/api?module=account&action=tokenbalance&contractaddress=";
            string contrato = "0x6Dd60AFB2586D31Bf390450aDf5E6A9659d48c4A";
            string uriBaseSegundaParte = "&address=";
            string carteira = "0xdbd8e899c2b2aa8c1da54c824fea17d58e082465";
            string uriBaseTerceiraParte = "&tag=latest&apikey=MPQA8WX7TMPXWCCBM16HSZDPIP2YQNXHQA";

            HttpClient client = new HttpClient();

            float diferenca = 0;



            for (int i = 0; i < carteiras.Count; i++)
            {

                Task.Delay(1000).Wait();

                carteira = carteiras[i].CodigoCarteira;

                HttpResponseMessage response = await client.GetAsync(uriBase + contrato + uriBaseSegundaParte + carteira + uriBaseTerceiraParte);


                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var respostaBsc = JsonConvert.DeserializeObject<RespostaBsc>(responseBody);


                    try
                    {
                        float saldo = 0;

                        if (respostaBsc.result.Length > 18)
                        {
                            saldo = float.Parse(respostaBsc.result.Substring(0, respostaBsc.result.Length - 18));
                        }

                        if (carteiras[i].Saldo != saldo)
                        {
                            diferenca = saldo - carteiras[i].Saldo;
                            Historico historico = new Historico();
                            historico.NumeroTransacoes = 0;
                            historico.Diferenca = diferenca;
                            historico.Saldo = saldo;
                            historico.CodigoCarteira = carteiras[i].CodigoCarteira;
                            historico.DataHistorico = DateTime.Now;
                            await this.historicoRepository.Save(historico);

                            carteiras[i].Saldo = saldo;
                            carteiras[i].DataVerificacao = DateTime.Now;
                            carteiras[i].Historicos.Add(historico);
                            await this.carteiraRepository.Update(carteiras[i]);



                        }


                    }

                    catch
                    {

                    }



                }



            }

            return "Sucesso";


        }
    }

}
