function attachEvents() {
    let btnLoadPosts = document.getElementById("btnLoadPosts");
    let btnViewPost = document.getElementById("btnViewPost");

    btnLoadPosts.addEventListener("click", async () => {
        let posts = document.getElementById("posts");
        posts.innerHTML = "";
        let allPosts = await (await fetch("http://localhost:3030/jsonstore/blog/posts")).json();
        for (const post of Object.values(allPosts)) {
            let option = document.createElement('option');
            option.value = post.id;
            option.textContent = post.title;
            posts.appendChild(option);
        }
    });

    btnViewPost.addEventListener("click", async () => {
        let postComments = document.getElementById("post-comments");
        postComments.innerHTML = "";
        let id = document.getElementById("posts").value;
        let post = await (await fetch(`http://localhost:3030/jsonstore/blog/posts/${id}`)).json();
        let comments = await (await fetch(`http://localhost:3030/jsonstore/blog/comments`)).json();

        let postTitle = document.getElementById("post-title");
        postTitle.textContent = post.title;

        let postBody = document.getElementById("post-body");
        postBody = post.body;

        for (const comment of Object.values(comments)) {
            if (comment.postId == post.id) {
                let li = document.createElement("li");
                li.textContent = comment.text;
                li.id = comment.id;
                postComments.appendChild(li);
            }
        }
    });
}

attachEvents();

// 50/100