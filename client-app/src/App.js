import React from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './components/Navbar';
import HomePage from './components/Home';
import NutritionTable from './components/NutritionTable';

function App() {
    return (
        <Router>
            <div className="App">
                <Navbar />
                <div className="container mt-4">
                    <Routes>
                        <Route path="/" element={<HomePage />} />
                        <Route path="/nutrition" element={<NutritionTable />} /> {/* Nutrition page route */}
                    </Routes>
                </div>
            </div>
        </Router>
    );
}

export default App;