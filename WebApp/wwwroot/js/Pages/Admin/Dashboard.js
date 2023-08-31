
const canvas2 = document.getElementById('canvas2');
var ctx2 = canvas2.getContext('2d');
new Chart(ctx2, {
    type: 'doughnut',
    data: {
        labels: ['Musica', 'Deportes','Fiestas','Autos'],
        datasets: [{
            label: '# of Votes',
            data: [40,25,5,15,15],
            borderWidth: 1,
            backgroundColor: ['rgba(255, 99, 132, 0.6)', 'rgba(255, 205, 86, 0.6)', 'rgba(75, 192, 192, 0.6)', 'rgba(153, 102, 255, 0.6)', 'rgba(255, 159, 64, 0.6)']
        }]
    },
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

const canvas = document.getElementById('canvas-linechart');
var ctx = canvas.getContext('2d');

async function populateChartWithRandomData() {

   
    
        const totalAmount = await retrieveGanancias();

        if (totalAmount !== null) {
            const fivePercent = totalAmount * 0.05;
            updateTotalGananciasDisplay(fivePercent);
            
    if (fivePercent !== null) {
        updateTotalGananciasDisplay(fivePercent);
        const eventLabels = ['Membresias', 'Comisiones'];
      

        const chartData = {
            labels: eventLabels,
            datasets: [{
                label: '# of Votes',
                data: [150000,fivePercent],
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
  


}


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
    const h4Tag = document.getElementById('ganaciasComisiones');
    if (h4Tag) {
        h4Tag.textContent = `$${totalAmount.toFixed(2)}`;
    }

    const total = document.getElementById('total');

    const totalTotal = parseFloat(totalAmount) + 150000; // Convert to number and add 150000
    total.textContent = `$${totalTotal.toFixed(2)}`;
}