import { Component } from '@angular/core';
import { Batalhao } from '../../../models/batalhao.model';
import { ActivatedRoute, Router } from '@angular/router';
import { BatalhaoService } from '../../../services/batalhao.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-batalhao-form',
  standalone: false,
  templateUrl: './batalhao-form.component.html',
  styleUrl: './batalhao-form.component.css'
})
export class BatalhaoFormComponent {
  model : Batalhao = {};
  status: String = '';

  constructor(private route: Router,
              private activedRoute: ActivatedRoute,
              private batalhaoService: BatalhaoService) {
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
      let resposta = this.batalhaoService.retornarPorId(id);
      resposta.subscribe({
        next: batalhao => this.model = batalhao
      })
    }
  }

  salvar() {
    this.status = 'Processando ...';

    let id = Number(this.model.id);
    let resposta: Observable<Batalhao>;

    if (id > 0) {
      //Incluir
      resposta = this.batalhaoService.atualizar(id, this.model);
    } else {
      //Salvar
      resposta = this.batalhaoService.adicionar(this.model);
    }

    resposta.subscribe({
      next: value => {
        this.obterDados(Number(value.id));
        this.status = "Salvo com sucesso!";
        setTimeout(() => this.route.navigate(['/batalhoes', value.id]), 5000);
      }
    })
  }
}