import { Component, signal, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { PetService } from '../../service/pet-service';
import { DonoService } from '../../service/dono-service';
import { Pet, Vacina } from '../../model/pet';
import { Dono } from '../../model/dono';

@Component({
  selector: 'app-cadastrar-pet',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './pet-form.html',
  styleUrl: './pet-form.css'
})
export class CadastrarPet {
  pet = signal<Partial<Pet>>({
    nome: '',
    especie: '',
    raca: '',
    idade: 0,
    peso: '',
    cor: '',
    sexo: '',
    vacinado: 'Não',
    donoId: undefined,
    vacinas: [],
    observacoes: '',
    observacoesMedicas: '',
    fotos: []
  });

  donos = computed(() => this.donoService.getDonos()());

  constructor(
    private petService: PetService,
    private donoService: DonoService,
    private router: Router
  ) {}

  adicionarVacina() {
    const novaVacina: Vacina = {
      nomeVacina: '',
      dataAplicacao: '',
      proximaDose: '',
      nomeVeterinario: ''
    };
    
    this.pet.update(pet => ({
      ...pet,
      vacinas: [...(pet.vacinas || []), novaVacina]
    }));
  }

  removerVacina(index: number) {
    this.pet.update(pet => ({
      ...pet,
      vacinas: (pet.vacinas || []).filter((_, i) => i !== index)
    }));
  }

  adicionarFoto() {
    // Simulação de upload de foto
    const input = document.createElement('input');
    input.type = 'file';
    input.accept = 'image/*';
    input.onchange = (event: any) => {
      const file = event.target.files[0];
      if (file) {
        const reader = new FileReader();
        reader.onload = (e: any) => {
          this.pet.update(pet => ({
            ...pet,
            fotos: [...(pet.fotos || []), e.target.result]
          }));
        };
        reader.readAsDataURL(file);
      }
    };
    input.click();
  }

  salvarPet() {
    if (this.validarFormulario()) {
      const petData = this.pet();
      this.petService.adicionar(petData as Omit<Pet, 'id'>).subscribe({
        next: (resposta) => {
          alert('Pet cadastrado com sucesso!');
          this.router.navigate(['/']);
        },
        error: (erro) => {
          console.error(erro);
          alert('Erro ao salvar pet');
        }
      });
    }
  }

  private validarFormulario(): boolean {
    const pet = this.pet();
    if (!pet.nome || !pet.especie || !pet.donoId) {
      alert('Por favor, preencha os campos obrigatórios (Nome, Espécie, Dono)');
      return false;
    }
    return true;
  }

  irParaDashboard() {
    this.router.navigate(['/']);
  }

  irParaCadastrarDono() {
    this.router.navigate(['/cadastrar-dono']);
  }
}
