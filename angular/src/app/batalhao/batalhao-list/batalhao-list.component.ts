import { Component } from '@angular/core';
import { Batalhao } from '../../../models/batalhao.model';
import { BatalhaoService } from '../../../services/batalhao.service';

@Component({
  selector: 'app-batalhao-list',
  standalone: false,
  templateUrl: './batalhao-list.component.html',
  styleUrl: './batalhao-list.component.css'
})
export class BatalhaoListComponent {
  batalhoes: Batalhao[] = [];

  constructor(private batalhaoService: BatalhaoService) {
  }

  ngOnInit(): void {
    this.obterDados();
  }

  obterDados() {
    let resposta = this.batalhaoService.retornarTodos();
    
    resposta.subscribe({
      next: value => this.batalhoes = value,
      error: erro => alert('falha na conexão!')
    })
  }

  excluir(batalhao: Batalhao) {
    let confirma = confirm("Deseja confirmar a exclusão?");

    if (confirma) {
      let id = Number(batalhao.id);
      let resposta = this.batalhaoService.excluir(id);

      resposta.subscribe({
        next: () => this.obterDados(),
        error: err => alert(err)
      });
    }
  }
}