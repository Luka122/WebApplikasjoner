import React from 'react';
import { Link } from 'react-router-dom';
import './NutritionTable.css';

// mock data
function NutritionTable() {
    const items = [
        {
            NutritionId: 1,
            Name: 'Apple',
            FoodGroup: 'Fruits',
            Carbohydrates: 25,
            Calories: 95,
            Protein: 0.5,
            Fat: 0.3,
            ImageURL: '/images/NutritionTableImages/apple.png',
        },
        {
            NutritionId: 2,
            Name: 'Chicken Breast',
            FoodGroup: 'Meats',
            Carbohydrates: 0,
            Calories: 165,
            Protein: 31,
            Fat: 3.6,
            ImageURL: '/images/NutritionTableImages/chicken.png',
        },
        {
            NutritionId: 3,
            Name: 'Broccoli',
            FoodGroup: 'Vegetables',
            Carbohydrates: 11,
            Calories: 55,
            Protein: 4,
            Fat: 0.6,
            ImageURL: '/images/NutritionTableImages/broccoli.png',
        },
        {
            NutritionId: 4,
            Name: 'Rice',
            FoodGroup: 'Grains',
            Carbohydrates: 45,
            Calories: 206,
            Protein: 4.3,
            Fat: 0.4,
            ImageURL: '/images/NutritionTableImages/rice.png',
        },
        {
            NutritionId: 5,
            Name: 'Almonds',
            FoodGroup: 'Nuts',
            Carbohydrates: 6,
            Calories: 164,
            Protein: 6,
            Fat: 14,
            ImageURL: '/images/NutritionTableImages/almonds.png',
        }
    ];

    return (
        <div>
            <h1 className="page-title">Nutrition Table</h1>
            <Link to="/NutritionCreatePage" className="btn btn-primary">
                Create New Entry
            </Link>
            <div className="container">
                <div className="row">
                    {items.map((item) => (
                        <div key={item.NutritionId} className="col-md-6 mb-3">
                            <div className="card">
                                <div className="row">
                                    <div className="col-md-8">
                                        <h5>{item.Name}, {item.FoodGroup}</h5>
                                    </div>
                                    <div className="col-md-4 text-end">
                                        <Link to={`/NutritionUpdatePage/${item.NutritionId}`}
                                              className="btn btn-secondary btn-sm">
                                            Edit
                                        </Link>
                                        <form action={`/nutrition/delete/${item.NutritionId}`} method="post"
                                              style={{display: 'inline'}}>
                                            <input type="hidden" name="id" value={item.NutritionId}/>
                                            <button type="submit" className="btn btn-danger btn-sm">Delete</button>
                                        </form>
                                    </div>
                                </div>
                                <hr/>
                                <div className="row">
                                    <div className="col-md-8">
                                        <div className="d-flex flex-column">
                                            <div className="d-flex mb-2">
                                                <p style={{marginBottom: 0, width: '50%'}}><strong>Carbohydrates
                                                    (g):</strong></p>
                                                <p style={{marginBottom: 0, maxWidth: '50%'}}>{item.Carbohydrates}</p>
                                            </div>
                                            <div className="d-flex mb-2">
                                                <p style={{marginBottom: 0, width: '50%'}}><strong>Calories
                                                    (kcal):</strong></p>
                                                <p style={{marginBottom: 0, maxWidth: '50%'}}>{item.Calories}</p>
                                            </div>
                                            <div className="d-flex mb-2">
                                                <p style={{marginBottom: 0, width: '50%'}}><strong>Protein (g):</strong>
                                                </p>
                                                <p style={{marginBottom: 0, maxWidth: '50%'}}>{item.Protein}</p>
                                            </div>
                                            <div className="d-flex mb-2">
                                                <p style={{marginBottom: 0, width: '50%'}}><strong>Fat (g):</strong></p>
                                                <p style={{marginBottom: 0, maxWidth: '50%'}}>{item.Fat}</p>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="col-md-4 text-center">
                                        <div className="image-wrapper">
                                            <img src={item.ImageURL} alt={item.Name} className="item-image"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
}

export default NutritionTable;
