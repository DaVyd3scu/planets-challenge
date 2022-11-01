import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ShowPlanetsComponent } from './components/show-planets/show-planets.component';

const bootstrap = require('bootstrap')

@NgModule({
  declarations: [
    AppComponent,
    ShowPlanetsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
