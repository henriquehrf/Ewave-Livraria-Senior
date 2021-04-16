import { Component, Input, OnInit } from '@angular/core';
import { EmprestimoService } from 'app/emprestimos/emprestimo.service';
import { BehaviorSubject, interval, Observable } from 'rxjs';
import { Emprestimo } from 'app/emprestimos/emprestimo';
import * as moment from 'moment';
import { UserService } from 'app/core/user/usuario.service';
import { User } from 'app/core/user/usuario';

@Component({
    selector: 'todo-livraria',
    templateUrl: 'livraria.component.html'
})
export class LivrariaComponent implements OnInit {

    @Input() menuSelecionado: string;
    private emprestimos = new BehaviorSubject<Emprestimo>(null);
    user$: Observable<User>;

    constructor(private emprestimoService: EmprestimoService, private userService: UserService) {
        this.user$ = userService.getUser();
    }

    ngOnInit(): void {
        this.user$.subscribe(
            (usuario) => {
                const usuarioAdministrador = 1;
                if (usuario && usuario.idPerfil == usuarioAdministrador) {
                    this.carregarDados();
                    interval(1000 * 60).subscribe(i => this.carregarDados())
                }
            }
        )
    };

    receberValorMenu(valor) {
        this.menuSelecionado = valor;
    }

    carregarDados() {
        this.emprestimoService.retornarTodosEmprestimoAtivo().subscribe(
            (response) => this.emprestimos.next(response as Emprestimo)
        );
    }

    retornarStatusEmprestimo(emprestimo: Emprestimo) {
        const dataDevolucao = moment(emprestimo.dataPrevistaDevolucao).format('YYYY-MM-DD');
        const hoje = moment(new Date().getTime()).format('YYYY-MM-DD');
        const estaEmAtraso = moment(hoje).isAfter(dataDevolucao);
        if (estaEmAtraso)
            return "alert-danger"
        return "alert-dark"
    }

}