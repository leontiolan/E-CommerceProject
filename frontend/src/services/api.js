import axios from 'axios';

// Base configuration for Axios
const api = axios.create({
    baseURL: 'http://localhost:8083/api', // Matches your Spring Boot port
    headers: {
        'Content-Type': 'application/json',
    }
});

// Add a request interceptor to attach the JWT token if it exists
api.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem('token');
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    (error) => Promise.reject(error)
);

export default api;