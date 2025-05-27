import { Component } from '@angular/core';
import { Patente } from '../../../models/patente.model';
import { ActivatedRoute, Router } from '@angular/router';
import { PatenteService } from '../../../services/patente.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-patente-form',
  standalone: false,
  templateUrl: './patente-form.component.html',
  styleUrl: './patente-form.component.css'
})
export class PatenteFormComponent {
  model : Patente = {};
  status: String = '';

  constructor(private route: Router,
              private activedRoute: ActivatedRoute,
              private patenteService: PatenteService) {
  }

  ngOnInit(): void {
    this.activedRoute.paramMap.subscribe({
      next: parameters => {
        let id = Number(parameters.get('id'));
        this.obterDados(id);
      }
    })
  }

  obterDados(id: number) {
    if (id > 0) {
      let resposta = this.patenteService.retornarPorId(id);
      resposta.subscribe({
        next: patente => this.model = patente
      })
    }
  }

  salvar() {
    this.status = 'Processando ...';

    let id = Number(this.model.id);
    let resposta: Observable<Patente>;

    if (id > 0) {
      //Incluir
      resposta = this.patenteService.atualizar(id, this.model);
    } else {
      //Salvar
      resposta = this.patenteService.adicionar(this.model);
    }

    resposta.subscribe({
      next: value => {
        this.obterDados(Number(value.id));
        this.status = "Salvo com sucesso!";
        setTimeout(() => this.route.navigate(['/patentes', value.id]), 5000);
      }
    })
  }
}