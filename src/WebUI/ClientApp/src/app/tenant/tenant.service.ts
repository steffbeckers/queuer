import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AppState } from '../app.state';
import {
  RequestTicketCommand,
  TenantDto,
  TenantsClient,
  TicketDto,
  TicketsClient,
} from '../queuer-api';

@Injectable()
export class TenantService {
  constructor(
    private appState: AppState,
    private tenantsClient: TenantsClient,
    private ticketsClient: TicketsClient
  ) {}

  getBySlug(slug: string): Observable<TenantDto> {
    return this.tenantsClient.getBySlug(slug).pipe(
      tap((tenant: TenantDto) => {
        // Update state
        this.appState.tenant.next(tenant);
      })
    );
  }

  requestTicket(): Observable<string> {
    const command: RequestTicketCommand = new RequestTicketCommand();
    command.tenantId = this.appState.tenant.value.id;

    return this.ticketsClient.requestTicket(command);
  }

  getTicketById(id: string): Observable<TicketDto> {
    return this.ticketsClient.getById(id);
  }
}
