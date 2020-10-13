import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AppState } from '../app.state';
import { TenantDto, TenantsClient } from '../queuer-api';

@Injectable()
export class TenantService {
  constructor(
    private appState: AppState,
    private tenantsClient: TenantsClient
  ) {}

  getBySlug(slug: string): Observable<TenantDto> {
    return this.tenantsClient.getBySlug(slug).pipe(
      tap((tenant: TenantDto) => {
        // Update state
        this.appState.tenant.next(tenant);
      })
    );
  }
}
