import { Component, OnInit } from '@angular/core';
import { CidadeService } from '../cidade.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Cidade } from '../cidade';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  id: number;
  cidade: Cidade;

  constructor(
    public cidadeService: CidadeService,
    private route: ActivatedRoute,
    private router: Router
   ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['cidadeId'];
    console.log( this.id)
    this.cidadeService.find(this.id).subscribe((data: Cidade)=>{
      console.log(data)
      this.cidade = data['cidade'];
    });
  }

}
