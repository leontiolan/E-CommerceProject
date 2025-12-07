import { useState, useEffect, useContext } from 'react';
import { getMyProfile, changePassword } from '../services/accountService';
import { getMyOrders, cancelOrder, confirmDelivery, getOrderDetails } from '../services/orderService'; 
import { AuthContext } from '../context/AuthContext';

const ProfilePage = () => {
    const { logout } = useContext(AuthContext);
    const [profile, setProfile] = useState(null);
    const [orders, setOrders] = useState([]);
    const [passData, setPassData] = useState({ current: '', new: '' });
    
    const [selectedOrder, setSelectedOrder] = useState(null);
    const [loadingDetails, setLoadingDetails] = useState(false);

    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    const loadData = async () => {
        try {
            setLoading(true);
            const p = await getMyProfile();
            setProfile(p);
            const o = await getMyOrders();
            setOrders(o);
            setError(null);
        } catch (err) {
            console.error(err);
            setError("Failed to load profile data. Please try again.");
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => { loadData(); }, []);

    const handlePassChange = async (e) => {
        e.preventDefault();
        try {
            await changePassword(passData.current, passData.new);
            alert("Password updated");
            setPassData({ current: '', new: '' });
        } catch (err) { alert("Failed to update password"); }
    };

    const handleCancel = async (id) => {
        if(confirm("Are you sure you want to cancel this order?")) {
            try {
                await cancelOrder(id);
                loadData(); 
            } catch(e) { alert(e.response?.data?.message || "Error cancelling"); }
        }
    };

    const handleConfirmReceived = async (id) => {
        if(confirm("Confirm that you have received this order?")) {
            try {
                await confirmDelivery(id);
                loadData(); 
            } catch(e) { 
                console.error(e);
                alert(e.response?.data?.message || "Error updating status"); 
            }
        }
    };

    const openOrderDetails = async (id) => {
        setLoadingDetails(true);
        try {
            const details = await getOrderDetails(id);
            setSelectedOrder(details);
        } catch (err) {
            alert("Failed to load order details.");
        } finally {
            setLoadingDetails(false);
        }
    };

    const getRowStyle = (status) => {
        switch (status) {
            case 'PENDING': return { background: '#e0f2fe' }; 
            case 'SHIPPED': return { background: '#fefce8' }; 
            case 'DELIVERED': return { background: '#dcfce7' };
            case 'CANCELLED': return { background: '#fee2e2' }; 
            default: return {};
        }
    };

    if (loading) return <p style={{ padding: '2rem', textAlign: 'center' }}>Loading profile...</p>;
    
    if (error) return (
        <div style={{ padding: '2rem', textAlign: 'center', color: '#ef4444' }}>
            <p>{error}</p>
            <button onClick={loadData} className="btn" style={{marginTop: '1rem'}}>Retry</button>
        </div>
    );

    if (!profile) return <p style={{ padding: '2rem', textAlign: 'center' }}>Profile not found.</p>;

    return (
        <div style={{ maxWidth: '900px', margin: '0 auto', display: 'grid', gap: '2rem' }}>
            
            {/* My Profile & Password Section */}
            <div className="panel" style={{ padding: '2rem', borderRadius: 'var(--radius)', boxShadow: 'var(--shadow-md)' }}>
                <h2>My Profile</h2>
                <p><strong>Username:</strong> {profile.username}</p>
                <p><strong>Email:</strong> {profile.email}</p>
                
                <hr style={{margin: '1.5rem 0', border: '0', borderTop: '1px solid #e2e8f0'}} />
                
                <h3>Change Password</h3>
                <form onSubmit={handlePassChange} style={{display:'flex', flexDirection: 'column', gap:'1rem', maxWidth:'400px'}}>
                    <div>
                        <label style={{display:'block', fontSize:'0.9rem', marginBottom:'5px'}}>Current Password</label>
                        <input type="password" value={passData.current} onChange={e => setPassData({...passData, current: e.target.value})} />
                    </div>
                    <div>
                        <label style={{display:'block', fontSize:'0.9rem', marginBottom:'5px'}}>New Password</label>
                        <input type="password" value={passData.new} onChange={e => setPassData({...passData, new: e.target.value})} />
                    </div>
                    <button type="submit" className="btn btn-secondary" style={{alignSelf: 'flex-start'}}>Update</button>
                </form>
            </div>

            {/* Order History Section */}
            <div className="panel" style={{ padding: '2rem', borderRadius: 'var(--radius)', boxShadow: 'var(--shadow-md)' }}>
                <h2>Order History</h2>
                {orders.length === 0 ? <p>No orders found.</p> : (
                    <table style={{ width: '100%', borderCollapse: 'collapse', marginTop: '1rem' }}>
                        <thead>
                            <tr style={{textAlign:'left', borderBottom:'2px solid #cbd5e1'}}>
                                <th style={{padding:'12px'}}>Order ID</th>
                                <th style={{padding:'12px'}}>Date</th>
                                <th style={{padding:'12px'}}>Total</th>
                                <th style={{padding:'12px'}}>Status</th>
                                <th style={{padding:'12px'}}>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            {orders.map(o => (
                                <tr key={o.id} style={{ borderBottom: '1px solid #e2e8f0', ...getRowStyle(o.status) }}>
                                    <td style={{padding:'12px'}}>#{o.id}</td>
                                    <td style={{padding:'12px'}}>{new Date(o.orderDate).toLocaleDateString()}</td>
                                    <td style={{padding:'12px', fontWeight:'bold'}}>${o.orderPrice.toFixed(2)}</td>
                                    <td style={{padding:'12px'}}>
                                        <span style={{
                                            padding:'4px 8px', borderRadius:'12px', fontSize:'0.85rem', fontWeight:'bold',
                                            color: '#0f172a', background: 'rgba(255,255,255,0.6)', border: '1px solid rgba(0,0,0,0.05)'
                                        }}>
                                            {o.status}
                                        </span>
                                    </td>
                                    <td style={{padding:'12px', display:'flex', gap:'8px', alignItems: 'center'}}>
                                        <button onClick={() => openOrderDetails(o.id)} className="btn btn-secondary" style={{padding:'5px 10px', fontSize:'0.8rem'}}>View</button>

                                        {o.status === 'PENDING' && (
                                            <button onClick={() => handleCancel(o.id)} className="btn btn-danger" style={{padding:'5px 10px', fontSize:'0.8rem'}}>Cancel</button>
                                        )}
                                        {o.status === 'SHIPPED' && (
                                            <button onClick={() => handleConfirmReceived(o.id)} className="btn btn-success" style={{padding:'5px 10px', fontSize:'0.8rem'}}>Received?</button>
                                        )}
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                )}
            </div>

            {/* --- Order Details Modal --- */}
            {selectedOrder && (
                <div className="modal-overlay" onClick={() => setSelectedOrder(null)}>
                    <div className="modal-content" onClick={e => e.stopPropagation()}>
                        <div style={{display:'flex', justifyContent:'space-between', alignItems:'center', marginBottom:'1.5rem'}}>
                            <h2 style={{margin:0}}>Order #{selectedOrder.id} Details</h2>
                            <button onClick={() => setSelectedOrder(null)} style={{background:'none', border:'none', fontSize:'1.5rem', cursor:'pointer'}}>✕</button>
                        </div>
                        
                        <p><strong>Date:</strong> {new Date(selectedOrder.orderDate).toLocaleString()}</p>
                        <p><strong>Status:</strong> {selectedOrder.status}</p>
                        <p><strong>Shipping Address:</strong> {selectedOrder.shippingAddress}</p>
                        
                        <h3 style={{marginTop:'1.5rem', borderBottom:'1px solid #eee', paddingBottom:'0.5rem'}}>Items</h3>
                        <div style={{maxHeight:'300px', overflowY:'auto'}}>
                            {selectedOrder.orderItems.map((item, idx) => (
                                <div key={idx} style={{display:'flex', justifyContent:'space-between', padding:'0.8rem 0', borderBottom:'1px solid #f8fafc'}}>
                                    <span>{item.productName} (x{item.quantity})</span>
                                    <strong>${(item.purchasePrice * item.quantity).toFixed(2)}</strong>
                                </div>
                            ))}
                        </div>
                        
                        <div style={{textAlign:'right', marginTop:'1.5rem', fontSize:'1.2rem'}}>
                            <strong>Total: ${selectedOrder.orderPrice.toFixed(2)}</strong>
                        </div>
                    </div>
                </div>
            )}
        </div>
    );
};

export default ProfilePage;