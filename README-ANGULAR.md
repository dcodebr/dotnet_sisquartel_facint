# PROJETO SISQUARTEL EM ANGULAR/CLI

## CRIAÇÃO DA ESTRUTURA DO PROJETO

```bash
ng new angular --no-standalone --routing
```

## Instalação das dependências

**jQuery**

```bash
npm i jquery --save

npm i --save-dev @types/jquery
```

**popper.js**

```bash
npm i popper.js
```

**Bootstrap**
```bash
ng add @ng-bootstrap/ng-bootstrap
```

## Execução do servidor

```bash
ng serve
```


## Adicionar aos arquivos

**1. index.html**
```html
<!doctype html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <title>AngularSisvendas</title>
  <base href="/">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="icon" type="image/x-icon" href="favicon.ico">
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css">
</head>
<body>
  <app-root></app-root>
</body>
</html>
```

**2. app.component.html**

```html
<div class="wrapper d-flex align-items-stretch">
  <nav id="sidebar">
    <div class="custom-menu">
      <button type="button" id="sidebarCollapse" class="btn btn-primary">
      </button>
    </div>
    <div class="logo img bg-wrap text-center py-4">
    </div>
    <ul class="list-unstyled components mb-5">
      <li class="active">
        <a [routerLink]="['/']"><span class="fa fa-home mr-3"></span>Principal</a>
      </li>
      <li>
        <a [routerLink]="['patentes']"><span class="fa fa-medal mr-3"></span>Patentes</a>
      </li>
      <li>
        <a [routerLink]="['militares']"><span class="fa fa-shield mr-3"></span>Militares</a>
      </li>
      <li>
        <a [routerLink]="['batalhoes']"><span class="fa fa-tent mr-3"></span>Batalhões</a>
      </li>
    </ul>
  </nav>

  <nav class="navbar navbar-dark bg-dark">
    <!-- Navbar content -->
  </nav>

  <div id="content" class="p-4 p-md-5 pt-5">
    <router-outlet></router-outlet>
  </div>
</div>
```

**3. app.component.ts**
```typescript
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import $ from 'jquery';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'angular-sisquartel';
  tituloModulo: String = "";

  constructor(private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.configurarMenu();
  }


  private configurarMenu() {
    this.fullHeight();
    $('#sidebarCollapse').on('click', () => {
      $('#sidebar').toggleClass('active');
    });
  }

  private fullHeight(): void {
    $('.js-fullheight').css('height', window.innerHeight);
    
    $(window).resize(() => {
      $('.js-fullheight').css('height', window.innerHeight);
    });
  }
}
```

**4. Copiar arquivo [styles.csss](./_files/styles.css):**


**5. Alterar package.json**:

```json
    "styles": [
        "src/styles.css",
        "node_modules/bootstrap/dist/css/bootstrap.min.css"
    ],
    "scripts": [
        "node_modules/jquery/dist/jquery.min.js",
        "node_modules/bootstrap/dist/js/bootstrap.min.js",
        "node_modules/popper.js/dist/umd/popper.min.js"
    ]
```