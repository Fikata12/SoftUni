import { html, render } from "./node_modules/lit-html/lit-html.js";
import { cats } from "./catSeeder.js";

const root = document.querySelector('#allCats');
const catTemplate = (cat) => html`
<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn">Show status code</button>
        <div class="status" style="display: none" id="${cat.id}">
            <h4>Status Code: ${cat.statusCode}</h4>
            <p>${cat.statusMessage}</p>
        </div>
    </div>
</li>
`;
const listOfCatsTemplate = () => html`
<ul>
    ${cats.map(catTemplate)}
</ul> 
`;
render(listOfCatsTemplate(), root);

let allButtons = document.getElementsByClassName('showBtn'); 
for (const button of Array.from(allButtons)) {
    button.addEventListener('click', () => {
        let status = button.parentElement.getElementsByClassName('status')[0];
        if (status.style.display === 'none') {
            status.style.display = '';
            button.textContent = 'Hide status code';
        }
        else {
            status.style.display = 'none';
            button.textContent = 'Show status code';
        }
    });
}