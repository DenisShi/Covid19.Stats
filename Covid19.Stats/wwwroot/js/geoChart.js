function BuildGeoChart(json_header, json_data, canvas_id) {
    var result = [];
    result.push(json_header)
    for (var i in json_data)
        result.push([i, json_data[i]]);




    google.charts.load('current', {
        'packages': ['geochart'],
    });
    google.charts.setOnLoadCallback(drawRegionsMap);

    function drawRegionsMap() {
        var data = google.visualization.arrayToDataTable(result);

        var options = {
            colorAxis: { colors: ['red'] },

        };

        var chart = new google.visualization.GeoChart(document.getElementById(canvas_id));

        chart.draw(data, options);
    }
}
