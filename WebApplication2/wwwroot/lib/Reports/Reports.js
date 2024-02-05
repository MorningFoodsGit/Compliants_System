google.load('visualization', '1.0', { 'packages': ['corechart'] });

// Set a callback to run when the Google Visualization API is loaded.
google.setOnLoadCallback(drawBarStacked);

// Callback that creates and populates a data table, instantiates the pie chart, passes in the data and draws it.
function drawBarStacked() {

    // Create the data table.
    var data = google.visualization.arrayToDataTable([
        ['Genre', 'MornFlake', 'ALDI', 'LIDL', 'Asda', 'Co-op', 'Sainsbury', 'Tesco', { role: 'annotation' }],
        ['Crisp', 10, 15, 25, 35, 45, 23, 45, ''],
        ['Flake', 12, 20, 25, 32, 36, 34, 55, ''],
        ['Granola', 5, 24, 20, 34, 17, 24, 32, ''],
        ['Muesli', 18, 25, 30, 38, 24, 13, 21, ''],
        ['Oats', 16, 22, 23, 28, 15, 22, 36, ''],
        ['Pots', 8, 26, 20, 42, 30, 31, 40, ''],
        ['Sachets', 24, 17, 24, 35, 14, 37, 19, ''],
        ['Squares', 19, 12, 24, 45, 17, 20, 50, '']
    ]);

    // Set chart options
    var options_bar_stacked = {
        height: 400,
        fontSize: 12,
        colors: ['#f5bd05', '#05c9f5', '#edf505', '#6df505', '#19c3f7', '#f78c19', '#f72b19'],
        chartArea: {
            left: '5%',
            width: '90%',
            height: 350
        },
        isStacked: true,
        hAxis: {
            gridlines: {
                color: '#e9e9e9',
                count: 10
            },
            minValue: 0
        },
        legend: {
            position: 'top',
            alignment: 'center',
            textStyle: {
                fontSize: 12
            }
        }
    };

    // Instantiate and draw our chart, passing in some options.
    var bar = new google.visualization.BarChart(document.getElementById('stacked-bar-chart'));
    bar.draw(data, options_bar_stacked);

}


// Resize chart
// ------------------------------

$(function () {

    // Resize chart on menu width change and window resize
    $(window).on('resize', resize);
    $(".menu-toggle").on('click', resize);

    // Resize function
    function resize() {
        drawBarStacked();
    }
});