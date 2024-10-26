import { Component, OnDestroy, OnInit } from '@angular/core';
import { MainTemplateIngreedIOComponent } from '../../shared/main-template-ingreed-io/main-template-ingreed-io.component';
import { Store } from '@ngrx/store';
import { selectIsJwtTokenSet, selectJwtToken } from '../../core/store/jwt-token/jwt-token.selectors';
import { PanelComponent } from '../../shared/user-panel/panel/panel.component';
import { enumRole } from '../../core/models/enums/role.enum';
import { UserProducerComponent } from './user-producer/user-producer.component';
import { UserClientComponent } from './user-client/user-client.component';
import { CommonModule } from '@angular/common';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ROLES_JWT_FIELD, ROLES_USERNAME } from '../../core/constants/constants';
import { getEnumValueFromString } from '../../core/utils/utils';
import { resetJwtToken } from '../../core/store/jwt-token/jwt-token.actions';
import { Router } from '@angular/router';
import { UserPanelComponent } from '../../shared/user-panel/user-panel.component';
import { Subscription, combineLatest } from 'rxjs';
import { UserAdministratorComponent } from './user-administrator/user-administrator.component';

@Component({
  selector: 'ingreedio-user-app',
  standalone: true,
  imports: [MainTemplateIngreedIOComponent, PanelComponent, UserProducerComponent, UserClientComponent, UserAdministratorComponent, CommonModule, UserPanelComponent],
  templateUrl: './user-app.component.html',
  styleUrl: './user-app.component.scss'
})
export class UserAppComponent implements OnInit, OnDestroy {
  userRole: enumRole = enumRole.Client;
  username: string = ""
  enumRole = enumRole;
  jwtHelperService = new JwtHelperService();
  subscription: Subscription = new Subscription()

  constructor(private store: Store, private router: Router) {  }

  ngOnInit(): void {
    const isSet$ = this.store.select(selectIsJwtTokenSet);
    const jwtToken$ = this.store.select(selectJwtToken);

    this.subscription = combineLatest([isSet$, jwtToken$]).subscribe(([isSet, jwtToken]) => {
      if (isSet && jwtToken) {

        const decodedJwtToken = this.jwtHelperService.decodeToken(jwtToken as string)
        const userRoleString = decodedJwtToken[ROLES_JWT_FIELD]
        const userRole = getEnumValueFromString(userRoleString, enumRole);
        
        if (userRole !== undefined) {
          this.userRole = userRole
        }

        const username = decodedJwtToken[ROLES_USERNAME]
        this.username = username
    }});
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe()
    }
  }
}
