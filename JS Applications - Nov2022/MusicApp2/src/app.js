import { updateNav } from './views/nav.js';
import { page, render } from './lib.js';
import { getUserData } from './util.js';

const main = document.getElementById('main-container');
//document.getElementById('logoutBtn').addEventListener('click', onLogout);

page(decorateContext);
page('/', () => console.log('homeView'));
page('/home', () => console.log('homeView'));
page('/login', () => console.log('loginView'));
page('/register', () => console.log('registerView'));
page('/catalog', () => console.log('catalogView'));
page('/create', () => console.log('createView'));
page('/detail/:id', () => console.log('detailView'));
page('/edit/:id', () => console.log('editView'));
page('/search', () => console.log('searchView'));

updateNav();
page.start();

function decorateContext(ctx, next) {
    ctx.render = renderMain;
    ctx.updateNav = updateNav;
    const user = getUserData();
    if (user) {
        ctx.user = user;
    }
    next();
}

function renderMain(content) {
    render(content, main);
}