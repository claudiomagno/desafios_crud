import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PessoaRoutingModule } from './pessoa-routing.module';
import { ViewPessoaComponent } from './view-pessoa/view-pessoa.component';
import { CreatePessoaComponent } from './create-pessoa/create-pessoa.component';
import { EditPessoaComponent } from './edit-pessoa/edit-pessoa.component';
import { IndexPessoaComponent } from './index-pessoa/index-pessoa.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextMaskModule } from 'angular2-text-mask';

//export const options: Partial<IConfig> | (() => Partial<IConfig>) = {};

@NgModule({
  declarations: [IndexPessoaComponent,ViewPessoaComponent, CreatePessoaComponent, EditPessoaComponent],
  imports: [
    CommonModule,
    PessoaRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule,
    TextMaskModule
   // NgxMaskModule.forRoot(options),
  ]
})
export class PessoaModule { }
