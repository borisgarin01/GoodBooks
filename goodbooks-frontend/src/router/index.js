import { createRouter, createWebHistory } from 'vue-router';
import HomeComponent from '../views/HomeComponent.vue';
import AboutComponent from '@/views/AboutComponent.vue';
import BooksComponent from '@/views/BooksComponent.vue';
import AddBookComponent from '@/views/AddBookComponent.vue';

const routes = [
    {
        path: '/',
        name: 'HomeComponent',
        component: HomeComponent
    },
    {
        path: '/about',
        name: 'AboutComponent',
        component: AboutComponent
    },
    {
        path: '/books',
        name: 'BooksComponent',
        component: BooksComponent
    },
    {
        path: '/add-book',
        name: 'AddBookComponent',
        component: AddBookComponent
    }
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
});

export default router;