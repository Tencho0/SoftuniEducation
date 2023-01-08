import { createAlbum } from "../api/data.js";
import { html } from "../lib.js";
import { createSubmitHandler } from "../util.js";

const createTemp = (handler) => html`
<section id="create">
    <div class="form">
        <h2>Add Album</h2>
        <form @submit=${handler} class="create-form">
            <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" />
            <input type="text" name="album" id="album-album" placeholder="Album" />
            <input type="text" name="imageUrl" id="album-img" placeholder="Image url" />
            <input type="text" name="release" id="album-release" placeholder="Release date" />
            <input type="text" name="label" id="album-label" placeholder="Label" />
            <input type="text" name="sales" id="album-sales" placeholder="Sales" />

            <button type="submit">post</button>
        </form>
    </div>
</section>`;

export function showCreate(ctx) {
    ctx.render(createTemp(createSubmitHandler(onRegister)));

    async function onRegister(data) {
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
        await createAlbum(data);
        ctx.page.redirect('/catalog');
    }
}