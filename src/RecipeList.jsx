import React, { useState, useEffect } from 'react';

const RecipeList = () => {
  const [recipes, setRecipes] = useState([]);

  useEffect(() => {
    fetch('/Recipe/GetRecipes') // Assuming you have an API to get the recipes.
      .then(response => response.json())
      .then(data => setRecipes(data));
  }, []);

  return (
    <div className="container my-4">
      <h2 className="text-center mb-4">Our Collection of Recipes</h2>
      <div className="row">
        {recipes.map((recipe) => (
          <div key={recipe.recipeId} className="col-lg-4 col-md-6 col-sm-12 mb-4">
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
                    ? recipe.description.substring(0, 100) + '...'
                    : recipe.description}
                </p>
                <div className="mt-auto">
                  <span className="badge bg-primary">{recipe.cookingTime} min</span>
                </div>
              </div>
              <div className="card-footer text-center">
                <a href={`/Recipe/Details/${recipe.recipeId}`} className="btn btn-info btn-sm mx-1">
                  View
                </a>
                <a href={`/Recipe/Edit/${recipe.recipeId}`} className="btn btn-warning btn-sm mx-1">
                  Edit
                </a>
                <a href={`/Recipe/Delete/${recipe.recipeId}`} className="btn btn-danger btn-sm mx-1">
                  Delete
                </a>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default RecipeList;
