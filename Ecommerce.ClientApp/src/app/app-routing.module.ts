import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormComponent } from './form/form.component';
import { MsalGuard } from '@azure/msal-angular';
import { AppComponent } from './app.component';

const routes: Routes = [
  {
    path:'form',
    component: FormComponent,
    canActivate: [
      MsalGuard
    ]
  },
  {
    path:'',
    component:AppComponent,
    canActivate:[
      MsalGuard
    ]
  }
];

const isIframe = window !== window.parent && !window.opener;

@NgModule({
  imports: [RouterModule.forRoot(routes,{
    useHash: false,
    // Don't perform initial navigation in iframes
    initialNavigation: !isIframe ? 'enabledBlocking' : 'disabled'
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
