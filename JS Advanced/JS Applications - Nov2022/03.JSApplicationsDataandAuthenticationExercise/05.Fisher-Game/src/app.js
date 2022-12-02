console.log('TODO:// Implement Home functionality');
import page from '.././node_modules/page/page.mjs'
import {saveUserStatus} from '.././src/middlewares/authMiddleware.js';
import {displayContent, displayNavigation} from '.././src/middlewares/renderMiddleware.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';
import { registerView } from './views/registerView.js';

page(saveUserStatus);
page(displayNavigation);
page(displayContent);
page('/', homeView)
page('/home', homeView)
page('/login', loginView)
page('/register', registerView)
page('/logout', logoutView)

page.start();

// indow.addEventListener('DOMContentLoaded', onLoadHTML);

// document.getElementById('logout').addEventListener('click', onLogout);
// document.getElementById('addForm').addEventListener('submit', createCatch);
// document.querySelector('.load').addEventListener('click', onLoadCatch);

// async function onLogout() {
//     const url = 'http://localhost:3030/users/logout';
//     const header = getHeader('GET', '');
//     const response = await fetch(url, header);
//     sessionStorage.clear();
//     onLoadHTML();
// }

// function onLoadHTML() {
//     const token = sessionStorage.getItem('accessToken');
//     const greatingMsg = document.querySelector('p.email span');
//     const addBtn = document.querySelector('.add');

//     if (token) {
//         document.getElementById('guest').style.display = 'none';
//         document.getElementById('user').style.display = 'inline-block'
//         greatingMsg.textContent = sessionStorage.getItem('email');
//         addBtn.disabled = false;
//     } else {
//         document.getElementById('guest').style.display = 'inline-block';
//         document.getElementById('user').style.display = 'none'
//         greatingMsg.textContent = sessionStorage.getItem('guest');
//         addBtn.disabled = true;
//     }
// }

// // render method
// async function onLoadCatch() {
//     const url = 'http://localhost:3030/data/catches';
//     const response = await fetch(url);
//     const data = await response.json();
//     return data;
// }

// function createCatch(ev) {
//     ev.preventDefault();
//     const form = ev.target;
//     const formData = new FormData(form);
//     const data = Object.fromEntries(formData);
//     onCreateCatch(data);
// }

// async function onCreateCatch(body) {
//     const url = 'http://localhost:3030/data/catches';
//     const header = getHeader('POST', body);
//     const response = await fetch(url, header);
//     const data = await response.json();
//     return data;
// }

// function getHeader(method, body) {
//     const token = sessionStorage.getItem('accessToken');
//     const header = {
//         method: `${method}`,
//         headers: {
//             'Content-Type': 'application/json',
//             'X-Authorization': token
//         },
//     }
//     if (body) {
//         header.body = JSON.stringify(body)
//     }
//     return header;
// }