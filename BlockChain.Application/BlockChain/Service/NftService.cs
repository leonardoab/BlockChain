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
    public class NftService : INftService
    {
        private readonly INftRepository nftRepository;
        private readonly IMapper mapper;

        public NftService(INftRepository NftRepository, IMapper mapper)
        {
            this.nftRepository = NftRepository;
            this.mapper = mapper;
        }

        public async Task<NftOutputDto> Criar(NftInputCreateDto dto)
        {
            var Nft = this.mapper.Map<Domain.BlockChain.Nft>(dto);

            await this.nftRepository.Save(Nft);

            return this.mapper.Map<NftOutputDto>(Nft);

        }

        public async Task<NftOutputDto> Deletar(NftInputDeleteDto dto)
        {
            var Nft = this.mapper.Map<Domain.BlockChain.Nft>(dto);

            await this.nftRepository.Delete(Nft);

            return this.mapper.Map<NftOutputDto>(Nft);

        }

        public async Task<NftOutputDto> Atualizar(NftInputUpdateDto dto)
        {
            var Nft = this.mapper.Map<Domain.BlockChain.Nft>(dto);

            await this.nftRepository.Update(Nft);

            return this.mapper.Map<NftOutputDto>(Nft);

        }


        public async Task<List<NftOutputDto>> ObterTodos()
        {
            var Nft = await this.nftRepository.GetAll();

            return this.mapper.Map<List<NftOutputDto>>(Nft);
        }
    }
}
