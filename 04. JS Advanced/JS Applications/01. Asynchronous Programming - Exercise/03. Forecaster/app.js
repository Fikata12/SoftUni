async function attachEvents() {
    const emojis = {
        "Sunny": '☀',
        "Partly sunny": '⛅',
        "Overcast": '☁',
        "Rain": '☂',
        "Degrees": '°',
    }

    const submit = document.getElementById("submit");
    const current = document.getElementById("current");
    const upcoming = document.getElementById("upcoming");
    const forecast = document.getElementById("forecast");
    const allLocations = await (await fetch("http://localhost:3030/jsonstore/forecaster/locations")).json();

    submit.addEventListener("click", async () => {
        try {
            let locationName = document.getElementById("location");
            let location = allLocations.find(l => l.name == locationName.value);
            let [currentData, upcomingData] = await Promise.all([
                (await fetch(`http://localhost:3030/jsonstore/forecaster/today/${location.code}`)).json(),
                (await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${location.code}`)).json()
            ]);

            current.appendChild(generateToday(currentData));
            upcoming.appendChild(generateUpcoming(upcomingData));
            forecast.style.display = "";
        }
        catch (error) {
            forecast.style.display = "";
            forecast.textContent = "Error";
        }
    });

    function generateToday(todayObj) {
        let div = document.createElement("div");
        div.classList.add("forecasts");

        let span1 = document.createElement("span");
        span1.classList.add("symbol");
        span1.textContent = emojis[todayObj.forecast.condition];
        div.appendChild(span1);

        let span2 = document.createElement("span");
        span2.classList.add("condition");
        div.appendChild(span2);

        let span3 = document.createElement("span");
        span3.classList.add("forecast-data");
        span3.textContent = todayObj.name;
        span2.appendChild(span3);

        let span4 = document.createElement("span");
        span4.classList.add("forecast-data");
        span4.textContent = `${todayObj.forecast.low}${emojis.Degrees}/${todayObj.forecast.high}${emojis.Degrees}`;
        span2.appendChild(span4);

        let span5 = document.createElement("span");
        span5.classList.add("forecast-data");
        span5.textContent = todayObj.forecast.condition;
        span2.appendChild(span5);

        return div;
    }
    function generateUpcoming(upcomingObj) {
        let div = document.createElement("div");
        div.classList.add("forecast-info");
        for (const day of upcomingObj.forecast) {
            let mainSpan = document.createElement("span");
            mainSpan.classList.add("upcoming");

            let span1 = document.createElement("span");
            span1.classList.add("symbol");
            span1.textContent = emojis[day.condition];
            mainSpan.appendChild(span1);

            let span2 = document.createElement("span");
            span2.classList.add("forecast-data");
            span2.textContent = `${day.low}${emojis.Degrees}/${day.high}${emojis.Degrees}`;
            mainSpan.appendChild(span2);

            let span3 = document.createElement("span");
            span3.classList.add("forecast-data");
            span3.textContent = day.condition;
            mainSpan.appendChild(span3);

            div.appendChild(mainSpan);
        }
        return div;
    }
}

attachEvents();