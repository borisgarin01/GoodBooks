<template>
    <div class="nav nav-bar">
        <router-link to="/">Home</router-link> |
        <router-link to="/books/add">Add Book</router-link>
    </div>
    <div class="books-container">
        <HelloWorld msg="Books" />
        <div v-for="book in books" :key="book.id" class="book-item">
            <BookComponent :book="book" />
        </div>
    </div>
</template>

<script>
import HelloWorld from '@/components/HelloWorld.vue';
import BookComponent from './BookComponent.vue';

export default {
    name: "BooksComponent",
    components: {
        HelloWorld,
        BookComponent
    },
    data() {
        return {
            books: []
        };
    },
    created() {
        this.fetchBooks();
    },
    methods: {
        async fetchBooks() {
            try {
                const response = await fetch(`${process.env.VUE_APP_API_URL}/books`);
                const data = await response.json();
                this.books = data;
            } catch (error) {
                console.error('Error fetching books:', error);
            }
        },
        formatDate(dateString) {
            // Optional: Format the date if needed
            return new Date(dateString).toLocaleDateString();
        }
    }
};
</script>

<style scoped>
.books-container {
    padding: 20px;
}

.book-item {
    margin-bottom: 20px;
    padding: 15px;
    border: 1px solid #ddd;
    border-radius: 5px;
}
</style>