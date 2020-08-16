
import { FormsModule } from '@angular/forms';
import { RecoveryTruckService } from '../../services/recovery-truck.service';
import { RecoveryTruckFormComponent } from './recovery-truck-form/recovery-truck-form.component';
import { ListComponent } from './list/list.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
     FormsModule,
     CommonModule
    ],
  declarations: [
    RecoveryTruckFormComponent,
    ListComponent
  ],
  providers: [ RecoveryTruckService ],
  exports: [
    RecoveryTruckFormComponent,
    ListComponent
   ]
})
export class RecoveryTruckModule {}
