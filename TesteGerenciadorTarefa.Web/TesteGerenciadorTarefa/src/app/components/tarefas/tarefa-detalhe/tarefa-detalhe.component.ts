

import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';

@Component({
    selector: 'app-tarefa-detalhe',
    templateUrl: './tarefa-detalhe.component.html',
    styleUrls: ['./tarefa-detalhe.component.scss']
})
export class TarefaDetalheComponent implements OnInit {

    form: FormGroup;
    public id: string;
    public descricao: string;
    public data: Date;
    public status: boolean;

    constructor(private apiService: ApiService, private router: Router, private route: ActivatedRoute) {
        this.form = new FormGroup({
            id: new FormControl('', Validators.required),
            descricao: new FormControl('', Validators.required),
            data: new FormControl('', Validators.required),
            status: new FormControl('', Validators.required),

        });
    }

    ngOnInit(): void {

        this.id = this.route.snapshot.params['id'];
        this.buscarTarefa(this.id);

    }

    buscarTarefa(id: string) {
        this.apiService.get('Tarefas/buscarporid' + id).subscribe((result: any) => {
            this.form.setValue({
                id: result.id,
                descricao: result.descricao,
                data: result.data,
                status: result.status
            });
        });
    }

    voltar() {
        this.router.navigateByUrl('');
    }
}

