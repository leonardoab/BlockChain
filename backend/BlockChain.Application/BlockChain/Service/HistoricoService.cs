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
    public class HistoricoService : IHistoricoService
    {
        private readonly IHistoricoRepository historicoRepository;
        private readonly IMapper mapper;

        public HistoricoService(IHistoricoRepository HistoricoRepository, IMapper mapper)
        {
            this.historicoRepository = HistoricoRepository;
            this.mapper = mapper;
        }

        public async Task<HistoricoOutputDto> Criar(HistoricoInputCreateDto dto)
        {
            var Historico = this.mapper.Map<Domain.BlockChain.Historico>(dto);

            await this.historicoRepository.Save(Historico);

            return this.mapper.Map<HistoricoOutputDto>(Historico);

        }

        public async Task<HistoricoOutputDto> Deletar(HistoricoInputDeleteDto dto)
        {
            var Historico = this.mapper.Map<Domain.BlockChain.Historico>(dto);

            await this.historicoRepository.Delete(Historico);

            return this.mapper.Map<HistoricoOutputDto>(Historico);

        }

        public async Task<HistoricoOutputDto> Atualizar(HistoricoInputUpdateDto dto)
        {
            var Historico = this.mapper.Map<Domain.BlockChain.Historico>(dto);

            await this.historicoRepository.Update(Historico);

            return this.mapper.Map<HistoricoOutputDto>(Historico);

        }


        public async Task<List<HistoricoOutputDto>> ObterTodos()
        {
            var Historico = await this.historicoRepository.GetAll();

            return this.mapper.Map<List<HistoricoOutputDto>>(Historico);
        }
    }
}
