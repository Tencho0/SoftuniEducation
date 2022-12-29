import { editAlbum, getDetailsById } from "../api/data.js";
import { html } from "../lib.js";
import { createSubmitHandler } from "../util.js";

const editTemp = (album, handler) => html`    
<section id="edit">
    <div class="form">
        <h2>Edit Album</h2>
        <form @submit=${handler} class="edit-form">
            <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" .value=${album.singer} />
            <input type="text" name="album" id="album-album" placeholder="Album" .value=${album.album} />
            <input type="text" name="imageUrl" id="album-img" placeholder="Image url" .value=${album.imageUrl} />
            <input type="text" name="release" id="album-release" placeholder="Release date" .value=${album.release} />
            <input type="text" name="label" id="album-label" placeholder="Label" .value=${album.label} />
            <input type="text" name="sales" id="album-sales" placeholder="Sales" .value=${album.sales} />

            <button type="submit">post</button>
        </form>
    </div>
</section>`;

export async function showEdit(ctx) {
    const id = ctx.params.id;
    const album = await getDetailsById(id);
    ctx.render(editTemp(album, createSubmitHandler(onEdit)));
    async function onEdit(data) {
        const {
            singer,
            album,
            imageUrl,
            release,
            label,
            sales
        } = data;
        if (!singer || !album || !imageUrl || !release || !label || !sales) {
            return alert('All fields are required!')
        }
        await editAlbum(id, data);
        // ctx.page.redirect(`/details/` + id);
        ctx.page.redirect(`/details/${id}`);
    }
}







// import { html } from '../../node_modules/lit-html/lit-html.js';
// import { editItem } from '../services/dataService.js';

// const editTemplate = (album, onSubmit) => html`<section id="edit">
//     <div class="form">
//         <h2>Edit Album</h2>
//         <form @submit =${onSubmit} class="edit-form">
//             <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" />
//             <input type="text" name="album" id="album-album" placeholder="Album" />
//             <input type="text" name="imageUrl" id="album-img" placeholder="Image url" />
//             <input type="text" name="release" id="album-release" placeholder="Release date" />
//             <input type="text" name="label" id="album-label" placeholder="Label" />
//             <input type="text" name="sales" id="album-sales" placeholder="Sales" />

//             <button type="submit">post</button>
//         </form>
//     </div>
// </section>`;

// export const showEdit = async (ctx) => {
//     ctx.render(editTemplate(ctx.data, createSubmitHandler(onSubmit)));

//     async function onSubmit(data) {
//         if (data.values.includes('')) return alert('All fields are required')

//         await editItem(ctx.params.id, data);
//         ctx.page.redirect(`/details/${ctx.data._id}`);
//     }
// }