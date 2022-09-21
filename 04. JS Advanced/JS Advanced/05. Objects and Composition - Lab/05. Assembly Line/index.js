function func() {
    return {
        hasClima(obj) {
            obj.temp = 21;
            obj.tempSettings = 21;
            obj.adjustTemp = () => {
                if ((temp < tempSettings)) {
                    temp++;
                } else if ((temp > tempSettings)) {
                    temp--;
                }
            }
        },
        hasAudio(obj) {
            obj.currentTrack = {
                name: null,
                artist: null
            }
            obj.nowPlaying = () => console.log(`Now playing '${currentTrack.name}' by ${currentTrack.artist}`);
        },
        hasParktronic(obj) {
            obj.checkDistance = (distance) => {
                if (distance < 0.1) {
                    console.log("Beep! Beep! Beep!");
                } 
                else if (distance >= 0.1 && distance < 0.25) {
                    console.log("Beep! Beep!");
                }
                else if (distance >= 0.25 && distance < 0.5) {
                    console.log("Beep!");
                }
                else {
                    console.log("");
                }
            }
        }
    }
}