import { get } from "../api/api.js";
import { html } from "../api/lib.js";

const dashboardTemplate = (albums) => html`
    <section id="dashboard">
        <h2>Albums</h2>
        ${albums.length ? html`
        <ul class="card-wrapper">
            ${albums.map(albumTemplate)}
        </ul>` : html`<h2>There are no albums added yet.</h2>`}
    </section>`;

const albumTemplate = (album) => html`
        <li class="card">
            <img src=${album.imageUrl} alt=${album.imageUrl} />
            <p>
                <strong>Singer/Band: </strong><span class="singer">${album.singer}</span>
            </p>
            <p>
                <strong>Album name: </strong><span class="album">${album.album}</span>
            </p>
            <p><strong>Sales:</strong><span class="sales">${album.sales}</span></p>
            <a class="details-btn" href="/dashboard/${album._id}">Details</a>
        </li>`;

export async function showDashboard(ctx) {
    const albums = await get('/data/albums?sortBy=_createdOn%20desc');
    ctx.render(dashboardTemplate(albums));
}