import { get, put } from "../api/api.js";
import { html } from "../api/lib.js";
import { createSubmitHandler } from "../api/util.js";

const editTemplate = (album, onEdit) => html`
      <section id="edit">
        <div class="form">
          <h2>Edit Album</h2>
          <form @submit=${onEdit} class="edit-form">
            <input .value=${album.singer} type="text" name="singer" id="album-singer" placeholder="Singer/Band" />
            <input .value=${album.album} type="text" name="album" id="album-album" placeholder="Album" />
            <input .value=${album.imageUrl} type="text" name="imageUrl" id="album-img" placeholder="Image url" />
            <input .value=${album.release} type="text" name="release" id="album-release" placeholder="Release date" />
            <input .value=${album.label} type="text" name="label" id="album-label" placeholder="Label" />
            <input .value=${album.sales} type="text" name="sales" id="album-sales" placeholder="Sales" />

            <button type="submit">post</button>
          </form>
        </div>
      </section>`;

export async function showEdit(ctx) {
    const album = await get('/data/albums/' + ctx.params.id);
    ctx.render(editTemplate(album, createSubmitHandler(onEdit)));

    async function onEdit({ singer, album, imageUrl, release, label, sales }) {
        if (!singer || !album || !imageUrl || !release || !label || !sales) {
            return alert("All fields are required!");
        }
        await put('/data/albums/' + ctx.params.id, { singer, album, imageUrl, release, label, sales });
        ctx.page.redirect('/dashboard/' + ctx.params.id);
    }
}