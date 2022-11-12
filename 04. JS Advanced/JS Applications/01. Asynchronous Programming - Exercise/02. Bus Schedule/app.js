function solve() {
    let info = document.querySelector("#info span");
    let departBtn = document.getElementById("depart");
    let arriveBtn = document.getElementById("arrive");
    let nextStop = "depot";

    async function depart() {
        let data = await (await fetch("http://localhost:3030/jsonstore/bus/schedule/" + nextStop)).json();
        info.textContent = `Next stop ${data.name}`;
        departBtn.disabled = true;
        arriveBtn.disabled = false;
    }

    async function arrive() {
        let data = await (await fetch("http://localhost:3030/jsonstore/bus/schedule/" + nextStop)).json();
        info.textContent = `Arriving at ${data.name}`;
        departBtn.disabled = false;
        arriveBtn.disabled = true;
        nextStop = data.next;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();