import api from './api';

export const getMyOrders = async () => {
    const response = await api.get('/orders/my-orders');
    return response.data;
};

export const cancelOrder = async (orderId) => {
    await api.put(`/orders/${orderId}/cancel`);
};