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
        private readonly IMapper mapper;

        public CarteiraService(ICarteiraRepository CarteiraRepository, IMapper mapper)
        {
            this.carteiraRepository = CarteiraRepository;
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

        public async Task<string> BuscarSaldosCarteiras()
        {
            //string uri = "https://api.bscscan.com/api?module=account&action=tokenbalance&contractaddress=0x6Dd60AFB2586D31Bf390450aDf5E6A9659d48c4A&address=0xdbd8e899c2b2aa8c1da54c824fea17d58e082465&tag=latest&apikey=MPQA8WX7TMPXWCCBM16HSZDPIP2YQNXHQA";

            string uriBase = "https://api.bscscan.com/api?module=account&action=tokenbalance&contractaddress=";
            string contrato = "0x6Dd60AFB2586D31Bf390450aDf5E6A9659d48c4A";
            string uriBaseSegundaParte = "&address=";
            string carteira = "0xdbd8e899c2b2aa8c1da54c824fea17d58e082465";
            string uriBaseTerceiraParte = "&tag=latest&apikey=MPQA8WX7TMPXWCCBM16HSZDPIP2YQNXHQA";

            HttpClient client = new HttpClient();

            IList<Carteira> carteiras = (IList<Carteira>)await this.carteiraRepository.GetAll();

            for (int i = 0; i < carteiras.Count; i++) {

                carteira = carteiras[i].CodigoCarteira;
                
                HttpResponseMessage response = await client.GetAsync(uriBase + contrato + uriBaseSegundaParte + carteira + uriBaseTerceiraParte);


                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var respostaBsc = JsonConvert.DeserializeObject<RespostaBsc>(responseBody);

                    float saldo = float.Parse(respostaBsc.result.Substring(0, respostaBsc.result.Length - 16));

                    if (carteiras[i].Saldo != saldo)
                    {
                        carteiras[i].Saldo = saldo;
                        this.carteiraRepository.Update(carteiras[i]);


                    }

                    //await this.carteiraRepository.Update(Carteiras[i]);

                }
                else
                {

                    string msg = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(msg);
                    throw new Exception(msg);
                }


            }

            return "Sucesso";





            
            

        }
    }
}
