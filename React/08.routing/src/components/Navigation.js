import { NavLink } from "react-router-dom"
import styles from './Navigation.module.css';

export default function Navigation() {
    const setStyle = ({ isActive }) => {
        return isActive
            ? styles['active-link']
            : undefined;
    }
    return (
        <nav>
            <ul>
                <li><NavLink className={setStyle} to='/'>Home</NavLink></li>
                <li><NavLink className={setStyle} to='/about'>About</NavLink></li>
                <li><NavLink className={setStyle} to='/pricing'>Home</NavLink></li>
                <li><NavLink className={setStyle} to='/pricing/premium'>About</NavLink></li>
                <li><NavLink className={setStyle} to='/products/2' >Porducts</NavLink></li>
                <li><NavLink className={setStyle} to='/millennium-falcon'>Millennium Falcon</NavLink></li>
                <li><NavLink className={setStyle} to='/contacts'>Home</NavLink></li>
            </ul>
        </nav>
    )
}