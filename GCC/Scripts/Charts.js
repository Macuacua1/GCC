
$(document).ready(function () {

    $("#Chart").on("click", function (e) {
        e.preventDefault();
        $("#Lista").removeClass("active");
        $(this).addClass("active");
        document.getElementById("CHartLista").style.display = "block";
        document.getElementById("TabelaLista").style.display = "none";
        $("#Recorrencia").val('default').selectpicker("refresh");
        $('#Periodo').selectpicker('val', 0).change();
        var Periodo = 0;
        var Recorrencia = 100;
        GetRecorrenciaChart(Periodo, Recorrencia);

    });
    $("#RecorrenciaChart").on("change", function (e) {
        e.preventDefault();

       
        var Periodo = $("#PeriodoChart").val();
        var Recorrencia = $("#RecorrenciaChart").val();
        GetRecorrenciaChart(Periodo, Recorrencia);
    });
    $("#PeriodoChart").on("change", function (e) {
        e.preventDefault();

      
        var Periodo = $("#PeriodoChart").val();
        var Recorrencia = $("#RecorrenciaChart").val();
        GetRecorrenciaChart(Periodo, Recorrencia);
    });
    function GetRecorrenciaChart(Periodo, Recorrencia) {
        $.post("/GCC/Recorrencia/GetRecorrenciaChart", { Periodo: Periodo, Recorrencia: Recorrencia })
           .done(function (response) {
               if (response.status) {

                   FillChart(response.data);
               } else { swal("Erro...", response.msg, "error"); }
           })
       .fail(function (XMLHttpRequest, textStatus, errorThrown) {
           var titleText = textFromHTMLString(XMLHttpRequest.responseText, 'title');
           swal("Erro...", titleText, "error");
       });
    }
    function FillChart(response) {

        var datas = [];
        var sucesso = [];
        var falha = [];

        $.each(response, function (index, item) {

            var DataInicio = getFormattedDate(new Date(item.Data));
            datas.push(DataInicio);
            sucesso.push(item.sucesso);
            falha.push(item.falha);
        });

        Highcharts.chart('barCharts', {
            chart: {
                type: 'column'
            },
            title: {
                text: 'Grafico das Recorrências'
            },
            xAxis: {
                categories: datas,
                crosshair: true
            },
            yAxis: {
                min: 0,
                title: {
                    text: 'Total de Recorrências por Estado'
                }
            },
            plotOptions: {
                column: {
                    pointPadding: 0.2,
                    borderWidth: 0
                }
            },
            colors: ['#50B432', 'red', '#ED561B', '#DDDF00', '#24CBE5', '#64E572', '#FF9655', '#FFF263', '#6AF9C4'],
            series: [{
                name: 'Sucesso',
                data: sucesso

            }, {
                name: 'Falha',
                data: falha

            }]
        });
        $('#lineCharts').highcharts({
            title: {
                text: 'Total de Recorrências por Estado',
            },
            xAxis: {
                categories: datas
            },
            yAxis: {
                title: {
                    text: 'Grafico das Recorrências'
                },
            },
            //tooltip: {
            //    valueSuffix: '%'
            //},
            colors: ['#50B432', 'red', '#ED561B', '#DDDF00', '#24CBE5', '#64E572', '#FF9655', '#FFF263', '#6AF9C4'],
            series: [{
                name: "Sucesso",
                data: sucesso
            }, {
                name: "Falha",
                data: falha
            }]
        });
    }
    function getFormattedDate(date) {

        var year = date.getFullYear();

        var month = (1 + date.getMonth()).toString();
        month = month.length > 1 ? month : '0' + month;

        var day = date.getDate().toString();
        day = day.length > 1 ? day : '0' + day;

        return day + '-' + month + '-' + year;
    }
    //$('#lineCharts').highcharts({
    //    title: {
    //        text: 'Code Hubs Analysis 2018 - 2019',
    //    },
    //    xAxis: {
    //        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
    //    },
    //    yAxis: {
    //        title: {
    //            text: 'Growth Rate'
    //        },
    //    },
    //    tooltip: {
    //        valueSuffix: '%'
    //    },
    //    colors: ['#50B432', 'red', '#ED561B', '#DDDF00', '#24CBE5', '#64E572', '#FF9655', '#FFF263', '#6AF9C4'],
    //    series: [{
    //        name: "Year 2018",
    //        data: [51, 26, 52.6, 78.5, 95, 45, 85, 70, 56, 69, 95, 90]
    //    }, {
    //        name: "Year 2019",
    //        data: [69, 45, 92, 45, 75.6, 84, 59, 47, 65, 80, 85, 96]
    //    }]
    //});
    //function FillChart(response) {
    //    debugger;
    //    console.log(response);
    //Highcharts.chart('barCharts', {
    //    chart: {
    //        type: 'column'
    //    },
    //    title: {
    //        text: 'Technology Analysis'
    //    },
    //    xAxis: {
    //        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
    //        crosshair: true
    //    },
    //    yAxis: {
    //        min: 0,
    //        title: {
    //            text: 'Total de Recorrências por Estado'
    //        }
    //    },
    //    plotOptions: {
    //        column: {
    //            pointPadding: 0.2,
    //            borderWidth: 0
    //        }
    //    },
    //    series: [{
    //        name: 'Sucesso',
    //        data: [49, 71, 106, 129, 144, 176, 135, 148, 216, 194, 95, 54]

    //    }, {
    //        name: 'Falha',
    //        data: [42, 33, 34, 39, 52, 75, 57, 60, 47, 39, 46, 51]

    //    }]
    //});
    //}
    

});
