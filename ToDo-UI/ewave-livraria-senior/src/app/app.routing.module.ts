import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SignInComponent } from './home/signin/signin.component';
import { LivrariaComponent } from './livraria/livraria.component';
import { AuthGuard } from './core/auth/auth.guard';
import { HomeGuard } from './core/auth/home.guard';
import { NotFoundComponent } from './erros/not-found/not-found.component';
import { InstituicaoEnsinoFormComponent } from './instituicoes-ensino/instituicao-ensino/instituicao-ensino-form.component';
import { InstituicaoEnsinoListComponent } from './instituicoes-ensino/instituicao-ensino-list/instituicao-ensino-list.component';

const routes: Routes = [
    {
        path: '',
        component: SignInComponent,
        canActivate: [AuthGuard],
        children: [
        ]
    },
    {
        path: 'home',
        component: LivrariaComponent,
        canActivate:[HomeGuard]

    },
    {
        path: '**',
        component: NotFoundComponent
    }
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }

