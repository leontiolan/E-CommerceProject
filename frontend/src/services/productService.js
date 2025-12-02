import api from './api';

export const getProducts = async (params) => {
    // params: { page, size, sort, category, search }
    const response = await api.get('/products', { params });
    return response.data;
};

export const getProductById = async (id) => {
    const response = await api.get(`/products/${id}`);
    return response.data;
};

export const getCategories = async () => {
    const response = await api.get('/categories');
    return response.data;
};