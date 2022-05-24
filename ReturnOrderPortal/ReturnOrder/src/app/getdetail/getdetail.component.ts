import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ReturnserviceService } from '../service/returnservice.service';

@Component({
  selector: 'app-getdetail',
  templateUrl: './getdetail.component.html',
  styleUrls: ['./getdetail.component.css']
})
export class GetdetailComponent implements OnInit {

  constructor(public service:ReturnserviceService,private toastr:ToastrService,private route:Router) { }

  ngOnInit(): void {
  }
  onSubmit(form:NgForm)
  {
    this.service.getDetails().subscribe(
      res=>{
        this.service.rorder=this.service.getdata;
        this.service.pres = res;
        console.log(this.service.pres);
        console.log(this.service.getdata);
          this.toastr.success('Details Created Successfully');
          this.route.navigate(['processfinal'], { skipLocationChange: true });
      }
    );
  }
}
