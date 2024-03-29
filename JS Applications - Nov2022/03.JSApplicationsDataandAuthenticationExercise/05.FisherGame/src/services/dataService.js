import * as request from './requester.js';

const endpoints = {
    getAllData: '/data/catches',
    create: '/data/catches',
    edit: (id) =>  `/data/catches/${id}`,
    delete: (id) =>  `/data/catches/${id}`,
    filter: (query) => `/data/shoes?where=brand%20LIKE%20%22${query}%22`
}

export const getData = async () => {
    return await request.get(endpoints.getAllData);
}

export const createItem = async (data) => {
    return await request.post(endpoints.create, data);
}

export const getItem = async (id) => {
    return await request.get(endpoints.details(id));
}

export const editItem = async (id, data) => {
    return await request.put(endpoints.edit(id), data)
}

export const deleteItem = async (id) => {
    return await request.del(endpoints.delete(id));
}