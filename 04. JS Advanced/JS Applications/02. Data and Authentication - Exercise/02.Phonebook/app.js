function attachEvents() {
    let btnLoad = document.querySelector("#btnLoad");
    let btnCreate = document.querySelector("#btnCreate");

    btnLoad.addEventListener("click", async () => {
        let phoneBook = document.querySelector("#phonebook");
        phoneBook.innerHTML = "";

        let data = await (await fetch("http://localhost:3030/jsonstore/phonebook")).json();
        for (const person of Object.values(data)) {
            let li = document.createElement("li");
            li.textContent = `${person.person}: ${person.phone}`;
            li.id = person._id;

            let button = document.createElement("button");
            button.textContent = "Delete";
            button.addEventListener("click", (e) => {
                fetch(`http://localhost:3030/jsonstore/phonebook/${e.target.parentElement.id}`, {
                method: "delete"
                });
                button.parentElement.remove();
            });

            li.appendChild(button);
            phoneBook.appendChild(li);
        }
    });

    btnCreate.addEventListener("click", () => {
        let person = document.querySelector("#person");
        let phone = document.querySelector("#phone");

        let data = {
            person: person.value,
            phone: phone.value
        };

        fetch("http://localhost:3030/jsonstore/phonebook", {
            method: "post",
            body: JSON.stringify(data)
        });
    });
}

attachEvents();