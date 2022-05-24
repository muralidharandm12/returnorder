import { Injectable } from '@angular/core';
import { Returnservice } from './returnservice.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IErrorDto } from '../ErrorDto';
import { Getdetail } from './getdetail.model';
import { Processresponse } from './processresponse.model';
import { Processreq } from './processreq.model';

@Injectable({
  providedIn: 'root'
})
export class ReturnserviceService {

  constructor(private http:HttpClient) { }
  formData:Returnservice = new Returnservice();
  public pres:Processresponse=<Processresponse>{};
  public rorder:Processreq=<Processreq>{};

  getdata:Getdetail = new Getdetail();

  readonly baseUrl = 'http://52.149.254.200/api/UserLogin';
  readonly baseUrl1 = 'http://52.149.254.200/api/ReturnOrder/GetDetails';
  readonly cprocess = "http://52.149.254.200/api/ReturnOrder/CompleteProcessing?flag="
  postLogin():Observable<any>
  {
    return this.http.post(this.baseUrl,this.formData)
  }
  getDetails():Observable<any>
  {
    const headers = new HttpHeaders().set('Content-Type','application/json');
    return this.http.post(this.baseUrl1,this.getdata,{'headers':headers});
    // return this.http.post(this.baseUrl1,this.getdata)
  }
  CompleteProcess(flag:number) : Observable<any>{
  
    return this.http.post(this.cprocess+flag, null);
  }
  
}
