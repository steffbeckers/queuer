import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TicketDto } from 'src/app/queuer-api';

@Component({
  selector: 'app-tenant-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css'],
})
export class TenantTicketComponent implements OnInit {
  ticket: TicketDto;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.ticket = this.route.snapshot.data['ticket'];
  }
}
