import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';
import { TarefaNovo, TarefaEditar } from './tarefa.class';

@Component({
    selector: 'app-tarefa-criar-editar',
    templateUrl: './tarefa-criar-editar.component.html',
    styleUrls: ['./tarefa-criar-editar.component.scss']
})
export class TarefaCriarEditarComponent implements OnInit {

  form: FormGroup;
  public id: string;
  public descricao: string;
  public data: Date;
  public status: boolean;

    constructor(private apiService: ApiService, private router: Router, private route: ActivatedRoute) {
        this.form = new FormGroup({
          id: new FormControl('', ),
          descricao: new FormControl('', ),
          data: new FormControl('', ),
          status: new FormControl('', )
        });
    }

    ngOnInit(): void {

        this.id = this.route.snapshot.params['id'];

        if (this.id != "0") {
            this.buscarTarefa(this.id);
        }
    }

    buscarTarefa(id: string) {
        this.apiService.get('tarefas/buscarporid/' + id).subscribe((result: any) => {



            this.form.setValue({
                id: result.id,
                descricao: result.descricao,
                data: result.data,
                status: result.status,

            });
        });
    }







    salvar() {

        if (this.id == "0") {

            // Valida formulário
            if (!this.form.valid) {
                for (let ctrl in this.form.controls) { this.form.controls[ctrl].markAsTouched(); }
            }
            else {
                let tarefa = new TarefaNovo();

                tarefa.descricao = this.form.controls['descricao'].value;
                tarefa.data = this.form.controls['data'].value;
                tarefa.status = this.form.controls['status'].value;


                this.apiService.post('tarefas/criar', tarefa).subscribe((result: any) => {
                    this.voltar();
                });
            }
        }
        else {
            // Valida formulário
            if (!this.form.valid) {
                for (let ctrl in this.form.controls) { this.form.controls[ctrl].markAsTouched(); }
            }
            else {
                let tarefa = new TarefaEditar();

                tarefa.id = +this.id;
                tarefa.descricao = this.form.controls['marca'].value;
                tarefa.data = this.form.controls['modelo'].value;
                tarefa.status = this.form.controls['versao'].value;


                this.apiService.put('tarefas/editar/' + this.id, tarefa).subscribe((result: any) => {
                    this.voltar()
                });
            }
        }
    }

    voltar() {
        this.router.navigateByUrl('');
    }
}
