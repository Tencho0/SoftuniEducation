function toggle() {
    let buttonElement = document.getElementsByClassName('button')[0];
    let buttonValue = buttonElement.textContent;
    let textElement = document.getElementById('extra');
    switch (buttonValue) {
        case 'More':
            textElement.style.display = 'block';
            buttonElement.textContent = 'Less';
            break;

        case 'Less':
            textElement.style.display = 'none';
            buttonElement.textContent = 'More';
            break;
    }
}