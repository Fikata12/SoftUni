import { del, get, post } from "../api/api.js";
import { html, nothing } from "../api/lib.js";
import { getUserData } from "../api/util.js";

const detailsTemplate = (offer, isUser, isOwner, canApply, applicationsCount, onDelete, onApply) => html`
        <section id="details">
            <div id="details-wrapper">
                <img id="details-img" src=${offer.imageUrl} alt="example1" />
                <p id="details-title">${offer.title}</p>
                <p id="details-category">
                    Category: <span id="categories">${offer.category}</span>
                </p>
                <p id="details-salary">
                    Salary: <span id="salary-number">${offer.salary}</span>
                </p>
                <div id="info-wrapper">
                    <div id="details-description">
                        <h4>Description</h4>
                        <span>${offer.description}</span>
                    </div>
                    <div id="details-requirements">
                        <h4>Requirements</h4>
                        <span>${offer.requirements}</span>
                    </div>
                </div>
                <p>Applications: <strong id="applications">${applicationsCount}</strong></p>
                <div id="action-buttons">
                    ${isUser ? (isOwner ? html`
                    <a href="/edit/${offer._id}" id="edit-btn">Edit</a>
                    <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>` : (canApply ? html`
                    <a @click=${onApply} href="javascript:void(0)" id="apply-btn">Apply</a>` : nothing)) : nothing}
                </div>
            </div>
        </section>`;

export async function showDetails(ctx) {
    const offer = await get('/data/offers/' + ctx.params.id);
    const user = getUserData();
    const isUser = Boolean(user);
    const applicationsCount = await get(`/data/applications?where=offerId%3D%22${offer._id}%22&distinct=_ownerId&count`);
    let isOwner = false;
    let canApply = false;
    if (isUser) {
        isOwner = user._id == offer._ownerId;
        canApply = (await get(`/data/applications?where=offerId%3D%22${offer._id}%22%20and%20_ownerId%3D%22${user._id}%22&count`)) == 0;
    }
    ctx.render(detailsTemplate(offer, isUser, isOwner, canApply, applicationsCount, onDelete, onApply));

    async function onDelete() {
        await del('/data/offers/' + ctx.params.id);
        ctx.page.redirect('/dashboard');
    }

    async function onApply() {
        const offerId = offer._id;
        await post('/data/applications', { offerId });
        ctx.page.redirect('/dashboard/' + offerId);
    }
}