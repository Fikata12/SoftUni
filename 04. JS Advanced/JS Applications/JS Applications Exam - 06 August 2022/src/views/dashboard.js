import { get } from "../api/api.js";
import { html } from "../api/lib.js";

const dashboardTemplate = (offers) => html`
        <section id="dashboard">
            <h2>Job Offers</h2>
            ${offers.length ? offers.map(offerTemplate) : html`
            <h2>No offers yet.</h2>`}
        </section>`;

const offerTemplate = (offer) => html`
                    <div class="offer">
                        <img src=${offer.imageUrl} alt=${offer.imageUrl} />
                        <p>
                            <strong>Title: </strong><span class="title">${offer.title}</span>
                        </p>
                        <p><strong>Salary:</strong><span class="salary">${offer.salary}</span></p>
                        <a class="details-btn" href="/dashboard/${offer._id}">Details</a>
                    </div>`;

export async function showDashboard(ctx) {
    const offers = await get('/data/offers?sortBy=_createdOn%20desc');
    ctx.render(dashboardTemplate(offers));
}