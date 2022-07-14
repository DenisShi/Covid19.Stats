const defaultColor = 'rgb(0, 154, 207)'

function BuildBarChart(labels, cases, canvasId, chartName) {

    this.labels = labels;
   
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
        options: {
            animations: {
                animation: false
            }
        }
    };

    const ch = new Chart(
        document.getElementById(canvasId),
        config
    );
}

function BuildPieChart(labels, cases, canvasId, chartName) {
    this.labels = labels;

    const data = {
        labels: labels,
        datasets: [{
            label: chartName,
            backgroundColor: defaultColor,
            borderColor: defaultColor,
            data: cases,
        }]
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
function BuildCombinedLineChart(labels, cases, casesSecond, canvasId, chartName, chartNameSecond) {
    var dataFirst = {
        label: chartName,
        data: cases,
        borderColor: defaultColor
    };

    var dataSecond = {
        label: chartNameSecond,
        data: casesSecond,
    };

    var Data = {
        labels: labels,
        datasets: [dataFirst, dataSecond]

    };


    var ch = new Chart(canvasId, {
        type: 'line',
        data: Data
    });
}