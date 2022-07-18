import { Component, OnInit } from '@angular/core';
import { CidadeService } from '../cidade.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Cidade } from '../cidade';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  id: number;
  cidade: Cidade;
  form: FormGroup;
  listUfs = [];

  constructor(
    public cidadeService: CidadeService,
    private route: ActivatedRoute,
    private router: Router
  ) {


  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['cidadeId'];
    this.cidadeService.find(this.id).subscribe((data: Cidade)=>{
      console.log(data['cidade'])
      this.cidade = data['cidade'];
      this.form.patchValue(this.cidade);
    });

    this.form = new FormGroup({
      nome: new FormControl('', [Validators.required]),
      uf: new FormControl('', Validators.required)
    });


    this.listUfs = this.cidadeService.getUfs();
  }

  get f(){
    return this.form.controls;
  }

  submit(){
    console.log(this.form.value);
    this.cidadeService.update(this.id, this.form.value).subscribe(res => {
         alert('Cidade updated successfully!');
         this.router.navigateByUrl('cidade/index');
    },
    error => {
      // error path
      alert(error)
  }
    )
  }

}
