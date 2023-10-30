google.charts.load('current', { packages: ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Retailer');
    data.addColumn('string', 'Product Code');
    data.addColumn('string', 'Product Description');

    var cmplnt_base = @Html.Raw(Json.Serialize(ViewBag.cmplnt_base)); // Convert ViewBag data to JavaScript object

    for (var i = 0; i < cmplnt_base.length; i++) {
        data.addRow([cmplnt_base[i].rtlr, cmplnt_base[i].prdct_cde_mf, cmplnt_base[i].prdct_desc]);
    }

    var options = {
        title: 'Retailer vs Product Code',
        hAxis: { title: 'Retailer' },
        vAxis: { title: 'Product Code' },
        width: '100%',
        height: 400
    };

    var chart = new google.visualization.ScatterChart(document.getElementById('chart_div'));
    chart.draw(data, options);

    google.visualization.events.addListener(chart, 'select', selectHandler);

    function selectHandler() {
        var selectedItem = chart.getSelection()[0];
        if (selectedItem) {
            var retailer = data.getValue(selectedItem.row, 0);
            var productCode = data.getValue(selectedItem.row, 1);
            var productDesc = data.getValue(selectedItem.row, 2);

            console.log('Retailer: ' + retailer);
            console.log('Product Code: ' + productCode);
            console.log('Product Description: ' + productDesc);
        }
    }
}