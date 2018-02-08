import axios from 'axios';

export default () => axios.create({
  baseURL: 'localhost:5000/',
});

