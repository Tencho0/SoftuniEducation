const url = 'http://localhost:3030/jsonstore/messenger';

const messages = document.querySelector('#messages');
const author = document.querySelector('input[name=author]');
const content = document.querySelector('input[name=content]');
const sendBtn = document.querySelector('#submit');
const refreshBtn = document.querySelector('#refresh');

function attachEvents() {
    refreshBtn.addEventListener('click', showMessages);
    sendBtn.addEventListener('click', sendMessage);
}

async function sendMessage() {
    if (author.value && content.value) {
        let info = {
            author: author.value,
            content: content.value
        }
        await request(url, info);

    } else {
        alert('All fields are required');
    }
    author.value = '';
    content.value = '';
}

async function showMessages() {
    let response = await fetch(url);
    let data = await response.json();

    messages.value = Object.values(data)
        .map(x => `${x.author}: ${x.content}`).join('\n');
}


async function request(url, body) {
    if (body) {
        body = {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
            },
            body: JSON.stringify(body)
        }
    }
    let res = await fetch(url, body);
    return await res.json();
}

attachEvents();


// const url = 'http://localhost:3030/jsonstore/messenger';
// const messenges = document.getElementById('messages');

// function attachEvents() {
//     document.getElementById('submit').addEventListener('click', postMessage);
//     document.getElementById('refresh').addEventListener('click', loadAllMessages);
// }

// async function postMessage(e) {
//     // const [author, content] = [document.querySelector('author'), document.getElementById('content')];
//     const [author, content] = [document.querySelector('#controls > input[type=text]:nth-child(2)'), document.getElementById('#controls > input[type=text]:nth-child(5)')];
//     //if (author.value !== '' || content.value !== '') {
//     if (author.value !== '' && content.value !== '') {
//         await request(url, { author: author.value, content: content.value });
//         author.value = '';
//         content.value = '';
//         //   messenges += `${author.value}: ${content.value}`;
//     }
//     //     alert('Fields are required');
// }

// async function loadAllMessages(e) {
//     const res = await fetch(url);
//     const data = await res.json();

//     messages.value = Object.values(data).map(({ author, content }) => `${author}: ${content}`).join('\n');
// }

// async function request(url, option) {

//     if (option) {
//         option = {
//             method: 'POST',
//             headers: {
//                 'Content-Type': 'application/json'
//             },
//             body: JSON.stringify(option)
//         }
//     }
//     const response = await fetch(url, option);
//     return response.json();
// }

// attachEvents();