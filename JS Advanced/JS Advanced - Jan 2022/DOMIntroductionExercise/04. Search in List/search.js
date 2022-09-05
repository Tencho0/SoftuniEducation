function search() {
   let result = document.getElementById('result');
   result.textContent = '';

   let towns = document.querySelectorAll('#towns li');
   let input = document.getElementById('searchText').value;
   let matches = [];

   for (const currEl of towns) {

      if (currEl.textContent.includes(input)) {
         matches.push(currEl.textContent);
         currEl.style.fontWeight = 'bold';
         currEl.style.textDecoration = 'underline';
      }else{
         currEl.style.fontWeight = 'normal';
         currEl.style.textDecoration = 'none';
      }

      // let isMatch = true;
      // let town = Array.from(currEl.textContent);

      // for (const letter of input) {
      //    if (town.filter(x => x == letter).length === 0) {
      //       isMatch = false;
      //       break;
      //    }
      // }
      // if (isMatch) {
      //    matches.push(town);
      // }else{
      //    currEl.style.fontWeight = 'normal';
      //    currEl.style.textDecoration = 'none';
      // }
   }

   // for (const iterator of matches) {
   //    iterator.style.fontWeight = 'bold';
   //    iterator.style.textDecoration = 'underline';
   // }

   result.textContent = `${matches.length} matches found`;
}
