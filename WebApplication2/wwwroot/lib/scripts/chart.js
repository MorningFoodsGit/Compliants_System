google.charts.load('current', { packages: ['corechart'] });
google.charts.setOnLoadCallback(fetchAndPlotData);

function fetchAndPlotData() {
    $.ajax({
        url: '/ControllerName/GetRetailerQuantities', // Adjust the URL based on your controller
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            drawChart(data);
        },
        error: function (error) {
            console.log('Error:', error);
        }
    });
}

function drawChart(data) {
    var dataTable = new google.visualization.DataTable();
    dataTable.addColumn('string', 'Retailer');
    dataTable.addColumn('number', 'Quantity');

    data.forEach(item => {
        dataTable.addRow([item.Retailer, item.Quantity]);
    });

    var options = {
        title: 'Retailer Quantities',
        width: 800,
        height: 400,
        legend: { position: 'none' },
        chartArea: { width: '70%' }
    };

    var chart = new google.visualization.BarChart(document.getElementById('retailerChart'));
    chart.draw(dataTable, options);
}