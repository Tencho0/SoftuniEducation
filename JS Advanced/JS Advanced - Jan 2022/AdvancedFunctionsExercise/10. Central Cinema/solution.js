function solve() {
    const [name, hall, ticketPrice] = document.querySelectorAll("#container input");
    const movieSection = document.querySelector("#movies ul");
    const archiveSection = document.querySelector("#archive ul");
    const clearButton = archiveSection.parentElement.querySelector("button");
    clearButton.addEventListener("click", () => {
        archiveSection.innerHTML = "";
    })
    const addMovieButton = document.querySelector("#container button");
    addMovieButton.addEventListener("click", addMovie);



    function addMovie(e) {
        e.preventDefault();
        if (name.value !== "" && hall.value !== "" && ticketPrice.value != "" && !isNaN(Number(ticketPrice.value))) {
            const movie = document.createElement("li");
            movie.innerHTML =
                `<span>${name.value}</span>
                 <strong>${hall.value}</strong>
                <div>
                    <strong>${Number(ticketPrice.value).toFixed(2)}</strong>
                    <input placeholder="Tickets Sold">
                    <button >Archive</button>
                </div>`
            movieSection.appendChild(movie);

            const button = movie.querySelector("div button");
            button.addEventListener("click", addToArchive);
            name.value = "";
            hall.value = "";
            ticketPrice.value = "";
        }
    }


    function addToArchive(e) {
        const inputValue = e.target.parentElement.querySelector("input");
        const ticketPrice = e.target.parentElement.querySelector("strong");
        const movieName = e.target.parentElement.parentElement.querySelector("span");
        if (inputValue.value != "" && !isNaN(Number(inputValue.value))) {
            const income = Number(inputValue.value) * Number(ticketPrice.textContent);

            const liEl = document.createElement("li");
            liEl.innerHTML = `<span>${movieName.textContent}</span>
                              <strong>Total amount: ${income.toFixed(2)}</strong>
                              <button>Delete</button>`

            const button = liEl.querySelector("button");
            button.addEventListener("click", deleteEntry);
            archiveSection.appendChild(liEl);
        }

        e.target.parentElement.parentElement.remove();
    }

    function deleteEntry(e) {
        e.target.parentElement.remove();
    }
}



// function solve() {

//     let name = document.querySelector('#container input:nth-of-type(1)');
//     let hall = document.querySelector('#container input:nth-of-type(2)');
//     let price = document.querySelector('#container input:nth-of-type(3)');
//     let btnOnScreen = document.querySelector('#container button');

//     let ulMoviesElement = document.querySelector('#movies > ul');
//     let ulArchiveElement = document.querySelector('#archive > ul');

//     let buttonClearElement = document.querySelector('#archive > button');


//     btnOnScreen.addEventListener('click', e => {
//         e.preventDefault();

//         if (name.value === '' || hall.value === '' || price.value === '') {
//             return;
//         }

//         if (!Number(price.value)) {
//             return;
//         }

//         let liElement = document.createElement('li');
//         let spanElement = document.createElement('span');
//         spanElement.textContent = name.value;
//         let strongElement = document.createElement('strong');
//         strongElement.textContent = `Hall: ${hall.value}`;

//         liElement.appendChild(spanElement)
//         liElement.appendChild(strongElement)
//         ulMoviesElement.appendChild(liElement)

//         let divElement = document.createElement('div');
//         let strongPriceElement = document.createElement('strong');
//         strongPriceElement.textContent = Number(price.value).toFixed(2);
//         let inputPriceElement = document.createElement('input');
//         inputPriceElement.setAttribute('placeholder', 'TicketsSold');
//         let buttonArchive = document.createElement('button');
//         buttonArchive.textContent = 'Archive';

//         divElement.appendChild(strongPriceElement);
//         divElement.appendChild(inputPriceElement);
//         divElement.appendChild(buttonArchive);

//         liElement.appendChild(divElement);

//         name.value = ''
//         hall.value = ''
//         price.value = ''

//         buttonArchive.addEventListener('click', e => {
//             e.preventDefault();

//             if (!Number(inputPriceElement.value)) {
//                 return;
//             }

//             let currentPrice = Number(inputPriceElement.value) * Number(strongPriceElement.textContent);

//             let liArchiveElement = document.createElement('li');
//             let spanArchiveElement = document.createElement('span');
//             spanArchiveElement.textContent = e.currentTarget.parentElement.parentElement.firstChild.textContent;
//             let strongArchiveElement = document.createElement('strong');
//             strongArchiveElement.textContent = `Total amount: ${Number(currentPrice).toFixed(2)}`
//             let buttonDeleteElement = document.createElement('button');
//             buttonDeleteElement.textContent = 'Delete';

//             liArchiveElement.appendChild(spanArchiveElement);
//             liArchiveElement.appendChild(strongArchiveElement);
//             liArchiveElement.appendChild(buttonDeleteElement);

//             ulArchiveElement.appendChild(liArchiveElement);

//             e.currentTarget.parentElement.parentElement.remove()

//             buttonDeleteElement.addEventListener('click', e => {
//                 e.preventDefault();

//                 e.currentTarget.parentElement.remove();


//             })

//             buttonClearElement.addEventListener('click', e => {
//                 e.preventDefault();

//                 let li = (e.currentTarget.parentElement.children[1].children);

//                 for (const el of li) {
//                     el.remove();
//                 }
//             })
//         })

//     })

// }
