import * as api from './api.js';

const endpoints = {
    'ideas': '/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc'
};

export async function getAllIdeas() {
    return api.get(endpoints.ideas);
}