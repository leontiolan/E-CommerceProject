import api from './api';

export const getProducts = async () => {
    try {
        // Matches CatalogController.java: @GetMapping("/products")
        const response = await api.get('/products');
        return response.data;
    } catch (error) {
        console.error("Error fetching products", error);
        throw error;
    }
};