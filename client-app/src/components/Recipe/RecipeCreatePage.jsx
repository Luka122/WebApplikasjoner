import React from 'react';
import './RecipeCreatePage.css';

const RecipeCreatePage = () => {
    return (
        <div className="recipe-create-page-container">
            <h2 className="text-center">Add Recipe</h2>
            <form>
                <div className="form-group">
                    <label htmlFor="Name">Recipe Name:</label>
                    <input type="text" id="Name" name="Name" className="form-control" placeholder="Enter recipe name" required />
                    <span className="text-danger"></span>
                </div>

                <div className="form-group">
                    <label htmlFor="Description">Description:</label>
                    <textarea id="Description" name="Description" className="form-control" rows="3" placeholder="Enter description of the recipe" required></textarea>
                    <span className="text-danger"></span>
                </div>

                <div className="form-group">
                    <label htmlFor="CookingTime">Cooking Time (minutes):</label>
                    <input type="number" id="CookingTime" name="CookingTime" className="form-control" placeholder="Enter cooking time in minutes" required />
                    <span className="text-danger"></span>
                </div>

                <div className="form-group">
                    <label htmlFor="Ingredients">Ingredients:</label>
                    <textarea id="Ingredients" name="Ingredients" className="form-control" rows="3" placeholder="Enter ingredients, separated by commas" required></textarea>
                    <span className="text-danger"></span>
                </div>

                <div className="form-group">
                    <label htmlFor="ImageURL">Image URL (optional):</label>
                    <input type="text" id="ImageURL" name="ImageURL" className="form-control" placeholder="Optional: Enter an image URL for the recipe" />
                    <span className="text-danger"></span>
                </div>

                <div className="form-buttons">
                    <button type="submit" className="btn btn-success mt-3">Save Recipe</button>
                    <button type="button" className="btn btn-secondary mt-3">Cancel</button>
                </div>
            </form>
        </div>
    );
};

export default RecipeCreatePage;
