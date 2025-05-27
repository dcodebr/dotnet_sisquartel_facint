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