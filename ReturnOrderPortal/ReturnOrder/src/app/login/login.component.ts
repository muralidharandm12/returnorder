import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ReturnserviceService } from 'src/app/service/returnservice.service';
import { Returnservice } from '../service/returnservice.model';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpClient } from '@angular/common/http';
import { IErrorDto } from '../ErrorDto';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  err:IErrorDto;
  constructor(public service:ReturnserviceService,private toastr:ToastrService,private route:Router) { }

  ngOnInit(): void {
  }
  onSubmit(form:NgForm)
  {
    let err = new IErrorDto()
    this.service.postLogin().subscribe(
      res=>{this.err=res,console.log(this.err)
        if(this.err.message=="Success")
        {
          console.log(this.err.message)
          this.toastr.success('Login Successfully')
          this.route.navigate(['getdetail'], { skipLocationChange: true })
        }
        else
        {
          alert("invalid username or password")
              this.onReset(form);
        }
        
      }
    );
  }
  onReset(form:NgForm)
    {
      form.form.reset();
    }
  
}
