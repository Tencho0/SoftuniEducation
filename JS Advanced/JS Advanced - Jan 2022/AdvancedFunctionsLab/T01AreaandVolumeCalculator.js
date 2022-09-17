function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};

function solve(area, vol, input) {
    // let coordinates = JSON.parse(input);
    // let result = [];

    // coordinates.forEach(element => {
    //     let areaResult = area.call(element);
    //     let volumeResult = vol.call(element);
    //     let currResult = {
    //         area: areaResult,
    //         volume: volumeResult
    //     };
    //     result.push(currResult);
    // });

    // return result;

    return JSON.parse(input).map(x =>
    ({
        area: area.call(x),
        volume: vol.call(x),
    }));
}

console.log(solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`
));
