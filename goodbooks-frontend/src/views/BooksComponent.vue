<template>
  <div class="books-container">
    <HelloWorld msg="Books"/>
    <div v-for="book in books" :key="book.id" class="book-item">
      <h2>{{ book.title }}</h2>
      <p>Author: {{ book.author }}</p>
      <p>Published: {{ formatDate(book.createdOn) }}</p>
    </div>
  </div>
</template>

<script>
import HelloWorld from '@/components/HelloWorld.vue';

export default {
  name: "BooksComponent",
  components: {
    HelloWorld,
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