import { Component, OnInit } from '@angular/core';
import { ReturnserviceService } from '../service/returnservice.service';
import { Router } from '@angular/router';
import { Processresponse } from '../service/processresponse.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-processfinal',
  templateUrl: './processfinal.component.html',
  styleUrls: ['./processfinal.component.css']
})
export class ProcessfinalComponent implements OnInit {
  public processResponse:Processresponse=<Processresponse>{};
  constructor(private retService:ReturnserviceService,private router:Router,private toastr:ToastrService) { }

  ngOnInit(): void {
    this.processResponse = this.retService.pres;
    
    
  }

  OnProcess(){    
    
    this.retService.CompleteProcess(1).subscribe(result=>
      { 
        var msg=result;         
         this.router.navigate(['completeProcess'], { skipLocationChange: true });
         this.toastr.success('Processed Successfully');
        } );
      
  }


}
