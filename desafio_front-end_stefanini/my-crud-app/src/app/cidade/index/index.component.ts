import { Component, OnInit } from '@angular/core';
import { CidadeService } from '../cidade.service';
import { Cidade } from '../cidade';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  Cidades: Cidade[] = [];

  constructor(public CidadeService: CidadeService) { }

  ngOnInit(): void {
    this.CidadeService.getAll().subscribe((data: Cidade[])=>{
      this.Cidades = data['cidades'];
      console.log(this.Cidades);
    })
  }

  deleteCidade(id){
    this.CidadeService.delete(id).subscribe(res => {
         this.Cidades = this.Cidades.filter(item => item.id !== id);
         console.log('Cidade deleted successfully!');
    },
    error => {
      // error path
      alert(error)
  }
    )
  }

}
