import { Component } from '@angular/core';
import { Militar } from '../../../models/militar.model';
import { MilitarService } from '../../../services/militar.service';

@Component({
  selector: 'app-militar-list',
  standalone: false,
  templateUrl: './militar-list.component.html',
  styleUrl: './militar-list.component.css'
})
export class MilitarListComponent {
  militares: Militar[] = [];

  constructor(private militarService: MilitarService) {
  }

  ngOnInit(): void {
    this.obterDados();
  }

  obterDados() {
    let resposta = this.militarService.retornarTodos();
    
    resposta.subscribe({
      next: value => this.militares = value,
      error: erro => alert('falha na conexão!')
    })
  }

  excluir(militar: Militar) {
    let confirma = confirm("Deseja confirmar a exclusão?");

    if (confirma) {
      let id = Number(militar.id);
      let resposta = this.militarService.excluir(id);

      resposta.subscribe({
        next: () => this.obterDados(),
        error: err => alert(err)
      });
    }
  }
}
