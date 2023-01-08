import { html, render } from './node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

const townsRoot = document.getElementById('towns');
const resultRoot = document.getElementById('result');
document.querySelector('button').addEventListener('click', search);

update();

function searchTemplate(townsName, match) {
   const ul = html`
   <ul>
      ${townsName.map(townName => createLiTemplate(townName, match))}
   </ul>
   `;
   return ul;
}

function createLiTemplate(townName, match) {
   //return html`<li class="${(match && townName.toLowerCase().includes(match)) ? " active" : "" }">${townName}</li>`;
   return html`<li class="${(match && townName.includes(match)) ? " active" : ""}">${townName}</li>`;
}

function update(text) {
   const ul = searchTemplate(towns, text);
   render(ul, townsRoot);
}

function search(e) {
   const textNode = document.getElementById('searchText');
   //const text = textNode.value.toLowerCase();
   const text = textNode.value;
   update(text);
   updateCount();
   textNode.value = '';
}

function updateCount() {
   const count = document.querySelectorAll('.active').length;
   //const countElement = count ? html`<p>${count} matches found</p>` : '';
   const countElement = html`<p>${count} matches found</p>`;
   render(countElement, resultRoot);
}