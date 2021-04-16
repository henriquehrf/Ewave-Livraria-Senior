import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'todo-search',
    templateUrl: './search.component.html'
})
export class SearchComponent implements OnInit {

    @Output() textoPesquisado = new EventEmitter<string>();

    constructor() {

    }

    ngOnInit(): void {
    }

    pesquisar(valor) {
        this.textoPesquisado.emit(valor);
    }
}
