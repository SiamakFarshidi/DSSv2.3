<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CaseDefinition.aspx.cs" Inherits="WebApplication1.DecisionModel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NavBar" runat="server">
    <nav class="navbar navbar-expand-xl">
        <div class="container h-100">
            <a class="navbar-brand" href="index.html">
                <h1 class="tm-site-title mb-0">Decision Studio</h1>
            </a>
            <button class="navbar-toggler ml-auto mr-0" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <i class="fas fa-bars tm-nav-icon"></i>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mx-auto h-100">
                    <li class="nav-item">
                        <a class="nav-link" href="Default.aspx">
                            <i class="fas fa-sitemap"></i>
                            Decision Models
                                <span class="sr-only">(current)</span>
                        </a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link active" href="CaseDefinition.aspx">
                            <i class="fas fa-chart-bar"></i>
                            Case
                        </a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link" href="DecisionModel.aspx?Type=Qualities">
                            <i class="fas fa-award"></i>
                            Qualities
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="DecisionModel.aspx?Type=Features">
                            <i class="fas fa-list-alt"></i>
                            Features
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="DecisionModel.aspx?Type=Alternatives">
                            <i class="far fa-window-restore"></i>
                            Alternatives
                        </a>
                    </li>
                    <li class="nav-item dropdown" style="min-width: 150px; display: block;">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown"
                            aria-haspopup="true" aria-expanded="false">
                            <i class="fas fa-user"></i>
                            <span>
                                <span id="CurrentUserName"></span>
                                <i class="fas fa-angle-down"></i>
                            </span>
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <a class="nav-link" href="accounts.html">
                                <i class="fas fa-address-card"></i>
                                Edit user profile
                            </a>
                            <a class="nav-link" href="Login.aspx">
                                <i class="fas fa-power-off"></i>
                                Logout
                            </a>
                        </div>
                    </li>
                </ul>
            </div>
        </div>

    </nav>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br>
        <div class="row" style="margin-bottom: 10px; margin-top: 10px;">
            <div class="col">
                <div style="float: left; width: 50px; height: 50px; border-radius: 50%; background-color: orange; padding-top: 1px; color: black; font-weight: bold; text-align: center;">
                    <span style="font-size: xx-large;"><i class="fas fa-edit"></i></span>
                </div>

                <div style="float: left; width: 50px; height: 50px; padding-left: 10px; margin: 10px; padding-top: 0px; color: orange; font-weight: bold; font-size: x-large; text-align: center;">
                    Description
                </div>
            </div>
        </div>
        <!-- row -->

        <div class="row tm-content-row">

            <div class="col-sm-12 col-md-12 col-lg-3 col-xl-3 tm-block-col" id="PlnCaseImage">

                <div class="tm-bg-primary-dark tm-block" style="text-align: center;">
                    <h2 class="tm-block-title" id="PageCaption"></h2>

                    <div class="tm-avatar-container">
                        <br />
                        <img
                            src="Image/DM_Default.png"
                            class="tm-avatar img-fluid mb-4" style="width: 150px; height: 150px;" id="myUploadedImg" />
                    </div>
                    <div style="width: 100%; height: 100%;" class="file-upload-container">
                        <input type="file" id="f_UploadImage" style="display: none; overflow: hidden; height: 0px; width: 0px;" />
                        <label for="f_UploadImage" class="btn btn-primary btn-block text-uppercase">
                            Upload Image
                        </label>
                    </div>
                </div>
            </div>

            <div class="col-sm-12 col-md-12 col-lg-9 col-xl-9 tm-block-col" id="PlnDescription">
                <div class="tm-bg-primary-dark tm-block" style="text-align: left;">
                    <div class="tm-signup-form row">
                        <div class="form-group col-lg-12">
                            <label for="name">Case title:</label>
                            <input
                                id="txttitle"
                                name="tile"
                                type="text"
                                class="form-control validate" />
                        </div>
                        <div class="form-group col-lg-12">
                            <label for="email">Case Purpose:</label>
                            <textarea
                                id="txtdescription"
                                name="description"
                                rows="2" cols="20"
                                class="form-control validate"></textarea>
                        </div>
                        <div class="form-group col-lg-6">
                            <label class="tm-hide-sm">&nbsp;</label>
                            <button
                                class="btn btn-primary btn-block text-uppercase mb-3"
                                id="updateDefinition">
                                Update</button>
                        </div>
                        <div class="form-group col-lg-6">
                            <label class="tm-hide-sm">&nbsp;</label>
                            <button
                                class="btn btn-primary btn-block text-uppercase mb-3"
                                id="ExtractFeatures">
                                Extract Features</button>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <!-- row -->
        <div id="PlnCaseDefinition">
            <div class="row">
                <div style="float: left; width: 50px; height: 50px; border-radius: 50%; background-color: orange; margin: 10px; padding-top: 1px; color: black; font-weight: bold; text-align: center;">
                    <span style="font-size: xx-large;"><i class="fas fa-tasks"></i></span>
                </div>

                <div style="float: left; width: 50px; height: 50px; margin: 10px; padding-top: 6px; color: orange; font-weight: bold; font-size: x-large; text-align: center;">
                    Definition
                </div>
            </div>

            <br>

            <div class="row tm-content-row">
                <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6 tm-block-col" id="FeatureRequirementSelection">
                    <div class="tm-bg-primary-dark tm-block tm-block-products">
                        <div style="margin-bottom: 15px;">
                            <input style="float: left; width: 78%; margin-right: 1%;" title="Search term"
                                name="SearchCriteria"
                                type="text"
                                class="form-control validate"
                                id="SearchCriteria"
                                required
                                onfocus="SearchCriteria_OnFocus();"
                                onblur="SearchCriteria_OnBlur();" />

                            <button
                                id="btn_SearchForFeatures"
                                type="submit" style="padding: 0px; width: 10%; float: left; height: 50px; margin-right: 1%;" title="Search feature"
                                class="btn btn-primary btn-block text-uppercase">
                                <i class="fas fa-search"></i>
                            </button>

                            <button
                                id="btn_AllFeatures"
                                type="submit" style="padding: 0px; width: 10%; height: 50px;" title="Show all features"
                                class="btn btn-primary btn-block text-uppercase">
                                <i class="fa fa-redo"></i>
                            </button>
                        </div>
                        <div id="Table_DomainFeatureRequirement" class="tabulator" style="margin-bottom: 15px;"></div>
                        <button
                            class="btn btn-primary btn-block text-uppercase mb-3"
                            id="UpdateFeatures" <%--onclick="MakeDecision()"--%> onclick=" $('#cover').show();location.reload();">
                            Evaluate Alternatives</button>
                    </div>

                </div>
                <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6 tm-block-col" id="FeatureDetailedInformation">
                    <div class="tm-bg-primary-dark tm-block tm-block-products">
                        <input type="hidden" id="FeatureID" value="" />
                        <label for="name" style="color: white;">Title:</label>
                        <div id="FeatureTitle" class="UI_Panel" style="height: 50px;"></div>

                        <label for="name" style="color: white;">Description:</label>
                        <div id="FeatureDescription" class="UI_Panel" style="height: 150px;"></div>


                        <div style="margin-top: 60px;">
                            <label for="name" style="color: white;">Details:</label>
                            <table class=" table table-hover tm-table-small tm-product-table" id="basic" style="text-align: left; font-size: small; font-weight: 100;">
                                <tbody>
                                    <tr>
                                        <td style="width: 50%;">Data type:</td>
                                        <td style="width: 50%; color: lightyellow;" id="FeatureDataType"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%;">Category:</td>
                                        <td style="width: 50%; color: lightyellow;" id="FeatureCategory"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%;">Parent:</td>
                                        <td style="width: 50%; color: lightyellow;" id="FeatureParent"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%;">Supported alternatives:</td>
                                        <td style="width: 50%; color: lightyellow;" id="FeatureSupportedAlternatives"></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div style="float: left; width: 50px; height: 50px; border-radius: 50%; background-color: orange; margin: 10px; padding-top: 1px; color: black; font-weight: bold; text-align: center;">
                <span style="font-size: xx-large;"><i class="fas fa-chart-pie"></i></span>
            </div>

            <div style="float: left; width: 50px; height: 50px; margin: 10px; padding-top: 6px; color: orange; font-weight: bold; font-size: x-large; text-align: center;">
                Evaluation
            </div>
        </div>
        <br>
        <!-- row -->
        <div class="row tm-content-row">
            <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12 tm-block-col">
                <div class="tm-bg-primary-dark tm-block tm-block-product-categories">

                    <div style="width: 100%; display: none;">
                        <div style="width: 83%; float: left; padding-right: 1%;">
                            <select class="custom-select" id="ListOfInfeasibleSolutions" style="margin-bottom: 20px;" onmousedown="if(this.options.length>10){this.size=10;}" onchange='this.size=0;' onblur="this.size=0;">
                                <option value="None">-</option>
                            </select>
                        </div>

                        <button
                            id="btn_add_alternative_from_DecisionMatrix"
                            type="submit" style="padding: 0px; width: 8%; float: left; height: 50px; margin-right: 1%;" title="Add the infeasible solution to the decision matrix"
                            class="btn btn-primary btn-block text-uppercase">
                            <i class="fas fa-plus"></i>
                        </button>

                        <button
                            id="btn_remove_alternative_from_DecisionMatrix"
                            type="submit" style="padding: 0px; width: 8%; height: 50px;" title="Remove the infeasible solution from the decision matrix"
                            class="btn btn-primary btn-block text-uppercase">
                            <i class="fas fa-minus"></i>
                        </button>
                    </div>
                    <span id="DD_Placeholder">
                        <span class="autocomplete-select" id="spnInfeasibleList"></span>
                    </span>
                    <div style="clear: both;" id="Table_DecisionMatrix" class="tabulator"></div>
                </div>
            </div>

            <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6 tm-block-col">
                <div class="tm-bg-primary-dark tm-block" style="text-align: left;" id="PlnPieChart">
                    <canvas id="pieChart" class="chartjs-render-monitor" width="200" height="200" style="display: none;"></canvas>
                    <div id="piechart_3d" style="width: 460px; height: 400px;"></div>

                </div>
            </div>

            <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6 tm-block-col">
                <div class="tm-bg-primary-dark tm-block" style="text-align: left;" id="PlnBarChart">
                    <canvas id="barChart" width="200" height="150" style="display: none;"></canvas>
                    <div id="barchart_values" style="width: 550px; height: 400px;"></div>

                </div>
            </div>

            <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12 tm-block-col">
                <div class="tm-bg-primary-dark tm-block tm-block-products" style="text-align: left;" id="PlnDecisionStructure">
                    <div style="color: white; font-weight: bold; font-size: 11pt;">Decision Structure:</div>
                    <div id="DecisionStructure" style="width: 100%; font-size: xx-small; height: 640px; background-color: #BCC6CC; border: 2px solid #51697D;">
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
                </div>
            </div>
        </div>

        <div style="width: 100%; text-align: center; left: auto; right: auto; padding: 0px; margin: 0px;">

            <button
                id="btnShow_Report"
                type="submit" style="padding: -0px; width: 15%; float: left; height: 60px; font-size: xx-large; margin-right: 2%;" title="Report"
                class="btn btn-primary btn-block text-uppercase">
                <i class="fas fa-file-invoice"></i>
            </button>

            <button
                id="btnPrint_Report"
                type="submit" style="padding: 0px; margin-top: -0px; width: 15%; float: left; height: 60px; font-size: xx-large; margin-right: 2%;" title="Print"
                class="btn btn-primary btn-block text-uppercase">
                <i class="fas fa-print"></i>
            </button>

            <button
                id="btnPDF_Report"
                type="submit" style="padding: 0px; margin-top: -0px; width: 15%; float: left; height: 60px; font-size: xx-large; margin-right: 2%;" title="Export to PDF"
                class="btn btn-primary btn-block text-uppercase">
                <i class="fas fa-file-pdf"></i>
            </button>

            <button
                id="btnDownload"
                type="submit" style="padding: 0px; margin-top: -0px; width: 15%; float: left; height: 60px; font-size: xx-large; margin-right: 2%;" title="Download the decision model"
                class="btn btn-primary btn-block text-uppercase">
                <i class="fas fa-file-download"></i>
            </button>

            <button
                id="btnUpload"
                type="submit" style="padding: 0px; margin-top: -0px; width: 15%; float: left; height: 60px; font-size: xx-large; margin-right: 2%;" title="Upload a decision model"
                class="btn btn-primary btn-block text-uppercase" data-toggle="modal" data-target="#UploadFrame">
                <i class="fas fa-file-upload"></i>
            </button>

            <button
                id="btnVisualization"
                type="submit" style="padding: 0px; width: 15%; height: 60px; font-size: xx-large;" title="Open graphical design studio"
                class="btn btn-primary btn-block text-uppercase" data-toggle="modal" data-target="#GraphicalDesign">
                <i class="fas fa-feather-alt"></i>
            </button>
        </div>
        <br />
    </div>

    <!-- The Modal -->

    <div class="modal fade" id="GraphicalDesign">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title"><span style="color: orange; font-weight: bold;"><i class="fas fa-feather-alt"></i>&nbsp;&nbsp;Graphical Design</span></h4>
                    <button type="button" class="close" data-dismiss="modal" style="color: red;" title="Close">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="tm-bg-primary-dark tm-block tm-block-products" style="text-align: left;">
                        <iframe src="Template/Graphical Design/GraphicalDesign.html" style='width: 100%; height: 655px; margin: 0px; padding: 0px; border: none;'></iframe>
                    </div>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary btn-block text-uppercase" style="width: 100px; margin: 10px;" data-dismiss="modal">Close</button>
                </div>

            </div>
        </div>
    </div>

    <!-- The Modal -->

    <div class="modal fade" id="UploadFrame" role="dialog">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title"><span style="color: orange; font-weight: bold;"><i class="fas fa-file-upload"></i>&nbsp;&nbsp;Upload Decision Model</span></h4>
                    <button type="button" class="close" data-dismiss="modal" style="color: red;" title="Close">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body" style="color: white; padding: 30px;">
                    Please select a valid decision model.
                    <br />
                    <br />
                    <div style="width: 100%; height: 100%;" class="file-upload-container">
                        <input type="file" id="f_DecisionModel" style="display: none; overflow: hidden; height: 0px; width: 0px;" />
                        <label for="f_DecisionModel" class="btn btn-primary btn-block text-uppercase">
                            Select Decision Model
                        </label>
                    </div>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary btn-block text-uppercase" style="width: 100px; margin: 10px;" data-dismiss="modal">Ok</button>
                </div>
            </div>
        </div>
    </div>

    <%------------------------------------------------------------------------------------------------------%>
    <script src="Template/Graphical Design/assets/js/go.js" type="text/javascript"></script>
    <script src="Template/Select/dist/bundle.min.js" type="text/javascript"></script>
    <script src="Template/js/Chart.min.js" type="text/javascript"></script>
    <script src="Template/tabulator/dist/js/tabulator.min.js" type="text/javascript"></script>
    <script src="Template/js/popper.min.js" type="text/javascript"></script>
    <script src="Template/js/loader.js" type="text/javascript"></script>

    <%------------------------------------------------------------------------------------------------------%>
    <link href="Template/tabulator/dist/css/customized-ui/tabulator_midnight.min.css" rel="stylesheet">
    <%-----------------------------------------------------------Generated_JS_Files-------------------------%>
    <script src="XML_DB/Profiles/<%=Session["UID"]%>/JS/FeatureRequirements.js" type="text/javascript"></script>
    <script src="XML_DB/Profiles/<%=Session["UID"]%>/JS/DecisionMatrix.js" type="text/javascript"></script>
    <script src="XML_DB/Profiles/<%=Session["UID"]%>/JS/ListOfInfeasibleSolutions.js" type="text/javascript"></script>
    <script src="XML_DB/Profiles/<%=Session["UID"]%>/JS/BarGraphData.js" type="text/javascript"></script>
    <script src="XML_DB/Profiles/<%=Session["UID"]%>/JS/PieChartData.js" type="text/javascript"></script>
    <script src="XML_DB/Profiles/<%=Session["UID"]%>/JS/DecisionStructure.js" type="text/javascript"></script>
    <script src="XML_DB/Profiles/<%=Session["UID"]%>/JS/CaseDefinition.js" type="text/javascript"></script>

    <script type="text/javascript">
        var UID = "<%=Session["UID"]%>";
    </script>

    <%------------------------------------------------------------------------------------------------------%>
    <script src="Scripts/__Diagrams.js" type="text/javascript"></script>
    <script src="Scripts/__CaseDefinition.js" type="text/javascript"></script>
    <%------------------------------------------------------------------------------------------------------%>

    <script type="text/javascript">
        var url = window.location.search;
        if (url.match("ViewDecisionModel=").length > 0) {
            $("#PlnCaseDefinition").hide();
            $("#updateDefinition").hide();
            $("#ExtractFeatures").hide();
            $("#PlnCaseImage").hide();
            document.getElementById("PlnDescription").className = "col-sm-12 col-md-12 col-lg-12 col-xl-12 tm-block-col";                       
        }
    </script>



</asp:Content>


