import { BaseModel } from "./base.model";
import { Batalhao } from "./batalhao.model";
import { Patente } from "./patente.model";

export class Militar extends BaseModel {
    public nome?: string;
    public patenteId?: Number;
    public batalhaoId?: Number;
    public dataNascimento?: Date;

    public patente?: Patente;
    public batalhao?: Batalhao;
}