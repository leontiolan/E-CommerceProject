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
            {/* ... Your existing Search/Filter Inputs ... */}
            
            <div className="product-grid">
               {/* ... Your existing Product mapping ... */}
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