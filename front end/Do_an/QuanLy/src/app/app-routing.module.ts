import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [ { path: 'insertData', loadChildren: () => import('./pages/insert-data/insert-data.module').then(m => m.InsertDataModule) },{ path: '**', loadChildren: () => import('./pages/table-page/table-page.module').then(m => m.TablePageModule) }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
