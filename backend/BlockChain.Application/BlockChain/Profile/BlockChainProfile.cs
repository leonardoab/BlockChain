using BlockChain.Application.BlockChain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Profile
{
    public class BlockChainProfile : AutoMapper.Profile
    {
        public BlockChainProfile() 
        {


            CreateMap<UsuarioInputCreateDto, Domain.BlockChain.Usuario>()
                   .ForPath(x => x.Password.Valor, f => f.MapFrom(m => m.Password))
                   .ForPath(x => x.Email.Valor, f => f.MapFrom(m => m.Email));

            CreateMap<UsuarioInputUpdateDto, Domain.BlockChain.Usuario>()
                .ForPath(x => x.Password.Valor, f => f.MapFrom(m => m.Password))
                .ForPath(x => x.Email.Valor, f => f.MapFrom(m => m.Email));            

            CreateMap<Domain.BlockChain.Usuario, UsuarioOutputDto>()
                .ForPath(x => x.Password, f => f.MapFrom(m => m.Password.Valor))
                .ForPath(x => x.Email, f => f.MapFrom(m => m.Email.Valor));

            CreateMap<UsuarioInputAutenticacaoDto, Domain.BlockChain.Usuario>()
                .ForPath(x => x.Password.Valor, f => f.MapFrom(m => m.Password))
                .ForPath(x => x.Email.Valor, f => f.MapFrom(m => m.Email));


            CreateMap<UsuarioInputDeleteDto, Domain.BlockChain.Usuario>();
            


            CreateMap<TransacaoInputCreateDto, Domain.BlockChain.Transacao>();            

            CreateMap<TransacaoInputUpdateDto, Domain.BlockChain.Transacao>();

            CreateMap<TransacaoInputDeleteDto, Domain.BlockChain.Transacao>();

            CreateMap<Domain.BlockChain.Transacao, TransacaoOutputDto>();

            


            CreateMap<HistoricoInputCreateDto, Domain.BlockChain.Historico>();

            CreateMap<HistoricoInputUpdateDto, Domain.BlockChain.Historico>();

            CreateMap<HistoricoInputDeleteDto, Domain.BlockChain.Historico>();

            

            CreateMap<Domain.BlockChain.Historico, HistoricoOutputDto>();



            CreateMap<CarteiraInputCreateDto, Domain.BlockChain.Carteira>();

            CreateMap<CarteiraInputUpdateDto, Domain.BlockChain.Carteira>();

            CreateMap<CarteiraInputDeleteDto, Domain.BlockChain.Carteira>();

            

            CreateMap<Domain.BlockChain.Carteira, CarteiraOutputDto>();


            CreateMap<NftInputCreateDto, Domain.BlockChain.Nft>();

            CreateMap<NftInputUpdateDto, Domain.BlockChain.Nft>();

            CreateMap<Domain.BlockChain.Nft, NftOutputDto>();

            CreateMap<NftInputDeleteDto, Domain.BlockChain.Nft>();
            















        }




    }
}
