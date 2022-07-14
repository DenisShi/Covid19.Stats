function BuildGeoChart(json_table, canvas_id) {

    google.charts.load('current', {
        'packages': ['geochart'],
    });
    google.charts.setOnLoadCallback(drawRegionsMap);

    function drawRegionsMap() {
        var data = new google.visualization.DataTable(json_table);

        var options = {
            colorAxis: { colors: ['#5499C7', '#2471A3', '#1A5276', '#154360'] },
            legend: 'none',
        };

        var chart = new google.visualization.GeoChart(document.getElementById(canvas_id));

        chart.draw(data, options);
    }
}
