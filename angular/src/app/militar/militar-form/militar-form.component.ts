import { Component } from '@angular/core';
import { Militar } from '../../../models/militar.model';
import { ActivatedRoute, Router } from '@angular/router';
import { MilitarService } from '../../../services/militar.service';
import { Observable } from 'rxjs';
import { PatenteService } from '../../../services/patente.service';
import { BatalhaoService } from '../../../services/batalhao.service';
import { Patente } from '../../../models/patente.model';
import { Batalhao } from '../../../models/batalhao.model';

@Component({
  selector: 'app-militar-form',
  standalone: false,
  templateUrl: './militar-form.component.html',
  styleUrl: './militar-form.component.css'
})
export class MilitarFormComponent {
  model: Militar = {};
  patentes: Patente[] = [];
  batalhoes: Batalhao[] = [];
  status: String = '';

  constructor(private route: Router,
    private activedRoute: ActivatedRoute,
    private militarService: MilitarService,
    private patenteService: PatenteService,
    private batalhaoService: BatalhaoService) {
  }

  ngOnInit(): void {
    this.patenteService.retornarTodos().subscribe({
      next: value => this.patentes = value
    });

    this.batalhaoService.retornarTodos().subscribe({
      next: value => this.batalhoes = value
    });

    this.activedRoute.paramMap.subscribe({
      next: parameters => {
        let id = Number(parameters.get('id'));
        this.obterDados(id);
      }
    });
  }

  obterDados(id: number) {
    if (id > 0) {
      let resposta = this.militarService.retornarPorId(id);
      resposta.subscribe({
        next: militar => {
          this.model = militar;
          console.log(this.model);
        }
      })
    }
  }

  salvar() {
    this.status = 'Processando ...';

    let id = Number(this.model.id);
    let resposta: Observable<Militar>;

    if (id > 0) {
      //Incluir
      resposta = this.militarService.atualizar(id, this.model);
    } else {
      //Salvar
      resposta = this.militarService.adicionar(this.model);
    }

    resposta.subscribe({
      next: value => {
        this.obterDados(Number(value.id));
        this.status = "Salvo com sucesso!";
        setTimeout(() => this.route.navigate(['/militares', value.id]), 5000);
      }
    })
  }

  onDataNascimentoChange(valor: string | null) {
    this.model.dataNascimento = valor ? new Date(valor) : undefined;
  }
}