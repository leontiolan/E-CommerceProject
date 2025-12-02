import api from './api';

export const getReviews = async (productId) => {
    const response = await api.get(`/products/${productId}/reviews`);
    return response.data;
};

export const createReview = async (productId, rating, comment) => {
    const response = await api.post('/reviews', { productId, rating, comment });
    return response.data;
};