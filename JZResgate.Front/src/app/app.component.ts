import { Component } from '@angular/core';
import { RecoveryTruck } from './models/recovery-truck';
import { RecoveryTruckService } from './services/recovery-truck.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'jz-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private recoveryTruckService: RecoveryTruckService) { }

  isFormClosed = true;

  recoveryTruck = new RecoveryTruck('', '', '');
  formTitle = '';

  recoveryTruckList = [];

  handleCreateRecoveryTruck(): void {
    this.recoveryTruck = new RecoveryTruck('', '', '');
    this.isFormClosed = false;
    this.formTitle = 'Novo Guincho';
  }

  handleEditRecoveryTruck(recoveryTruck: RecoveryTruck): void{
    this.recoveryTruck = recoveryTruck;
    this.isFormClosed = false;
    this.formTitle = 'Editar Guincho';
  }

  handleFormClose(): void {
    this.isFormClosed = true;
    this.recoveryTruck = new RecoveryTruck('', '', '');
  }

  handleFormSave(): void {
    if (this.recoveryTruck.id){
      this.isFormClosed = true;
    }
    this.getRecoveryTruckList();
  }

  handleRecoveryTruckRemove(): void {
    this.getRecoveryTruckList();
  }

  private getRecoveryTruckList(): void {
    this.recoveryTruckService.listRecoveryTruck().subscribe(response => {
      this.recoveryTruckList = response;
    }, (erro: HttpErrorResponse) => {
      console.error(erro);
    });
  }
}
