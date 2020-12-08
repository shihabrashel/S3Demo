var lineChartWrapper = {
    renderReadingData: function (data) {
		var limit = 10000;    //increase number of dataPoints by increasing the limit
		var y = 100;
		var data = [];
		var dataSeries = { type: "line" };
		var dataPoints = [];
		$.each(data, function (index, item) {
			dataPoints.push({
				x: item.Timestamp,
				y: item.Value
			});
		});
		//for (var i = 0; i < limit; i += 1) {
		//	y += Math.round(Math.random() * 10 - 5);
			
		//}
		dataSeries.dataPoints = dataPoints;
		data.push(dataSeries);

		//Better to construct options first and then pass it as a parameter
		var options = {
			zoomEnabled: true,
			animationEnabled: true,
			title: {
				text: "Time series data"
			},
			data: data  // random data
		};
		var lineChart = new CanvasJS.Chart("chartContainer", options);
		lineChart.render();
		//$("#chartContainer").CanvasJSChart(options);

		//var lineChart = new CanvasJS.Chart("chartContainer",
		//	title: {
		//	text: '',
		//	verticalAlign: 'bottom',
		//	horizontalAlign: 'left',
		//	fontColor: "#2b91d5",
		//	fontSize: 14,
		//	fontFamily: "AsembiaFont",
		//	fontWeight: "normal"
		//},
		//	animationEnabled: true,
		//	legend: {
		//	fontFamily: "AsembiaFont"
		//},
		//	data: [
		//	{
		//		type: "doughnut",
		//		startAngle: 20,
		//		toolTipContent: "{legendText}",
		//		indexLabel: "{label}",
		//		dataPoints: dataPoints,
		//		indexLabelFontColor: "#000",
		//		indexLabelFontFamily: "AsembiaFont",
		//		indexLabelFontSize: 12
		//	});

	}
}