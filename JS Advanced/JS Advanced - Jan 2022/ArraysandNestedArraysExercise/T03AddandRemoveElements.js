function solve(arr) {

    let result = [];
    let num = 1;
    for (const command of arr) {
        switch (command) {
            case 'add':
                result.push(num);
                break;
            case 'remove':
                result.pop();
                break;
        }
        num++;
    }

    if (result.length == 0) {
        console.log('Empty');
    } else {
        console.log(result.join('\n'));
    }
}

solve(['add',
    'add',
    'add',
    'add']
);
solve(['add',
    'add',
    'remove',
    'add',
    'add']
);
solve(['remove',
    'remove',
    'remove']
);