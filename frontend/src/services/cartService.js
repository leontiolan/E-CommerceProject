import api from './api';

export const getCart = async () => {
    const response = await api.get('/cart');
    return response.data;
};

export const addToCart = async (productId, quantity) => {
    const response = await api.post('/cart/items', { productId, quantity });
    return response.data;
};

export const removeFromCart = async (itemId) => {
    const response = await api.delete(`/cart/items/${itemId}`);
    return response.data;
};

export const checkout = async (shippingAddress) => {
    const response = await api.post('/orders/checkout', { shippingAdress: shippingAddress }); // Note: typo 'shippingAdress' matches your backend DTO
    return response.data;
};