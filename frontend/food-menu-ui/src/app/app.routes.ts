
import { Routes } from '@angular/router';
import { AdminLogin } from './components/admin-login/admin-login';
import { AdminDashboard } from './components/admin-dashboard/admin-dashboard';
import { FoodList } from './components/food-list/food-list';

export const routes: Routes = [

  {
    path: '',
    component: FoodList
  },

  {
    path: 'admin-login',
    component: AdminLogin
  },

  {
    path: 'admin-dashboard',
    component: AdminDashboard
  },

  {
    path: '**',
    redirectTo: ''
  }

];
