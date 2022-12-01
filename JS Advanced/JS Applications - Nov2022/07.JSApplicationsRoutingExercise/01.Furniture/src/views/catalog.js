import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAllItem } from "../api/data.js";
import { getItemTemp } from "./fragment/itemsFragment.js"; // `../views/fragment/itemsFragment.js`

export async function catalogView(ctx) {
    const items = await getAllItem();
    ctx.render(catalogTemp(items));
}

function catalogTemp(data) {
    return html`<div class="row space-top">
    <div class="col-md-12">
        <h1>Welcome to Furniture System</h1>
        <p>Select furniture from the catalog to view details.</p>
    </div>
</div>
<div class="row space-top">
    ${Object.values(data).map(x => getItemTemp(x))};
</div>`;
}