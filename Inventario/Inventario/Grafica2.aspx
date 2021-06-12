<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grafica2.aspx.cs" Inherits="Inventario.WebForm2" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
      google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawChart);

      function drawChart() {

        var data = google.visualization.arrayToDataTable(<%=obtenerDatos()%>);

        var options = {
          title: 'Usuarios por area'
        };

        var chart = new google.visualization.PieChart(document.getElementById('piechart'));

        chart.draw(data, options);
      }
    </script>
</head>
<body>
    <br />
    <form id="form1" runat="server">
        <div>
       <div id="piechart" style="width: 900px; height: 500px;"></div>
            </div>
    </form>
</body>
</html>
