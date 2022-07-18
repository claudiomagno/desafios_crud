import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Pessoa } from '../pessoa';
import { CidadeService } from 'src/app/cidade/cidade.service';
import { PessoaService } from '../pessoa.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Cidade } from 'src/app/cidade/cidade';

@Component({
  selector: 'app-edit-pessoa',
  templateUrl: './edit-pessoa.component.html',
  styleUrls: ['./edit-pessoa.component.css']
})
export class EditPessoaComponent implements OnInit {

  id: number;
  pessoa: Pessoa;
  form: FormGroup;
  listUfs = [];
  listCidade : Cidade[] = [];
  cpfpMask = '000.000.000-00'
  public mask = [/[1-9]/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '-', /\d/, /\d/]


  constructor(
    public pessoaService: PessoaService,
    public cidadeService: CidadeService,
    private route: ActivatedRoute,
    private router: Router
  ) {


  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['pessoaId'];

    this.cidadeService.getAll().subscribe((data: Cidade[])=>{
      this.listCidade = data['cidades'];
      console.log(this.listCidade);
    })
    this.pessoaService.find(this.id).subscribe((data: Pessoa)=>{
      console.log(data['pessoa'])
      this.pessoa = data['pessoa'];
      this.pessoa['id_Cidade'] = this.pessoa.cidade.id
      this.form.patchValue(this.pessoa);
    });

    this.form = new FormGroup({
      nome: new FormControl('', [Validators.required]),
      cpf: new FormControl('', Validators.required),
      idade: new FormControl('', Validators.required),
      id_Cidade: new FormControl('', Validators.required)
    });


    this.listUfs = this.cidadeService.getUfs();
  }

  get f(){
    return this.form.controls;
  }

  submit(){
    console.log(this.form.value);
    this.pessoaService.update(this.id, this.form.value).subscribe(res => {
         alert('Pessoa updated successfully!');
         this.router.navigateByUrl('pessoa/index');
    },
         error => {
           // error path
           alert(error)
       }
         )
  }
}
