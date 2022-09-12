function deleteByEmail() {
    let emailInputElement = document.querySelector('input[name="email"]');
    let emailCellElements = document.querySelectorAll("#customers tr td:nth-child(2)");
    let resultElement = document.getElementById('result');

    let emailElements = Array.from(emailCellElements);
    let nodeToDelete = emailElements.find(x => x.textContent == emailInputElement.value);

    if (nodeToDelete) {
        nodeToDelete.parentElement.remove();
        resultElement.textContent = 'Deleted.';
    } else {
        resultElement.textContent = 'Not found.';
    }
}