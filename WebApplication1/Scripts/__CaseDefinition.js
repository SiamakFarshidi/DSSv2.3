var DecisionModel = null;
DecisionModel = "";
autoComplete();
//---------------------------------------------------- Query Strings
var qs = (function (a) {
    if (a === "") return {};
    var b = {};
    for (var i = 0; i < a.length; ++i) {
        var p = a[i].split('=', 2);
        if (p.length === 1)
            b[p[0]] = "";
        else
            b[p[0]] = decodeURIComponent(p[1].replace(/\+/g, " "));
    }
    return b;
})(window.location.search.substr(1).split('&'));


document.getElementById("PageCaption").innerText = qs["PageCaption"];
DecisionModel = '<% =Session["CurrentDecisionModel"] %>';
var ListOfUpdates = { "DM": DecisionModel, "Updates": [] };
//----------------------------------------------------Bar and Pie charts

function drawChart_PieChart() {
    var data = google.visualization.arrayToDataTable(QualityAttributesRatio);

    var options = {
        title: 'Impacts of the selected feature requirements on quality attributes:',
        is3D: true,
        legend: { position: 'left', textStyle: { color: 'white' } },
        backgroundColor: 'transparent',
        chartArea: { left: 0, top: 50, width: "100%", height: "100%" },
        titleTextStyle: {
            color: 'white',
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
            color: 'white',
            fontSize: 14,
            bold: true
        },
        hAxis: { minValue: 0, maxValue: 100, textStyle: { color: '#FFF' } },
        vAxis: { textStyle: { color: '#FFF' } }

    };
    var chart = new google.visualization.BarChart(document.getElementById("barchart_values"));
    chart.draw(view, options);
}



//----------------------------------------------------Decision Structure

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
                { strokeWidth: 1, stroke: "white" }));
    // generate a tree with the default values
    rebuildGraph();
}

//---------------------------------------------------- DropDown Infeasible Solution

function autoComplete() {
    document.getElementById("spnInfeasibleList").remove();
    $("#DD_Placeholder").append("<span class='autocomplete-select' id='spnInfeasibleList'></span>");

    document.getElementById("DecisionStructure").remove();
    $("#PlnDecisionStructure").append("<div id='DecisionStructure' style='width: 100%; font-size: xx-small; height: 630px; background-color: #435C70; border: 2px solid #435C70;'></div >");

    var autocomplete = new SelectPure(".autocomplete-select", {

        options: ListOfInfeasibleSolutions,
        value: [],
        multiple: true,
        autocomplete: true,
        icon: "fa fa-times",
        onChange: value => { ListOfSelectedInfeasibleSolutionsChanges(value); }
    });

    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawChart_PieChart);
    google.charts.setOnLoadCallback(drawChart_BarChart);

    init();
}

var CurrentListOfInfeasibleSolutions = [];

function ListOfSelectedInfeasibleSolutionsChanges(value) {

    if (CurrentListOfInfeasibleSolutions.length < value.length) {
        CurrentListOfInfeasibleSolutions.push(value[value.length - 1]);
        Add_InfeasibleSolution_DecisionMatrix(CurrentListOfInfeasibleSolutions[CurrentListOfInfeasibleSolutions.length - 1]);
    }
    else if (CurrentListOfInfeasibleSolutions.length > value.length) {
        Index = getRemovedItemIndex(value);
        Remove_InfeasibleSolution_DecisionMatrix(CurrentListOfInfeasibleSolutions[Index]);
        CurrentListOfInfeasibleSolutions.splice(Index, 1);
    }
}

var getRemovedItemIndex = function (value) {

    var found = false;

    for (i = 0; i < CurrentListOfInfeasibleSolutions.length; i++) {
        found = false;
        for (j = 0; j < value.length; j++) {
            if (CurrentListOfInfeasibleSolutions[i] === value[j]) {
                found = true;
                break;
            }
        }
        if (!found)
            return i;
    }
    return -1;
};


var getNameByID = function (ID) {

    for (i = 0; i < ListOfInfeasibleSolutions.length; i++)
        if (ListOfInfeasibleSolutions[i].value === ID)
            return ListOfInfeasibleSolutions[i].label;

    return "";
};

function Add_InfeasibleSolution_DecisionMatrix(ID) {
    Name = getNameByID(ID);

    if (!table_decision_matrix.getColumn("A" + ID))
        table_decision_matrix.addColumn({ title: Trim(Name, 15), field: "A" + ID, align: "center", formatter: "tickCross", headerSort: true, headerVertical: true, headerTooltip: Name }, false, "MoSCoW");
    GetInfeasibleSolution({ "Name": Name, "ID": ID });
}

function Trim(str, length) {
    appendix = "...";
    delim = " ";

    if (str.length <= length) return str;

    var trimmedStr = str.substr(0, length + delim.length);

    var lastDelimIndex = trimmedStr.lastIndexOf(delim);
    if (lastDelimIndex >= 0) trimmedStr = trimmedStr.substr(0, lastDelimIndex);

    if (trimmedStr) trimmedStr += appendix;
    return trimmedStr;
}

function Remove_InfeasibleSolution_DecisionMatrix(ID) {

    if (table_decision_matrix.getColumn("A" + ID))
        table_decision_matrix.deleteColumn("A" + ID);
}

//---------------------------------------------------- List of infeasible solutions
var x = document.getElementById("ListOfInfeasibleSolutions");
var option = null;
for (i = 0; i < ListOfInfeasibleSolutions.length; i++) {
    option = document.createElement("option");
    option.text = ListOfInfeasibleSolutions[i].Name;
    option.value = ListOfInfeasibleSolutions[i].ID;
    x.add(option, i + 1);
}

//----------------------------------------------------Feature Requirement

var table_feature_requirements = new Tabulator("#Table_DomainFeatureRequirement", {
    height: "500px",
    data: FeatureRequirement_datatable, //assign data to table
    layout: "fitColumns",
    headerFilterPlaceholder: "Find Features...",
    selectable: 1, //make rows selectable
    dataTree: true,
    dataTreeBranchElement: true,
    dataTreeStartExpanded: false,
    dataTreeElementColumn: "Feature",
    tooltipsHeader: false,
    columns: [
        //{title: "MoSCoW", field: "MoSCoW", sorter: "string", width: 96 },
        { title: "FeatureID", field: "FeatureID", sorter: "string", width: 259, visible: false },
        { title: "Feature Requirement", field: "Feature", sorter: "string", width: 259 },
        {
            title: "MoSCoW", field: "MoSCoW", sorter: "string", editor: "select",
            editorParams: function (cell) {
                var row = cell.getRow();
                if (row.getData().FeatureDataType !== "Category") {
                    return { "None": "None", "Must-Have": "Must-Have", "Should-Have": "Should-Have", "Could-Have": "Could-Have", "Won't-Have": "Won't-Have" };
                }
                return {};
            },
            width: 98,
            cellEdited: function (cell) {

                var row = cell.getRow();
                if (row.getData().FeatureDataType !== "Category") {
                    ID = row.getData().FeatureID;
                    if (cell.getValue() === "None")
                        Req = "N";
                    else
                        Req = getMoSCoW(cell.getValue());
                    UpdateFeatureRequirements_MoSCoW(ID, Req);
                }
            }
        },
        {
            title: "Criterion", field: "FeatureCriterionValue", sorter: "string", editor: "select", width: 90, editorParams: function (cell) {
                var row = cell.getRow();
                if (row.getData().FeatureDataType !== "Category" && (row.getData().FeatureDataType === "Monetary" || row.getData().FeatureDataType === "Numeric")) {
                    if (CurrentDecisionModel === "DBMSMODEL" && row.getData().FeatureDataType === "Monetary") {
                        return { "None": "None", "0.00": "Free", "10000": "less than or equal to &#128;10000", "50000": "less than or equal to &#128;50000", "100000": "less than or equal to &#128;100000", "99999999": "less than or equal to &#128;99999999" };
                    }
                    else if (CurrentDecisionModel === "CSPMODEL" && row.getData().FeatureDataType === "Monetary") {
                        return { "None": "None", "0.00": "Free", "200": "less than or equal to &#128;200", "500": "less than or equal to &#128;500", "1000": "less than or equal to &#128;1000", "2000": "less than or equal to &#128;2000", "3000": "less than or equal to &#128;3000", "5000": "less than or equal to &#128;5000", "99999999": "less than or equal to &#128;99999999" };
                    }
                    else if (CurrentDecisionModel === "SWAPMODEL" && row.getData().FeatureDataType === "Numeric") {
                        return { "None": "None", "0.29": "Low", "0.60": "Average", "0.79": "High" };
                    }
                    else if (CurrentDecisionModel === "PLMODEL" && row.getData().FeatureDataType === "Numeric") {
                        return { "None": "None", "0.09": "Low", "0.49": "Average", "0.89": "High" };
                    }
                    else if (CurrentDecisionModel === "CSPMODEL" && row.getData().FeatureDataType === "Numeric" && row.getData().Feature === "Popularity in the market") {
                        return { "None": "None", "10": "Low", "50": "Average", "70": "High" };
                    }
                    else if (row.getData().FeatureDataType === "Numeric") {
                        return { "None": "None", "0.1": "Low", "0.5": "Average", "0.7": "High" };
                    }
                }
                return {};
            },
            visible: true,
            cellEdited: function (cell) {
                var row = cell.getRow();
                if (row.getData().FeatureDataType !== "Category") {
                    ID = row.getData().FeatureID;
                    UpdateFeatureRequirements_Criterion(ID, cell.getValue());
                }
            }
        },
        {
            title: "Description", field: "Description", sorter: "string", visible: false,
            formatter: function (cell, formatterParams, onRendered) {
                var row = cell.getRow();
                if (row.getData().FeatureDataType === "Category") {
                    row.getElement().style.backgroundColor = "#273746";
                    row.getElement().style.color = "#F1C40F";
                    row.getElement().style.fontWeight = "bold";
                }
            }

        }, //hide this column first
        { title: "FeatureDataType", field: "FeatureDataType", sorter: "string", visible: false }, //hide this column first
        { title: "FeatureCategory", field: "FeatureCategory", sorter: "string", visible: false }, //hide this column first
        { title: "FeatureParent", field: "FeatureParent", sorter: "string", visible: false }, //hide this column first
        { title: "FeatureSupportedAlternatives", field: "FeatureSupportedAlternatives", sorter: "string", visible: false } //hide this column first
    ],
    rowClick: function (e, row) {
        if (row.getData().FeatureDataType === "Category") {
            row.update({ "MoSCoW": "" });

            document.getElementById("FeatureID").value = "";
            document.getElementById("FeatureDescription").innerText = "";
            document.getElementById("FeatureTitle").innerText = "";
            document.getElementById("FeatureDataType").innerText = "";
            document.getElementById("FeatureCategory").innerText = "";
            document.getElementById("FeatureParent").innerText = "";
            document.getElementById("FeatureSupportedAlternatives").innerText = "";
        }
        else {
            document.getElementById("FeatureID").value = row.getIndex();
            document.getElementById("FeatureDescription").innerText = row.getData().Description;
            document.getElementById("FeatureTitle").innerText = row.getData().Feature;
            document.getElementById("FeatureDataType").innerText = row.getData().FeatureDataType;
            document.getElementById("FeatureCategory").innerText = row.getData().FeatureCategory;
            document.getElementById("FeatureParent").innerText = row.getData().FeatureParent;
            document.getElementById("FeatureSupportedAlternatives").innerText = row.getData().FeatureSupportedAlternatives;

            $('#FeatureCriterion option:contains(' + row.getData().FeatureCriterionValue + ')').prop({ selected: true });
            $('#FeatureMoSCoW option:contains(' + row.getData().MoSCoW + ')').prop({ selected: true });
        }
    }
});

//------------------------------------------------------DecisionMatrix
var table_decision_matrix = new Tabulator("#Table_DecisionMatrix", {
    height: "520px",
    data: DecisionMatrix_datatable,
    layout: "fitColumns",
    headerFilterPlaceholder: "Find Features...",
    selectable: 1, //make rows selectable
    tooltipsHeader: true,
    columns: DecisionMatrix_Columns
});
//----------------------------------------------------Search Datasets

var UpdateJasonElementByID = function (JasonDataset, FeatureID, Key, Value) {
    var i = null;
    for (i = 0; JasonDataset.length > i; i += 1) {
        if (JasonDataset[i].id === FeatureID) {
            JasonDataset[i][Key] = Value;
            return JasonDataset;
        }
        if ('_children' in JasonDataset[i]) {

            var j = null;
            for (j = 0; j < JasonDataset[i]._children.length; j++) {
                if (JasonDataset[i]._children[j].id === FeatureID) {
                    JasonDataset[i]._children[j][Key] = Value;
                    return JasonDataset;
                }
                if ('_children' in JasonDataset[i]._children[j]) {
                    for (k = 0; k < JasonDataset[i]._children[j]._children.length; k++) {
                        if (JasonDataset[i]._children[j]._children[k].id === FeatureID) {
                            JasonDataset[i]._children[j]._children[k][Key] = Value;
                            return JasonDataset;
                        }
                    }
                }
            }
        }
    }
    return null;
};

var FlattenDataSet = function (DataSet) {
    var txtDataSet = JSON.stringify(DataSet);
    var i = null;
    for (i = 0; i < txtDataSet.split('{').length; i++) {
        txtDataSet = txtDataSet.replace(',"_children":[', '},');
        txtDataSet = txtDataSet.replace(']}', '');
    }
    return JSON.parse(txtDataSet);
};

var SerachFeatures = function (MainDataSet, searchTerm) {

    searchTerm = searchTerm.toLowerCase();
    DataSet = FlattenDataSet(MainDataSet);
    DataSet = DataSet.filter(e => RegExp(searchTerm, 'i').test(e.Feature) || RegExp(searchTerm, 'i').test(e.Description));

    return DataSet;
};

function Synchronization(FlatDataSet, OriginalDataSet) {
    for (i = 0; i < FlatDataSet.length; i++) {
        OriginalDataSet = UpdateJasonElementByID(OriginalDataSet, FlatDataSet[i].id, 'MoSCoW', FlatDataSet[i].MoSCoW);
        OriginalDataSet = UpdateJasonElementByID(OriginalDataSet, FlatDataSet[i].id, 'FeatureCriterionValue', FlatDataSet[i].FeatureCriterionValue);
    }

    return OriginalDataSet;
}
//---------------------------------------------------- Ajax

function UpdateCase() {
    JsonCase = { "title": document.getElementById("txttitle").value, "explanation": document.getElementById("txtdescription").value };
    var postdata = JSON.stringify(JsonCase);

    try {
        $.ajax({
            type: "POST",
            url: "GenericHandlers/UpdateCase.ashx",
            cache: false,
            data: postdata,
            success: getSuccess,
            error: getFail
        });
    } catch (e) {
        alert(e);
    }
    function getSuccess(data, textStatus, jqXHR) {

        showMessageBox("Update", "The case was successfully updated!");
    }

    function getFail(jqXHR, textStatus, errorThrown) {
        alert(jqXHR.status);
    }
}

var _URL = window.URL || window.webkitURL;
$("#f_UploadImage").on('change', function () {

    var file = this.files[0], img;
    if (file) {
        img = new Image();
        img.onload = function () {
            sendImage(file);
        };
        img.onerror = function () {
            alert("Not a valid file:" + file.type);
        };
        img.src = _URL.createObjectURL(file);
    }
});

function sendImage(file) {

    var formData = new FormData();
    formData.append('file', $('#f_UploadImage')[0].files[0]);
    $.ajax({
        type: 'post',
        url: 'GenericHandlers/fileUploader.ashx',
        data: formData,
        success: function (status) {
            if (status !== 'error') {
                var my_path = "Image/Cases/" + status;
                $("#myUploadedImg").attr("src", my_path);
            }
        },
        processData: false,
        contentType: false,
        error: function () {
            alert("Uploading failed!");
        }
    });
}

$("#f_DecisionModel").on('change', function () {

    var file = this.files[0], img;
    if (file) {
        if (file.type === "text/xml") {
            sendFile(file);
        }
        else {
            alert("Not a valid file:" + file.type);
        }
    }
});

function sendFile(file) {

    var formData = new FormData();
    formData.append('file', $('#f_DecisionModel')[0].files[0]);
    $.ajax({
        type: 'post',
        url: 'GenericHandlers/DecisionModelUploader.ashx',
        data: formData,
        success: function (status) {
            if (status !== 'error') {

                result = status.split(";");
                window.location = "CaseDefinition.aspx?OpenDecisionModel=" + result[0] + "&PageCaption=" + result[1];
            }
        },
        processData: false,
        contentType: false,
        error: function () {
            alert("Uploading failed!");
        }
    });
}

function UpdateFeatureRequirements_MoSCoW(ID, Req) {
    var postdata = JSON.stringify({ "ID": ID, "Req": Req });
    $.ajax({
        type: 'post',
        url: 'GenericHandlers/UpdateFeatureRequirements_MoSCoW.ashx',
        cache: false,
        data: postdata,
        success: function (status) {
            //  alert(status);
        },
        error: function () {
            alert("Updating MoSCoW priorities failed!");
        }
    });
}

function UpdateFeatureRequirements_Criterion(ID, Val) {
    var postdata = JSON.stringify({ "ID": ID, "Val": Val });
    $.ajax({
        type: 'post',
        url: 'GenericHandlers/UpdateFeatureRequirements_Criterion.ashx',
        cache: false,
        data: postdata,
        success: function (status) {
            //  alert(status);
        },
        error: function () {
            alert("Updating criteria failed!");
        }
    });
}

function MakeDecision() {
    $.ajax({
        url: 'GenericHandlers/MakeDecision.ashx',
        timeout: 60000,
        error: function (jqXHR, textStatus) {
                location.reload(true); 
        },
        success: function (status) {
            if (status < 1)
                showMessageBox("Feasible solutions", "<div style='margin:15px;'> No feasible solution found! <br /> Please revise your feature requirements.</div>");

            ReloadScriptFile('XML_DB/Profiles/' + UID + '/JS/DecisionMatrix.js');
            ReloadScriptFile('XML_DB/Profiles/' + UID + '/JS/ListOfInfeasibleSolutions.js');
            ReloadScriptFile('XML_DB/Profiles/' + UID + '/JS/PieChartData.js');
            ReloadScriptFile('XML_DB/Profiles/' + UID + '/JS/BarGraphData.js');
            ReloadScriptFile('XML_DB/Profiles/' + UID + '/JS/DecisionStructure.js');

            table_decision_matrix.clearData();
            table_decision_matrix.setColumns(DecisionMatrix_Columns);
            table_decision_matrix.setData(DecisionMatrix_datatable);
            autoComplete();
        }       
    });
}

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

function GetInfeasibleSolution(InfeasibleSolutionData) {
    var postdata = JSON.stringify(InfeasibleSolutionData);
    try {
        $.ajax({
            type: "POST",
            url: "GenericHandlers/UpdateInfeasibleList.ashx",
            cache: false,
            data: postdata,
            success: getSuccess,
            error: getFail
        });
    } catch (e) {
        alert(e);
    }
    function getSuccess(data, textStatus, jqXHR) {
        UpdateDecisionMatrix(data, InfeasibleSolutionData);
    }
    function getFail(jqXHR, textStatus, errorThrown) {
        alert(jqXHR.status);
    }
}
//----------------------------------------------------Update Decision Matrix
function UpdateDecisionMatrix(FeatureRequirements, InfeasibleSolutionData) {
    var Features = FeatureRequirements.split(';');
    for (i = 0; i < Features.length; i++) {
        Feature = Features[i].split(',');
        for (j = 0; j < DecisionMatrix_datatable.length; j++) {
            if (Feature[0] === DecisionMatrix_datatable[j].FeatureID) {
                DecisionMatrix_datatable[j]["A" + InfeasibleSolutionData.ID] = (Feature[1] === "true" ? true : false);

            }
        }
    }

    table_decision_matrix.setData(DecisionMatrix_datatable);
}

//---------------------------------------------------- Update the list of updates in the knowledge base
function AddUpdate(NewUpdate) {

    isDuplicate = 0;

    for (i = 0; i < ListOfUpdates["Updates"].length; i++) {
        if (ListOfUpdates["Updates"][i].ID === NewUpdate.ID && ListOfUpdates["Updates"][i].UF === NewUpdate.UF) {
            ListOfUpdates["Updates"][i].Val = NewUpdate.Val;
            isDuplicate = 1;
            break;
        }
    }

    if (isDuplicate === 0)
        ListOfUpdates["Updates"].push(NewUpdate);
}

//---------------------------------------------------- Event Handlers
SearchCriteria_OnBlur();

$("#UpdateFeatures").click(function () {
    if (ListOfUpdates["Updates"].length > 0)
        UpdateKnowledgeBase();
});

$("#updateDefinition").click(function () {
    UpdateCase();
});

$("#ExtractFeatures").click(function () {

    showMessageBox('title', 'body');
});

$("#btnShow_Report").click(function () {
    window.open('ExtraPage/PrintableReport.aspx', '_blank');
});


function ClearSearchCriteria() {
    document.getElementById("SearchCriteria").value = "Find features...";
    document.getElementById("SearchCriteria").style.fontStyle = "italic";
    document.getElementById("SearchCriteria").style.fontSize = "small";
    document.getElementById("SearchCriteria").style.color = "#D0D3D4";
}

function SearchCriteria_OnBlur() {
    if (document.getElementById("SearchCriteria").value === "") {
        ClearSearchCriteria();
    }
}

function SearchCriteria_OnFocus() {
    if (document.getElementById("SearchCriteria").value === "Find features...") {
        document.getElementById("SearchCriteria").value = "";
        document.getElementById("SearchCriteria").style.fontStyle = "normal";
        document.getElementById("SearchCriteria").style.fontSize = "medium";
        document.getElementById("SearchCriteria").style.color = "white";
    }
}

$("#btn_SearchForFeatures").click(function () {
    if (document.getElementById("SearchCriteria").value !== "Find features...") {
        FeatureRequirement_datatable = Synchronization(FeatureRequirement_datatable, DuplicateDataset);
        FeatureRequirement_datatable = SerachFeatures(FeatureRequirement_datatable, document.getElementById("SearchCriteria").value);
        table_feature_requirements.setData(FeatureRequirement_datatable);
    }
});

$("#btnDownload").click(function () {
    window.location = "ExtraPage/DownloadFile.aspx";
});

$("#btn_AllFeatures").click(function () {
    FeatureRequirement_datatable = Synchronization(FeatureRequirement_datatable, DuplicateDataset);
    table_feature_requirements.setData(FeatureRequirement_datatable);
    ClearSearchCriteria();
});

$("#SearchCriteria").keyup(function (event) {
    if (document.getElementById("SearchCriteria").value === "") {
        FeatureRequirement_datatable = Synchronization(FeatureRequirement_datatable, DuplicateDataset);
        table_feature_requirements.setData(FeatureRequirement_datatable);
    }
    else
        $("#btn_SearchForFeatures").click();
});

var getMoSCoW = function (Priority) {

    switch (Priority) {
        case "Must-Have": return "M";
        case "Should-Have": return "S";
        case "Could-Have": return "C";
        case "Won't-Have": return "W";
    }
};
//----------------------------------------------------

