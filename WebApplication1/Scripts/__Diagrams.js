//----------------------------------------------------Decision Structure
function rebuildGraph() {
    var minNodes = 20;
    minNodes = parseInt(minNodes, 10);
    var maxNodes = 100;
    maxNodes = parseInt(maxNodes, 10);
    generateDigraph(minNodes, maxNodes);
}
function generateDigraph(minNodes, maxNodes) {
    myDiagram.startTransaction("generateDigraph");

    generateNodes(minNodes, maxNodes);
    generateLinks();
    initialGraph();

    layout();
    myDiagram.commitTransaction("generateDigraph");
}
// Creates a random number of randomly colored nodes.
function generateNodes(minNodes, maxNodes) {
    var nodeArray = [];
    // get the values from the fields and create a random number of nodes within the range
    var min = parseInt(minNodes, 10);
    var max = parseInt(maxNodes, 10);
    if (isNaN(min)) min = 0;
    if (isNaN(max) || max < min) max = min;
    var numNodes = Math.floor(Math.random() * (max - min + 1)) + min;
    var i;
    for (i = 0; i < numNodes; i++) {
        nodeArray.push({ key: i, text: i.toString(), fill: go.Brush.randomColor() });
    }
    // randomize the node data
    for (i = 0; i < nodeArray.length; i++) {
        var swap = Math.floor(Math.random() * nodeArray.length);
        var temp = nodeArray[swap];
        nodeArray[swap] = nodeArray[i];
        nodeArray[i] = temp;
    }
    // set the nodeDataArray to this array of objects
    myDiagram.model.nodeDataArray = nodeArray;
}
// Create some link data
function generateLinks() {
    if (myDiagram.nodes.count < 2) return;
    var linkArray = [];
    var nit = myDiagram.nodes;
    var nodes = new go.List(go.Node);
    nodes.addAll(nit);
    for (var i = 0; i < nodes.count - 1; i++) {
        var from = nodes.elt(i);
        var numto = Math.floor(1 + Math.random() * 3 / 2);
        for (var j = 0; j < numto; j++) {
            var idx = Math.floor(i + 5 + Math.random() * 10);
            if (idx >= nodes.count) idx = i + Math.random() * (nodes.count - i) | 0;
            var to = nodes.elt(idx);
            linkArray.push({ from: from.data.key, to: to.data.key });
        }
    }
    myDiagram.model.linkDataArray = linkArray;
}

function layout() {
    myDiagram.startTransaction("change Layout");
    var lay = myDiagram.layout;
    var direction = getRadioValue("direction");
    direction = parseFloat(direction, 10);
    lay.direction = direction;
    var layerSpacing = document.getElementById("layerSpacing").value;
    layerSpacing = parseFloat(layerSpacing, 10);
    lay.layerSpacing = layerSpacing;
    var columnSpacing = document.getElementById("columnSpacing").value;
    columnSpacing = parseFloat(columnSpacing, 10);
    lay.columnSpacing = columnSpacing;
    var cycleRemove = getRadioValue("cycleRemove");
    if (cycleRemove === "CycleDepthFirst") lay.cycleRemoveOption = go.LayeredDigraphLayout.CycleDepthFirst;
    else if (cycleRemove === "CycleGreedy") lay.cycleRemoveOption = go.LayeredDigraphLayout.CycleGreedy;
    var layering = getRadioValue("layering");
    if (layering === "LayerOptimalLinkLength") lay.layeringOption = go.LayeredDigraphLayout.LayerOptimalLinkLength;
    else if (layering === "LayerLongestPathSource") lay.layeringOption = go.LayeredDigraphLayout.LayerLongestPathSource;
    else if (layering === "LayerLongestPathSink") lay.layeringOption = go.LayeredDigraphLayout.LayerLongestPathSink;
    var initialize = getRadioValue("initialize");
    if (initialize === "InitDepthFirstOut") lay.initializeOption = go.LayeredDigraphLayout.InitDepthFirstOut;
    else if (initialize === "InitDepthFirstIn") lay.initializeOption = go.LayeredDigraphLayout.InitDepthFirstIn;
    else if (initialize === "InitNaive") lay.initializeOption = go.LayeredDigraphLayout.InitNaive;
    var aggressive = getRadioValue("aggressive");
    if (aggressive === "AggressiveLess") lay.aggressiveOption = go.LayeredDigraphLayout.AggressiveLess;
    else if (aggressive === "AggressiveNone") lay.aggressiveOption = go.LayeredDigraphLayout.AggressiveNone;
    else if (aggressive === "AggressiveMore") lay.aggressiveOption = go.LayeredDigraphLayout.AggressiveMore;
    //TODO implement pack option
    var pack = document.getElementsByName("pack");
    var packing = 0;
    for (var i = 0; i < pack.length; i++) {
        if (pack[i].checked) packing = packing | parseInt(pack[i].value, 10);
    }
    lay.packOption = packing;
    var setsPortSpots = document.getElementById("setsPortSpots");
    lay.setsPortSpots = setsPortSpots.checked;

    myDiagram.commitTransaction("change Layout");
}
function getRadioValue(name) {
    var radio = document.getElementsByName(name);
    for (var i = 0; i < radio.length; i++)
        if (radio[i].checked) return radio[i].value;
}

function initialGraph() {
    myDiagram.model.nodeDataArray = DecisionStructureNodes;
    myDiagram.model.linkDataArray = DecisionStructureLinks;
}


