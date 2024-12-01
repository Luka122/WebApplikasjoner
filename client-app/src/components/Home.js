import React from 'react';
import './Home.css';

function HomePage() {
    return (
        <div className="container my-5">
            <section className="text-center bg-light py-5 rounded">
                <h1 className="display-4 mb-3">Welcome to Our Nutrition Page</h1>
                <p className="lead">
                    Your one-stop solution for nutritional information and healthy eating! Explore our tools and features to lead a healthier lifestyle.
                </p>
            </section>

            <div className="row align-items-center my-5">
                <div className="col-lg-6">
                    <h2 className="mb-4">Why Choose Us?</h2>
                    <p className="text-muted">
                        We provide accurate nutritional information to help you make better choices for a healthier lifestyle. Whether you're looking for inspiration or sharing new meal ideas, our platform offers everything you need to reach your health goals.
                    </p>
                    <p className="text-muted">
                        Choose us for a comprehensive, user-friendly experience that empowers you to live a healthier life.
                    </p>
                </div>

                <div className="col-lg-6">
                    <div id="homeCarousel" className="carousel slide" data-bs-ride="carousel" data-bs-interval="5000" aria-label="Nutrition Carousel">
                        <div className="carousel-inner shadow rounded">
                            {/* Slide 1 */}
                            <div className="carousel-item active">
                                <img src="images/chicken.jpg" className="d-block w-100 rounded" alt="Fruits and Greens" loading="lazy" />
                            </div>
                            {/* Slide 2 */}
                            <div className="carousel-item">
                                <img src="/images/berries.jpg" className="d-block w-100 rounded" alt="Chicken" loading="lazy" />
                            </div>
                            {/* Slide 3 */}
                            <div className="carousel-item">
                                <img src="/images/fruits-basket.jpg" className="d-block w-100 rounded" alt="Berries" loading="lazy" />
                            </div>
                        </div>

                        {/* Carousel Controls */}
                        <button className="carousel-control-prev" type="button" data-bs-target="#homeCarousel" data-bs-slide="prev" aria-label="Previous">
                            <span className="carousel-control-prev-icon" aria-hidden="true"></span>
                        </button>
                        <button className="carousel-control-next" type="button" data-bs-target="#homeCarousel" data-bs-slide="next" aria-label="Next">
                            <span className="carousel-control-next-icon" aria-hidden="true"></span>
                        </button>

                        {/* Carousel Indicators */}
                        <div className="carousel-indicators">
                            <button type="button" data-bs-target="#homeCarousel" data-bs-slide-to="0" className="active" aria-current="true" aria-label="Slide 1"></button>
                            <button type="button" data-bs-target="#homeCarousel" data-bs-slide-to="1" aria-label="Slide 2"></button>
                            <button type="button" data-bs-target="#homeCarousel" data-bs-slide-to="2" aria-label="Slide 3"></button>
                        </div>
                    </div>
                </div>
            </div>

            <footer className="bg-light py-3 text-center border-top mt-5">
                <p className="mb-0">
                    Copyright © 2024 | Designed with 💚 for Healthy Living
                </p>
            </footer>
        </div>
    );
}

export default HomePage;