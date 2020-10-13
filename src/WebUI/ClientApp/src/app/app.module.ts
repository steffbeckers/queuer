import { API_BASE_URL } from './queuer-api';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AppComponent } from './app.component';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { environment } from 'src/environments/environment';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TenantResolver } from './tenant/tenant.resolver';

@NgModule({
  declarations: [AppComponent, NavMenuComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FontAwesomeModule,
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      {
        path: 'admin',
        loadChildren: () =>
          import('./admin/admin.module').then((m) => m.AdminModule),
        canActivate: [AuthorizeGuard],
      },
      {
        path: ':slug',
        loadChildren: () =>
          import('./tenant/tenant.module').then((m) => m.TenantModule),
      },
      { path: '**', redirectTo: '', pathMatch: 'full' },
    ]),
    BrowserAnimationsModule,
    ModalModule.forRoot(),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    {
      provide: API_BASE_URL,
      useValue: environment.api_base_url,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
