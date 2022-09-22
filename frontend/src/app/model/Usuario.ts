import { BaseEntity } from './BaseEntity';
import { Carteira } from './Carteira';

/*import { TipocomandOperacao } from './TipocomandOperacao';
import { TipoMotivorestricao } from './TipoMotivorestricao';
import { ComandOperacao } from './ComandOperacao';*/


export class Usuario extends BaseEntity<number> {


    public Nome?: string;

    public Email?: string;
    
    public Password?: string;

    public CarteirasLista?: Carteira;
    

}