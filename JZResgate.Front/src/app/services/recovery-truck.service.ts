import { RecoveryTruck } from './../models/recovery-truck';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class RecoveryTruckService {

  private static readonly api = 'https://localhost:44378/recoverytruck';

  constructor(private http: HttpClient) { }

  createRecoveryTruck(recoveryTruck: RecoveryTruck): Observable<object> {
    return this.http
        .post(RecoveryTruckService.api, recoveryTruck);
  }

  listRecoveryTruck(): Observable<RecoveryTruck[]>{
    return this.http
        .get(RecoveryTruckService.api)
        .pipe<RecoveryTruck[]>(map((response: any[]) => {
          return response.map(recoveryTruck => this.recoveryTruckFactory(recoveryTruck));
      }));

  }

  editRecoveryTruck(recoveryTruck: RecoveryTruck, id: string): Observable<object> {
    return this.http
        .put(`${RecoveryTruckService.api}/${id}`, recoveryTruck);
  }

  removeRecoveryTruck(id: string): Observable<object>{
    return this.http
        .delete(`${RecoveryTruckService.api}/${id}`);
  }

  findRecoveryTruckById(id: string): Observable<RecoveryTruck> {
    return this.http
    .get(`${RecoveryTruckService.api}/${id}`)
    .pipe<RecoveryTruck>(map((response: any) => {
      return this.recoveryTruckFactory(response);
    }));
  }

  private recoveryTruckFactory(recoveryTruck: any): RecoveryTruck {
    return new RecoveryTruck(recoveryTruck.alias, recoveryTruck.model, recoveryTruck.plate, recoveryTruck.id, recoveryTruck.createDate);
  }

}
