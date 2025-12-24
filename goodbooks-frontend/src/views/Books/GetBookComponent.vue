<template>
    <h2>{{ book.title }}</h2>
    <p>Author: {{ book.author }}</p>
    <p>Published: {{ formatDate(book.createdOn) }}</p>
    <p><router-link :to="`/books/update/${book.id}`">Update</router-link></p>
    <p><router-link :to="`/books/remove/${book.id}`">Remove</router-link></p>
</template>

<script>


export default {
    name: "GetBookComponent",
    data() {
        return {
            book: {
                id: '',
                title: '',
                author: '',
                createdOn: '',
                updatedOn: ''
            }
        };
    },
    created() {
        this.fetchBook();
    },
    methods: {
        async fetchBook() {
            try {
                const response = await fetch(`${process.env.VUE_APP_API_URL}/books/${this.$route.params.id}`);
                const data = await response.json();
                this.book = data;
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