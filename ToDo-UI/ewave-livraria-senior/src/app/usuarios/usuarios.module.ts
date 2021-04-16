import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioListModule } from './usuario-list/usuario-list.module';
import { UsuarioFormModule } from './usuario/usuario-form.module';

@NgModule({
    imports: [
        CommonModule,
        UsuarioListModule,
        UsuarioFormModule
    ],
    exports: [UsuarioListModule, UsuarioFormModule]
})
export class UsuariosModule { }