import { inject, Injectable, signal } from '@angular/core';
import { Pet } from '../model/pet';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root', 
})
export class PetService {
  private http = inject(HttpClient);
  private readonly API = "https://localhost:7240/api/pet";
  private petsSignal = signal<Pet[]>([]);

  constructor() {
    this.carregarPets();
  }

  getPets() {
    return this.petsSignal;
  }

  private carregarPets() {
    this.http.get<Pet[]>(this.API).subscribe({
      next: (pets) => this.petsSignal.set(pets),
      error: (erro) => {
        console.error('Erro ao carregar pets:', erro);
        // Em caso de erro, mantém array vazio
        this.petsSignal.set([]);
      }
    });
  }

  listar(): Observable<Pet[]> {
    return this.http.get<Pet[]>(this.API).pipe(
      tap(pets => this.petsSignal.set(pets))
    );
  }

  adicionar(pet: Omit<Pet, 'id'>): Observable<Pet> {
    return this.http.post<Pet>(this.API, pet).pipe(
      tap(novoPet => {
        const petsAtuais = this.petsSignal();
        this.petsSignal.set([...petsAtuais, novoPet]);
      })
    );
  }

  atualizar(pet: Pet): Observable<Pet> {
    return this.http.put<Pet>(`${this.API}/${pet.id}`, pet).pipe(
      tap(petAtualizado => {
        const petsAtuais = this.petsSignal();
        const index = petsAtuais.findIndex(p => p.id === pet.id);
        if (index !== -1) {
          petsAtuais[index] = petAtualizado;
          this.petsSignal.set([...petsAtuais]);
        }
      })
    );
  }

  excluirPet(id: number) {
    this.http.delete(`${this.API}/${id}`).subscribe({
      next: () => {
        const petsAtuais = this.petsSignal();
        this.petsSignal.set(petsAtuais.filter(p => p.id !== id));
      },
      error: (erro) => {
        console.error('Erro ao excluir pet:', erro);
        alert('Erro ao excluir pet');
      }
    });
  }

  obterPorId(id: number): Observable<Pet> {
    return this.http.get<Pet>(`${this.API}/${id}`);
  }
}

