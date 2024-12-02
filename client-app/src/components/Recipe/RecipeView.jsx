import React from 'react';
import './RecipeView.css';

const RecipeView = ({ recipe }) => {
    return (
        <div className="container">
            <div className="card my-5">
                <div className="card-header text-center">
                    <h3>{recipe.name}</h3>
                </div>

                {recipe.imageURL && (
                    <img src={recipe.imageURL} className="card-img-top" alt={recipe.name} />
                )}

                <div className="card-body">
                    <h5 className="card-title">Description</h5>
                    <p className="card-text">{recipe.description}</p>

                    <h5 className="card-title">Cooking Time</h5>
                    <span className="badge bg-primary">{recipe.cookingTime} minutes</span>

                    <h5 className="card-title mt-4">Ingredients</h5>
                    <p className="card-text">{recipe.ingredients}</p>
                </div>

                <div className="card-footer text-center">
                    <button className="btn btn-secondary" onClick={() => window.history.back()}>Back to List</button>
                    <button className="btn btn-primary mx-1">Edit</button>
                    <button className="btn btn-danger mx-1">Delete</button>
                </div>
            </div>
        </div>
    );
};

// attempted edit and delete
/*
const handleEdit = (id) => {
    window.location.href = `/edit-recipe/${id}`;
};

const handleDelete = (id) => {
    if (window.confirm("Are you sure you want to delete this recipe?")) {
        // Call API to delete the recipe
        fetch(`/api/recipes/${id}`, { method: 'DELETE' })
            .then(response => {
                if (response.ok) {
                    window.location.href = '/recipes'; // Redirect after deletion
                } else {
                    alert('Failed to delete recipe');
                }
            })
            .catch(error => alert('Error deleting recipe'));
    };
*/
    export default RecipeView;
