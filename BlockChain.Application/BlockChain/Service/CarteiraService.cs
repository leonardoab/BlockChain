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
        private readonly ICarteiraRepository playlistRepository;
        private readonly IMapper mapper;

        public CarteiraService(ICarteiraRepository CarteiraRepository, IMapper mapper)
        {
            this.playlistRepository = CarteiraRepository;
            this.mapper = mapper;
        }

        public async Task<CarteiraOutputDto> Criar(CarteiraInputCreateDto dto)
        {
            var Carteira = this.mapper.Map<Domain.BlockChain.Carteira>(dto);

            await this.playlistRepository.Save(Carteira);

            return this.mapper.Map<CarteiraOutputDto>(Carteira);

        }

        public async Task<CarteiraOutputDto> Deletar(CarteiraInputDeleteDto dto)
        {
            var Carteira = this.mapper.Map<Domain.BlockChain.Carteira>(dto);

            await this.playlistRepository.Delete(Carteira);

            return this.mapper.Map<CarteiraOutputDto>(Carteira);

        }

        public async Task<CarteiraOutputDto> Atualizar(CarteiraInputUpdateDto dto)
        {
            var Carteira = this.mapper.Map<Domain.BlockChain.Carteira>(dto);

            await this.playlistRepository.Update(Carteira);

            return this.mapper.Map<CarteiraOutputDto>(Carteira);

        }


        public async Task<List<CarteiraOutputDto>> ObterTodos()
        {
            var Carteira = await this.playlistRepository.GetAll();

            return this.mapper.Map<List<CarteiraOutputDto>>(Carteira);
        }
    }
}
