import { Routes } from '@angular/router';
import { CategoryOperation } from './myComponents/category-operation/category-operation';

export const routes: Routes = [
    { path: '', component: CategoryOperation },
    { path: 'categories', component: CategoryOperation },
    // { path: 'posts', component: PostOperation },
    // { path: 'tags', component: TagOperation },
];
