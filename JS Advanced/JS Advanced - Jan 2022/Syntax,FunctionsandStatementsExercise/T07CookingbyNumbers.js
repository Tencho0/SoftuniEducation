function solve(num, p1, p2, p3, p4, p5) {

    let number = Number(num);
    let arrayOfCommands = [p1, p2, p3, p4, p5];

    arrayOfCommands.forEach(element => {
        let result;
        switch (element) {
            case 'chop': result = number /= 2; break;
            case 'dice': result = number = Math.sqrt(number); break;
            case 'spice': result = number += 1; break;
            case 'bake': result = number *= 3; break;
            case 'fillet': result = number *= 0.8; break;
        }
        console.log(result);
    });

    // let number = Number(num);

    // calculateTheValue(p1);
    // calculateTheValue(p2);
    // calculateTheValue(p3);
    // calculateTheValue(p4);
    // calculateTheValue(p5);

    // function calculateTheValue(operation) {
    //     let result;
    //     switch (operation) {
    //         case 'chop': result = number /= 2;break;
    //         case 'dice': result = number = Math.sqrt(number); break;
    //         case 'spice': result = number += 1; break;
    //         case 'bake': result = number *= 3; break;
    //         case 'fillet': result = number *= 0.8; break;
    //     }
    //     console.log(result);
    // }
}

solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');