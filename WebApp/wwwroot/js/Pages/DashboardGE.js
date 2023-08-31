
const canvas = document.getElementById('canvas-linechart');
var ctx = canvas.getContext('2d');

async function populateChartWithRandomData() {

    const totalAmount = await retrieveGanancias();

    if (totalAmount !== null) {
        updateTotalGananciasDisplay(totalAmount);
        const eventLabels = ['Evento 1', 'Evento 2', 'Evento 3', 'Evento 4'];
        const randomAmounts = generateRandomAmounts(eventLabels.length, totalAmount);

        const chartData = {
            labels: eventLabels,
            datasets: [{
                label: '# of Votes',
                data: randomAmounts,
                borderWidth: 1,
                backgroundColor: ['rgba(255, 99, 132, 0.6)', 'rgba(255, 205, 86, 0.6)', 'rgba(75, 192, 192, 0.6)', 'rgba(153, 102, 255, 0.6)', 'rgba(255, 159, 64, 0.6)']
            }]
        };

        new Chart(ctx, {
            type: 'doughnut',
            data: chartData,
            options: {
                plugins: {
                    legend: {
                        labels: {
                            color: 'white'
                        }
                    }
                }
            }
        });
    }
}

// Function to generate random amounts that total to a given target amount
function generateRandomAmounts(count, totalAmount) {
    const randomAmounts = [];

    for (let i = 0; i < count - 1; i++) {
        const randomValue = Math.random() * totalAmount;
        randomAmounts.push(randomValue);
        totalAmount -= randomValue;
    }

    randomAmounts.push(totalAmount); // Ensure the last value matches the remaining total

    return randomAmounts;
}

populateChartWithRandomData();

async function retrieveGanancias() {
    const apiUrl = 'https://localhost:7152/api/Venta/RetrieveAllVenta';

    try {
        const response = await $.ajax({
            url: apiUrl,
            type: 'GET',
            dataType: 'json'
        });

        if (Array.isArray(response) && response.length > 0) {
            return response[0].ventasTotales;
        } else {
            console.error('Empty or invalid response:', response);
            return null;
        }
    } catch (error) {
        console.error('Error retrieving data:', error);
        return null;
    }
}
function updateTotalGananciasDisplay(totalAmount) {
    const h4Tag = document.getElementById('totalGanancias');
    if (h4Tag) {
        h4Tag.textContent = `$${totalAmount.toFixed(2)}`;
    }
}
