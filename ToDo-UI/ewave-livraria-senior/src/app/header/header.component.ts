import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { User } from '../core/user/usuario';
import { UserService } from 'app/core/user/usuario.service';
import { Observable } from 'rxjs';

@Component({
    selector: 'todo-header',
    templateUrl: './header.component.html'
})
export class HeaderComponent {
    user$: Observable<User>;

    @Output() menuSelecionado = new EventEmitter<string>();
    private menuAtivo: string;

    constructor(
        private userService: UserService) {
        this.user$ = userService.getUser();
        // this.menuSelecionado.emit("instituicao-ensino");
    }

    logout() {
        this.userService.logout();
    }

    selecionarMenu(menu) {
        this.menuSelecionado.emit(menu);
        this.menuAtivo = menu;
    }

    retornarClassMenuSelecionado(menu) {
        if (menu === this.menuAtivo)
            return 'active bg-secondary rounded'

        return '';
    }
}