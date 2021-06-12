<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grafica3.aspx.cs" Inherits="Inventario.Grafica3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

     <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
      google.charts.load('current', {'packages':['bar']});
      google.charts.setOnLoadCallback(drawChart);

      function drawChart() {
          var data = google.visualization.arrayToDataTable(<%=obtenerDatos()%>);
          
        var options = {
          chart: {
            title: 'Listado de artículos por tipo.',
            //subtitle: 'Sales, Expenses, and Profit: 2014-2017',
          },
          bars: 'horizontal' // Required for Material Bar Charts.
        };

        var chart = new google.charts.Bar(document.getElementById('barchart_material'));

        chart.draw(data, google.charts.Bar.convertOptions(options));
      }
    </script>
</head>
<body>
    <br />
    <br />
    <br />
    <form id="form1" runat="server">
        <div>
               <div id="barchart_material" style="width: 500px; height: 200px;"></div>
        </div>
    </form>
</body>
</html>
