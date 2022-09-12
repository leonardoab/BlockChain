using AutoMapper;
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
        private readonly IMapper mapper;

        public CarteiraService(ICarteiraRepository CarteiraRepository, IHistoricoRepository HistoricoRepository, IMapper mapper)
        {
            this.carteiraRepository = CarteiraRepository;
            this.historicoRepository = HistoricoRepository;
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
            var Carteira = await this.carteiraRepository.GetAll();

            return this.mapper.Map<List<CarteiraOutputDto>>(Carteira);
        }


        public async Task<string> AtualizarCarteiras()
        {

            IList<String> linhasTabela = await BuscarTabela("https://bscscan.com/token/tokenholderchart/0x6dd60afb2586d31bf390450adf5e6a9659d48c4a?range=500");

            linhasTabela.RemoveAt(497);

            IList<Carteira> carteiras = (IList<Carteira>)await this.carteiraRepository.ObterTodasCarteiras();

            IList<String> listaCarteirasAtualizadas = new List<String>();



            for (int i = 0; i < linhasTabela.Count; i++)
            {                

                IList<String> campos = await ConverterLinhaEmCampos(linhasTabela[i]);

                listaCarteirasAtualizadas.Add(campos[1]);

                var result = carteiras.Where(x => x.CodigoCarteira.Equals(campos[1]));      

                

                if (result.Count() > 0)
                {
                    Carteira carteiraEncontrada = new Carteira();
                    carteiraEncontrada = result.First();

                    if (carteiraEncontrada.Saldo != float.Parse(campos[2]))
                    {
                        carteiraEncontrada.Saldo = float.Parse(campos[2]);
                        carteiraEncontrada.DataVerificacao = DateTime.Now;
                        carteiraEncontrada.Rank = 1;

                        Historico historico = new Historico();
                        historico.NumeroTransacoes = 0;
                        historico.Saldo = carteiraEncontrada.Saldo;
                        historico.CodigoCarteira = carteiraEncontrada.CodigoCarteira;
                        historico.DataHistorico = DateTime.Now;
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


                    Historico historico = new Historico();
                    historico.NumeroTransacoes = 0;
                    historico.Saldo = carteiraNova.Saldo;
                    historico.CodigoCarteira = carteiraNova.CodigoCarteira;
                    historico.DataHistorico = DateTime.Now;
                    await this.historicoRepository.Save(historico);

                    IList<Historico> historicos = new List<Historico>();
                    historicos.Add(historico);
                    carteiraNova.Historicos = historicos;
                    await this.carteiraRepository.Update(carteiraNova);

                }



            }

            for (int i = 0; i < carteiras.Count; i++)
            {

                var result = listaCarteirasAtualizadas.Contains(carteiras[i].CodigoCarteira);
                
                if (!result)
                {
                    carteiras[i].Rank = 0;
                    await this.carteiraRepository.Update(carteiras[i]);

                }


            }

            
            return "Sucesso";
        }


        public async Task<IList<String>> BuscarTabela(string url)
        {
            IList<String> linhasTabela = new List<String>();

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                var inicio = responseBody.IndexOf("<tbody>");
                var fim = responseBody.IndexOf("</tbody>");

                responseBody = responseBody.Substring(inicio, (fim - inicio));

                while (responseBody.IndexOf("<tr>") > 0)
                {
                    inicio = responseBody.IndexOf("<tr>");
                    fim = responseBody.IndexOf("</td><tr>") + 9;
                    var linha = responseBody.Substring(inicio, (fim - inicio));
                    responseBody = " " + responseBody.Substring(fim - 4, (responseBody.Length - (fim - 4 + 1)));
                    linhasTabela.Add(linha);

                }

            }

            return linhasTabela;

        }

        public Task<IList<string>> ConverterLinhaEmCampos(String listaTabela)
        {

            IList<String> listaCampos = new List<String>();

            while (listaTabela.IndexOf("<td>") > 0)
            {
                var inicio = listaTabela.IndexOf("<td>");
                var fim = listaTabela.IndexOf("</td>") + 5;
                var linha = listaTabela.Substring(inicio + 4, (fim - inicio) - 9);

                if (linha.IndexOf("c4a?a=") > 0)
                {

                    inicio = listaTabela.IndexOf("c4a?a=");
                    linha = linha.Substring(inicio + 1, 42);

                }

                if (linha.IndexOf(".") > 0)
                {
                    linha = linha.Substring(0, linha.IndexOf("."));

                }

                if (linha.IndexOf(",") > 0)
                {
                    linha = linha.Replace(",", "");

                }


                listaTabela = " " + listaTabela.Substring(fim, (listaTabela.Length - (fim)));
                listaCampos.Add(linha);

            }

            return Task.FromResult(listaCampos);




        }



    }
}
