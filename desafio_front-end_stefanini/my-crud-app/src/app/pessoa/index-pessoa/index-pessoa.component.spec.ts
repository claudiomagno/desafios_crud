import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IndexPessoaComponent } from './index-pessoa.component';

describe('IndexPessoaComponent', () => {
  let component: IndexPessoaComponent;
  let fixture: ComponentFixture<IndexPessoaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IndexPessoaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IndexPessoaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
