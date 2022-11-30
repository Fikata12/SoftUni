import { html, render } from "./node_modules/lit-html/lit-html.js";

const form = document.querySelector('form.content');

form.addEventListener('submit', (e) => {
    e.preventDefault();
    const root = document.querySelector('#root');
    let formData = new FormData(form);
    let towns = formData.get('towns').split(', ');
    const townTemplate = (town) => html`<li>${town}</li>`;
    const listTemplate = () => html`<ul>${towns.map(townTemplate)}</ul>`;
    render(listTemplate(), root);
});