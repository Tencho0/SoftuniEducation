function primtSquare(input){
    for (let index = 0; index < input ; index++) {
        let row = '*';
        for (let index = 0; index < input - 1; index++) {
                        row += ' *';
        }
        console.log(row);
    }
}
primtSquare(6);