<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DecisionModel.aspx.cs" Inherits="WebApplication1.DecisionModel1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NavBar" runat="server">
    <nav class="navbar navbar-expand-xl">
        <div class="container h-100">
            <a onclick="$('#cover').show();" class="navbar-brand" href="index.html">
                <h1 class="tm-site-title mb-0">Decision Studio</h1>
            </a>
            <button class="navbar-toggler ml-auto mr-0" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <i class="fas fa-bars tm-nav-icon"></i>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mx-auto h-100" id="Toppage_menu">
                    <li class="nav-item" id="item_home">
                        <a onclick="$('#cover').show();" class="nav-link" href="index.html">
                            <i class="fas fa-home"></i>
                            Home
                                <span class="sr-only">(current)</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a onclick="$('#cover').show();" class="nav-link" href="Default.aspx">
                            <i class="fas fa-sitemap"></i>
                            Decision Models
                                <span class="sr-only">(current)</span>
                        </a>
                    </li>

                    <li class="nav-item dropdown" id="item_Benchmarks">

                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown"
                            aria-haspopup="true" aria-expanded="false">
                            <i class="far fa-newspaper"></i>
                            <span>Benchmarks <i class="fas fa-angle-down"></i>
                            </span>
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <a onclick="$('#cover').show();" class="dropdown-item" href="DecisionModel.aspx?View=DBMSMODEL&PageCaption=Database Technologies">Database Technologies</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="DecisionModel.aspx?View=CSPMODEL&PageCaption=Cloud Service Providers">Cloud Service Providers</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="DecisionModel.aspx?View=BPMODEL&PageCaption=Blockchain Platforms">Blockchain Platforms</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="DecisionModel.aspx?View=SWAPMODEL&PageCaption=Architecture Patterns">Architecture Patterns</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="DecisionModel.aspx?View=PLMODEL&PageCaption=Programming Languages">Programming Languages</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="DecisionModel.aspx?View=MDDMODEL&PageCaption=MDD Platforms">Programming Languages">MDD Platforms</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="DecisionModel.aspx?View=BPMLMODEL&PageCaption=BP Modeling Lanaguages">Business Process Modeling Lanaguages">BP Modeling Lanaguages</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="DecisionModel.aspx?View=QAMODEL&PageCaption=QA Models">Programming Languages">MDD Platforms</a>                            
                        </div>
                    </li>
                    
                    <li class="nav-item" id="DM_Case">
                        <a onclick="$('#cover').show();" class="nav-link" href="CaseDefinition.aspx">
                            <i class="fas fa-chart-bar"></i>
                            Case
                        </a>
                    </li>

                    <li class="nav-item" id="DM_Qualities">
                        <a onclick="$('#cover').show();" id="item_qualities" class="nav-link" href="DecisionModel.aspx?Type=Qualities">
                            <i class="fas fa-award"></i>
                            Qualities
                        </a>
                    </li>
                    <li class="nav-item" id="DM_Features">
                        <a onclick="$('#cover').show();" id="item_features" class="nav-link" href="DecisionModel.aspx?Type=Features">
                            <i class="fas fa-list-alt"></i>
                            Features
                        </a>
                    </li>
                    <li class="nav-item" id="DM_Alternatives">
                        <a onclick="$('#cover').show();" id="item_alternatives" class="nav-link" href="DecisionModel.aspx?Type=Alternatives">
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
                            <a onclick="$('#cover').show();" class="nav-link" href="accounts.html">
                                <i class="fas fa-address-card"></i>
                                Edit user profile
                            </a>
                            <a onclick="$('#cover').show();" class="nav-link" href="Login.aspx">
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
        <div id="PlnNewAspects">
            <div class="row">
                <div class="col">
                    <p id="NewSectionName" class="text-white mt-5 mb-5" style="font-size: large;"></p>
                </div>
            </div>
            <div class="row tm-content-row">
                <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12 tm-block-col" id="NewQualityAttribute">
                    <div class="tm-bg-primary-dark tm-block">
                        <input type="hidden" id="QualityID" value="" />
                        <label for="name" style="color: white;">Quality Attribute:</label>
                        <input
                            id="txtQAtitle"
                            name="tile"
                            type="text"
                            class="form-control validate" />

                        <label for="name" style="color: white;">Description:</label>
                        <textarea
                            id="txtQAdescription"
                            name="description"
                            rows="2" cols="20"
                            class="form-control validate"></textarea>

                        <label for="level" style="color: white;">Level:</label>
                        <select class="custom-select" name="level" id="QAlevel" style="margin-bottom: 20px;" onmousedown="if(this.options.length>10){this.size=10;}" onchange='this.size=0;' onblur="this.size=0;">
                            <option value="Characteristic">Characteristic</option>
                            <option value="Subcharacteristic">Subcharacteristic</option>
                        </select>

                        <button
                            class="btn btn-primary btn-block text-uppercase mb-12"
                            id="AddQualityAttribute" onclick="NewQualityAttribute();">
                            Add</button>
                    </div>
                </div>

                <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12 tm-block-col" id="NewAlternative">
                    <div class="tm-bg-primary-dark tm-block">
                        <input type="hidden" id="AlternativeID" value="" />
                        <label for="name" style="color: white;">Alternative Title:</label>
                        <input
                            id="txtAlternativetitle"
                            name="tile"
                            type="text"
                            class="form-control validate" />

                        <label for="name" style="color: white;">Description:</label>
                        <textarea
                            id="txtAlternativedescription"
                            name="description"
                            rows="2" cols="20"
                            class="form-control validate"></textarea>

                        <label for="AlternativeKeywords" style="color: white;">Corporation:</label>
                        <input
                            id="AlternativeKeywords"
                            name="tile"
                            type="text"
                            class="form-control validate" />
                        <br />
                        <button
                            class="btn btn-primary btn-block text-uppercase mb-12"
                            id="AddAlternative" onclick="NewAlternative();">
                            Add</button>
                    </div>
                </div>

                <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12 tm-block-col" id="NewFeature">
                    <div class="tm-bg-primary-dark tm-block tm-block-products">
                        <input type="hidden" id="FeatureID" value="" />
                        <label for="name" style="color: white;">Feature Title:</label>
                        <input
                            id="txtFeaturetitle"
                            name="tile"
                            type="text"
                            class="form-control validate" />

                        <label for="description" style="color: white;">Description:</label>
                        <textarea
                            id="txtFeaturedescription"
                            name="description"
                            rows="2" cols="20"
                            class="form-control validate"></textarea>

                        <label for="title" style="color: white;">Keywords:</label>
                        <input
                            id="FeatureKeywords"
                            name="tile"
                            type="text"
                            class="form-control validate" />

                        <label for="level" style="color: white;">Data Type:</label>
                        <select class="custom-select" name="level" id="datatype" style="margin-bottom: 20px;" onmousedown="if(this.options.length>10){this.size=10;}" onchange='this.size=0;' onblur="this.size=0;">
                            <option value="Boolean">Boolean</option>
                            <option value="Numeric">Numeric</option>
                            <option value="Monetary">Monetary</option>
                            <option value="Description">Description</option>
                        </select>

                        <label for="level" style="color: white;">Member Of:</label>
                        <select class="custom-select" name="level" id="MemberOf" style="margin-bottom: 20px;" onmousedown="if(this.options.length>10){this.size=10;}" onchange='this.size=0;' onblur="this.size=0;">
                        </select>

                        <label for="level" style="color: white;">UI Category:</label>
                        <select class="custom-select" name="level" id="UICategory" style="margin-bottom: 20px;" onmousedown="if(this.options.length>10){this.size=10;}" onchange='this.size=0;' onblur="this.size=0;">
                        </select>

                        <button
                            class="btn btn-primary btn-block text-uppercase mb-12"
                            id="AddFeatures" onclick="NewFeature();">
                            Add</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <p id="AspectSectionName" class="text-white mt-5 mb-5" style="font-size: large;"></p>
            </div>
        </div>
        <!-- row -->
        <div class="row tm-content-row">

            <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12 tm-block-col">
                <div class="tm-bg-primary-dark tm-block tm-block-products" style="text-align: left;">
                    <div id="Table_Aspects" class="tabulator" style="margin-bottom: 15px;"></div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <p id="MappingSectionName" class="text-white mt-5 mb-5" style="font-size: large;"></p>
            </div>
        </div>
        <!-- row -->
        <div class="row tm-content-row">

            <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12 tm-block-col">
                <div class="tm-bg-primary-dark tm-block tm-block-products" style="text-align: left;">
                    <div id="Table_Mapping" class="tabulator" style="margin-bottom: 15px;"></div>
                </div>
            </div>
        </div>
    </div>

    <div style="width: 100%; text-align: center; padding-top: 20px;">
        <div style="clear: both; display: block;" id="Upload_download_button">
            <div style="float: left; width: 35%;">&nbsp;</div>
            <button
                id="btnDownload"
                type="submit" style="right: auto; padding: 0px; margin-top: -0px; width: 15%; float: left; height: 60px; font-size: xx-large; margin-right: 2%;" title="Download the mapping"
                class="btn btn-primary btn-block text-uppercase">
                <i class="fas fa-file-download"></i>
            </button>

            <div style="width: 100%; height: 100%;" class="file-upload-container">
                <input type="file" id="f_UploadMapping" style="display: none; overflow: hidden; height: 0px; width: 0px;" />
                <label for="f_UploadMapping" class="btn btn-primary btn-block text-uppercase" style="padding: 0px; margin-top: -0px; width: 15%; float: left; height: 60px; font-size: xx-large; margin-right: 2%;" title="Upload the mapping">
                    <i class="fas fa-file-upload"></i>
                </label>
            </div>


        </div>
        <div style="clear: both">&nbsp;</div>
    </div>


    <script type="text/javascript">
        var Aspects_datatable = [];
        var Mapping_datatable = [];
    </script>
    <%------------------------------------------------------------------------------------------------------%>
    <script src="Template/tabulator/dist/js/tabulator.min.js" type="text/javascript"></script>
    <script src="Template/js/popper.min.js" type="text/javascript"></script>
    <%------------------------------------------------------------------------------------------------------%>
    <link href="Template/tabulator/dist/css/customized-ui/tabulator_midnight.min.css" rel="stylesheet">
    <script type="text/javascript">
        var UID = "<%=Session["UID"]%>";
    </script>
    <%------------------------------------------------------------------------------------------------------%>
    <script src="XML_DB/Profiles/<%=Session["UID"]%>/JS/Aspects.js" type="text/javascript"></script>
    <%------------------------------------------------------------------------------------------------------%>
    <script type="text/javascript">
        $("#btnDownload").click(function () {
            window.location = "ExtraPage/DownloadFile.aspx";
        });

        //---------------------------------------------------Tabel Aspects
        var Table_Aspects, Table_Mapping;


        var url = window.location.search;
        if (url.indexOf("View=") > 0) {
            document.getElementById("PlnNewAspects").style.display = "none";

            Table_Aspects = new Tabulator("#Table_Aspects", {
                height: "650px",
                data: Aspects_datatable, //assign data to table
                layout: "fitColumns",
                headerFilterPlaceholder: "Find...",
                selectable: 1, //make rows selectable
                tooltipsHeader: false,
                tooltips: true,
                columns: [
                    { title: "AspectID", field: "AspectID", sorter: "string", width: 200, visible: false },
                    { title: "Alternative", field: "Alternative", sorter: "string", width: 360, headerFilter: "input", editor: "input" },
                    {
                        title: "URL", field: "Description", sorter: "string", width: 665, headerFilter: "input", editor: "input"
                    },
                ]
            });
        }
        else {
            Table_Aspects = new Tabulator("#Table_Aspects", {
                height: "650px",
                data: Aspects_datatable, //assign data to table
                layout: "fitColumns",
                headerFilterPlaceholder: "Find...",
                selectable: 1, //make rows selectable
                tooltipsHeader: false,
                tooltips: true,
                columns: Aspects_columns,
                rowClick: function (e, row) {

                },
                rowMouseEnter: function (e, row) {

                },
                rowSelectionChanged: function (data, rows) {
                    //update selected row counter on selection change
                },
            });
        }

        //---------------------------------------------------Tabel Aspects

        Table_Mapping = new Tabulator("#Table_Mapping", {
            height: "650px",
            data: Mapping_datatable, //assign data to table
            layout: "fitColumns",
            headerFilterPlaceholder: "Find...",
            selectable: 1, //make rows selectable
            tooltipsHeader: false,
            columns: Mapping_columns,
            rowClick: function (e, row) {

            },
            rowMouseEnter: function (e, row) {

            },
            rowSelectionChanged: function (data, rows) {
                //update selected row counter on selection change
            },
        });
        //---------------------------------------------------- Query Strings
        var qs = (function (a) {
            if (a == "") return {};
            var b = {};
            for (var i = 0; i < a.length; ++i) {
                var p = a[i].split('=', 2);
                if (p.length == 1)
                    b[p[0]] = "";
                else
                    b[p[0]] = decodeURIComponent(p[1].replace(/\+/g, " "));
            }
            return b;
        })(window.location.search.substr(1).split('&'));


        if (qs["View"] != null) {

            $("#item_Benchmarks").attr("class", "nav-item dropdown active");

            document.getElementById("item_home").style.display = "block";

            document.getElementById("DM_Case").style.display = "none";
            document.getElementById("item_qualities").style.display = "none";
            document.getElementById("DM_Features").style.display = "none";
            document.getElementById("DM_Alternatives").style.display = "none";

            document.getElementById("Upload_download_button").style.display = "none";

            document.getElementById("AspectSectionName").innerText = qs["PageCaption"];

            document.getElementById("MappingSectionName").innerText = "Supportability of the features by the " + qs["PageCaption"] + ":";

        }
        else {

            document.getElementById("item_Benchmarks").style.display = "none";
            document.getElementById("item_home").style.display = "none";

            if (qs["Type"] == "Qualities") {
                $("#item_qualities").attr("class", "nav-link active");
                document.getElementById("NewSectionName").innerText = "Add a new quality attribute:";
                document.getElementById("AspectSectionName").innerText = "Quality attributes:";
                document.getElementById("MappingSectionName").innerText = "Mapping:";
                document.getElementById("NewQualityAttribute").style.display = "block";
                document.getElementById("NewFeature").style.display = "none";
                document.getElementById("NewAlternative").style.display = "none";
            }
            else if (qs["Type"] == "Features") {
                $("#item_features").attr("class", "nav-link active");
                document.getElementById("NewSectionName").innerText = "Add a new feature:";
                document.getElementById("AspectSectionName").innerText = "Features:";
                document.getElementById("MappingSectionName").innerText = "Mapping:";
                document.getElementById("NewQualityAttribute").style.display = "none";
                document.getElementById("NewFeature").style.display = "block";
                document.getElementById("NewAlternative").style.display = "none";
            }
            else if (qs["Type"] == "Alternatives") {
                $("#item_alternatives").attr("class", "nav-link active");
                document.getElementById("NewSectionName").innerText = "Add a new alternative:";
                document.getElementById("AspectSectionName").innerText = "Alternatives:";
                document.getElementById("MappingSectionName").innerText = "Mapping:";
                document.getElementById("NewQualityAttribute").style.display = "none";
                document.getElementById("NewFeature").style.display = "none";
                document.getElementById("NewAlternative").style.display = "block";
            }
        }
        //---------------------------------------------------- Ajax
        function NewQualityAttribute() {
            JsonCase = { "title": document.getElementById("txtQAtitle").value, "description": document.getElementById("txtQAdescription").value, "level": document.getElementById("QAlevel").value };
            var postdata = JSON.stringify(JsonCase);

            try {
                $.ajax({
                    type: "POST",
                    url: "GenericHandlers/NewQualityAttribute.ashx",
                    cache: false,
                    data: postdata,
                    success: getSuccess,
                    error: getFail
                });
            } catch (e) {
                alert(e);
            }
            function getSuccess(data, textStatus, jqXHR) {

                ReloadScriptFile('XML_DB/Profiles/' + UID + '/JS/Aspects.js');
                showMessageBox("New aspect", "The quality attribute is added successfully!");
            }

            function getFail(jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            }
        }
        //---------------------------------------------------- 
        function NewFeature() {
            JsonCase = {
                "title": document.getElementById("txtFeaturetitle").value,
                "description": document.getElementById("txtFeaturedescription").value,
                "Keywords": document.getElementById("FeatureKeywords").value,
                "datatype": document.getElementById("datatype").value,
                "MemberOf": document.getElementById("MemberOf").value,
                "UICategory": document.getElementById("UICategory").value
            };
            var postdata = JSON.stringify(JsonCase);

            try {
                $.ajax({
                    type: "POST",
                    url: "GenericHandlers/NewFeature.ashx",
                    cache: false,
                    data: postdata,
                    success: getSuccess,
                    error: getFail
                });
            } catch (e) {
                alert(e);
            }
            function getSuccess(data, textStatus, jqXHR) {

                ReloadScriptFile('XML_DB/Profiles/' + UID + '/JS/Aspects.js');
                showMessageBox("New aspect", "The feature is added successfully!");
            }

            function getFail(jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            }
        }
        //---------------------------------------------------- 

        function NewAlternative() {
            JsonCase = {
                "title": document.getElementById("txtAlternativetitle").value,
                "description": document.getElementById("txtAlternativedescription").value,
                "Keywords": document.getElementById("AlternativeKeywords").value
            };
            var postdata = JSON.stringify(JsonCase);

            try {
                $.ajax({
                    type: "POST",
                    url: "GenericHandlers/NewAlternative.ashx",
                    cache: false,
                    data: postdata,
                    success: getSuccess,
                    error: getFail
                });
            } catch (e) {
                alert(e);
            }
            function getSuccess(data, textStatus, jqXHR) {

                ReloadScriptFile('XML_DB/Profiles/' + UID + '/JS/Aspects.js');
                showMessageBox("New aspect", "The alternative is added successfully!");
            }

            function getFail(jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            }
        }
        //----------------------------------------------------
        function ReloadScriptFile(JSFile) {
            $("script").each(function () {
                var oldScript = this.getAttribute("src");
                if (oldScript === JSFile) {
                    $(this).remove();
                    var newScript;
                    newScript = document.createElement('script');
                    newScript.type = 'text/javascript';
                    newScript.src = oldScript;
                    document.getElementsByTagName("head")[0].appendChild(newScript);
                }
            });
        }
        //----------------------------------------------------
        function DeleteAspect(AspectID, level) {

            JsonCase = {
                "id": AspectID,
                "level": level
            };

            var postdata = JSON.stringify(JsonCase);

            try {
                $.ajax({
                    type: "POST",
                    url: "GenericHandlers/DeleteAspect.ashx",
                    cache: false,
                    data: postdata,
                    success: getSuccess,
                    error: getFail
                });
            } catch (e) {
                alert(e);
            }
            function getSuccess(data, textStatus, jqXHR) {

                ReloadScriptFile('XML_DB/Profiles/' + UID + '/JS/Aspects.js');
                showMessageBox("Delete aspect", "The aspect is deleted successfully!");
            }

            function getFail(jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            }
        }
        //----------------------------------------------------
        function UpdateLinks(AspectID, ParentID, newValue) {

            JsonCase = {
                "AspectID": AspectID,
                "ParentID": ParentID,
                "newValue": newValue
            };

            var postdata = JSON.stringify(JsonCase);

            try {
                $.ajax({
                    type: "POST",
                    url: "GenericHandlers/UpdateMappings.ashx",
                    cache: false,
                    data: postdata,
                    success: getSuccess,
                    error: getFail
                });
            } catch (e) {
                alert(e);
            }
            function getSuccess(data, textStatus, jqXHR) {
                //ReloadScriptFile('XML_DB/Profiles/' + UID + '/JS/Aspects.js');
                showMessageBox("Update mapping", "The mapping is updated successfully!");
            }

            function getFail(jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            }
        }
        //----------------------------------------------------
        function UpdateAspect(Row, level) {
            JsonCase = "";

            if (level == "Qualities") {
                JsonCase = {
                    "TreeLevel": level,
                    "ID": Row.AspectID,
                    "Title": Row.QualityAttribute,
                    "DataType": "Numeric",
                    "Level": Row.Level,
                    "Description": Row.Description,
                    "Order": "G1",
                    "UpperLevel": "NULL",
                    "Keywords": ""
                };
            }
            else if (level == "Features") {
                JsonCase = {
                    "TreeLevel": level,
                    "ID": Row.AspectID,
                    "Title": Row.Feature,
                    "DataType": Row.DataType,
                    "Level": "Feature",
                    "Description": Row.Description,
                    "Order": Row.UICategory,
                    "UpperLevel": Row.MemberOf,
                    "Keywords": Row.Keywords
                };
            }
            else if (level == "Alternatives") {
                JsonCase = {
                    "TreeLevel": level,
                    "ID": Row.AspectID,
                    "Title": Row.Alternative,
                    "DataType": "Description",
                    "Level": "Alternative",
                    "Description": Row.Description,
                    "Order": Row.Corporation,
                    "UpperLevel": Row.Corporation,
                    "Keywords": "NULL"
                };
            }

            var postdata = JSON.stringify(JsonCase);

            try {
                $.ajax({
                    type: "POST",
                    url: "GenericHandlers/UpdateAspect.ashx",
                    cache: false,
                    data: postdata,
                    success: getSuccess,
                    error: getFail
                });
            } catch (e) {
                alert(e);
            }
            function getSuccess(data, textStatus, jqXHR) {

                ReloadScriptFile('XML_DB/Profiles/' + UID + '/JS/Aspects.js');
                showMessageBox("Update aspect", "The aspect is updated successfully!");
            }

            function getFail(jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            }
        }
        //----------------------------------------------------

        var _URL = window.URL || window.webkitURL;
        $("#f_UploadMapping").on('change', function () {

            var file = this.files[0], img;
            if (file)
                UploadMappingFile(file);
        });

        function UploadMappingFile(file) {

            showMessageBox("Uploading the mapping", "Please wait, the process takes a couple of minutes!");
            var formData = new FormData();
            formData.append('file', $('#f_UploadMapping')[0].files[0]);
            $.ajax({
                type: 'post',
                url: 'GenericHandlers/UploadMapping.ashx',
                data: formData,
                success: function (status) {
                    if (status !== 'error') {
                        alert("Uploading successful!");
                    }
                },
                processData: false,
                contentType: false,
                error: function () {
                    alert("Uploading failed!");
                }
            });
        }

    </script>
</asp:Content>
