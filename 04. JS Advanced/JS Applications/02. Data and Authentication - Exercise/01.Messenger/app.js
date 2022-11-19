function attachEvents() {
    let submit = document.querySelector("#submit");
    let refresh = document.querySelector("#refresh");

    submit.addEventListener("click", () => {
        let author = document.querySelector("[name=author]");
        let content = document.querySelector("[name=content]");

        let data = {
            author: author.value,
            content: content.value,
        };

        fetch("http://localhost:3030/jsonstore/messenger", {
            method: "post",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        });
    });

    refresh.addEventListener("click", async () => {
        let messages = document.querySelector("#messages");

        let data = await (await fetch("http://localhost:3030/jsonstore/messenger")).json();
        let result = "";
        for (const message of Object.values(data)) {
            result += `${message.author}: ${message.content}\n`;
        }
        messages.textContent = result.trim();
    });
}

attachEvents();