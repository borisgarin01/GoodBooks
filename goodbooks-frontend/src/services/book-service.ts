import IBook from '@/types/Book';
import axios from 'axios';

export default class BookService {
    API_URL = process.env.VUE_APP_API_URL;

    public async getAllBooks(): Promise<IBook[]> {
        const response = await axios.get<IBook[]>('${this.API_URL}/books/');
        return response.data;
    }
}