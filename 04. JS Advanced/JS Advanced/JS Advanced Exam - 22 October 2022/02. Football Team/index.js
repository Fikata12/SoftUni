class footballTeam {
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }
    newAdditions(footballPlayers) {
        let invited = [];
        for (const footballPlayer of footballPlayers) {
            let [name, age, playerValue] = footballPlayer.split('/');
            let player = this.invitedPlayers.find(p => p.name == name);
            if (player) {
                if (player.playerValue < playerValue) {
                    player.playerValue = playerValue;
                }
            }
            else {
                this.invitedPlayers.push({
                    name: name,
                    age: age,
                    playerValue: playerValue
                });
                invited.push(name);
            }
        }
        return `You successfully invite ${invited.join(', ')}.`
    }
    signContract(selectedPlayer) {
        let [name, playerOffer] = selectedPlayer.split('/');
        let player = this.invitedPlayers.find(p => p.name == name);
        if (player) {
            if (player.playerValue > playerOffer) {
                throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${player.playerValue - playerOffer} million more are needed to sign the contract!`);
            }
            player.playerValue = "Bought";
            return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`
        }
        throw new Error(`${name} is not invited to the selection list!`);
    }
    ageLimit(name, age) {
        let player = this.invitedPlayers.find(p => p.name == name);
        if (player) {
            if (player.age < age) {
                if (age - player.age < 5) {
                    return `${name} will sign a contract for ${age - player.age} years with ${this.clubName} in ${this.country}!`
                }
                return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`
            }
            return `${name} is above age limit!`
        }
        throw new Error(`${name} is not invited to the selection list!`)
    }
    transferWindowResult() {
        let result = "Players list:\n";
        for (const player of this.invitedPlayers.sort((a, b) => a.name.localeCompare(b.name))) {
            result += `Player ${player.name}-${player.playerValue}\n`;
        }
        return result.trim();
    }
}