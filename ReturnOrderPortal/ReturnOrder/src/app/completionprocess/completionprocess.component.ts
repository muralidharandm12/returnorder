import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Processreq } from '../service/processreq.model';
import { Processresponse } from '../service/processresponse.model';
import { ReturnserviceService } from '../service/returnservice.service';

@Component({
  selector: 'app-completionprocess',
  templateUrl: './completionprocess.component.html',
  styleUrls: ['./completionprocess.component.css']
})
export class CompletionprocessComponent implements OnInit {

  public processResponse:Processresponse=<Processresponse>{};
  public details : Processreq = <Processreq>{};
  constructor(private retService:ReturnserviceService,private toastr:ToastrService,private router:Router) { }

  ngOnInit(): void {
    this.processResponse = this.retService.pres;
    this.details = this.retService.rorder;
    this.retService.pres = <Processresponse>{};
    this.retService.rorder = <Processreq>{};
  }


    
}
