import { useState, useEffect, useContext } from 'react';
import { getMyProfile, changePassword } from '../services/accountService';
import { getMyOrders, cancelOrder } from '../services/orderService';
import { AuthContext } from '../context/AuthContext';

const ProfilePage = () => {
    const { logout } = useContext(AuthContext);
    const [profile, setProfile] = useState(null);
    const [orders, setOrders] = useState([]);
    const [passData, setPassData] = useState({ current: '', new: '' });

    const loadData = async () => {
        const p = await getMyProfile();
        setProfile(p);
        const o = await getMyOrders();
        setOrders(o);
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
                loadData(); // Refresh list
            } catch(e) { alert(e.response?.data?.message || "Error cancelling"); }
        }
    };

    if (!profile) return <p>Loading...</p>;

    return (
        <div style={{ maxWidth: '900px', margin: '0 auto', display: 'grid', gap: '2rem' }}>
            <div style={{ background: 'white', padding: '2rem', borderRadius: 'var(--radius)', boxShadow: 'var(--shadow-md)' }}>
                <h2>My Profile</h2>
                <p><strong>Username:</strong> {profile.username}</p>
                <p><strong>Email:</strong> {profile.email}</p>
                
                <hr style={{margin: '1.5rem 0', border: '0', borderTop: '1px solid #e2e8f0'}} />
                
                <h3>Change Password</h3>
                <form onSubmit={handlePassChange} style={{display:'flex', gap:'1rem', alignItems:'flex-end'}}>
                    <div style={{flex:1}}>
                        <label style={{display:'block', fontSize:'0.9rem', marginBottom:'5px'}}>Current Password</label>
                        <input type="password" value={passData.current} onChange={e => setPassData({...passData, current: e.target.value})} style={{width:'100%', padding:'8px', borderRadius:'6px', border:'1px solid #ccc'}} />
                    </div>
                    <div style={{flex:1}}>
                        <label style={{display:'block', fontSize:'0.9rem', marginBottom:'5px'}}>New Password</label>
                        <input type="password" value={passData.new} onChange={e => setPassData({...passData, new: e.target.value})} style={{width:'100%', padding:'8px', borderRadius:'6px', border:'1px solid #ccc'}} />
                    </div>
                    <button type="submit" className="btn btn-secondary">Update</button>
                </form>
            </div>

            <div style={{ background: 'white', padding: '2rem', borderRadius: 'var(--radius)', boxShadow: 'var(--shadow-md)' }}>
                <h2>Order History</h2>
                {orders.length === 0 ? <p>No orders found.</p> : (
                    <table style={{ width: '100%', borderCollapse: 'collapse', marginTop: '1rem' }}>
                        <thead>
                            <tr style={{textAlign:'left', borderBottom:'2px solid #f1f5f9'}}>
                                <th style={{padding:'10px'}}>Order ID</th>
                                <th style={{padding:'10px'}}>Date</th>
                                <th style={{padding:'10px'}}>Total</th>
                                <th style={{padding:'10px'}}>Status</th>
                                <th style={{padding:'10px'}}>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            {orders.map(o => (
                                <tr key={o.id} style={{borderBottom:'1px solid #f1f5f9'}}>
                                    <td style={{padding:'10px'}}>#{o.id}</td>
                                    <td style={{padding:'10px'}}>{new Date(o.orderDate).toLocaleDateString()}</td>
                                    <td style={{padding:'10px', fontWeight:'bold'}}>${o.orderPrice.toFixed(2)}</td>
                                    <td style={{padding:'10px'}}>
                                        <span style={{
                                            padding:'4px 8px', borderRadius:'12px', fontSize:'0.85rem', fontWeight:'bold',
                                            background: o.status === 'DELIVERED' ? '#dcfce7' : o.status === 'CANCELLED' ? '#fee2e2' : '#e0f2fe',
                                            color: o.status === 'DELIVERED' ? '#166534' : o.status === 'CANCELLED' ? '#991b1b' : '#075985'
                                        }}>
                                            {o.status}
                                        </span>
                                    </td>
                                    <td style={{padding:'10px'}}>
                                        {o.status === 'PENDING' && (
                                            <button onClick={() => handleCancel(o.id)} className="btn btn-danger" style={{padding:'5px 10px', fontSize:'0.8rem'}}>Cancel</button>
                                        )}
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                )}
            </div>
        </div>
    );
};

export default ProfilePage;