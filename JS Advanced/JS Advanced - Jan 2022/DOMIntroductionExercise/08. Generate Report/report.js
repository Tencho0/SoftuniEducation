function generateReport() {
    let inputs = document.querySelectorAll('table>thead>tr>th>input');
    let rows = document.querySelectorAll('tbody>tr');
    let output = [];
    for (let index = 0; index < rows.length; index++) {
        let obj = {};
        let values = Array.from(rows[index].getElementsByTagName('td')).map(el => el.textContent);
        for (let j = 0; j < inputs.length; j++) {
            if (inputs[j].checked) {
                obj[inputs[j].name] = values[j];
            }
        }
        output.push(obj);
    }
    document.querySelector('#output').value = JSON.stringify(output, null, 2);
}