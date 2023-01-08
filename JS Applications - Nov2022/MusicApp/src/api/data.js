import { del, get, post, put } from "./api.js";

const endpoints = {
    'albums': '/data/albums',
    'getAllAlbums': '/data/albums?sortBy=_createdOn%20desc&distinct=name',
    'singleAlbum': '/data/albums/'
}

export async function createAlbum(data) {
    return post(endpoints.albums, data);
}

export async function getAllAlbums() {
    return get(endpoints.getAllAlbums);
}

export async function getDetailsById(id) {
    return get(endpoints.albums + '/' + id);
}

export async function deleteItemById(id) {
    return del(endpoints.singleAlbum, id);
}

// export async function editPet(id, petData) {
//     return put('/data/pets/' + id, petData);
// }