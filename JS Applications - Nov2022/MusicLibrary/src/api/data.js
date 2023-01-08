import { del, get, post, put } from "./api.js";

const endpoints = {
    'createNewAlbum': '/data/albums',
    'getAllAlbums': '/data/albums?sortBy=_createdOn%20desc',
    'singleAlbum': '/data/albums/'
}

export async function createAlbum(data) {
    return post(endpoints.createNewAlbum, data);
}

export async function getAllAlbums() {
    return get(endpoints.getAllAlbums);
}

export async function getDetailsById(id) {
    return get(endpoints.singleAlbum + id);
}

export async function deleteItemById(id) {
    return del(endpoints.singleAlbum + id);
}

// export async function editItem(id, albumData) {
//     return put(endpoints.singleAlbum + id, albumData);
// }

export async function editAlbum(id, data) {
    return put(endpoints.singleAlbum + id, data);
}