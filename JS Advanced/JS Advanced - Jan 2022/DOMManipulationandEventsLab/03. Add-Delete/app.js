function addItem() {
    let givenInputElement = document.getElementById('newItemText');
    let ulElement = document.getElementById('items');
    let newLiElement = document.createElement('li');
    newLiElement.textContent = givenInputElement.value;

    let deleteElement = document.createElement('a');
    deleteElement.href = '#';
    deleteElement.textContent = '[Delete]';
    deleteElement.addEventListener('click', (e) => {
        e.currentTarget.parentElement.remove();
    });

    newLiElement.appendChild(deleteElement);
    ulElement.appendChild(newLiElement);
}