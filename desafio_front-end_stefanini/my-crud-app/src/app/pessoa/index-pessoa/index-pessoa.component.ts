import { Component, OnInit } from '@angular/core';
import { Pessoa } from '../pessoa';
import { PessoaService } from '../pessoa.service';

@Component({
  selector: 'app-index-pessoa',
  templateUrl: './index-pessoa.component.html',
  styleUrls: ['./index-pessoa.component.css']
})
export class IndexPessoaComponent implements OnInit {

  pessoas: Pessoa[] = [];

  constructor(public PessoaService: PessoaService) { }

  ngOnInit(): void {
    this.PessoaService.getAll().subscribe((data: Pessoa[])=>{
      this.pessoas = data['pessoas'];
      console.log(this.pessoas);
    })
  }

  deletePessoa(id){
    this.PessoaService.delete(id).subscribe(res => {
         this.pessoas = this.pessoas.filter(item => item.id !== id);
         console.log('Pessoa deleted successfully!');
    },
    error => {
      // error path
      alert(error)
  }
    )
  }
}
