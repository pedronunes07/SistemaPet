import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {

  constructor(private router: Router) { }

  irParaDashboard() {
    this.router.navigate(['/dashboard']);
  }
  
  irParaCadastrarPet() {
    this.router.navigate(['/cadastrar-pet']);
  }

  irParaCadastrarDono() {
    this.router.navigate(['/cadastrar-dono']);
  }
}
