class SummerCamp {
    constructor(organizer, location) {
        this.priceForTheCamp = { "child": 150, "student": 300, "collegian": 500 };
        this.listOfParticipants = [];
        this.organizer = organizer;
        this.location = location;
    }
    registerParticipant(name, condition, money) {
        if (!this.priceForTheCamp[condition]) {
            throw new Error('Unsuccessful registration at the camp.');
        }

        if (this.listOfParticipants.some(x => x.name == name)) {
            return `The ${name} is already registered at the camp.`;
        }

        //if (money <= this.priceForTheCamp[condition]) {
        if (money < this.priceForTheCamp[condition]) {
            return `The money is not enough to pay the stay at the camp.`;
        }

        this.listOfParticipants.push({ name, condition, power: 100, wins: 0 });
        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant(name) {

        let participant = this.listOfParticipants.find(x => x.name == name);
        if (!participant) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        numbers.splice(this.listOfParticipants.indexOf(participant), 1);
        return `The ${name} removed successfully.`;
    }

    timeToPlay(typeOfGame, participant1, participant2) {

    }
}