import { Component, OnInit } from '@angular/core';
import { CidadeService } from '../cidade.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  form: FormGroup;
  //listUfs: string []
  listUfs = [{ uf: 'BA' }, { uf: 'SP' }];


  constructor(
    public cidadeService: CidadeService,
    private router: Router
  ) {

    this.listUfs = cidadeService.getUfs();
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      nome: new FormControl('', [Validators.required]),
      uf: new FormControl('', Validators.required)
    });
  }

  get f(){
    return this.form.controls;
  }

  submit(){
    console.log(this.form.value);
    this.cidadeService.create(this.form.value).subscribe(res => {
         alert('cidade created successfully!');
         this.router.navigateByUrl('cidade/index');
    },
    error => {
      // error path
      alert(error)
  }
    )
  }

}
