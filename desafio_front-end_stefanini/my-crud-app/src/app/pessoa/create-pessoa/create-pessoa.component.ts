import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Cidade } from 'src/app/cidade/cidade';
import { CidadeService } from 'src/app/cidade/cidade.service';
import { PessoaService } from '../pessoa.service';


@Component({
  selector: 'app-create-pessoa',
  templateUrl: './create-pessoa.component.html',
  styleUrls: ['./create-pessoa.component.css']
})
export class CreatePessoaComponent implements OnInit {

  form: FormGroup;
  //listUfs: string []
  listCidade : Cidade[] = [];
  cpfpMask = '000.000.000-00'
  public mask = [/[1-9]/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '-', /\d/, /\d/]



  constructor(
    public pessoaService: PessoaService,
    public cidadeService: CidadeService,
    private router: Router
  ) {

  }

  ngOnInit(): void {
    this.form = new FormGroup({
      nome: new FormControl('', [Validators.required]),
      cpf: new FormControl('', Validators.required),
      idade: new FormControl('', Validators.required),
      id_Cidade: new FormControl('', Validators.required)
    });

    this.cidadeService.getAll().subscribe((data: Cidade[])=>{
      this.listCidade = data['cidades'];
      console.log(this.listCidade);
    })
  }

  get f(){
    return this.form.controls;
  }

  submit(){
    console.log(this.form.value);
    this.pessoaService.create(this.form.value).subscribe(res => {
         alert('Incluido com sucesso!')
         this.router.navigateByUrl('pessoa/index');

    },
    error => {
      // error path
      alert(error)
  }
    )
  }

}
