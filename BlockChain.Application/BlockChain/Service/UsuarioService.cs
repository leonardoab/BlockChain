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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository playlistRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository UsuarioRepository, IMapper mapper)
        {
            this.playlistRepository = UsuarioRepository;
            this.mapper = mapper;
        }

        public async Task<UsuarioOutputDto> Criar(UsuarioInputCreateDto dto)
        {
            var Usuario = this.mapper.Map<Domain.BlockChain.Usuario>(dto);

            await this.playlistRepository.Save(Usuario);

            return this.mapper.Map<UsuarioOutputDto>(Usuario);

        }

        public async Task<UsuarioOutputDto> Deletar(UsuarioInputDeleteDto dto)
        {
            var Usuario = this.mapper.Map<Domain.BlockChain.Usuario>(dto);

            await this.playlistRepository.Delete(Usuario);

            return this.mapper.Map<UsuarioOutputDto>(Usuario);

        }

        public async Task<UsuarioOutputDto> Atualizar(UsuarioInputUpdateDto dto)
        {
            var Usuario = this.mapper.Map<Domain.BlockChain.Usuario>(dto);

            await this.playlistRepository.Update(Usuario);

            return this.mapper.Map<UsuarioOutputDto>(Usuario);

        }


        public async Task<List<UsuarioOutputDto>> ObterTodos()
        {
            var Usuario = await this.playlistRepository.GetAll();

            return this.mapper.Map<List<UsuarioOutputDto>>(Usuario);
        }
    }
}
