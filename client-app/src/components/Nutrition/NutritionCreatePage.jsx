import React from 'react';
import './NutritionCreatePage.css';

const NutritionCreatePage = () => {
    return (
        <div className="nutrition-create-container">
            <h1>Create a New Nutrition Entry</h1>
            <form>
                <div className="form-group">
                    <label htmlFor="Name">Name:</label>
                    <input type="text" id="Name" name="Name" className="form-control" required />
                </div>

                <div className="form-group">
                    <label htmlFor="FoodGroup">Food Group:</label>
                    <input type="text" id="FoodGroup" name="FoodGroup" className="form-control" required />
                </div>

                <div className="form-group">
                    <label htmlFor="Calories">Calories:</label>
                    <input type="number" id="Calories" name="Calories" className="form-control" required />
                </div>

                <div className="form-group">
                    <label htmlFor="Protein">Protein (g):</label>
                    <input type="number" step="0.01" id="Protein" name="Protein" className="form-control" required />
                </div>

                <div className="form-group">
                    <label htmlFor="Fat">Fat (g):</label>
                    <input type="number" step="0.01" id="Fat" name="Fat" className="form-control" required />
                </div>

                <div className="form-group">
                    <label htmlFor="Carbohydrates">Carbohydrates (g):</label>
                    <input type="number" step="0.01" id="Carbohydrates" name="Carbohydrates" className="form-control" required />
                </div>
                
                <div className="form-group">
                    <label htmlFor="ImageURL">Image URL:</label>
                    <input type="text" id="ImageURL" name="ImageURL" className="form-control" required />
                </div>
                
                <div className="form-buttons">
                    <button type="submit" className="btn btn-primary">Create Entry</button>
                    <button type="button" className="btn btn-secondary">Cancel</button>
                </div>
            </form>
        </div>
    );
};

export default NutritionCreatePage;
