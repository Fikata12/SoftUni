import { html, page, render } from "../api/lib.js";
import { logout } from "../api/user.js";
import { getUserData } from "../api/util.js";

const nav = document.querySelector('header');

const navTemplate = (isLogged) => html`
    <a id="logo" href="/"><img id="logo-img" src="/images/logo.png" alt="" /></a>
    <nav>
        <div>
            <a href="/dashboard">Dashboard</a>
        </div>
        ${isLogged ? html`
        <div class="user">
            <a href="/add">Add Album</a>
            <a @click=${onLogout} href="javascript:void(0)">Logout</a>
        </div>` : html`
        <div class="guest">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
        </div>`}
    </nav>`;
export function showNav() {
    const user = getUserData();
    render(navTemplate(user), nav);
}
function onLogout() {
    logout();
    showNav();
    page.redirect('/dashboard');
}