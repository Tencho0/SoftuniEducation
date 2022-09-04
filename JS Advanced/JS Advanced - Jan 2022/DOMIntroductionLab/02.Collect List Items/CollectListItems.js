function extractText() {
    let ulElement = document.getElementById('items');
    let textArea = document.getElementById('result');
    textArea.textContent = ulElement.textContent;
}