function create(words) {
   let content = document.getElementById('content');
   const createdSection = function (word) {
      let newDivEl = document.createElement('div');
      let newParagraph = document.createElement('p');
      newParagraph.textContent = word;
      newParagraph.style.display = 'none';
      newDivEl.addEventListener('click', (e) => {
         e.currentTarget.querySelector('div p').style.display = 'block';
      });

      newDivEl.appendChild(newParagraph);
      content.appendChild(newDivEl);
   };

   words.forEach(element => {
      createdSection(element);
   });
}