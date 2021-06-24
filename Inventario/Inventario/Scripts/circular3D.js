google.charts.load('current', {'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

           /* var data = google.visualization.arrayToDataTable(@Html.Raw(ViewBag.grafico));*/



            var options = {
        title: 'Alancet',
                is3D: true,
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));
            chart.draw(data, options);
        }

