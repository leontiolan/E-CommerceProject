import api from './api';

export const getMyProfile = async () => {
    const response = await api.get('/account/me');
    return response.data;
};

export const changePassword = async (currentPassword, newPassword) => {
    await api.put('/account/change-password', { currentPassword, newPassword });
};