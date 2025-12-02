import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { getCart, removeFromCart, checkout } from '../services/cartService';

const CartPage = () => {
    const [cart, setCart] = useState(null);
    const [address, setAddress] = useState('');
    const navigate = useNavigate();

    const fetchCart = () => {
        getCart().then(setCart).catch(err => console.error(err));
    };

    useEffect(() => {
        fetchCart();
    }, []);

    const handleRemove = async (itemId) => {
        await removeFromCart(itemId);
        fetchCart();
    };

    const handleCheckout = async () => {
        if (!address.trim()) return alert("Please enter a shipping address");
        
        try {
            // 1. Send checkout request to backend
            const orderData = await checkout(address);
            
            // 2. Navigate to the Success Page with the new order data
            navigate('/order-success', { state: { order: orderData } });
            
        } catch (error) {
            console.error("Checkout Error:", error);
            alert("Failed to place order: " + (error.response?.data?.message || "Unknown error"));
        }
    };

    if (!cart || !cart.cartItemDetailsDTOList || cart.cartItemDetailsDTOList.length === 0) {
        return (
            <div className="form-container" style={{ textAlign: 'center', marginTop: '50px' }}>
                <h2>Your cart is empty.</h2>
            </div>
        );
    }

    return (
        <div className="form-container" style={{ maxWidth: '800px' }}>
            <h2>Shopping Cart</h2>
            {cart.cartItemDetailsDTOList.map(item => (
                <div key={item.cartItemId} className="cart-item">
                    <div>
                        <h4>{item.productName}</h4>
                        <p>Quantity: {item.quantity} x ${item.productPrice.toFixed(2)}</p>
                    </div>
                    <div>
                        <p><strong>${(item.quantity * item.productPrice).toFixed(2)}</strong></p>
                        <button onClick={() => handleRemove(item.cartItemId)} className="btn btn-danger">Remove</button>
                    </div>
                </div>
            ))}
            
            <div style={{ marginTop: '20px', textAlign: 'right' }}>
                <h3>Total: ${cart.totalCartPrice.toFixed(2)}</h3>
            </div>

            <div style={{ marginTop: '30px', borderTop: '1px solid #ccc', paddingTop: '20px' }}>
                <h3>Checkout</h3>
                <div className="form-group">
                    <label>Shipping Address</label>
                    <textarea 
                        rows="3" 
                        value={address} 
                        onChange={(e) => setAddress(e.target.value)}
                        placeholder="Enter full shipping address..."
                        style={{ width: '100%', padding: '10px', borderRadius: '4px', border: '1px solid #ccc' }}
                    ></textarea>
                </div>
                <button onClick={handleCheckout} className="btn btn-success" style={{ width: '100%' }}>
                    Confirm Order
                </button>
            </div>
        </div>
    );
};

export default CartPage;