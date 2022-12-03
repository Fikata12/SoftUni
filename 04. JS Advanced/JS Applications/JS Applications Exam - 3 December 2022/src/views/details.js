import { del, get, post } from "../api/api.js";
import { html, nothing } from "../api/lib.js";
import { getUserData } from "../api/util.js";

const detailsTemplate = (album, isUser, isOwner, canLike, likesCount, onDelete, onLike) => html`
    <section id="details">
        <div id="details-wrapper">
            <p id="details-title">Album Details</p>
            <div id="img-wrapper">
                <img src=${album.imageUrl} alt=${album.imageUrl} />
            </div>
            <div id="info-wrapper">
                <p><strong>Band:</strong><span id="details-singer">${album.singer}</span></p>
                <p>
                    <strong>Album name:</strong><span id="details-album">${album.album}</span>
                </p>
                <p><strong>Release date:</strong><span id="details-release">${album.release}</span></p>
                <p><strong>Label:</strong><span id="details-label">${album.label}</span></p>
                <p><strong>Sales:</strong><span id="details-sales">${album.sales}</span></p>
            </div>
            <div id="likes">Likes: <span id="likes-count">${likesCount}</span></div>
            <div id="action-buttons">
                ${isUser ? isOwner ? html`
                <a href="/edit/${album._id}" id="edit-btn">Edit</a>
                <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>` : canLike ? html`
                <a @click=${onLike} href="javascript:void(0)" id="like-btn">Like</a>` : nothing : nothing}
            </div>
        </div>
    </section>`;

export async function showDetails(ctx) {
    const album = await get('/data/albums/' + ctx.params.id);
    const user = getUserData();
    const isUser = Boolean(user);
    const likesCount = await get(`/data/likes?where=albumId%3D%22${album._id}%22&distinct=_ownerId&count`);
    let isOwner = false;
    let canLike = false;
    if (isUser) {
        isOwner = user._id == album._ownerId;
        canLike = (await get(`/data/likes?where=albumId%3D%22${album._id}%22%20and%20_ownerId%3D%22${user._id}%22&count`)) == 0;
    }
    ctx.render(detailsTemplate(album, isUser, isOwner, canLike, likesCount, onDelete, onLike));

    async function onDelete() {
        await del('/data/albums/' + ctx.params.id);
        ctx.page.redirect('/dashboard');
    }

    async function onLike() {
        const albumId = album._id;
        await post('/data/likes', { albumId });
        ctx.page.redirect('/dashboard/' + albumId);
    }
}