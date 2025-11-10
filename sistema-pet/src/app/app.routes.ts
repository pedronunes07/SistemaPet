import { Routes } from '@angular/router';
import { Dashboard } from './pet/dashboard/dashboard';
import { CadastrarPet } from './pet/pet-form/pet-form';
import { PetList } from './pet/pet-list/pet-list';

export const routes: Routes = [
    { path: '', component: Dashboard },
    { path: 'dashboard', component: Dashboard },
    { path: 'cadastrar-pet', component: CadastrarPet },
    { path: 'editar-pet/:id', component: CadastrarPet },
    { path: 'detalhes-pet/:id', component: PetList },
    { path: 'cadastrar-dono', loadComponent: () => import('./pet/dono-form/dono-form').then(m => m.DonoForm) },
    { path: 'editar-dono/:id', loadComponent: () => import('./pet/dono-form/dono-form').then(m => m.DonoForm) },
    { path: 'lista', component: PetList },
    { path: 'novo', component: CadastrarPet }
];
