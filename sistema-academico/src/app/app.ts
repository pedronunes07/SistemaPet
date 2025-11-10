import { Component, signal } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { PetForm } from './pet/pet-form/pet-form';
import { PetList } from './pet/pet-list/pet-list';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, PetForm, PetList, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {

  constructor(private router: Router) { }

  irParaLista() {
    this.router.navigate(['/']);
  }
  
  irParaNovo() {
    this.router.navigate(['/novo']);
  }
}
