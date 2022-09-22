import { BaseEntity } from './BaseEntity';

/*import { TipocomandOperacao } from './TipocomandOperacao';
import { TipoMotivorestricao } from './TipoMotivorestricao';
import { ComandOperacao } from './ComandOperacao';*/


export class Transacao extends BaseEntity<number> {


    public TipoTransacao?: string;

    public CodigoTransacao?: string;
    
    public CodigoCarteiraOrigem?: string;

    public CodigoCarteiraDestino?: string;

    public DataTrasacao?: string;    

    public Saldo?: number;   
    

}