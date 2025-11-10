import { Component } from '@angular/core';
import { Pet } from '../../model/pet';
import { PetService } from '../../service/pet-service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pet-form',
  imports: [CommonModule, FormsModule],
  templateUrl: './pet-form.html',
  styleUrl: './pet-form.scss'
})
export class PetForm {
  nome: string = '';
  especie: string = '';
  idade: number = 0;

  constructor(private petService: PetService, private router: Router) { }

  adicionar() {
    const novoPet = new Pet(this.nome, this.especie, this.idade);
    this.petService.adicionar(novoPet).subscribe({
      next: (resposta) => {
        this.router.navigate(['/']);
        alert('Pet salvo');
      },
      error: (erro) => {
        console.error(erro);
        alert('Erro ao salvar pet');
      }
    });
  }
}

