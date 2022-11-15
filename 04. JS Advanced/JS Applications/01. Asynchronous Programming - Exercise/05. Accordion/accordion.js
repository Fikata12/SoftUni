async function solution() {
    let sections = await (await fetch("http://localhost:3030/jsonstore/advanced/articles/list")).json();
    let main = document.getElementById("main");

    for (const item of sections) {
        let paragraph = await (await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${item._id}`)).json();
        main.innerHTML += `<div class="accordion">
                           <div class="head">
                           <span>${item.title}</span>
                           <button class="button" id="${item._id}">More</button>
                           </div>
                           <div class="extra">
                           <p>${paragraph.content}</p>
                           </div>
                           </div>`;
    }
    let allButtons = Array.from(document.querySelectorAll(".accordion button"));
    for (let button of allButtons) {
        button.addEventListener("click", () => {
            if (button.textContent == "More") {
                button.textContent = "Less";
                let extra = button.parentElement.parentElement.getElementsByClassName('extra')[0];
                extra.style.display = "block";
            }
            else {
                button.textContent = "More";
                let extra = button.parentElement.parentElement.getElementsByClassName('extra')[0];
                extra.style.display = 'none';
            }
        });
    }
}
solution();