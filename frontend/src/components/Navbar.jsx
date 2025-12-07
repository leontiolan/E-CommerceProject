import { useContext, useState, useEffect } from 'react';
import { Link, useNavigate, useSearchParams } from 'react-router-dom';
import { AuthContext } from '../context/AuthContext';

const Navbar = () => {
    const { user, logout } = useContext(AuthContext);
    const navigate = useNavigate();
    const [searchParams] = useSearchParams();
    
    const [searchTerm, setSearchTerm] = useState(searchParams.get('search') || '');

    useEffect(() => {
        const delaySearch = setTimeout(() => {
            const currentUrlSearch = searchParams.get('search') || '';
            
            if (searchTerm !== currentUrlSearch) {
                if (searchTerm.trim()) {
                    navigate(`/?search=${encodeURIComponent(searchTerm)}`);
                } else {
                    navigate('/'); 
                }
            }
        }, 500);

        return () => clearTimeout(delaySearch);
    }, [searchTerm, navigate, searchParams]);

    return (
        <nav className="navbar">
            <Link to="/" className="brand">E-Shop</Link>
            
            <div className="navbar-search-container">
                <input 
                    type="text" 
                    placeholder="Search products..." 
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                    className="navbar-search-input"
                />
            </div>

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