import { useState, useEffect, useContext } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getProductById } from '../services/productService';
import { addToCart } from '../services/cartService';
import { getReviews, createReview } from '../services/reviewService.js';
import { AuthContext } from '../context/AuthContext';

const ProductDetailsPage = () => {
    const { id } = useParams();
    const { user } = useContext(AuthContext);
    const navigate = useNavigate();
    
    const [product, setProduct] = useState(null);
    const [reviews, setReviews] = useState([]);
    const [newReview, setNewReview] = useState({ rating: 5, comment: '' });
    
    const [quantity, setQuantity] = useState(1);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        setLoading(true);
        Promise.all([getProductById(id), getReviews(id)])
            .then(([prodData, reviewData]) => {
                setProduct(prodData);
                setReviews(reviewData);
                setLoading(false);
            })
            .catch(err => console.error(err));
    }, [id]);

    const handleAddToCart = async () => {
        if (!user) return navigate('/login');
        try {
            await addToCart(product.id, parseInt(quantity));
            alert('Added to cart!');
        } catch (error) {
            alert('Failed to add to cart.');
        }
    };

    const handlePostReview = async (e) => {
        e.preventDefault();
        try {
            await createReview(product.id, newReview.rating, newReview.comment);
            const updatedReviews = await getReviews(product.id);
            setReviews(updatedReviews);
            setNewReview({ rating: 5, comment: '' });
        } catch (error) {
            alert(error.response?.data?.message || "Failed to post review. Have you bought this item?");
        }
    };

    if (loading) return <p style={{textAlign:'center', marginTop:'2rem'}}>Loading details...</p>;
    if (!product) return <p>Product not found.</p>;

    return (
        <div style={{ maxWidth: '1000px', margin: '0 auto' }}>
            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '3rem', background: 'white', padding: '2rem', borderRadius: 'var(--radius)', boxShadow: 'var(--shadow-md)' }}>
                <div>
                    {product.imageURLs && product.imageURLs.length > 0 ? (
                        <img src={product.imageURLs[0]} alt={product.name} style={{ width: '100%', borderRadius: 'var(--radius)' }} />
                    ) : (
                        <div style={{ width: '100%', height: '350px', background: '#f1f5f9', display: 'flex', alignItems: 'center', justifyContent: 'center', borderRadius: 'var(--radius)' }}>No Image</div>
                    )}
                </div>
                
                <div>
                    <h1 style={{marginTop: 0}}>{product.name}</h1>
                    <p style={{ fontSize: '1.5rem', fontWeight: 'bold', color: 'var(--primary-color)' }}>${product.price.toFixed(2)}</p>
                    <p style={{color: '#64748b'}}>Category: {product.category?.name}</p>
                    <p style={{lineHeight: '1.6'}}>{product.description}</p>
                    
                    <div style={{ margin: '2rem 0' }}>
                        <label style={{display:'block', marginBottom:'0.5rem', fontWeight:'500'}}>Quantity</label>
                        <input 
                            type="number" min="1" max={product.stockQuantity} value={quantity} 
                            onChange={(e) => setQuantity(e.target.value)}
                            style={{ padding: '0.5rem', width: '80px', marginRight: '1rem', borderRadius: '0.5rem', border:'1px solid #cbd5e1' }}
                        />
                        <button onClick={handleAddToCart} className="btn" disabled={product.stockQuantity <= 0}>
                            {product.stockQuantity > 0 ? 'Add to Cart' : 'Out of Stock'}
                        </button>
                    </div>
                </div>
            </div>

            {/* Reviews Section */}
            <div style={{ marginTop: '2rem', background: 'white', padding: '2rem', borderRadius: 'var(--radius)', boxShadow: 'var(--shadow-md)' }}>
                <h2>Reviews ({reviews.length})</h2>
                
                <div style={{ marginBottom: '2rem', maxHeight: '300px', overflowY: 'auto' }}>
                    {reviews.length === 0 && <p style={{color:'#64748b'}}>No reviews yet.</p>}
                    {reviews.map(r => (
                        <div key={r.id} style={{ borderBottom: '1px solid #e2e8f0', padding: '1rem 0' }}>
                            <div style={{display:'flex', justifyContent:'space-between'}}>
                                <strong>{r.username}</strong>
                                <span style={{color: '#eab308'}}>★ {r.rating}/10</span>
                            </div>
                            <p style={{margin: '0.5rem 0', color: '#334155'}}>{r.comment}</p>
                        </div>
                    ))}
                </div>

                {user && (
                    <form onSubmit={handlePostReview} style={{ borderTop: '1px solid #e2e8f0', paddingTop: '1.5rem' }}>
                        <h3>Write a Review</h3>
                        <div style={{ display: 'grid', gap: '1rem' }}>
                            <div>
                                <label style={{marginRight: '1rem'}}>Rating (1-10)</label>
                                <input type="number" min="1" max="10" value={newReview.rating} onChange={e => setNewReview({...newReview, rating: e.target.value})} style={{padding:'0.5rem', width:'60px'}} />
                            </div>
                            <textarea 
                                rows="3" 
                                placeholder="Your experience..." 
                                value={newReview.comment} 
                                onChange={e => setNewReview({...newReview, comment: e.target.value})}
                                style={{ width: '100%', padding: '0.8rem', borderRadius: '0.5rem', border: '1px solid #cbd5e1' }}
                            />
                            <button type="submit" className="btn btn-secondary" style={{justifySelf: 'start'}}>Post Review</button>
                        </div>
                    </form>
                )}
            </div>
        </div>
    );
};

export default ProductDetailsPage;