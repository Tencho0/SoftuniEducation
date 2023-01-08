const enumIcon = {
    'Sunny': '&#x2600', // ☀
    'Partly sunny': '&#x26C5', // ⛅
    'Overcast': '&#x2601', // ☁
    'Rain': '&#x2614', // ☂
    'Degrees': '&#176',   // °
};

const forecastDiv = document.getElementById('forecast');

function attachEvents() {
    document.getElementById('submit').addEventListener('click', getWeather);
}

async function getWeather() {
    const location = document.getElementById('location');

    try {
        const url = 'http://localhost:3030/jsonstore/forecaster/locations';
        const response = await fetch(url);
        const data = await response.json();

        const info = data.find(x => x.name === location.value);
        createForcaster(info.code);
    } catch (error) {
        forecastDiv.textContent = 'Error';
        forecastDiv.style.display = 'block';
    }
}

async function createForcaster(code) {
    const currentDiv = document.getElementById('current');
    const upcomingDiv = document.getElementById('upcoming');
    const urlToday = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
    const urlUpComing = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;

    try {
        const responseToday = await fetch(urlToday);
        const dataToday = await responseToday.json();

        const responseUpComing = await fetch(urlUpComing);
        const dataUpComing = await responseUpComing.json();

        forecastDiv.style.display = 'block';
        const todayHTMLTemp = createToday(dataToday);
        currentDiv.appendChild(todayHTMLTemp);

        const upComingHTMLTemp = createUpComing(dataUpComing);
        upcomingDiv.appendChild(upComingHTMLTemp);
    } catch (error) {
        forecastDiv.textContent = 'Error';
        forecastDiv.style.display = 'block';
    }
}

function createToday(data) {
    const forecastDiv = document.createElement('div');
    forecastDiv.classList.add('forecast');

    const spanConditionSymbol = document.createElement('span');
    spanConditionSymbol.classList.add('condition', 'symbol');
    spanConditionSymbol.innerHTML = enumIcon[data.forecast.condition];

    const spanConditionContainer = document.createElement('span');
    spanConditionContainer.classList.add('condition');

    const spanName = document.createElement('span');
    spanName.classList.add('forecast-data');
    spanName.textContent = data.name;

    const spanTemp = document.createElement('span');
    spanTemp.classList.add('forecast-data');
    spanTemp.innerHTML = `${data.forecast.low}${enumIcon['Degrees']}/${data.forecast.high}${enumIcon['Degrees']}`;


    const spanCondition = document.createElement('span');
    spanCondition.classList.add('forecast-data');
    spanCondition.textContent = data.forecast.condition;

    spanConditionContainer.appendChild(spanName);
    spanConditionContainer.appendChild(spanTemp);
    spanConditionContainer.appendChild(spanCondition);
    forecastDiv.appendChild(spanConditionSymbol);
    forecastDiv.appendChild(spanConditionContainer);
    return forecastDiv;
}

function createUpComing(data) {
    const forecastInfoDiv = document.createElement('div');
    forecastInfoDiv.classList.add('forecast-info');

    const firstDaySpan = createPerDay(data.forecast[0]);
    const secondDaySpan = createPerDay(data.forecast[1]);
    const thirdDaySpan = createPerDay(data.forecast[2]);

    forecastInfoDiv.appendChild(firstDaySpan);
    forecastInfoDiv.appendChild(secondDaySpan);
    forecastInfoDiv.appendChild(thirdDaySpan);

    return forecastInfoDiv;
}

function createPerDay(data) {

    const spanUpComing = document.createElement('span');
    spanUpComing.classList.add('upcoming');

    const spanSymbol = document.createElement('span');
    spanSymbol.classList.add('symbol');
    spanSymbol.innerHTML = enumIcon[data.condition];

    const spanTemp = document.createElement('span');
    spanTemp.classList.add('forecast-data');
    spanTemp.innerHTML = `${data.low}${enumIcon['Degrees']}/${data.high}${enumIcon['Degrees']}`;

    const spanCondition = document.createElement('span');
    spanCondition.classList.add('forecast-data');
    spanCondition.textContent = data.condition;

    spanUpComing.appendChild(spanSymbol);
    spanUpComing.appendChild(spanTemp);
    spanUpComing.appendChild(spanCondition);
    return spanUpComing;
}

attachEvents();