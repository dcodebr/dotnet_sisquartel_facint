import { Component, OnInit } from '@angular/core';
import { PatenteModel } from '../../../models/patente.model';
import { PatenteService } from '../../../services/patente.service';

@Component({
  selector: 'app-patente-list',
  standalone: false,
  templateUrl: './patente-list.component.html',
  styleUrl: './patente-list.component.css'
})
export class PatenteListComponent implements OnInit {
  
  patentes: PatenteModel[] = [];

  constructor(private patenteService: PatenteService) {

  }

  ngOnInit(): void {
    let resposta = this.patenteService.retornarTodos();

    resposta.subscribe({
      next: value => this.patentes = value,
      error: erro => alert("Falha de conexão!")
    });
  }

}
