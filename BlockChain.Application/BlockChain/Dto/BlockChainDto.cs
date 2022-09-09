﻿using BlockChain.Domain.BlockChain;
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
        int NumeroTransacoes,
        DateTime DataVerificacao,
        int Rank,
        string TipoCarteira,
        IList<Historico> Historicos,
        IList<Transacao> Transacoes);

    public record CarteiraInputUpdateDto(
        Guid Id,
        string CodigoCarteira,
        float Saldo,
        int NumeroTransacoes,
        DateTime DataVerificacao,
        int Rank,
        string TipoCarteira,
        IList<Historico> Historicos,
        IList<Transacao> Transacoes);

    public record CarteiraInputDeleteDto(
        Guid Id);

    public record CarteiraOutputDto(
        Guid Id,
        string CodigoCarteira,
        float Saldo,
        int NumeroTransacoes,
        DateTime DataVerificacao,
        int Rank,
        string TipoCarteira,
        IList<Historico> Historicos,
        IList<Transacao> Transacoes);


    ///CARTEIRA

    public record HistoricoInputCreateDto(
        DateTime DataHistorico,
        string CodigoCarteira,
        float Saldo,
        int NumeroTransacoes);

    public record HistoricoInputUpdateDto(
        Guid Id,
        DateTime DataHistorico,
        string CodigoCarteira,
        float Saldo,
        int NumeroTransacoes);

    public record HistoricoInputDeleteDto(
        Guid Id);

    public record HistoricoOutputDto(
        Guid Id,
        DateTime DataHistorico,
        string CodigoCarteira,
        float Saldo,
        int NumeroTransacoes);

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




















}