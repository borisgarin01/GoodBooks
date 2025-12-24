<template>
  <div class="books-container">
    <input type="text" v-model="newBook.title" placeholder="Title">
    <input type="text" v-model="newBook.author" placeholder="Author">
    <input type="date" v-model="newBook.createdOn" placeholder="Published Date">
    <input type="date" v-model="newBook.updatedOn" placeholder="Updated Date">
    <button @click="addBook">Add Book</button>
  </div>
</template>

<script>
import axios from 'axios';

export default {
    name: "AddBookComponent",
    data() {
    return {
      newBook: {
        title: '',
        author: '',
        createdOn: '',
        updatedOn: ''
      }
    };
  },
  methods: {
    async addBook() {
      try {
        await axios.post(`${process.env.VUE_APP_API_URL}/books`, this.newBook);
      } catch (error) {
        console.error('Error posting book:', error);
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