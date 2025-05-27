import { BaseModel } from "./base.model";

export class Militar extends BaseModel {
    public nome?: string;
    public patenteId?: Number;
    public batalhaoId?: Number;
    public dataNascimento?: Date;
}