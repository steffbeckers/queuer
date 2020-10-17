import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppState } from 'src/app/app.state';
import { TenantService } from '../tenant.service';

@Component({
  selector: 'app-tenant-request-ticket',
  templateUrl: './request-ticket.component.html',
  styleUrls: ['./request-ticket.component.css'],
})
export class TenantRequestTicketComponent implements OnInit {
  constructor(
    private appState: AppState,
    private tenantService: TenantService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  requestTicket(): void {
    this.tenantService.requestTicket().subscribe((ticketId: string) => {
      this.router.navigateByUrl(
        this.appState.tenant.value.slug + '/' + ticketId
      );
    });
  }
}
