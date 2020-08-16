import { RecoveryTruckService } from './../../../services/recovery-truck.service';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'jz-list',
    templateUrl: 'list.component.html',
    styleUrls: ['list.component.css']
})

export class ListComponent implements OnInit {

  constructor(private recoveryTruckService: RecoveryTruckService) { }

  @Input()
  recoveryTruckList = [];

  @Output()
  recoveryTruckEdit = new EventEmitter();

  @Output()
  recoveryTruckRemove = new EventEmitter();

  error = {
    hasError: false,
    message: null
  };

  ngOnInit(): void {
    this.recoveryTruckService.listRecoveryTruck().subscribe(response => {
      this.recoveryTruckList = response;
    });
  }

  handleEditRecoveryTruck(id: string): void {
    this.recoveryTruckService.findRecoveryTruckById(id)
    .subscribe(response => {
      this.recoveryTruckEdit.emit(response);
    }, (erro: HttpErrorResponse) => {
      this.error = {
        hasError: true,
        message: erro.error.errorMessage
      };
    });
  }

  handleRemoveRecoveryTruck(id: string): void {
    this.recoveryTruckService.removeRecoveryTruck(id)
    .subscribe(response => {
      this.recoveryTruckRemove.emit();
    }, (erro: HttpErrorResponse) => {
      this.error = {
        hasError: true,
        message: erro.error.errorMessage
      };
    });
  }
}
