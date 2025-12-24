import { createRouter, createWebHistory } from 'vue-router';
import HomeComponent from '../views/HomeComponent.vue';
import BooksComponent from '@/views/Books/BooksComponent.vue';
import AddBookComponent from '@/views/Books/AddBookComponent.vue';
import RemoveBookComponent from '@/views/Books/RemoveBookComponent.vue';
import GetBookComponent from '@/views/Books/GetBookComponent.vue';

const routes = [
    {
        path: '/',
        name: 'HomeComponent',
        component: HomeComponent
    },
    {
        path: '/books/list',
        name: 'BooksComponent',
        component: BooksComponent
    },
    {
        path: '/books/add',
        name: 'AddBookComponent',
        component: AddBookComponent
    },
    {
        path: '/books/remove/:id',
        name: 'RemoveBookComponent',
        component: RemoveBookComponent
    },
    {
        path: '/books/details/:id',
        name: 'GetBookComponent',
        component: GetBookComponent
    }
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
});

export default router;