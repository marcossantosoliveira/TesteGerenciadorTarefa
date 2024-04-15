
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { ListaTarefasComponent } from './lista-tarefas.component';
import { ListaTarefasRoutingModule } from './lista-tarefas-routing.module';

@NgModule({
    declarations: [
        ListaTarefasComponent
    ],
    imports: [
      CommonModule,
      ListaTarefasRoutingModule,
      MatTableModule,
      MatSortModule
    ],
    exports:[
        ListaTarefasComponent
    ]
  })
export class ListaTarefasModule { }
