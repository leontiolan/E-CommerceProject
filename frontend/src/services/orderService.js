import api from './api';

export const getMyOrders = async () => {
    const response = await api.get('/orders/my-orders');
    return response.data;
};

// --- NEW: Fetch specific order details ---
export const getOrderDetails = async (id) => {
    const response = await api.get(`/orders/${id}`);
    return response.data;
};

export const cancelOrder = async (orderId) => {
    await api.put(`/orders/${orderId}/cancel`);
};

export const confirmDelivery = async (orderId) => {
    await api.put(`/orders/${orderId}/delivered`);
};