import { RecoveryTruckService } from './services/recovery-truck.service';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { RecoveryTruckModule } from './components/recovery-truck/recovery-truck.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RecoveryTruckModule,
  ],
  providers: [ RecoveryTruckService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
