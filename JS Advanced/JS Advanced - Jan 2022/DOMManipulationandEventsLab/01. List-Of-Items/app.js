function addItem() {
    let newItemText = document.getElementById('newItemText').value;
    let newIem = document.createElement('li');
    let ulItems = document.getElementById('items');
    newIem.textContent = newItemText;
    ulItems.appendChild(newIem);
}