async function getInfo() {
    let stopId = document.getElementById('stopId');
    let stopName = document.getElementById('stopName');
    let buses = document.getElementById('buses');
    stopName.textContent = "";
    buses.innerHTML = "";
    try {
        const data = await (await fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId.value}`)).json();
        stopName.textContent = data.name;
        for (const bus in data.buses) {
            let li = document.createElement('li');
            li.textContent = `Bus ${bus} arrives in ${data.buses[bus]} minutes`;
            buses.appendChild(li);
        }
    } catch (error) {
        stopName.textContent = "Error";
    }
}