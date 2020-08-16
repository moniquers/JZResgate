import { RecoveryTruck } from '../../../models/recovery-truck';
import { RecoveryTruckService } from '../../../services/recovery-truck.service';
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'jz-recovery-truck-form',
    templateUrl: 'recovery-truck-form.component.html'
})
export class RecoveryTruckFormComponent {

  constructor(private recoveryTruckService: RecoveryTruckService) { }

  @Input()
  recoveryTruck: RecoveryTruck;

  @Input()
  formTitle: string;

  @Output()
  formClose = new EventEmitter();

  @Output()
  formSave = new EventEmitter();

  error = {
    hasError: false,
    message: null
  };

  handleSaveRecoveryTruck(formRecoveryTruck: NgForm): void {

    if (formRecoveryTruck.invalid)
    {
      return;
    }

    if (this.recoveryTruck.id){
      this.editRecoveryTruck(formRecoveryTruck);
    }
    else
    {
      this.createRecoveryTruck(formRecoveryTruck);
    }

  }

  private createRecoveryTruck(formRecoveryTruck): void {
    this.recoveryTruckService.createRecoveryTruck(this.recoveryTruck)
    .subscribe(response => {
      this.recoveryTruck = new RecoveryTruck('', '', '');
      formRecoveryTruck.resetForm();
      this.formSave.emit();
    }, (erro: HttpErrorResponse) => {
      this.error = {
        hasError: true,
        message: erro.error.errors.Plate[0]
      };
    });
  }

  private editRecoveryTruck(formRecoveryTruck): void {
    this.recoveryTruckService.editRecoveryTruck(this.recoveryTruck, this.recoveryTruck.id)
    .subscribe(response => {
      this.recoveryTruck = new RecoveryTruck('', '', '');
      formRecoveryTruck.resetForm();
      this.formSave.emit();
    }, (erro: HttpErrorResponse) => {
      this.error = {
        hasError: true,
        message: erro.error.errorMessage
      };
    });
  }

  handleFormClose(formRecoveryTruck): void {
    this.formClose.emit();
    formRecoveryTruck.resetForm();
    this.error = {
      hasError: false,
      message: null
    };
  }
}
