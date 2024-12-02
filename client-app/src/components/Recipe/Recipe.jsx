import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom'; // Import Link
import './Recipe.css';

function Recipe() {
    const [recipes, setRecipes] = useState([]);

    useEffect(() => {
        const fetchedRecipes = [
            {
                id: 1,
                name: "Spaghetti Carbonara",
                description: "A classic Italian pasta dish made with eggs, cheese, pancetta, and pepper.",
                imageURL: "images/RecipeImages/Spaghetti.jpg",
                cookingTime: 20,
            },
            {
                id: 2,
                name: "Chicken Curry",
                description: "A flavorful chicken curry with a variety of spices.",
                imageURL: "images/RecipeImages/chicken-dinner.jpg",
                cookingTime: 45,
            },
            {
                id: 3,
                name: "Grilled Cheese",
                description: "A simple but delicious grilled cheese sandwich.",
                imageURL: "images/RecipeImages/sallad.jpg",
                cookingTime: 10,
            },
        ];

        setRecipes(fetchedRecipes);
    }, []);

    return (
        <div className="container my-4">
            <h2 className="text-center mb-4">Our Collection of Recipes</h2>

            <div className="text-end mb-4">
                <Link to="/RecipeCreatePage" className="btn btn-primary">
                    <i className="bi bi-plus-lg"></i> Add Recipe+
                </Link>
            </div>

            <div className="row">
                {recipes.map((recipe) => (
                    <div key={recipe.id} className="col-lg-4 col-md-6 col-sm-12 mb-4">
                        <div className="card h-100 shadow-sm">
                            {recipe.imageURL && (
                                <img
                                    src={recipe.imageURL}
                                    className="card-img-top"
                                    alt={recipe.name}
                                    style={{ height: '200px', objectFit: 'cover' }}
                                />
                            )}
                            <div className="card-body d-flex flex-column">
                                <h5 className="card-title text-center">{recipe.name}</h5>
                                <p className="card-text">
                                    {recipe.description.length > 100
                                        ? `${recipe.description.substring(0, 100)}...`
                                        : recipe.description}
                                </p>
                                <div className="mt-auto">
                                    <span className="badge bg-primary">{recipe.cookingTime} min</span>
                                </div>
                            </div>
                            <div className="card-footer text-center">
                                {/* Update the "View" button to use the Link component */}
                                <Link to={`/recipe/${recipe.id}`} className="btn btn-info btn-sm mx-1">
                                    <i className="bi bi-eye"></i> View
                                </Link>

                                <Link to={`/RecipeUpdatePage/${recipe.id}`} className="btn btn-warning btn-sm mx-1">
                                    <i className="bi bi-pencil"></i> Edit
                                </Link>

                                <button className="btn btn-danger btn-sm mx-1">
                                    <i className="bi bi-trash"></i> Delete
                                </button>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default Recipe;
