using AutoMapper;
using BlockChain.Application.BlockChain.Dto;
using BlockChain.Domain.BlockChain;
using BlockChain.Domain.BlockChain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Service
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository transacaoRepository;
        private readonly IMapper mapper;

        public TransacaoService(ITransacaoRepository TransacaoRepository, IMapper mapper)
        {
            this.transacaoRepository = TransacaoRepository;
            this.mapper = mapper;
        }

        public async Task<TransacaoOutputDto> Criar(TransacaoInputCreateDto dto)
        {
            var Transacao = this.mapper.Map<Domain.BlockChain.Transacao>(dto);

            await this.transacaoRepository.Save(Transacao);

            return this.mapper.Map<TransacaoOutputDto>(Transacao);

        }

        public async Task<TransacaoOutputDto> Deletar(TransacaoInputDeleteDto dto)
        {
            var Transacao = this.mapper.Map<Domain.BlockChain.Transacao>(dto);

            await this.transacaoRepository.Delete(Transacao);

            return this.mapper.Map<TransacaoOutputDto>(Transacao);

        }

        public async Task<TransacaoOutputDto> Atualizar(TransacaoInputUpdateDto dto)
        {
            var Transacao = this.mapper.Map<Domain.BlockChain.Transacao>(dto);

            await this.transacaoRepository.Update(Transacao);

            return this.mapper.Map<TransacaoOutputDto>(Transacao);

        }


        public async Task<List<TransacaoOutputDto>> ObterTodos()
        {
            var Transacao = await this.transacaoRepository.GetAll();

            return this.mapper.Map<List<TransacaoOutputDto>>(Transacao);
        }


        public async Task<Transacao> BuscarTransacaoPorId(Guid Id)
        {

            var historicos = await this.transacaoRepository.FindAllByCriteria(x => x.Id == Id);

            if (historicos.Count() == 1) return historicos.First();
            else return null;


        }
    }
}
