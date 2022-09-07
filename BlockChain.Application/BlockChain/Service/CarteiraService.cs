using AutoMapper;
using BlockChain.Application.BlockChain.Dto;
using BlockChain.Domain.BlockChain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
