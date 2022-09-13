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
            var Carteira = await this.carteiraRepository.GetAll();

            return this.mapper.Map<List<CarteiraOutputDto>>(Carteira);
        }


        public async Task<string> AtualizarCarteiras()
        {

            IList<String> linhasTabela = await genericService.BuscarTabela("https://bscscan.com/token/tokenholderchart/0x6dd60afb2586d31bf390450adf5e6a9659d48c4a?range=500");

            linhasTabela.RemoveAt(497);

            IList<Carteira> carteiras = (IList<Carteira>)await this.carteiraRepository.ObterTodasCarteiras();

            IList<String> listaCarteirasAtualizadas = new List<String>();



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
                        carteiraEncontrada.Saldo = float.Parse(campos[2]);
                        carteiraEncontrada.DataVerificacao = DateTime.Now;
                        carteiraEncontrada.Rank = 1;

                        Historico historico = new Historico(carteiraEncontrada);                        
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
                    
                    await this.historicoRepository.Save(historico);                    
                    
                    carteiraNova.Historicos.Add(historico);

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


        

        



    }
}
