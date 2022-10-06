function attachEventsListeners() {
    let divs = Array.from(document.getElementsByTagName('div'));
    for (const div of divs) {
        Array.from(div.children).filter(d => d.type == 'button')[0].addEventListener('click', function(){
            let input = Array.from(div.children).filter(ch => ch.type == 'text')[0];
            let days = document.getElementById('days');
            let hours = document.getElementById('hours');
            let minutes = document.getElementById('minutes');
            let seconds = document.getElementById('seconds');
            if (input.id == 'days') {
                hours.value = days.value * 24;
                minutes.value = days.value * 1440;
                seconds.value = days.value * 86400;
            } 
            else if (input.id == 'hours') {
                days.value = hours.value / 24;
                minutes.value = hours.value * 60;
                seconds.value = hours.value * 60 * 60;
            }
            else if (input.id == 'minutes') {
                hours.value = minutes.value / 60;
                days.value = minutes.value / 60 / 24;
                seconds.value = minutes.value * 60;
            }
            else if (input.id == 'seconds') {
                hours.value = seconds.value / 60 / 60;
                minutes.value = seconds.value / 60;
                days.value = seconds.value / 60 / 60 / 24;
            }
        })
    }
}