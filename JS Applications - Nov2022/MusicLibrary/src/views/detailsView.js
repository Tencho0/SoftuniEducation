import { deleteItemById, getDetailsById } from '../api/data.js'; //"../api/data.js";
import { getLikes, getOwnLike, like } from '../api/like.js';
import { html, nothing } from '../lib.js'; //"../lib.js";

const detailsTemp = (album, likes, canLike, isOwner, onLike, onDelete) => html`
<section id="details">
    <div id="details-wrapper">
        <p id="details-title">Album Details</p>
        <div id="img-wrapper">
            <img src="./images/BackinBlack.jpeg" alt="example1" />
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
        <div id="likes">Likes: <span id="likes-count">${likes}</span></div>

        <div id="action-buttons">
            ${canLike ? html`
            <a @click=${onLike} href="javascript:void(0)" id="like-btn">Like</a>`
         : nothing}
            ${isOwner ? html`
            <a href="/edit/${album._id}" id="edit-btn">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>`
        : nothing}
        </div>
    </div>
</section>`;


export async function showDetails(ctx) {
    const id = ctx.params.id;

    const requests = [
        getDetailsById(id),
        getLikes(id)
    ];

    const hasUser = Boolean(ctx.user) // !!ctx.user
    if (hasUser) {
        requests.push(getOwnLike(id, ctx.user._id))
    }
    const [album, likes] = await Promise.all(requests);

    const isOwner = hasUser && ctx.user._id == album._ownerId; //album._ownerId === ctx.user._id;
    const canLike = !isOwner;

    ctx.render(detailsTemp(album, likes, canLike, isOwner, onLike, onDelete));

    async function onDelete() {
        const userConfirm = confirm('Are you sure?');
        if (userConfirm) {
            await deleteItemById(id);
            ctx.page.redirect('/catalog');
        }
    }
    async function onLike() {
        await like(id);
        ctx.page.redirect('/catalog/' + id);
    }
}