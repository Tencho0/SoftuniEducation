function solve() {
  let input = document.getElementById('text').value;
  let currentCase = document.getElementById('naming-convention').value;
  let result = "Error!";
  let arr = input.toLowerCase().split(' ');
  switch (currentCase) {
    case 'Camel Case':
      result = '';
      result += arr[0];
      for (let index = 1; index < arr.length; index++) {
        const element = arr[index];
        let word = element.charAt(0).toUpperCase() + element.slice(1);
        result += word;
      }
      break;

    case 'Pascal Case':
      result = '';
      for (let index = 0; index < arr.length; index++) {
        const element = arr[index];
        let word = element.charAt(0).toUpperCase() + element.slice(1);
        result += word;
      }
      break;
  }
  console.log(result);
  let resultEl = document.getElementById('result');
  resultEl.textContent = result;
}