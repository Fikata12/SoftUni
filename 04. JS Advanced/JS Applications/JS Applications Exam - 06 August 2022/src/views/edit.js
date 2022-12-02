import { get, put } from "../api/api.js";
import { html } from "../api/lib.js";
import { createSubmitHandler } from "../api/util.js";

const editTemplate = (offer, onEdit) => html`
        <section id="edit">
            <div class="form">
                <h2>Edit Offer</h2>
                <form @submit=${onEdit} class="edit-form">
                    <input .value=${offer.title} type="text" name="title" id="job-title" placeholder="Title" />
                    <input .value=${offer.imageUrl} type="text" name="imageUrl" id="job-logo" placeholder="Company logo url" />
                    <input .value=${offer.category} type="text" name="category" id="job-category" placeholder="Category" />
                    <textarea .value=${offer.description} id="job-description" name="description" placeholder="Description"
                        rows="4" cols="50"></textarea>
                    <textarea .value=${offer.requirements} id="job-requirements" name="requirements" placeholder="Requirements"
                        rows="4" cols="50"></textarea>
                    <input .value=${offer.salary} type="text" name="salary" id="job-salary" placeholder="Salary" />
        
                    <button type="submit">post</button>
                </form>
            </div>
        </section>`;

export async function showEdit(ctx) {
    const offer = await get('/data/offers/' + ctx.params.id);
    ctx.render(editTemplate(offer, createSubmitHandler(onEdit)));

    async function onEdit({ title, imageUrl, category, description, requirements, salary }) {
        if (!title || !imageUrl || !category || !description || !requirements || !salary) {
            return alert("All fields are required!");
        }
        await put('/data/offers/' + ctx.params.id, { title, imageUrl, category, description, requirements, salary });
        ctx.page.redirect('/dashboard/' + ctx.params.id);
    }
}