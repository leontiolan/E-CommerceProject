import { useState, useEffect } from 'react';
import { getProducts, getCategories } from '../services/productService';
import { Link } from 'react-router-dom';

const HomePage = () => {
    const [products, setProducts] = useState([]);
    const [categories, setCategories] = useState([]);
    const [filters, setFilters] = useState({
        page: 0,
        size: 10,
        sort: 'name', // or price_asc, price_desc
        category: '',
        search: ''
    });

    useEffect(() => {
        getCategories().then(setCategories);
    }, []);

    useEffect(() => {
        // Convert category ID to number if present
        const params = { ...filters };
        if(!params.category) delete params.category;
        
        getProducts(params).then(data => {
            setProducts(data.content); // Spring Data Page object returns 'content' array
        });
    }, [filters]);

    const handleFilterChange = (e) => {
        setFilters({ ...filters, [e.target.name]: e.target.value });
    };

    return (
        <div>
            <div style={{ display: 'flex', gap: '10px', marginBottom: '20px', padding: '15px', background: 'white', borderRadius: '8px' }}>
                <input 
                    type="text" 
                    placeholder="Search products..." 
                    name="search"
                    onChange={handleFilterChange}
                    style={{ padding: '8px', flex: 1 }}
                />
                <select name="category" onChange={handleFilterChange} style={{ padding: '8px' }}>
                    <option value="">All Categories</option>
                    {categories.map(c => (
                        <option key={c.id} value={c.id}>{c.name}</option>
                    ))}
                </select>
                <select name="sort" onChange={handleFilterChange} style={{ padding: '8px' }}>
                    <option value="name">Name (A-Z)</option>
                    <option value="price_asc">Price (Low to High)</option>
                    <option value="price_desc">Price (High to Low)</option>
                </select>
            </div>

            <div className="product-grid">
                {products.map(product => (
                    <div key={product.id} className="product-card">
                        {/* Placeholder image if none provided */}
                        <div className="product-image" style={{display:'flex', alignItems:'center', justifyContent:'center', color:'#888'}}>
                            No Image
                        </div>
                        <h3>{product.name}</h3>
                        <p style={{ fontWeight: 'bold', color: '#27ae60' }}>${product.price.toFixed(2)}</p>
                        <Link to={`/product/${product.id}`} className="btn" style={{ textAlign: 'center', marginTop: 'auto' }}>
                            View Details
                        </Link>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default HomePage;