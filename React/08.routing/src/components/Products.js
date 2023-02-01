import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

const Products = () => {
    const [starShip, setStarship] = useState({});
    const { productId } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        fetch(`https://swapi.dev/api/starships/${productId}/`)
            .then(res => res.json())
            .then(result => {
                setStarship(result);
            })
    }, [productId]);

    const nextProductHandler = () => {
        navigate(`/products/${Number(productId) + 1}`)
    }

    return (
        <>
            <h2>Products page</h2>
            <h3>Product {productId} Specification</h3>

            <ul>
                <li>Name: {starShip.name}</li>
                <li>Model: {starShip.model}</li>
                <li>Manifacturer: {starShip.manifacturer}</li>
            </ul>

            <button onClick={nextProductHandler}>Next</button>
        </>
    )
}

export default Products;