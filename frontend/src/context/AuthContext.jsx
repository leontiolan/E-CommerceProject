import { createContext, useState, useEffect } from 'react';
import { getCurrentUser, login, logout } from '../services/authService';

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const storedUser = getCurrentUser();
        if (storedUser) {
            setUser(storedUser);
        }
        setLoading(false);
    }, []);

    const handleLogin = async (username, password) => {
        try {
            const data = await login(username, password);
            setUser(data);
            return true;
        } catch (error) {
            console.error("Login failed", error);
            return false;
        }
    };

    const handleLogout = () => {
        logout();
        setUser(null);
        window.location.href = '/';
    };

    return (
        <AuthContext.Provider value={{ user, login: handleLogin, logout: handleLogout, loading }}>
            {!loading && children}
        </AuthContext.Provider>
    );
};