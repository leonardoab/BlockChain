import { BaseEntity } from './BaseEntity';

/*import { TipocomandOperacao } from './TipocomandOperacao';
import { TipoMotivorestricao } from './TipoMotivorestricao';
import { ComandOperacao } from './ComandOperacao';*/


export class Nft extends BaseEntity<number> {


    public Nome?: string;

    public Imagem?: string;
    
    public Rank?: number;

    public IdRede?: number;  
    

}