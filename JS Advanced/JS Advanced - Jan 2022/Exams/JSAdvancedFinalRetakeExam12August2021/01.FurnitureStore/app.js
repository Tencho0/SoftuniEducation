window.addEventListener('load', solve);

function solve() {
    let model = document.getElementById('model');
    let year = document.getElementById('year');
    let description = document.getElementById('description');
    let price = document.getElementById('price');
    let add = document.getElementById('add');
    add.addEventListener('click', addFurniture);
    let furnitureList = document.getElementById('furniture-list');
    let totalPrice = document.getElementsByClassName('total-price')[0];

    function addFurniture(e) {
        e.preventDefault();
        let priceVlaue = Number(price.value);
        let yearValue = Number(year.value);
        if (!model.value || !year.value || !description.value || !price.value || priceVlaue <= 0 || yearValue <= 0) {
            return;
        }

        let rowElement = document.createElement('tr');
        rowElement.classList.add('info');
        let td1 = document.createElement('td');
        td1.textContent = model.value;
        let td2 = document.createElement('td');
        td2.textContent = priceVlaue.toFixed(2);
        let td3 = document.createElement('td');
        let moreBtn = document.createElement('button');
        let buyBtn = document.createElement('button');
        moreBtn.classList.add('moreBtn');
        buyBtn.classList.add('buyBtn');
        moreBtn.textContent = 'More Info';
        buyBtn.textContent = 'Buy it';

        moreBtn.addEventListener('click', showMoreInformation);
        buyBtn.addEventListener('click', buyFurniture);

        let tr2 = document.createElement('tr');
        tr2.classList.add('hide');
        let td21 = document.createElement('td');
        td21.textContent = `Year: ${yearValue}`;
        let td22 = document.createElement('td');
        td22.setAttribute('colspan', 3);
        td22.textContent = `Description: ${description.value}`;

        td3.appendChild(moreBtn);
        td3.appendChild(buyBtn);
        rowElement.appendChild(td1);
        rowElement.appendChild(td2);
        rowElement.appendChild(td3);
        tr2.appendChild(td21);
        tr2.appendChild(td22);

        furnitureList.appendChild(rowElement);
        furnitureList.appendChild(tr2);


        model.value = '';
        year.value = '';
        description.value = '';
        price.value = '';
        add.value = '';

        function showMoreInformation(e) {
            if (moreBtn.textContent == 'Less Info') {
                moreBtn.textContent = 'More Info';
                tr2.style.display = 'none';
            } else {
                tr2.style.display = 'contents';
                moreBtn.textContent = 'Less Info';
            }
        }

        function buyFurniture(e) {
            // e.parentElement.parentElement.remove();
            rowElement.remove();
            tr2.remove();
            totalPrice.textContent = (Number(totalPrice.textContent) + Number(td2.textContent)).toFixed(2);
        }
    }
}
