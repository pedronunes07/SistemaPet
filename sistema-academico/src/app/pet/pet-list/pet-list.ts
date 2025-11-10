import { Component, OnInit } from '@angular/core';
import { Pet } from '../../model/pet';
import { PetService } from '../../service/pet-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-pet-list',
  imports: [CommonModule],
  templateUrl: './pet-list.html',
  styleUrl: './pet-list.scss'
})
export class PetList implements OnInit {
  pets: Pet[] = [];

  constructor(private petService: PetService) { }

  ngOnInit(): void {
    this.petService.listar().subscribe({
      next: (dados) => (this.pets = dados),
      error: () => alert('Deu erro ao carregar pets')
    })
  }
}

