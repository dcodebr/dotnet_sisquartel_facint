import { Component } from '@angular/core';
import { Patente } from '../../../models/patente.model';
import { PatenteService } from '../../../services/patente.service';

@Component({
  selector: 'app-patente-list',
  standalone: false,
  templateUrl: './patente-list.component.html',
  styleUrl: './patente-list.component.css'
})
export class PatenteListComponent {
  patentes: Patente[] = [];

  constructor(private patenteService: PatenteService) {
  }

  ngOnInit(): void {
    this.obterDados();
  }

  obterDados() {
    let resposta = this.patenteService.retornarTodos();
    
    resposta.subscribe({
      next: value => this.patentes = value,
      error: erro => alert('falha na conexão!')
    })
  }

  excluir(patente: Patente) {
    let confirma = confirm("Deseja confirmar a exclusão?");

    if (confirma) {
      let id = Number(patente.id);
      let resposta = this.patenteService.excluir(id);

      resposta.subscribe({
        next: () => this.obterDados(),
        error: err => alert(err)
      });
    }
  }
}