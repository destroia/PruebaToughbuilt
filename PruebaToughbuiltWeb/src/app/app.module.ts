import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
/*import { PruductComponent } from './ViewsHome/pruduct/pruduct.component';*/
import { CrudProductComponent } from './ViewsHome/crud-product/crud-product.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CategoryComponent } from './ViewsHome/category/category.component';
import { PruductComponent } from './ViewsHome/pruduct/pruduct.component';
import { DetailsComponent } from './ViewsHome/details/details.component';
@NgModule({
  declarations: [
    AppComponent,
    PruductComponent,
    CrudProductComponent,
    CategoryComponent,
    DetailsComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [{ provide: LocationStrategy, useClass: HashLocationStrategy }],
  bootstrap: [AppComponent]
})
export class AppModule { }
