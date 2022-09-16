﻿using AutoMapper;
using BlockChain.Application.BlockChain.Dto;
using BlockChain.Cross.Utils;
using BlockChain.Domain.BlockChain;
using BlockChain.Domain.BlockChain.Repository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Service
{
    public class UsuarioService : IUsuarioService
    {
        
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        private string jwtsecret = "ACDt1vR3lXToPQ1g3MyN";
        private string audience = "spotify-api";
        private string issuer = "http://127.0.0.1:80";

        public UsuarioService(IUsuarioRepository UsuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = UsuarioRepository;
            this.mapper = mapper;
        }

        public async Task<UsuarioOutputDto> Criar(UsuarioInputCreateDto dto)
        {
            var Usuario = this.mapper.Map<Domain.BlockChain.Usuario>(dto);

            await this.usuarioRepository.Save(Usuario);

            return this.mapper.Map<UsuarioOutputDto>(Usuario);

        }

        public async Task<UsuarioOutputDto> Deletar(UsuarioInputDeleteDto dto)
        {
            var Usuario = this.mapper.Map<Domain.BlockChain.Usuario>(dto);

            await this.usuarioRepository.Delete(Usuario);

            return this.mapper.Map<UsuarioOutputDto>(Usuario);

        }

        public async Task<UsuarioOutputDto> Atualizar(UsuarioInputUpdateDto dto)
        {
            var Usuario = this.mapper.Map<Domain.BlockChain.Usuario>(dto);

            await this.usuarioRepository.Update(Usuario);

            return this.mapper.Map<UsuarioOutputDto>(Usuario);

        }


        public async Task<List<UsuarioOutputDto>> ObterTodos()
        {
            var Usuario = await this.usuarioRepository.GetAll();

            return this.mapper.Map<List<UsuarioOutputDto>>(Usuario);
        }

        

        public async Task<bool> AuthenticateUser(UsuarioInputAutenticacaoDto dto)
        {
            var usuario = this.mapper.Map<Usuario>(dto);

            var usuarios = await this.usuarioRepository.GetAll();

            Usuario usuarioEncontrado = usuarios.Where(x => x.Email.Valor.Equals(usuario.Email.Valor)).First();

            if (usuarioEncontrado == null) return false;

            else
            {

                string senha = usuarioEncontrado.Password.Valor;

                if (senha == SecurityUtils.HashSHA1(usuario.Password.Valor)) return true;
                else return false;


            }

        }

        public Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name,"Usuario"),
                new Claim("role","Admin")
            };

            var token = new JwtSecurityToken(issuer,
               audience,
               claims,
               expires: DateTime.Now.AddMinutes(15),
               signingCredentials: credentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

        }
    }
}
