console.log(add(4)(3).toString());

function add(num) {
    let sum = 0;

    function inner(number) {
        sum += number;
        return inner;
    }

    inner.toString = () => {
        return sum;
    }

    return inner(num);
}