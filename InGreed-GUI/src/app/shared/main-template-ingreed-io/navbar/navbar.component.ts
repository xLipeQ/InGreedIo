import { Component, Input, OnChanges, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { paths } from '../../../app-paths';
import { CommonModule } from '@angular/common';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Store } from '@ngrx/store';
import { selectIsJwtTokenSet, selectJwtToken } from '../../../core/store/jwt-token/jwt-token.selectors';
import { resetJwtToken } from '../../../core/store/jwt-token/jwt-token.actions';
import path from 'path';
import { ROLES_USERNAME } from '../../../core/constants/constants';
import { Subscription, combineLatest } from 'rxjs';

@Component({
  selector: 'ingreedio-navbar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent implements OnInit, OnDestroy {
  @Input() showLogin: boolean = true;
  jwtHelperService = new JwtHelperService();
  username: string = ''
  isLogged: boolean = false;
  subscription: Subscription = new Subscription()

  constructor(private router: Router, private store: Store) {}

  ngOnInit(): void {
    const isSet$ = this.store.select(selectIsJwtTokenSet);
    const jwtToken$ = this.store.select(selectJwtToken);

    this.subscription = combineLatest([isSet$, jwtToken$]).subscribe(([isSet, jwtToken]) => {
      if (isSet && jwtToken) {
        this.username = this.jwtHelperService.decodeToken(jwtToken as string)[ROLES_USERNAME];
        this.isLogged = true;
      } else {
        this.isLogged = false;
      }
    });
  }

  showLoginPage() {
    this.router.navigate([paths.login]);
  }

  showMainPage() {
    this.router.navigate(['']);
  }

  showRegisterPage() {
    this.router.navigate([paths.register])
  }

  logoutUser() {
    this.store.dispatch(resetJwtToken())
    this.isLogged = false
  }

  showAboutPage(){
    this.router.navigate([paths.about])
  }

  showPricingPage() {
    this.router.navigate([paths.pricing])
  }

  showTermsConditionsPage() {
    this.router.navigate([paths.termsAndConditions])
  }

  navigateToUser() {
    this.router.navigate([paths.user])
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
