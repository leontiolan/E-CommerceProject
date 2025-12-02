import { useState } from 'react';
import { register } from '../services/authService';
import { useNavigate } from 'react-router-dom';

const RegisterPage = () => {
    const [formData, setFormData] = useState({ username: '', email: '', password: '' });
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await register(formData.username, formData.email, formData.password);
            alert("Registration successful! Please login.");
            navigate('/login');
        } catch (error) {
            alert("Registration failed.");
        }
    };

    return (
        <div className="form-container">
            <h2>Register</h2>
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label>Username</label>
                    <input type="text" onChange={e => setFormData({...formData, username: e.target.value})} required />
                </div>
                <div className="form-group">
                    <label>Email</label>
                    <input type="email" onChange={e => setFormData({...formData, email: e.target.value})} required />
                </div>
                <div className="form-group">
                    <label>Password</label>
                    <input type="password" onChange={e => setFormData({...formData, password: e.target.value})} required />
                </div>
                <button type="submit" className="btn" style={{width: '100%'}}>Register</button>
            </form>
        </div>
    );
};

export default RegisterPage;