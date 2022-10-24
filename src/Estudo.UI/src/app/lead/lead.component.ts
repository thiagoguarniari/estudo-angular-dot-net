import { Component, OnInit } from '@angular/core';
import { LeadsService } from '../service/leads.service';
import { Lead } from '../models/lead.model';

@Component({
  selector: 'app-lead',
  templateUrl: './lead.component.html',
  styleUrls: ['./lead.component.scss']
})
export class LeadComponent implements OnInit {

  constructor(private leadsService: LeadsService) { 
  }

  leadsList: Lead[];
  selectedTab: any;

  ngOnInit(): void {
    this.selectedTab = 'invited';
    this.leadsService.getbyStatys(0).subscribe((leads) => (
      this.leadsList = leads
      ));
  }
  
  loadCards(e: any) {
    this.selectedTab = e.target.value;
    if(e.target.value == 'invited'){
      this.getLeads(0);
    }
    else if (e.target.value == 'accepted'){
      this.getLeads(1);
    }
  }

  getLeads(status: number){
    this.leadsService.getbyStatys(status).subscribe((leads) => (
      this.leadsList = leads
      ));
  }

  acceptLead(id: any){
    this.leadsService.acceptLead(id).subscribe(() => {
      this.getLeads(0);
    });
  }

  declineLead(id: any){
    this.leadsService.declineLead(id).subscribe(() => {
      this.getLeads(0);
    });
  }

  getFirstLetter(name: string){
    return Array.from(name)[0];
  }
}