async function getInfo() {
    const stopNameElement = document.getElementById('stopName');
    const timeTableElement = document.getElementById('buses');
    const submitBtn = document.getElementById('submit');

    const stopId = document.getElementById('stopId').value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;

    try {
        stopNameElement.textContent = 'Loading...';
        timeTableElement.replaceChildren();
        //submitBtn.disabled = true;

        const res = await fetch(url);

        if (res.status !== 200) {
            //alert('Stop ID not found!');
            throw new Error('Stop ID not found!');
        }
        const data = await res.json();

        stopNameElement.textContent = data.name;
        Object.entries(data.buses).forEach(b => {
            const liElement = document.createElement('li');
            liElement.textContent = `Bus ${b[0]} arrives in ${b[1]} minutes`;
            timeTableElement.appendChild(liElement);
            console.log(b);
        });

    } catch (error) {
        stopNameElement.textContent = 'Error';
    }
}