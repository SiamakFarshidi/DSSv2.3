<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintableReport.aspx.cs" Inherits="WebApplication1.ExtraPage.PrintableReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report</title>
    <style type="text/css">
        .wrapper {
            padding-bottom: 90px;
        }

        .divider {
            position: relative;
            margin-top: 90px;
            height: 1px;
        }

        .div-transparent:before {
            content: "";
            position: absolute;
            top: 0;
            left: 5%;
            right: 5%;
            width: 90%;
            height: 1px;
            background-image: linear-gradient(to right, transparent, rgb(48,49,51), transparent);
        }

        .div-arrow-down:after {
            content: "";
            position: absolute;
            z-index: 1;
            top: -7px;
            left: calc(50% - 7px);
            width: 14px;
            height: 14px;
            transform: rotate(45deg);
            background-color: white;
            border-bottom: 1px solid rgb(48,49,51);
            border-right: 1px solid rgb(48,49,51);
        }

        .div-tab-down:after {
            content: "";
            position: absolute;
            z-index: 1;
            top: 0;
            left: calc(50% - 10px);
            width: 20px;
            height: 14px;
            background-color: white;
            border-bottom: 1px solid rgb(48,49,51);
            border-left: 1px solid rgb(48,49,51);
            border-right: 1px solid rgb(48,49,51);
            border-radius: 0 0 8px 8px;
        }

        .div-stopper:after {
            content: "";
            position: absolute;
            z-index: 1;
            top: -6px;
            left: calc(50% - 7px);
            width: 14px;
            height: 12px;
            background-color: white;
            border-left: 1px solid rgb(48,49,51);
            border-right: 1px solid rgb(48,49,51);
        }

        .div-dot:after {
            content: "";
            position: absolute;
            z-index: 1;
            top: -9px;
            left: calc(50% - 9px);
            width: 18px;
            height: 18px;
            background-color: goldenrod;
            border: 1px solid rgb(48,49,51);
            border-radius: 50%;
            box-shadow: inset 0 0 0 2px white, 0 0 0 4px white;
        }

        @media print {
            body {
                background-color: #FFFFFF;
                background-image: none;
                color: #000000
            }

            #ad {
                display: none;
            }

            #leftbar {
                display: none;
            }

            #contentarea {
                width: 100%;
            }
        }

        .tbl_FR {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

            .tbl_FR td, #tbl_FR th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            .tbl_FR tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            .tbl_FR tr:hover {
                background-color: #ddd;
            }

            .tbl_FR th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #4CAF50;
                color: white;
            }

        td.rotate {
            /* Something you can count on */
            height: 140px;
            white-space: nowrap;
            padding-top: 1px;
            padding-right: 1px;
            padding-left: 1px;
            mso-ignore: padding;
            color: black;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            mso-font-charset: 0;
            mso-number-format: General;
            text-align: center;
            vertical-align: bottom;
            border: none;
            background: white;
            mso-pattern: white none;
            white-space: nowrap;
            mso-rotate: 90;
        }

            td.rotate > div {
                transform:
                /* Magic Numbers */
                translate(0px, 0px)
                /* 45 is really 360 - 45 */
                rotate(315deg);
                width: 30px;
            }


                td.rotate > div > span {
                    border-bottom: 0px solid #ccc;
                    padding: 5px 10px;
                }
    </style>
    <script src="../Template/Graphical Design/assets/js/go.js" type="text/javascript"></script>
    <script src="../Template/Select/dist/bundle.min.js" type="text/javascript"></script>
    <script src="../Template/js/Chart.min.js" type="text/javascript"></script>
    <script src="../Template/tabulator/dist/js/tabulator.min.js" type="text/javascript"></script>
    <script src="../Template/js/popper.min.js" type="text/javascript"></script>
    <script src="../Template/js/loader.js" type="text/javascript"></script>


    <script src="../XML_DB/Profiles/<%=Session["UID"]%>/JS/DecisionMatrix.js" type="text/javascript"></script>
    <script src="../XML_DB/Profiles/<%=Session["UID"]%>/JS/BarGraphData.js" type="text/javascript"></script>
    <script src="../XML_DB/Profiles/<%=Session["UID"]%>/JS/PieChartData.js" type="text/javascript"></script>
    <script src="../XML_DB/Profiles/<%=Session["UID"]%>/JS/DecisionStructure.js" type="text/javascript"></script>
    <script src="../XML_DB/Profiles/<%=Session["UID"]%>/JS/GeneratedReport.js" type="text/javascript"></script>

    <script src="../Scripts/__Diagrams.js" type="text/javascript"></script>

</head>
<body style="font-family: Arial;">

    <div style="width: 100%; text-align: center;">
        <h1>REPORT</h1>
    </div>
    <div class="divider div-transparent div-dot"></div>
    <br />
    <h4>This is the list of feature requirements besides your priorities:</h4>
    <br />
    <div id="FrmTbleFeatureRequirements" style="width: 100%; height: 100%;">
    </div>

    <div class="divider div-transparent div-dot"></div>
    <br />


    <div id="piechart_3d" style="width: 460px; height: 400px;"></div>

    <div class="divider div-transparent div-dot"></div>
    <br />

    <div id="barchart_values" style="width: 550px; height: 400px;"></div>

    <br />
    <div id="FeasibleSolutions" style="width: 100%; height: 100%;"></div>

    <div class="divider div-transparent div-dot"></div>
    <br />

        <h4>This table shows part of the imapcts of the feasible patterns on the quality aspects: <br />[ Note: High (H), Medium (M), Low (L), Unknown (?) ] </h4>
    <br />

    <div id="NumbericFeaturesComparison" style="width: 100%; height: 100%;"></div>

    <div class="divider div-transparent div-dot"></div>
    <br />

    <h4>This is the decision structure:</h4>
    <br />

    <div id="DecisionStructure" style="width: 100%; font-size: xx-small; height: 1000px; background-color: white; border: 2px solid #51697D;">
    </div>

    <div style="margin-bottom: 5px; padding: 5px; background-color: white; display: none;">

        <br />
        <div id="SettingsPanel" style="">
            <span style="display: none; vertical-align: top; padding: 5px">
                <b>New Graph</b><br />
                MinNodes:
        <input type="text" size="2" id="minNodes" value="20" /><br />
                MaxNodes:
        <input type="text" size="2" id="maxNodes" value="100" /><br />
                <button type="button" onclick="rebuildGraph()">Generate Digraph</button>
            </span>
            <span style="display: inline-block; vertical-align: top; padding: 5px">
                <b>LayeredDigraphLayout Properties</b><br />
                Direction:
      <input type="radio" name="direction" onclick="layout()" value="0" checked="checked" />Right (0)
      <input type="radio" name="direction" onclick="layout()" value="90" />Down (90)
      <input type="radio" name="direction" onclick="layout()" value="180" />Left (180)
      <input type="radio" name="direction" onclick="layout()" value="270" />Up (270)<br />
                LayerSpacing:
      <input type="text" size="2" id="layerSpacing" value="50" onchange="layout()" style="clear: left;" /><br />
                ColumnSpacing:
      <input type="text" size="2" id="columnSpacing" value="1" onchange="layout()" /><br />
                CycleRemove:
      <input type="radio" name="cycleRemove" onclick="layout()" value="CycleDepthFirst" checked="checked" />
                CycleDepthFirst
      <input type="radio" name="cycleRemove" onclick="layout()" value="CycleGreedy" />
                CycleGreedy<br />
                Layering:
      <input type="radio" name="layering" onclick="layout()" value="LayerOptimalLinkLength" checked="checked" />
                LayerOptimalLinkLength
      <input type="radio" name="layering" onclick="layout()" value="LayerLongestPathSource" />
                LayerLongestPathSource
      <input type="radio" name="layering" onclick="layout()" value="LayerLongestPathSink" />
                LayerLongestPathSink<br />
                Initialize:
      <input type="radio" name="initialize" onclick="layout()" value="InitDepthFirstOut" checked="checked" />
                InitDepthFirstOut
      <input type="radio" name="initialize" onclick="layout()" value="InitDepthFirstIn" />
                InitDepthFirstIn
      <input type="radio" name="initialize" onclick="layout()" value="InitNaive" />
                InitNaive<br />
                Aggressive:
      <input type="radio" name="aggressive" onclick="layout()" value="AggressiveNone" />
                AggressiveNone
      <input type="radio" name="aggressive" onclick="layout()" value="AggressiveLess" checked="checked" />
                AggressiveLess
      <input type="radio" name="aggressive" onclick="layout()" value="AggressiveMore" />
                AggressiveMore<br />
                Pack:
      <input type="checkbox" name="pack" onclick="layout()" value="4" checked="checked" />
                PackMedian
      <input type="checkbox" name="pack" onclick="layout()" value="2" checked="checked" />
                PackStraighten
      <input type="checkbox" name="pack" onclick="layout()" value="1" checked="checked" />
                PackExpand<br />
                SetsPortSpots:
        <input type="checkbox" id="setsPortSpots" onclick="layout()" checked="checked" />
            </span>
        </div>
    </div>


    <script>
        function init() {
            if (window.goSamples) goSamples();  // init for these samples -- you don't need to call this
            var $ = go.GraphObject.make;  // for conciseness in defining templates
            myDiagram =
                $(go.Diagram, "DecisionStructure",  // must be the ID or reference to div
                    {
                        initialAutoScale: go.Diagram.UniformToFill,
                        layout: $(go.LayeredDigraphLayout)
                        // other Layout properties are set by the layout function, defined below
                    });
            // define the Node template
            myDiagram.nodeTemplate =
                $(go.Node, "Spot",
                    { locationSpot: go.Spot.Center },
                    $(go.Shape, "Rectangle",
                        {
                            fill: "lightyellow",  // the initial value, but data-binding may provide different value
                            stroke: null,
                            desiredSize: new go.Size(148, 15)
                        },
                        new go.Binding("stroke", "fill")),
                    $(go.TextBlock,
                        new go.Binding("text", "text"), { font: "9px sans-serif" })
                );
            // define the Link template to be minimal
            myDiagram.linkTemplate =
                $(go.Link,
                    { selectable: false },
                    $(go.Shape,
                        { strokeWidth: 1, stroke: "darkgray" }));
            // generate a tree with the default values
            rebuildGraph();
        }
        function autoComplete() {
            FeatureRequirements();

            google.charts.load("current", { packages: ["corechart"] });
            google.charts.setOnLoadCallback(drawChart_PieChart);
            google.charts.setOnLoadCallback(drawChart_BarChart);
            init();
        }
        //----------------------------------------------------Init

        document.getElementById("FeasibleSolutions").innerHTML = FeasibleSolutions;
        document.getElementById("NumbericFeaturesComparison").innerHTML = NumbericFeaturesComparison;


        //----------------------------------------------------Bar and Pie charts

        function drawChart_PieChart() {
            var data = google.visualization.arrayToDataTable(QualityAttributesRatio);

            var options = {
                title: 'Impacts of the selected feature requirements on quality attributes:',
                is3D: true,
                legend: { position: 'left', textStyle: { color: 'black' } },
                backgroundColor: 'transparent',
                chartArea: { left: 0, top: 50, width: "100%", height: "100%" },
                titleTextStyle: {
                    color: 'black',
                    fontSize: 14,
                    bold: true
                }
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));
            chart.draw(data, options);
        }

        function drawChart_BarChart() {
            var data = google.visualization.arrayToDataTable(FeasibleSolutionsScores);

            var view = new google.visualization.DataView(data);
            view.setColumns([0, 1,
                {
                    calc: "stringify",
                    sourceColumn: 1,
                    type: "string",
                    role: "annotation"
                },
                2]);

            var options = {
                title: "Top-10 feasible solutions:",
                backgroundColor: 'transparent',
                chartArea: { width: 350, height: 300 },
                bar: { groupWidth: "95%" },
                legend: { position: "none" },
                titleTextStyle: {
                    color: 'black',
                    fontSize: 14,
                    bold: true
                },
                hAxis: { minValue: 0, maxValue: 100, textStyle: { color: 'black' } },
                vAxis: { textStyle: { color: 'black' } }

            };
            var chart = new google.visualization.BarChart(document.getElementById("barchart_values"));
            chart.draw(view, options);
        }
        //----------------------------------------------------
        function FeatureRequirements() {
            var table_JS_FeatureRequirements = "<table class='tbl_FR'> <tr><th>Feature Requirements</th><th>MoSCoW Priorities</th><tr>";
            for (i = 0; i < DecisionMatrix_datatable.length; i++) {
                table_JS_FeatureRequirements += "<tr><td>" + DecisionMatrix_datatable[i].Feature + "</td><td>" + DecisionMatrix_datatable[i].MoSCoW + "</td></tr>";
            }
            table_JS_FeatureRequirements += "</table>"

            document.getElementById("FrmTbleFeatureRequirements").innerHTML = table_JS_FeatureRequirements;

        }
        //----------------------------------------------------
        var table_decision_matrix = new Tabulator("", {});
    </script>
    <script>
        autoComplete();
    </script>
</body>
</html>
