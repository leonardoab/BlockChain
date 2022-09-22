import { BaseEntity } from './BaseEntity';

/*import { TipocomandOperacao } from './TipocomandOperacao';
import { TipoMotivorestricao } from './TipoMotivorestricao';
import { ComandOperacao } from './ComandOperacao';*/


export class Historico extends BaseEntity<number> {


    public CodigoCarteira?: string;

    public Saldo?: number;
    
    public Diferenca?: number;

    public NumeroTransacoes?: number;

    public DataHistorico?: string;    
    

}