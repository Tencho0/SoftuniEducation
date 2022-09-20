function getArticleGenerator(articles) {

    return () => {
        if (articles.length > 0) {
            let container = document.getElementById('content');
            let article = document.createElement('article');
            let currentText = articles.shift();
            article.innerText = currentText;
            container.appendChild(article);
        }
    };
}
//     // let content = document.getElementById('content');
//     let articlesArr = [];
//     for (const iterator of articles) {
//         let newArticle = document.createElement('article');
//         newArticle.textContent = iterator;
//         // content.appendChild(newArticle);
//         articlesArr.push(newArticle);
//     }
//     return articlesArr;
// }