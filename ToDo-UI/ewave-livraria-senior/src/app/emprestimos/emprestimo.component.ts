import { Component, OnInit } from '@angular/core';
import { User } from '../core/user/usuario';
import { UserService } from 'app/core/user/usuario.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { EmprestimoService } from './emprestimo.service';
import { Emprestimo } from './emprestimo';
import { environment } from '@env/environment';

@Component({
    selector: 'todo-emprestimo',
    templateUrl: './emprestimo.component.html'
})
export class EmprestimoComponent implements OnInit {

    private emprestimos = new BehaviorSubject<Emprestimo>(null);
    user$: Observable<User>;
    endPointImagem: string;

    constructor(private emprestimoService: EmprestimoService, private userService: UserService) {
        this.user$ = userService.getUser();
    }

    ngOnInit(): void {
        this.buscarDados();
        this.endPointImagem = environment.endPointImagem;
    }

    buscarDados() {
        this.user$.subscribe(
            (usuario) => {
                if (usuario) {
                    this.emprestimoService.retornarEmprestimosAtivoPorIdUsuario(usuario.id).subscribe(
                        (response) => {
                            this.emprestimos.next(response as Emprestimo);
                        },
                        err => {
                            alert(err.error[0] != null ? err.error[0].Mensagem : err.error.mensagem);
                        }
                    )
                }
            }
        )
    }

    devolver(emprestimo) {
        this.emprestimoService.devolverLivro(emprestimo).subscribe(
            (response) => {
                alert("Livro devolvido com sucesso!");
                this.buscarDados();
            },
            err => {
                alert(err.error[0] != null ? err.error[0].Mensagem : err.error.mensagem);
            }
        )
    }
}

