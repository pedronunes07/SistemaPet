export class Pet {
    constructor(
        public nome: string,
        public especie: string,
        public idade: number,
        public id?: number // opcional para criação
    ) { }

    ehAdulto(): boolean {
        return this.idade >= 1;
    }
}

