import { useContext } from 'react';
import { Link } from 'react-router-dom';
import { AuthContext } from '../context/AuthContext';

const Navbar = () => {
    const { user, logout } = useContext(AuthContext);

    return (
        <nav className="navbar">
            <Link to="/" className="brand">E-Shop</Link>
            <div className="nav-links">
                <Link to="/">Home</Link>
                {user ? (
                    <>
                        <Link to="/cart">Cart</Link>
                        <Link to="/profile">Profile</Link>
                        <span style={{marginLeft: '20px', color: '#94a3b8'}}>|</span>
                        <button onClick={logout} className="btn btn-danger" style={{marginLeft: '20px', fontSize: '0.8rem'}}>Logout</button>
                    </>
                ) : (
                    <Link to="/login" className="btn">Login</Link>
                )}
            </div>
        </nav>
    );
};

export default Navbar;