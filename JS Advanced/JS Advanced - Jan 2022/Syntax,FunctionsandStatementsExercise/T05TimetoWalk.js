function solve(steps, footprint, speedKmH) {

    let distance = steps * footprint;
    let rest = Math.floor(distance / 500) * 60;
    let speed = speedKmH * 1000 / 3600;
    let time = (distance / speed) + rest;
    
    let hours = Math.floor(time / 3600).toFixed(0).padStart(2,'0');
    let mins = Math.floor(time / 60).toFixed(0).padStart(2,'0');
    let seconds = (time % 60).toFixed(0).padStart(2,'0');

    console.log( `${hours}:${mins}:${seconds}`);
}

solve(4000, 0.60, 5);