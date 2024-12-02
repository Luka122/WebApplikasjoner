import React from 'react';
import './RecipeUpdatePage.css';

const RecipeUpdatePage = () => {
    return (
        <div className="recipe-update-container">
            <h2 className="text-center">Edit Recipe</h2>

            <form className="recipe-form">
                <input type="hidden" name="RecipeId" />

                <div className="form-group">
                    <label htmlFor="Name">Recipe Name:</label>
                    <input type="text" id="Name" name="Name" className="form-control" />
                </div>

                <div className="form-group">
                    <label htmlFor="Description">Description:</label>
                    <textarea id="Description" name="Description" className="form-control"></textarea>
                </div>

                <div className="form-group">
                    <label htmlFor="CookingTime">Cooking Time:</label>
                    <input type="number" id="CookingTime" name="CookingTime" className="form-control" />
                </div>

                <div className="form-group">
                    <label htmlFor="Ingredients">Ingredients:</label>
                    <textarea id="Ingredients" name="Ingredients" className="form-control"></textarea>
                </div>

                <div className="form-group">
                    <label htmlFor="ImageURL">Image URL:</label>
                    <input type="text" id="ImageURL" name="ImageURL" className="form-control" />
                </div>

                <div className="form-buttons">
                    <button type="submit" className="btn btn-primary">Save</button>
                    <button type="button" className="btn btn-secondary">Cancel</button>
                </div>
            </form>
        </div>
    );
};

export default RecipeUpdatePage;
