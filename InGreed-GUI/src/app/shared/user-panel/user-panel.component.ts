import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { enumRole } from '../../core/models/enums/role.enum';
import { PanelComponent } from './panel/panel.component';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { resetJwtToken } from '../../core/store/jwt-token/jwt-token.actions';
import { selectIsJwtTokenSet, selectJwtToken } from '../../core/store/jwt-token/jwt-token.selectors';
import { CommonModule } from '@angular/common';
import { CookieService } from 'ngx-cookie-service';
import { JWT_TOKEN_FIELD, ROLES_USERNAME } from '../../core/constants/constants';
import { Subscribable, Subscription, combineLatest } from 'rxjs';
import { Location } from '@angular/common';

@Component({
  selector: 'ingreedio-user-panel',
  standalone: true,
  imports: [PanelComponent, CommonModule],
  templateUrl: './user-panel.component.html',
  styleUrl: './user-panel.component.scss'
})
  export class UserPanelComponent {
    @Input()
    userRole: enumRole = enumRole.Client

    @Input()
    username: string = ''
    enumRole = enumRole;
    jwtHelperService = new JwtHelperService();
    subscription: Subscription = new Subscription()

    constructor (private store: Store, private route: ActivatedRoute, private router: Router, private cookieService: CookieService, private location : Location) {}

    logoutUser() {
      this.cookieService.delete(JWT_TOKEN_FIELD)
      this.store.dispatch(resetJwtToken())
      this.router.navigate([''], {relativeTo: this.route, skipLocationChange: true});
    }
}
