import { MatInputModule } from '@angular/material/Input';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { TarefaCriarEditarComponent } from './tarefa-criar-editar.component';
import { TarefaCriarEditarRoutingModule } from './tarefa-criar-editar-routing.module';

@NgModule({
    declarations: [TarefaCriarEditarComponent],
    imports: [
        CommonModule,
        TarefaCriarEditarRoutingModule,
        ReactiveFormsModule,
        MatInputModule,
    ]
})
export class TarefaCriarEditarModule { }
