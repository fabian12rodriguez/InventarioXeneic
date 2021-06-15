        google.charts.load('current', {'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

        /*    var data = google.visualization.arrayToDataTable(<%=obtenerDatosGrafico() %>);*/
            var data = google.visualization.arrayToDataTable(<%= %>);

            var options = {title: 'Usuarios por area'
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart'));

            chart.draw(data, options);
        }