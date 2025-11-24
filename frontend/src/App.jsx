import { useState, useEffect } from 'react';
import { getProducts } from './services/productService';
import './App.css';

function App() {
  const [products, setProducts] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    // Fetch products when component mounts
    getProducts()
      .then(data => {
        console.log("Data received from backend:", data);
        setProducts(data);
      })
      .catch(err => {
        setError("Failed to connect to server. Is Backend running on port 8083?");
      });
  }, []);

  return (
    <div className="App">
      <h1>E-Commerce Store</h1>

      {error && <p style={{color: 'red'}}>{error}</p>}

      <div className="product-grid">
        {products.length === 0 && !error ? <p>Loading products...</p> : null}

        {products.map(product => (
          <div key={product.id} style={{border: '1px solid #ccc', margin: '10px', padding: '10px'}}>
            <h3>{product.name}</h3>
            <p>{product.description}</p>
            <p><strong>${product.price}</strong></p>
          </div>
        ))}
      </div>
    </div>
  );
}

export default App;