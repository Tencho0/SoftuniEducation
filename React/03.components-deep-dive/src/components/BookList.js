
import { Book } from "./Book"

export const BookList = (props) => {
    return (
        <ul>
            {props.books.map(book => <Book {...book}/>)}
        </ul>
    )
}