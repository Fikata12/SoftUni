import { page, render } from "./api/lib.js";
import { getUserData } from "./api/util.js";
import { showAdd } from "./views/add.js";
import { showDashboard } from "./views/dashboard.js";
import { showDetails } from "./views/details.js";
import { showEdit } from "./views/edit.js";
import { showHome } from "./views/home.js";
import { showLogin } from "./views/login.js";
import { showNav } from "./views/nav.js";
import { showRegister } from "./views/register.js";

const main = document.querySelector('main');

page(decorateContext);
page('/', showHome);
page('/dashboard', showDashboard);
page('/dashboard/:id', showDetails);
page('/edit/:id', showEdit);
page('/add', showAdd);
page('/login', showLogin);
page('/register', showRegister);
page.start();

showNav();

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);

    const user = getUserData();
    if (user) {
        ctx.user = user;
    }

    ctx.showNav = showNav;

    next();
}