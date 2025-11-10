import { inject, Injectable } from '@angular/core';
import { Pet } from '../model/pet';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root', 
})
export class PetService {
  private http = inject(HttpClient);
  private readonly API = "https://localhost:7240/api/pet";

  constructor() { }

  listar(): Observable<Pet[]> {
    return this.http.get<Pet[]>(this.API);
  }

  adicionar(pet: Omit<Pet, 'id'>): Observable<Pet> {
    return this.http.post<Pet>(this.API, pet);
  }
}

