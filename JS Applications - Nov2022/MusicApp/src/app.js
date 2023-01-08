import { updateNav } from './views/nav.js';
import { page, render } from './lib.js';
import { getUserData } from './util.js';
import { showLogin } from './views/loginView.js';
import { showRegister } from './views/registerView.js';
import { showHome } from './views/homeView.js';
import { showCreate } from './views/createView.js';
import { showCatalog } from './views/catalogView.js';
import { showDetails } from './views/detailsView.js';

const main = document.getElementById('main-content');
//document.getElementById('logoutBtn').addEventListener('click', onLogout);

page(decorateContext);
page('/', showHome);
page('/home', showHome);
page('/login', showLogin);
page('/register', showRegister);
page('/catalog', showCatalog);
page('/create', showCreate);
page('/details/:id', showDetails);
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