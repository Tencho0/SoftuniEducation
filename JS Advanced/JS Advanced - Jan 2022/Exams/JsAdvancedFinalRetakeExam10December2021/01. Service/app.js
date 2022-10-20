window.addEventListener("load", solve);

function solve() {
    document.querySelector('button[type="submit"]').addEventListener('click', createTask);
    let productType = document.getElementById('type-product');
    let problemDescription = document.getElementById('description');
    let clientName = document.getElementById('client-name');
    let clientPhone = document.getElementById('client-phone');
    let receivedOrdersSection = document.getElementById('received-orders');
    let completedOrdersSection = document.getElementById('completed-orders');
    let clearButton = document.getElementsByClassName('clear-btn')[0];
    clearButton.addEventListener('click', clearTask);

    function createTask(e) {
        e.preventDefault();
        let typeValue = productType.value;
        let descriptionValue = problemDescription.value;
        let nameValue = clientName.value;
        let phoneValue = clientPhone.value;

        if (!descriptionValue || !nameValue || !phoneValue) {
            return;
        }

        problemDescription.value = '';
        clientName.value = '';
        clientPhone.value = '';

        createOrder(typeValue, descriptionValue, nameValue, phoneValue);
    }

    function createOrder(typeValue, descriptionValue, nameValue, phoneValue) {
        let divContainer = document.createElement('div');
        divContainer.classList.add('container');

        let h2 = document.createElement('h2');
        h2.textContent = `Product type for repair: ${typeValue}`;

        let h3 = document.createElement('h3');
        h3.textContent = `Client information: ${nameValue}, ${phoneValue}`;

        let h4 = document.createElement('h4');
        h4.textContent = `Description of the problem: ${descriptionValue}`;

        let startBtn = document.createElement('button');
        startBtn.classList.add('start-btn');
        startBtn.textContent = 'Start repair';
        startBtn.addEventListener('click', startRepair);

        let finishBtn = document.createElement('button');
        finishBtn.classList.add('finish-btn');
        finishBtn.setAttribute('disabled', true);
        finishBtn.textContent = 'Finish repair';
        finishBtn.addEventListener('click', finishRepair);

        divContainer.appendChild(h2);
        divContainer.appendChild(h3);
        divContainer.appendChild(h4);
        divContainer.appendChild(startBtn);
        divContainer.appendChild(finishBtn);

        receivedOrdersSection.appendChild(divContainer);
    }

    function startRepair(e) {
        e.target.setAttribute('disabled', true);
        e.target.parentElement.getElementsByClassName('finish-btn')[0].disabled = false;
        // document.querySelector('.finish-btn').disabled = false;
    }

    function finishRepair(e) {
        completedOrdersSection.appendChild(e.target.parentElement);
        let btns = e.target.parentElement.querySelectorAll('button');
        btns[0].remove();
        btns[1].remove();
    }

    function clearTask() {
        let containers = completedOrdersSection.querySelectorAll('.container');
        Array.from(containers).forEach(x => x.remove());
    }
}