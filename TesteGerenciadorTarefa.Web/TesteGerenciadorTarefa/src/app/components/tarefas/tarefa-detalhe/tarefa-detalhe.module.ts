import { MatInputModule } from '@angular/material/Input';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { TarefaDetalheComponent } from './tarefa-detalhe.component';
import { TarefaDetalheRoutingModule } from './tarefa-detalhe-routing.module';

@NgModule({
    declarations: [TarefaDetalheComponent],
    imports: [
        CommonModule,
        TarefaDetalheRoutingModule,
        ReactiveFormsModule,
        MatInputModule,
    ]
})
export class TarefaDetalheModule { }
