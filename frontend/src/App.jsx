import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { AuthProvider, AuthContext } from './context/AuthContext';
import { useContext } from 'react';
import Navbar from './components/Navbar';
import ChatBot from './components/ChatBot';
import HomePage from './pages/HomePage';
import LoginPage from './pages/LoginPage';
import RegisterPage from './pages/RegisterPage';
import ProductDetailsPage from './pages/ProductDetailsPage';
import CartPage from './pages/CartPage';
import ProfilePage from './pages/ProfilePage';
import './App.css';
import OrderSuccessPage from './pages/OrderSuccessPage';

// Protected Route Component
const ProtectedRoute = ({ children }) => {
    const { user, loading } = useContext(AuthContext);
    if (loading) return null;
    if (!user) return <div style={{textAlign:'center', marginTop:'50px'}}>Please <a href="/login">Login</a> to view this page.</div>;
    return children;
};

function App() {
  return (
    <AuthProvider>
      <Router>
        <div className="app-container">
          <Navbar />
          <div className="main-content">
            <Routes>
              <Route path="/" element={<HomePage />} />
              <Route path="/login" element={<LoginPage />} />
              <Route path="/register" element={<RegisterPage />} />
              <Route path="/product/:id" element={<ProductDetailsPage />} />
              <Route path="/cart" element={<ProtectedRoute><CartPage /></ProtectedRoute>} />
              <Route path="/profile" element={<ProtectedRoute><ProfilePage /></ProtectedRoute>} />
              <Route path="/order-success" element={<ProtectedRoute><OrderSuccessPage /></ProtectedRoute>} />
            </Routes>
          </div>
          {/* Floating Chatbot visible on all pages when logged in (or public if desired) */}
          <ChatBot />
        </div>
      </Router>
    </AuthProvider>
  );
}

export default App;