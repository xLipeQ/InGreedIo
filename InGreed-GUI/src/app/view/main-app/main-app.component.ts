import { Component } from '@angular/core';
import { SearchProductsFormComponent } from '../../shared/search-products-form/search-products-form.component';
import { MainTemplateIngreedIOComponent } from '../../shared/main-template-ingreed-io/main-template-ingreed-io.component';

@Component({
  selector: 'app-main-app',
  standalone: true,
  imports: [SearchProductsFormComponent, MainTemplateIngreedIOComponent],
  templateUrl: './main-app.component.html',
  styleUrl: './main-app.component.scss',
})
export class MainAppComponent {}
