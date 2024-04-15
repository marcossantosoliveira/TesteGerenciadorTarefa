import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { TarefaCriarEditarComponent } from './tarefa-criar-editar.component';

describe('TarefaCriarEditarComponent', () => {
    let component: TarefaCriarEditarComponent;
    let fixture: ComponentFixture<TarefaCriarEditarComponent>;

    beforeEach(async(() => {
      TestBed.configureTestingModule({
        declarations: [ TarefaCriarEditarComponent ]
      })
      .compileComponents();
    }));

    beforeEach(() => {
      fixture = TestBed.createComponent(TarefaCriarEditarComponent);
      component = fixture.componentInstance;
      fixture.detectChanges();
    });

    it('should create', () => {
      expect(component).toBeTruthy();
    });
  });
