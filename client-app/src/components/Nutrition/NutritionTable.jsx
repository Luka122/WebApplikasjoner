import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import './NutritionTable.css';

const API_URL = 'http://localhost:5029'

const NutritionTable = () => {
    const [entries, setEntries] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const fetchEntries = async () => {
        setLoading(true);
        setError(null);

        try {
            const response = await fetch(`${API_URL}/api/NutritionAPI/Entries`);

            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            
            const data = await response.json();
            console.log(data);
            setEntries(data);
        } catch (error) {
            console.error(`There was a problem fetching entries: ${error.message}`);
            setError('Failed to fetch items.');
        } finally {
            setLoading(false);
        }
    };
    useEffect(() => {
        fetchEntries();
    }, []);

    return (
        <div>
            <h1 className="page-title">Nutrition Table</h1>
            <Link to="/NutritionCreatePage" className="btn btn-primary">
                Create New Entry
            </Link>
            <div className="container">
                {loading && <p>Loading entries...</p>}
                {error && <p className="error">{error}</p>}
                <div className="row">
                    {!loading && !error && entries.map((item) => (

                        <div key={item.nutritionId} className="col-md-6 mb-3">
                            <div className="card">
                                <div className="row">
                                    <div className="col-md-8">
                                        <h5>{item.name}, {item.foodGroup}</h5>
                                    </div>
                                    <div className="col-md-4 text-end">
                                        <Link to={`/NutritionUpdatePage/${item.nutritionId}`}
                                              className="btn btn-secondary btn-sm">
                                            Edit
                                        </Link>
                                        <form action={`/nutrition/delete/${item.nutritionId}`} method="post"
                                              style={{ display: 'inline' }}>
                                            <input type="hidden" name="id" value={item.nutritionId} />
                                            <button type="submit" className="btn btn-danger btn-sm">Delete</button>
                                        </form>
                                    </div>
                                </div>
                                <hr />
                                <div className="row">
                                    <div className="col-md-8">
                                        <div className="d-flex flex-column">
                                            <div className="d-flex mb-2">
                                                <p style={{ marginBottom: 0, width: '50%' }}>
                                                    <strong>Carbohydrates (g):</strong>
                                                </p>
                                                <p style={{ marginBottom: 0, maxWidth: '50%' }}>
                                                    {item.carbohydrates}
                                                </p>
                                            </div>
                                            <div className="d-flex mb-2">
                                                <p style={{ marginBottom: 0, width: '50%' }}>
                                                    <strong>Calories (kcal):</strong>
                                                </p>
                                                <p style={{ marginBottom: 0, maxWidth: '50%' }}>
                                                    {item.calories}
                                                </p>
                                            </div>
                                            <div className="d-flex mb-2">
                                                <p style={{ marginBottom: 0, width: '50%' }}>
                                                    <strong>Protein (g):</strong>
                                                </p>
                                                <p style={{ marginBottom: 0, maxWidth: '50%' }}>
                                                    {item.protein}
                                                </p>
                                            </div>
                                            <div className="d-flex mb-2">
                                                <p style={{ marginBottom: 0, width: '50%' }}>
                                                    <strong>Fat (g):</strong>
                                                </p>
                                                <p style={{ marginBottom: 0, maxWidth: '50%' }}>
                                                    {item.fat}
                                                </p>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="col-md-4 text-center">
                                        <div className="image-wrapper">
                                            <img src={`${API_URL}/${item.imageURL}`} alt={item.name} className="item-image" />
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
