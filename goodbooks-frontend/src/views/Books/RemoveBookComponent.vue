<template>
    <div class="books-container">
        <!-- Use {{ }} for displaying data, not v-model -->
        <p>{{ deletingBook.title }}</p>
        <p>{{ deletingBook.author }}</p>
        <p>{{ formatDate(deletingBook.createdOn) }}</p>
        <p>{{ formatDate(deletingBook.updatedOn) }}</p>
        <button @click="removeBook">Remove Book</button>
    </div>
</template>

<script>
import axios from 'axios';
import router from '@/router';

export default {
    name: "RemoveBookComponent",
    data() {
        return {
            deletingBook: {
                id: '',
                title: '',
                author: '',
                createdOn: '',
                updatedOn: ''
            }
        };
    },
    created() {
        // Get ID from route params and fetch the book
        this.fetchBook();
    },
    methods: {
        formatDate(dateString) {
            if (!dateString) return '';
            return new Date(dateString).toLocaleDateString();
        },

        async fetchBook() {
            try {
                // Get ID from route params (assuming route is like /remove-book/:id)
                const bookId = this.$route.params.id;

                if (!bookId) {
                    console.error('No book ID provided');
                    return;
                }

                // String interpolation for GET request
                const response = await fetch(`${process.env.VUE_APP_API_URL}/books/${bookId}`);
                const data = await response.json();
                this.deletingBook = data;
            } catch (error) {
                console.error('Error fetching book:', error);
            }
        },

        async removeBook() {
            try {
                // Get the book ID (from route or from deletingBook)
                const bookId = this.$route.params.id || this.deletingBook.id;

                if (!bookId) {
                    console.error('No book ID to delete');
                    return;
                }

                // FIXED: Use string interpolation instead of {id}
                const httpResponseMessage = await axios.delete(`${process.env.VUE_APP_API_URL}/books/${bookId}`);

                if (httpResponseMessage.status === 204) {
                    console.log('Book removed successfully');
                    router.push('/books/list');
                } else {
                    console.error('Failed to remove book:', httpResponseMessage);
                }
            } catch (error) {
                console.error('Error deleting book:', error);
            }
        }
    }
};
</script>