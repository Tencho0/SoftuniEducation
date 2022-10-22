class footballTeam {
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }
    newAdditions(footballPlayers) {
        let names = [];
        for (const iterator of footballPlayers) {
            let [name, age, playerValue] = iterator.split('/');
            age = Number(age);
            playerValue = Number(playerValue);
            let player = this.invitedPlayers.find(x => x.name == name);
            if (player) {
                if (playerValue > player.playerValue) {
                    player.playerValue = playerValue;
                }
            } else {
                this.invitedPlayers.push({ name, age, playerValue });
                names.push(name);
            }
        }
        return `You successfully invite ${names.join(', ')}.`;
    }
    signContract(selectedPlayer) {
        let [name, playerOffer] = selectedPlayer.split('/');
        let player = this.invitedPlayers.find(x => x.name == name);

        if (!player) {
            throw new Error(`${name} is not invited to the selection list!`);
        }

        if (playerOffer < player.playerValue) {
            let priceDifference = player.playerValue - playerOffer;
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${priceDifference} million more are needed to sign the contract!`);
        }

        player.playerValue = 'Bought';
        return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`;
    }
    ageLimit(name, age) {
        let player = this.invitedPlayers.find(x => x.name == name);

        if (!player) {
            throw new Error(`${name} is not invited to the selection list!`);
        }

        if (player.age < age) {
            let ageDifference = age - player.age;
            if (ageDifference <= 5) {
                return `${name} will sign a contract for ${ageDifference} years with ${this.clubName} in ${this.country}!`;
            }

            return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
        } else {
            return `${name} is above age limit!`;
        }
    }
    transferWindowResult() {
        let result = 'Players list:\n';
        Array.from(this.invitedPlayers.sort((a,b) => a.name.localeCompare(b.name))).forEach(player => {
            result += `Player ${player.name}-${player.playerValue}\n`;
        });
        return result.trimEnd();
    }
}

let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.signContract("Kylian Mbappé/240"));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.transferWindowResult());
