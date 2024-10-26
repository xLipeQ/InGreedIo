import { Routes } from '@angular/router';
import { MainAppComponent } from './view/main-app/main-app.component';
import { SearchProductsAppComponent } from './view/search-products-app/search-products-app.component';
import { LoginAppComponent } from './view/login-app/login-app.component';
import { paths } from './app-paths';
import { RegisterAppComponent } from './view/register-app/register-app.component';
import { ProductAppComponent } from './view/product-app/product-app.component';
import { ProductAddAppComponent } from './view/product add-app/product-add-app-component';
import { UserAppComponent } from './view/user-app/user-app.component';
import { EditPreferencesAppComponent } from './view/edit-preferences-app/edit-preferences-app.component';
import { authGuard } from './core/auth/guard/auth.guard';
import { clientAuthGuard } from './core/auth/guard/client-auth.guard';
import { producentAuthGuard } from './core/auth/guard/producent-auth.guard';
import { AboutAppComponent } from './view/about-app/about-app.component';
import { PricingAppComponent } from './view/pricing-app/pricing-app.component';
import { TermsConditionsAppComponent } from './view/terms-conditions-app/terms-conditions-app.component';

export const routes: Routes = [
  { path: '', component: MainAppComponent },
  { path: paths.searchProducts, component: SearchProductsAppComponent },
  { path: paths.product, component: ProductAppComponent},
  { path: paths.login, component: LoginAppComponent },
  { path: paths.register, component: RegisterAppComponent },
  { path: paths.about, component: AboutAppComponent },
  { path: paths.pricing, component: PricingAppComponent },
  { path: paths.termsAndConditions, component: TermsConditionsAppComponent },
  { path: paths.productAdd, component: ProductAddAppComponent, canActivate: [producentAuthGuard]},
  { path: paths.user, component: UserAppComponent, canActivate: [authGuard]},
  { path: paths.editPreferences, component: EditPreferencesAppComponent, canActivate: [clientAuthGuard]},
  { path: '**', redirectTo: '' }
];
