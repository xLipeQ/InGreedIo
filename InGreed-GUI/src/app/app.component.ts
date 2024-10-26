import { Component } from '@angular/core';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import { MainTemplateIngreedIOComponent } from './shared/main-template-ingreed-io/main-template-ingreed-io.component';
import { MainAppComponent } from './view/main-app/main-app.component';
import { IngredientsDataService } from './core/services/ingredients-data/ingredients-data.service';
import { Store } from '@ngrx/store';
import { initJwtToken, loadJwtTokenSuccess } from './core/store/jwt-token/jwt-token.actions';
import { CookieService } from 'ngx-cookie-service';
import { MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    MainAppComponent,
    RouterOutlet,
    RouterLink,
    RouterLinkActive,
    MatDialogModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  constructor(private cookieService: CookieService, private store: Store) {
    const jwtToken = this.cookieService.get("jwtToken");
    if (jwtToken) {
      this.store.dispatch(loadJwtTokenSuccess({jwtToken: jwtToken, isSet: true}))
    }
  }
}
