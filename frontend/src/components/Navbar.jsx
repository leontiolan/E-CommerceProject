import { useContext, useState, useEffect } from 'react';
import { Link, useNavigate, useSearchParams } from 'react-router-dom';
import { AuthContext } from '../context/AuthContext';

const Navbar = () => {
    const { user, logout } = useContext(AuthContext);
    const navigate = useNavigate();
    const [searchParams] = useSearchParams();
    
    // Initialize search from URL (so it persists on refresh)
    const [searchTerm, setSearchTerm] = useState(searchParams.get('search') || '');

    // Debounce Search Logic (Instant Search)
    useEffect(() => {
        const delaySearch = setTimeout(() => {
            const currentUrlSearch = searchParams.get('search') || '';
            
            // Only navigate if the search term has actually changed
            if (searchTerm !== currentUrlSearch) {
                if (searchTerm.trim()) {
                    navigate(`/?search=${encodeURIComponent(searchTerm)}`);
                } else {
                    // If search is cleared, go back to root home
                    navigate('/'); 
                }
            }
        }, 500); // 500ms delay

        return () => clearTimeout(delaySearch);
    }, [searchTerm, navigate, searchParams]);

    return (
        <nav className="navbar">
            <Link to="/" className="brand">E-Shop</Link>
            
            {/* --- NEW: Global Search Bar --- */}
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