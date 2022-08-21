function solve(arr) {

    let i = 1;
    arr.sort((a, b) => a.localeCompare(b)).forEach(x => console.log(`${i++}.${x}`));
    // for (const iterator of arr) {
    //     console.log(`${i}. ${iterator}`);
    //     i++;
    // }
}

solve(["John", "Bob", "Christina", "Ema"]);