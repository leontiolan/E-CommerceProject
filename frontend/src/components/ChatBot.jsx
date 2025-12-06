import { useState } from 'react';
// Change the import to use the new service
import { getChatResponse } from '../services/chatService'; 

const ChatBot = () => {
    const [isOpen, setIsOpen] = useState(false);
    const [messages, setMessages] = useState([{ sender: 'bot', text: 'Hi! How can I help you today?' }]);
    const [input, setInput] = useState('');

    const sendMessage = async () => {
        if (!input.trim()) return;
        const userMsg = { sender: 'user', text: input };
        setMessages(prev => [...prev, userMsg]);
        setInput('');

        try {
            // Use the service function
            const data = await getChatResponse(input);
            setMessages(prev => [...prev, { sender: 'bot', text: data.response }]); // Backend returns { response: "..." }
        } catch (error) {
            console.error("Chat Error:", error);
            setMessages(prev => [...prev, { sender: 'bot', text: 'Sorry, I am having trouble connecting.' }]);
        }
    };

    return (
        <div className="chatbot-container">
            {isOpen && (
                <div className="chat-window">
                    <div style={{padding:'10px', background:'#2563eb', color:'white', fontWeight:'bold', display:'flex', justifyContent:'space-between'}}>
                        <span>AI Assistant</span>
                        <button onClick={() => setIsOpen(false)} style={{background:'transparent', border:'none', color:'white', cursor:'pointer'}}>X</button>
                    </div>
                    <div className="chat-messages">
                        {messages.map((msg, idx) => (
                            <div key={idx} className={`message ${msg.sender}`}>
                                {msg.text}
                            </div>
                        ))}
                    </div>
                    <div className="chat-input-area">
                        <input 
                            value={input} 
                            onChange={e => setInput(e.target.value)} 
                            onKeyPress={e => e.key === 'Enter' && sendMessage()}
                            placeholder="Ask something..."
                            style={{border:'none', flex:1, outline:'none'}}
                        />
                        <button onClick={sendMessage} style={{border:'none', background:'transparent', color:'#2563eb', fontWeight:'bold', cursor:'pointer'}}>Send</button>
                    </div>
                </div>
            )}
            {!isOpen && (
                <button onClick={() => setIsOpen(true)} className="btn" style={{borderRadius: '50%', width: '60px', height: '60px', fontSize:'1.5rem', boxShadow: '0 4px 6px rgba(0,0,0,0.1)'}}>
                    💬
                </button>
            )}
        </div>
    );
};

export default ChatBot;