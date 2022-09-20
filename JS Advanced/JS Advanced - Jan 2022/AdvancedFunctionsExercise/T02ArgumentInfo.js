function solve() {

    let data = {};

    Array.from(arguments).forEach((line) => {
        console.log(`${typeof line}: ${line}`);
        if (!data[typeof line]) {
            data[typeof line] = 0;
        }
        data[typeof line]++;
    });

    Object.keys(data)
        .sort((a, b) => data[b] - data[a])
        .forEach(x => console.log(`${x} = ${data[x]}`));
}

solve('cat', 42, function () { console.log('Hello world!'); });