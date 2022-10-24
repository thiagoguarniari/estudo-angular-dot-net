import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { from, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Lead } from '../models/lead.model';

@Injectable({
  providedIn: 'root',
})
export class LeadsService {

  private readonly ApiUrl = `${environment.apiUrl}/api/`;

  constructor(
    private readonly httpClient: HttpClient
    ) { }

    getbyStatys(status: any): Observable<Lead[]> {
      return this.httpClient.get<Lead[]>(`${this.ApiUrl}v1/lead/status?status=${status}`);
    }

    acceptLead(id: any): Observable<any> {
      return from(new Promise<any>((resolve) => {
          this.httpClient
              .post(`${this.ApiUrl}v1/lead/accept`, {id: id})
              .subscribe((response: any) => {
                  resolve(response);
              }, (error) => resolve(error));
      }));
    }

    declineLead(id: any): Observable<any> {
      return from(new Promise<any>((resolve) => {
          this.httpClient
              .post(`${this.ApiUrl}v1/lead/decline`, {id: id})
              .subscribe((response: any) => {
                  resolve(response);
              }, (error) => resolve(error));
      }));
    }

}