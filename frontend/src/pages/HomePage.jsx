import { useState, useEffect } from 'react';
import { getProducts, getCategories } from '../services/productService';
import { Link } from 'react-router-dom';

const HomePage = () => {
    const [products, setProducts] = useState([]);
    const [categories, setCategories] = useState([]);
    const [totalPages, setTotalPages] = useState(0);
    const [showFilters, setShowFilters] = useState(false);
    
    // API State (Only updates when "Apply" is clicked)
    const [activeFilters, setActiveFilters] = useState({
        page: 0,
        size: 9,
        sort: 'name',
        category: '',
        search: '',
        minPrice: '',
        maxPrice: ''
    });

    // Form UI State (Updates as you type)
    const [formState, setFormState] = useState({ ...activeFilters });

    useEffect(() => {
        getCategories().then(setCategories);
    }, []);

    useEffect(() => {
        // Prepare parameters for API
        const params = { ...activeFilters };
        
        // Remove empty keys so API doesn't receive "minPrice": ""
        if (!params.category) delete params.category;
        if (!params.minPrice) delete params.minPrice;
        if (!params.maxPrice) delete params.maxPrice;
        if (!params.search) delete params.search;

        getProducts(params).then(data => {
            setProducts(data.content);
            setTotalPages(data.totalPages);
        }).catch(err => console.error("Error fetching products:", err));
    }, [activeFilters]); // Triggered only when activeFilters changes

    const handleInputChange = (e) => {
        setFormState({ ...formState, [e.target.name]: e.target.value });
    };

    const applyFilters = () => {
        // Commit form state to active state to trigger fetch
        setActiveFilters({ ...formState, page: 0 });
        setShowFilters(false);
    };

    const clearFilters = () => {
        const reset = { page: 0, size: 9, sort: 'name', category: '', search: '', minPrice: '', maxPrice: '' };
        setFormState(reset);
        setActiveFilters(reset);
    };

    return (
        <div>
            {/* Top Bar */}
            <div style={{ display: 'flex', gap: '1rem', marginBottom: '2rem', flexWrap: 'wrap', alignItems: 'center' }}>
                <button 
                    className="btn btn-secondary" 
                    onClick={() => setShowFilters(true)}
                    style={{ minWidth: '120px', display: 'flex', alignItems: 'center', gap: '8px', background: '#1e293b', color: 'white', border: 'none' }}
                >
                    <span style={{fontSize:'1.2rem'}}>☰</span> Filters
                </button>

                <input 
                    type="text" 
                    name="search" 
                    placeholder="Search products..." 
                    value={formState.search} 
                    onChange={(e) => {
                        // Update both for instant search effect, or remove setActiveFilters here if you want search on Apply only
                        setFormState({ ...formState, search: e.target.value });
                        setActiveFilters(prev => ({ ...prev, search: e.target.value, page: 0 }));
                    }}
                    style={{ flex: 1, maxWidth: '600px' }}
                />
            </div>

            {/* --- FILTER SIDEBAR (FIXED OVERLAY) --- */}
            {showFilters && (
                <div className="sidebar-overlay" onClick={() => setShowFilters(false)}>
                    <div className="sidebar-content" onClick={e => e.stopPropagation()}>
                        <div style={{display:'flex', justifyContent:'space-between', alignItems:'center', marginBottom:'2rem'}}>
                            <h2 style={{margin:0, color:'#0f172a'}}>Filters</h2>
                            <button onClick={() => setShowFilters(false)} style={{background:'none', border:'none', fontSize:'1.5rem', cursor:'pointer', color:'#64748b'}}>✕</button>
                        </div>

                        <div style={{ marginBottom: '1.5rem' }}>
                            <label style={{display:'block', marginBottom:'0.5rem', color:'#475569', fontWeight:'600', fontSize:'0.9rem'}}>Category</label>
                            <select name="category" value={formState.category} onChange={handleInputChange}>
                                <option value="">All Categories</option>
                                {categories.map(cat => (
                                    <option key={cat.id} value={cat.id}>{cat.name}</option>
                                ))}
                            </select>
                        </div>

                        <div style={{ marginBottom: '1.5rem' }}>
                            <label style={{display:'block', marginBottom:'0.5rem', color:'#475569', fontWeight:'600', fontSize:'0.9rem'}}>Price Range</label>
                            <div style={{display:'flex', gap:'0.8rem', alignItems:'center'}}>
                                <input 
                                    type="number" 
                                    name="minPrice" 
                                    placeholder="0" 
                                    value={formState.minPrice} 
                                    onChange={handleInputChange} 
                                />
                                <span style={{color: '#94a3b8'}}>-</span>
                                <input 
                                    type="number" 
                                    name="maxPrice" 
                                    placeholder="Any" 
                                    value={formState.maxPrice} 
                                    onChange={handleInputChange} 
                                />
                            </div>
                        </div>

                        <div style={{ marginBottom: '2rem' }}>
                            <label style={{display:'block', marginBottom:'0.5rem', color:'#475569', fontWeight:'600', fontSize:'0.9rem'}}>Sort By</label>
                            <select name="sort" value={formState.sort} onChange={handleInputChange}>
                                <option value="name">Name (A-Z)</option>
                                <option value="price_asc">Price: Low to High</option>
                                <option value="price_desc">Price: High to Low</option>
                            </select>
                        </div>
                        
                        <div style={{ display: 'grid', gap: '1rem' }}>
                            <button onClick={applyFilters} className="btn" style={{width:'100%'}}>Apply Filters</button>
                            <button onClick={clearFilters} className="btn btn-secondary" style={{width:'100%', background: 'white', color: '#0f172a'}}>Clear All</button>
                        </div>
                    </div>
                </div>
            )}

            {/* --- PRODUCT GRID --- */}
            <div className="product-grid">
                {products.length > 0 ? (
                    products.map(product => (
                        <div key={product.id} className="product-card">
                            <div style={{ padding: '1rem', background: 'white', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                                <img 
                                    src={product.imageUrl || 'https://via.placeholder.com/300?text=No+Image'} 
                                    alt={product.name} 
                                    className="product-image"
                                    style={{ border: 'none', maxHeight: '200px', width: 'auto' }}
                                />
                            </div>
                            <div className="card-body">
                                <h3>{product.name}</h3>
                                <p className="price">${product.price.toFixed(2)}</p>
                                <Link to={`/product/${product.id}`} className="btn" style={{marginTop:'auto', textAlign:'center'}}>
                                    View Details
                                </Link>
                            </div>
                        </div>
                    ))
                ) : (
                    <div style={{textAlign:'center', width:'100%', padding:'4rem', color:'#94a3b8', gridColumn: '1 / -1'}}>
                        <h2 style={{color:'white'}}>No products found</h2>
                        <p>Try adjusting your filters.</p>
                    </div>
                )}
            </div>

            {/* Pagination */}
            {totalPages > 1 && (
                <div style={{ display: 'flex', justifyContent: 'center', gap: '1rem', marginTop: '3rem', alignItems: 'center' }}>
                    <button 
                        className="btn btn-secondary" 
                        disabled={activeFilters.page === 0} 
                        onClick={() => setActiveFilters({...activeFilters, page: activeFilters.page - 1})}
                        style={{background: '#1e293b', color: 'white', border: 'none'}}
                    >
                        &lt; Previous
                    </button>
                    <span style={{color:'#94a3b8'}}>Page {activeFilters.page + 1} of {totalPages}</span>
                    <button 
                        className="btn btn-secondary" 
                        disabled={activeFilters.page >= totalPages - 1} 
                        onClick={() => setActiveFilters({...activeFilters, page: activeFilters.page + 1})}
                        style={{background: '#1e293b', color: 'white', border: 'none'}}
                    >
                        Next &gt;
                    </button>
                </div>
            )}
        </div>
    );
};

export default HomePage;