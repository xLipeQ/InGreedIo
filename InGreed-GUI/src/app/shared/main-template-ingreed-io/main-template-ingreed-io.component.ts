import { Component, Input, OnInit } from '@angular/core';
import { NavbarComponent } from './navbar/navbar.component';

@Component({
  selector: 'ingreedio-main',
  standalone: true,
  imports: [NavbarComponent],
  templateUrl: './main-template-ingreed-io.component.html',
  styleUrl: './main-template-ingreed-io.component.scss',
})
export class MainTemplateIngreedIOComponent {
  @Input() showLogin: boolean = true;
}
