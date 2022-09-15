function encodeAndDecodeMessages() {
    let inputMessageElement = document.querySelector('#main > div:nth-child(1) > textarea');
    let resultMessageElement = document.querySelector('#main > div:nth-child(2) > textarea');
    let encodeBtn = document.querySelector('#main > div:nth-child(1) > button');
    let decodeBtn = document.querySelector('#main > div:nth-child(2) > button');

    encodeBtn.addEventListener('click', encode);
    decodeBtn.addEventListener('click', decode);

    function encode() {
        let resultArr = [];
        let letters = Array.from(inputMessageElement.value.split(''));

        letters.forEach(letter => {
            resultArr.push(String.fromCharCode(letter.codePointAt() + 1));
        });

        inputMessageElement.value = '';
        resultMessageElement.textContent = resultArr.join('');
    }

    function decode() {
        let resultArr = [];
        let letters = Array.from(resultMessageElement.value.split(''));

        letters.forEach(letter => {
            resultArr.push(String.fromCharCode(letter.codePointAt() - 1));
        });
        
        resultMessageElement.textContent = resultArr.join('');
    }
}