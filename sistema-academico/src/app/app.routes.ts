import { Routes } from '@angular/router';
import { PetForm } from './pet/pet-form/pet-form';
import { PetList } from './pet/pet-list/pet-list';

export const routes: Routes = [
    { path: '', component: PetList },
    { path: 'novo', component: PetForm }
];
