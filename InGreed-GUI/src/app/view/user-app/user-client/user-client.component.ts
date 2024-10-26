import { Component } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { paths } from '../../../app-paths';
import { navigateToSearchProduct } from '../../../core/utils/utils';

@Component({
  selector: 'ingreedio-user-client',
  standalone: true,
  imports: [],
  templateUrl: './user-client.component.html',
  styleUrl: './user-client.component.scss'
})
export class UserClientComponent {

  constructor (private router: Router) {

  }

  navigateToFavouriteProducts() {
    navigateToSearchProduct(this.router, undefined, "", [], true);
  }

  navigateToAddNewFavouriteProducts() {
    navigateToSearchProduct(this.router, undefined, "", [], false);
  }

  navigateToEditPreferences() {
    this.router.navigate([paths.editPreferences])
  }
}
