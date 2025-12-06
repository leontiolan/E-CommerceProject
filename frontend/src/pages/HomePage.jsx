import { useState, useEffect } from 'react';
import { getProducts, getCategories } from '../services/productService';
import { Link, useSearchParams } from 'react-router-dom';

const HomePage = () => {
    const [products, setProducts] = useState([]);
    const [categories, setCategories] = useState([]);
    const [totalPages, setTotalPages] = useState(0);
    const [showFilters, setShowFilters] = useState(false);
    const [showFloatingFilter, setShowFloatingFilter] = useState(false);

    // --- URL Search Params ---
    const [searchParams, setSearchParams] = useSearchParams();
    const urlSearchQuery = searchParams.get('search') || '';

    // API State
    const [activeFilters, setActiveFilters] = useState({
        page: 0,
        size: 12,
        sort: 'name',
        category: '',
        search: urlSearchQuery,
        minPrice: '',
        maxPrice: ''
    });

    // Form UI State
    const [formState, setFormState] = useState({ ...activeFilters });

    // 1. Fetch Categories
    useEffect(() => {
        getCategories().then(setCategories);
    }, []);

    // 2. Handle Scroll
    useEffect(() => {
        const handleScroll = () => {
            if (window.scrollY > 150) setShowFloatingFilter(true);
            else setShowFloatingFilter(false);
        };
        window.addEventListener('scroll', handleScroll);
        return () => window.removeEventListener('scroll', handleScroll);
    }, []);

    // 3. Sync URL Search
    useEffect(() => {
        if (activeFilters.search !== urlSearchQuery) {
            setActiveFilters(prev => ({ ...prev, search: urlSearchQuery, page: 0 }));
        }
    }, [urlSearchQuery]);

    // 4. Fetch Products
    useEffect(() => {
        const params = { ...activeFilters };
        if (!params.category) delete params.category;
        if (!params.minPrice) delete params.minPrice;
        if (!params.maxPrice) delete params.maxPrice;
        if (!params.search) delete params.search;

        getProducts(params).then(data => {
            setProducts(data.content);
            setTotalPages(data.totalPages);
        }).catch(err => console.error("Error fetching products:", err));
    }, [activeFilters]); 

    const handleInputChange = (e) => {
        setFormState({ ...formState, [e.target.name]: e.target.value });
    };

    const applyFilters = () => {
        setActiveFilters({ ...formState, page: 0 });
        setShowFilters(false);
    };

    const clearFilters = () => {
        const reset = { page: 0, size: 12, sort: 'name', category: '', search: '', minPrice: '', maxPrice: '' };
        setFormState(reset);
        setActiveFilters(reset);
        setSearchParams({});
    };

    return (
        <div>
            {/* --- Top Bar --- */}
            <div style={{ display: 'flex', justifyContent: 'flex-start', marginBottom: '2rem' }}>
                <button 
                    className="btn btn-secondary" 
                    onClick={() => setShowFilters(true)}
                    style={{ minWidth: '120px', display: 'flex', alignItems: 'center', gap: '8px', background: '#1e293b', color: 'white', border: 'none' }}
                >
                    <span style={{fontSize:'1.2rem'}}>☰</span> Filters
                </button>
            </div>

            {/* --- Floating Filter Button --- */}
            {showFloatingFilter && (
                <button 
                    className="btn floating-filter-btn"
                    onClick={() => setShowFilters(true)}
                >
                    ☰ Filters
                </button>
            )}

            {/* --- FILTER SIDEBAR --- */}
            {showFilters && (
                <div className="sidebar-overlay" onClick={() => setShowFilters(false)}>
                    <div className="sidebar-content" onClick={e => e.stopPropagation()}>
                        <div style={{display:'flex', justifyContent:'space-between', alignItems:'center', marginBottom:'2rem'}}>
                            <h2 style={{margin:0, color:'#0f172a'}}>Filters</h2>
                            <button onClick={() => setShowFilters(false)} style={{background:'none', border:'none', fontSize:'1.5rem', cursor:'pointer', color:'#64748b'}}>✕</button>
                        </div>

                        <div className="filter-group">
                            <label>Category</label>
                            <div className="custom-select-wrapper">
                                <select name="category" value={formState.category} onChange={handleInputChange}>
                                    <option value="">All Categories</option>
                                    {categories.map(cat => (
                                        <option key={cat.id} value={cat.id}>{cat.name}</option>
                                    ))}
                                </select>
                            </div>
                        </div>

                        <div className="filter-group">
                            <label>Price Range</label>
                            <div style={{display:'flex', gap:'0.8rem', alignItems:'center'}}>
                                <input type="number" name="minPrice" placeholder="Min" value={formState.minPrice} onChange={handleInputChange} />
                                <span style={{color: '#94a3b8'}}>-</span>
                                <input type="number" name="maxPrice" placeholder="Max" value={formState.maxPrice} onChange={handleInputChange} />
                            </div>
                        </div>

                        <div className="filter-group">
                            <label>Sort By</label>
                            <div className="custom-select-wrapper">
                                <select name="sort" value={formState.sort} onChange={handleInputChange}>
                                    <option value="name">Name (A-Z)</option>
                                    <option value="name_desc">Name (Z-A)</option> 
                                    <option value="price_asc">Price: Low to High</option>
                                    <option value="price_desc">Price: High to Low</option>
                                </select>
                            </div>
                        </div>
                        
                        <div style={{ display: 'grid', gap: '1rem', marginTop: 'auto' }}>
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
                        <Link to={`/product/${product.id}`} key={product.id} style={{textDecoration: 'none', color: 'inherit'}}>
                            <div className="product-card">
                                <div style={{ padding: '1rem', background: 'white', display: 'flex', justifyContent: 'center', alignItems: 'center', height: '220px' }}>
                                    <img src={product.imageUrl || 'https://via.placeholder.com/300?text=No+Image'} alt={product.name} className="product-image" />
                                </div>
                                <div className="card-body">
                                    <h3>{product.name}</h3>
                                    <p className="price">${product.price.toFixed(2)}</p>
                                </div>
                            </div>
                        </Link>
                    ))
                ) : (
                    /* --- Empty State --- */
                    <div style={{textAlign:'center', width:'100%', padding:'4rem', color:'#94a3b8', gridColumn: '1 / -1'}}>
                        <h2 style={{color: 'var(--text-inverse)', marginBottom: '1rem'}}>No products found</h2>
                        <p>Try adjusting your search or filters.</p>
                    </div>
                )}
            </div>

            {/* Pagination Controls */}
            {totalPages > 1 && (
                <div style={{ display: 'flex', justifyContent: 'center', gap: '1rem', marginTop: '3rem', alignItems: 'center' }}>
                    <button className="btn btn-secondary" disabled={activeFilters.page === 0} onClick={() => setActiveFilters({...activeFilters, page: activeFilters.page - 1})} style={{background: '#1e293b', color: 'white', border: 'none'}}>&lt; Previous</button>
                    <span style={{color:'#94a3b8'}}>Page {activeFilters.page + 1} of {totalPages}</span>
                    <button className="btn btn-secondary" disabled={activeFilters.page >= totalPages - 1} onClick={() => setActiveFilters({...activeFilters, page: activeFilters.page + 1})} style={{background: '#1e293b', color: 'white', border: 'none'}}>Next &gt;</button>
                </div>
            )}
        </div>
    );
};

export default HomePage;