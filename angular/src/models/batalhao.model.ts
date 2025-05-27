import { Militar } from "./militar.model";
import { BaseModel } from "./base.model";

export class Batalhao extends BaseModel {
    public identificacao?: string;

    public militares?: Militar[];
}