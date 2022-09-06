﻿using BlockChain.Application.BlockChain.Dto;

namespace BlockChain.Application.BlockChain.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDto> Atualizar(UsuarioInputUpdateDto dto);
        Task<UsuarioOutputDto> Criar(UsuarioInputCreateDto dto);
        Task<UsuarioOutputDto> Deletar(UsuarioInputDeleteDto dto);
        Task<List<UsuarioOutputDto>> ObterTodos();
    }
}