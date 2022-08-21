function solve(arr) {
    let result = [];
    arr.sort((a, b) => a.length - b.length || a.localeCompare(b));
    console.log(arr.join('\n'));
}

solve(['alpha',
    'beta',
    'gamma']
);

solve(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']
);

solve(['test',
    'Deny',
    'omen',
    'Default']
);