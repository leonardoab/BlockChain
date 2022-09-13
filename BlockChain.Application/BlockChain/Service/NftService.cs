using AutoMapper;
using BlockChain.Application.BlockChain.Dto;
using BlockChain.Cross.Utils;
using BlockChain.Domain.BlockChain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Service
{
    public class NftService : INftService
    {
        private readonly INftRepository nftRepository;
        private readonly IMapper mapper;
        private IHttpClientFactory httpClientFactory;
        private AzureBlobStorage storage;

        public NftService(INftRepository NftRepository, IMapper mapper, IHttpClientFactory httpClientFactory, AzureBlobStorage storage)
        {
            this.nftRepository = NftRepository;
            this.mapper = mapper;
            this.httpClientFactory = httpClientFactory;
            this.storage = storage;
        }

        public async Task<NftOutputDto> Criar(NftInputCreateDto dto)
        {
            var Nft = this.mapper.Map<Domain.BlockChain.Nft>(dto);

            HttpClient httpClient = this.httpClientFactory.CreateClient();

            using var response = await httpClient.GetAsync(Nft.Imagem);


            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();

                var fileName = $"{Guid.NewGuid()}.jpg";

                var pathStorage = await this.storage.UploadFile(fileName, stream);

                Nft.Imagem = pathStorage;

            }

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
