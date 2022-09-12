function attachGradientEvents() {
    let resultElement = document.getElementById('result');
    let boxElement = document.getElementById('gradient');

    const gradientMove = (e) => {
        let percentage = Math.floor((e.offsetX / (e.target.clientWidth - 1)) * 100);
        resultElement.textContent = `${percentage}%`;
    };
    function gradientOut(event) {
        document.getElementById('result').textContent = "";
    }

    boxElement.addEventListener('mousemove', gradientMove);
    boxElement.addEventListener('mouseout', gradientOut);
}