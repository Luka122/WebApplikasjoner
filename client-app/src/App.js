import React from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

// Components
import Navbar from './components/Navbar';

// Home
import HomePage from './components/Home/Home';

// Nutrition
import NutritionTable from './components/Nutrition/NutritionTable';
import NutritionCreatePage from './components/Nutrition/NutritionCreatePage';
import NutritionUpdatePage from "./components/Nutrition/NutritionUpdatePage";

// Recipe
import Recipe from './components/Recipe/Recipe';
import RecipeCreatePage from './components/Recipe/RecipeCreatePage';
import RecipeUpdatePage from "./components/Recipe/RecipeUpdatePage";
import RecipeView from './components/Recipe/RecipeView';

function App() {
    return (
        <Router>
            <div className="App">
                <Navbar />
                <div className="container mt-4">
                    <Routes>
                        <Route path="/" element={<HomePage />} />
                        <Route path="/nutrition" element={<NutritionTable />} />
                        <Route path="/NutritionCreatePage" element={<NutritionCreatePage />} />
                        <Route path="/NutritionUpdatePage/:id" element={<NutritionUpdatePage />} />

                        <Route path="/recipe" element={<Recipe />} />
                        <Route path="/RecipeCreatePage" element={<RecipeCreatePage />} />
                        <Route path="/RecipeUpdatePage/:id" element={<RecipeUpdatePage />} />

                        <Route path="/RecipeView" element={<RecipeView />} />
                        <Route path="/recipe/:id" element={<RecipeView />} />
                    </Routes>
                </div>
            </div>
        </Router>
    );
}

export default App;
