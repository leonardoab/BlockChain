using BlockChain.Domain.BlockChain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Dto
{
    public record CarteiraInputCreateDto(
        string CodigoCarteira,
        float Saldo,
        float SaldoDiario,
        int NumeroTransacoes,
        DateTime DataVerificacao,
        int Rank,
        string TipoCarteira,        
        IList<Historico> Historicos,
        IList<Transacao> Transacoes,
        IList<Nft> Nfts);

    public record CarteiraInputUpdateDto(
        Guid Id,
        string CodigoCarteira,
        float Saldo,
        float SaldoDiario,
        int NumeroTransacoes,
        DateTime DataVerificacao,
        int Rank,
        string TipoCarteira,       
        IList<Historico> Historicos,
        IList<Transacao> Transacoes,
        IList<Nft> Nfts);

    public record CarteiraInputDeleteDto(
        Guid Id);

    public record CarteiraOutputDto(
        Guid Id,
        string CodigoCarteira,
        float Saldo,
        float SaldoDiario,
        int NumeroTransacoes,
        DateTime DataVerificacao,
        int Rank,
        string TipoCarteira,
        IList<Historico> Historicos,
        IList<Transacao> Transacoes,
        IList<Nft> Nfts);


    ///CARTEIRA

    public record HistoricoInputCreateDto(
        DateTime DataHistorico,
        string CodigoCarteira,
        float Saldo,
        int NumeroTransacoes,
        float Diferenca);

    public record HistoricoInputUpdateDto(
        Guid Id,
        DateTime DataHistorico,
        string CodigoCarteira,
        float Saldo,
        int NumeroTransacoes,
        float Diferenca);

    public record HistoricoInputDeleteDto(
        Guid Id);

    public record HistoricoOutputDto(
        Guid Id,
        DateTime DataHistorico,
        string CodigoCarteira,
        float Saldo,
        int NumeroTransacoes,
        float Diferenca);

    /// HISTORICO    

    public record TransacaoInputCreateDto(
       DateTime DataTrasacao,
       string TipoTransacao,
       string CodigoTransacao,
       string CodigoCarteiraOrigem,
       string CodigoCarteiraDestino,
       float Saldo);

    public record TransacaoInputUpdateDto(
       Guid Id,
       DateTime DataTrasacao,
       string TipoTransacao,
       string CodigoTransacao,
       string CodigoCarteiraOrigem,
       string CodigoCarteiraDestino,
       float Saldo);

    public record TransacaoInputDeleteDto(
        Guid Id);

    public record TransacaoOutputDto(
        Guid Id,
         DateTime DataTrasacao,
       string TipoTransacao,
       string CodigoTransacao,
       string CodigoCarteiraOrigem,
       string CodigoCarteiraDestino,
       float Saldo);

    /// TRANSACAO

    public record UsuarioInputCreateDto(
        string Nome,
        string Email,
        string Password,
        IList<Transacao> Transacoes);

    public record UsuarioInputUpdateDto(
        Guid Id,
        string Nome,
        string Email,
        string Password,
        IList<Transacao> Transacoes);

    public record UsuarioInputDeleteDto(
        Guid Id);

    public record UsuarioOutputDto(
        Guid Id,
        string Nome,
        string Email,
        string Password,
        IList<Transacao> Transacoes);

    //NFT

    public record NftInputCreateDto(
        string Nome,
        string Imagem,
        int Rank,
        int IdRede);

    public record NftInputUpdateDto(
        Guid Id,
        string Nome,
        string Imagem,
        int Rank,
        int IdRede);

    public record NftInputDeleteDto(
        Guid Id);

    public record NftOutputDto(
        Guid Id,
        string Nome,
        string Imagem,
        int Rank,
        int IdRede
        );

    public record UsuarioInputAutenticacaoDto(
                string Email,
                string Password);




















}
