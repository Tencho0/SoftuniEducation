import { login } from "../api/users.js";

const section = document.getElementById('loginPage');
const form = document.querySelector('form');
form.addEventListener('submit', onSubmit);

let ctx = null;

export function showLogin(context) {
    context.showSection(section);
    ctx = context;
}

async function onSubmit(e) {
    e.preventDefault();
    const formData = new FormData(form);
    const email = formData.get('email');
    const password = formData.get('password');
    await login(email, password);
    ctx.goTo('/');
}