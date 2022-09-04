function colorize() {
    let rowElements = document.querySelectorAll('tr:nth-of-type(2n) td')
    // rowElements.forEach(x => {
    //     x.style.backgroundColor = 'teal';
    // });

    for (const iterator of rowElements) {
        iterator.style.background = 'teal';
    }
}