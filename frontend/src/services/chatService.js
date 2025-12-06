import api from './api';

export const getChatResponse = async (prompt) => {
    const response = await api.post('/chat', { prompt });
    return response.data;
};