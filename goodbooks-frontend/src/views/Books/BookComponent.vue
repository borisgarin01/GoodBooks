<template>
    <h2>{{ book.title }}</h2>
    <p>Author: {{ book.author }}</p>
    <p>Published: {{ formatDate(book.createdOn) }}</p>
    <p><router-link :to="`/books/update/${book.id}`">Update</router-link></p>
    <p><router-link :to="`/books/remove/${book.id}`">Remove</router-link></p>
    <p><router-link :to="`/books/details/${book.id}`">Details</router-link></p>
</template>

<script>
export default {
    name: "BookComponent",
    props: {
        book: {
            type: Object,
            required: true
        }
    },
    methods: {
        formatDate(dateString) {
            return new Date(dateString).toLocaleDateString();
        }
    }
};
</script>