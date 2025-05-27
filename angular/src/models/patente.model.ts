import { Militar } from "./militar.model";
import { BaseModel } from "./base.model";

export class Patente extends BaseModel {
    public graduacao?: string;
    public militares?: Militar[];
}