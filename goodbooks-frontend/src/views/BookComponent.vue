<template>
    <h2>{{ book.title }}</h2>
    <p>Author: {{ book.author }}</p>
    <p>Published: {{ formatDate(book.createdOn) }}</p>
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