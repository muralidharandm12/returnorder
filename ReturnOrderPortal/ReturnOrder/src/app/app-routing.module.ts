import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompletionprocessComponent } from './completionprocess/completionprocess.component';
import { GetdetailComponent } from './getdetail/getdetail.component';
import { LoginComponent } from './login/login.component';
import { ProcessfinalComponent } from './processfinal/processfinal.component';

const routes: Routes = [
   {path :'getdetail',component:GetdetailComponent},
  {path:'',component:LoginComponent},
  {path:'processfinal',component:ProcessfinalComponent},
  {path:'completeProcess',component:CompletionprocessComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingcomponent = [GetdetailComponent,LoginComponent]
