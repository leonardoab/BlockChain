import { BaseEntity } from './BaseEntity';
import { Historico } from './Historico';
import { Transacao } from './Transacao';
import { Nft } from './Nft';

/*import { TipocomandOperacao } from './TipocomandOperacao';
import { TipoMotivorestricao } from './TipoMotivorestricao';
import { ComandOperacao } from './ComandOperacao';*/


export class Carteira extends BaseEntity<number> {


    public CodigoCarteira?: string;

    public Saldo?: number;
    
    public SaldoDiario?: number;

    public NumeroTransacoes?: number;

    public DataVerificacao?: string;

    public Rank?: number;

    public TipoCarteira?: string;
    
    
    public HistoricosLista?: Historico;

    public TransacoesLista?: Transacao;

    public NftsLista?: Nft;
    
    
    
    

}