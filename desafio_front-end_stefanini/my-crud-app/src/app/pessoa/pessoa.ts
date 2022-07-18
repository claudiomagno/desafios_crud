import { Cidade } from "../cidade/cidade";

export interface Pessoa {
  id: number;
  nome: string;
  cpf: string;
  idade: number;
  cidade: Cidade;
}
