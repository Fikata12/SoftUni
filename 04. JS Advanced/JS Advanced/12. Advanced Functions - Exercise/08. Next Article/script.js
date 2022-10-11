function getArticleGenerator(articles) {
    let allArticles = articles;
    let div = document.getElementById('content');
    let counter = 0;
    for (let i = 0; i < allArticles.length; i++) {
        return function() {
            if (counter != allArticles.length) {
                let article = document.createElement('article');
                article.textContent = allArticles[counter++];
                div.appendChild(article);
            }
        };
    }
}
