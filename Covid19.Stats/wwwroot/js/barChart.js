function BuildBarChart(labels, cases, canvasId, chartName) {
    this.labels = labels;
    const defaultColor = 'rgb(0, 154, 207)'

    const data = {
        labels: labels,
        datasets: [{
            label: chartName,
            backgroundColor: defaultColor,
            borderColor: defaultColor,
            data: cases, }]
    };


    const config = {
        type: 'bar',
        data: data,
        options: {}
    };

    const ch = new Chart(
        document.getElementById(canvasId),
        config
    );

}