import { useLocation, Link } from 'react-router-dom';

const OrderSuccessPage = () => {
    const location = useLocation();
    const { order } = location.state || {};

    if (!order) return (
        <div className="form-container" style={{textAlign:'center'}}>
            <h2>No Order Found</h2>
            <Link to="/" className="btn">Go Home</Link>
        </div>
    );

    return (
        <div className="form-container" style={{textAlign:'center', maxWidth:'600px'}}>
            <div style={{color: '#22c55e', fontSize: '4rem', marginBottom:'1rem'}}>✓</div>
            <h1>Order Confirmed!</h1>
            <p style={{fontSize:'1.2rem', color:'#64748b'}}>Thank you for your purchase.</p>
            
            <div style={{background:'#f8fafc', padding:'1.5rem', borderRadius:'0.5rem', margin:'2rem 0', textAlign:'left'}}>
                <p><strong>Order ID:</strong> #{order.id}</p>
                <p><strong>Status:</strong> <span style={{color:'#2563eb', fontWeight:'bold'}}>{order.status}</span></p>
                <p><strong>Total Amount:</strong> ${order.orderPrice.toFixed(2)}</p>
                <p><strong>Date:</strong> {new Date(order.orderDate).toLocaleDateString()}</p>
            </div>

            <div style={{display:'flex', gap:'1rem', justifyContent:'center'}}>
                <Link to="/profile" className="btn btn-secondary">View Order History</Link>
                <Link to="/" className="btn">Continue Shopping</Link>
            </div>
        </div>
    );
};

export default OrderSuccessPage;