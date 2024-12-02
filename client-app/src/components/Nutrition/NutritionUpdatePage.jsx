import React from 'react';
import './NutritionUpdatePage.css';

const NutritionUpdatePage = () => {
    return (
        <div className="nutrition-update-container">
            <h2 className="text-center">Update the Food Item</h2>

            <form className="nutrition-form">
                <input type="hidden" name="NutritionId" />

                <div className="form-group">
                    <label htmlFor="Name">Food Name:</label>
                    <input type="text" id="Name" name="Name" className="form-control" />
                </div>

                <div className="form-group">
                    <label htmlFor="FoodGroup">Food Group:</label>
                    <input type="text" id="FoodGroup" name="FoodGroup" className="form-control" />
                </div>

                <div className="form-group">
                    <label htmlFor="Calories">Calories:</label>
                    <input type="number" id="Calories" name="Calories" className="form-control" />
                </div>

                <div className="form-group">
                    <label htmlFor="Protein">Protein (g):</label>
                    <input type="number" id="Protein" name="Protein" className="form-control" />
                </div>

                <div className="form-group">
                    <label htmlFor="Fat">Fat (g):</label>
                    <input type="number" id="Fat" name="Fat" className="form-control" />
                </div>

                <div className="form-group">
                    <label htmlFor="Carbohydrates">Carbohydrates (g):</label>
                    <input type="number" id="Carbohydrates" name="Carbohydrates" className="form-control" />
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

export default NutritionUpdatePage;
