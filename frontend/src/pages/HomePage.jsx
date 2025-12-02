import { useState, useEffect } from 'react';
import { getProducts, getCategories } from '../services/productService';
import { Link } from 'react-router-dom';

const HomePage = () => {
    const [products, setProducts] = useState([]);
    const [categories, setCategories] = useState([]);
    const [totalPages, setTotalPages] = useState(0); // Store total pages
    const [filters, setFilters] = useState({
        page: 0,
        size: 8, // Reduced size for better grid look
        sort: 'name',
        category: '',
        search: ''
    });

    useEffect(() => {
        getCategories().then(setCategories);
    }, []);

    useEffect(() => {
        const params = { ...filters };
        if(!params.category) delete params.category;
        
        getProducts(params).then(data => {
            setProducts(data.content);
            setTotalPages(data.totalPages); // Backend returns this standard field
        });
    }, [filters]);

    const handleFilterChange = (e) => {
        // Reset to page 0 when filtering
        setFilters({ ...filters, [e.target.name]: e.target.value, page: 0 });
    };

    const handlePageChange = (newPage) => {
        if (newPage >= 0 && newPage < totalPages) {
            setFilters({ ...filters, page: newPage });
        }
    };

    return (
        <div>
            {/* Search and Filter Inputs */}
            <div style={{ marginBottom: '2rem', display: 'flex', gap: '1rem', flexWrap: 'wrap' }}>
                <input 
                    type="text" 
                    name="search" 
                    placeholder="Search products..." 
                    value={filters.search} 
                    onChange={handleFilterChange}
                    style={{ padding: '0.5rem', borderRadius: '4px', border: '1px solid #ccc', flex: 1 }}
                />
                
                <select 
                    name="category" 
                    value={filters.category} 
                    onChange={handleFilterChange}
                    style={{ padding: '0.5rem', borderRadius: '4px', border: '1px solid #ccc' }}
                >
                    <option value="">All Categories</option>
                    {categories.map(cat => (
                        <option key={cat.id} value={cat.id}>{cat.name}</option>
                    ))}
                </select>

                <select 
                    name="sort" 
                    value={filters.sort} 
                    onChange={handleFilterChange}
                    style={{ padding: '0.5rem', borderRadius: '4px', border: '1px solid #ccc' }}
                >
                    <option value="name">Sort by Name</option>
                    <option value="price_asc">Price: Low to High</option>
                    <option value="price_desc">Price: High to Low</option>
                </select>
            </div>
            
            {/* Product Grid */}
            <div className="product-grid">
               {products.length > 0 ? (
                   products.map(product => (
                       <div key={product.id} className="product-card">
                           <img 
                               src={product.imageUrl || 'https://via.placeholder.com/200'} 
                               alt={product.name} 
                               className="product-image" 
                           />
                           <div className="card-body">
                               <h3>{product.name}</h3>
                               <p className="price">${product.price.toFixed(2)}</p>
                               <Link to={`/product/${product.id}`} className="btn">
                                   View Details
                               </Link>
                           </div>
                       </div>
                   ))
               ) : (
                   <p>No products found.</p>
               )}
            </div>

            {/* Pagination Controls */}
            {totalPages > 1 && (
                <div style={{ display: 'flex', justifyContent: 'center', gap: '1rem', marginTop: '2rem', alignItems: 'center' }}>
                    <button 
                        className="btn btn-secondary" 
                        disabled={filters.page === 0}
                        onClick={() => handlePageChange(filters.page - 1)}
                    >
                        Previous
                    </button>
                    <span>Page {filters.page + 1} of {totalPages}</span>
                    <button 
                        className="btn btn-secondary" 
                        disabled={filters.page >= totalPages - 1}
                        onClick={() => handlePageChange(filters.page + 1)}
                    >
                        Next
                    </button>
                </div>
            )}
        </div>
    );
};

export default HomePage;