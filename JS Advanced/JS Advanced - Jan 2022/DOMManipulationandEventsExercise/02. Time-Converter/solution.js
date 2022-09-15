function attachEventsListeners() {

    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');

    let rations = {
        days: 1,
        hours: 24,
        minutes: 1440,
        seconds: 864000
    };

    document.getElementById('daysBtn').addEventListener('click', onConvert);
    document.getElementById('hoursBtn').addEventListener('click', onConvert);
    document.getElementById('minutesBtn').addEventListener('click', onConvert);
    document.getElementById('secondsBtn').addEventListener('click', onConvert);

    function onConvert(event) {
        let input = event.target.parentElement.querySelector('input[type="text"]');
        let time = convert(Number(input.value), input.id);
        days.value = time.days;
        hours.value = time.hours;
        minutes.value = time.minutes;
        seconds.value = time.seconds;
    }

    function convert(value, unit) {
        let days = value / rations[unit];
        return {
            days: days,
            hours: days * rations.hours,
            minutes: days * rations.minutes,
            seconds: days * rations.seconds
        };
    }
}


// function attachEventsListeners() {
//     let daysInput = document.getElementById('days');
//     let hoursInput = document.getElementById('hours');
//     let minutesInput = document.getElementById('minutes');
//     let secondsInput = document.getElementById('seconds');
 
//     let daysBtn = document.getElementById('daysBtn');
//     let hoursBtn = document.getElementById('hoursBtn');
//     let minutesBtn = document.getElementById('minutesBtn');
//     let secondsBtn = document.getElementById('secondsBtn');
 
//     daysBtn.addEventListener('click', function() {
//         let days = daysInput.value;
//         hoursInput.value = days * 24;
//         minutesInput.value = days * 1440;
//         secondsInput.value = days * 86400;
//     });
 
//     hoursBtn.addEventListener('click', function() {
//         let hours = hoursInput.value;
//         daysInput.value = hours / 24;
//         minutesInput.value = hours * 60;
//         secondsInput.value = hours * 60 * 60;
//     });
 
//     minutesBtn.addEventListener('click', function() {
//         let minutes = minutesInput.value;
//         hoursInput.value = minutes / 60;
//         daysInput.value = minutes / 60 / 24;
//         secondsInput.value = minutes * 60;
//     });
 
//     secondsBtn.addEventListener('click', function() {
//         let seconds = secondsInput.value;
//         hoursInput.value = seconds / 60 / 60;
//         minutesInput.value = seconds / 60;
//         daysInput.value = seconds / 60 / 60 / 24;
//     });
// }