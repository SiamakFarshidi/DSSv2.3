var DeleteIcon = function (cell, formatterParams) { return "<i class='fas fa-trash-alt'></i>";};var UpdateIcone = function(cell, formatterParams) { return "<i class='fas fa-sync-alt'></i>";};var Aspects_columns = [  { title: "AspectID", field: "AspectID", sorter: "string", width: 200, visible: false }, { title: "Alternative", field: "Alternative", sorter: "string", width: 225, headerFilter: "input", editor: "input" }, { title: "Description", field: "Description", sorter: "string", width: 520, headerFilter: "input", editor: "input" }, { title: "Corporation", field: "Corporation", sorter: "string", width: 200, headerFilter: "input", editor: "input" }, { formatter: UpdateIcone, width: 30, align: "center", tooltip: "Update", field: "Update", 
                                            cellClick:function(e, cell){
                                                var row = cell.getRow();
                                                UpdateAspect(row.getData(), "Alternatives");
                                            }
                   }, { formatter: DeleteIcon, width: 30, align: "center", tooltip: "Delete", field: "Delete", 
                                            cellClick:function(e, cell){
                                                var row = cell.getRow();
                                                DeleteAspect(row.getData().AspectID, "Alternatives");
                                            }
                       }]; Aspects_datatable = [ {AspectID:"637792449917676250",Alternative:"Ordered Checklist",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449917796272",Alternative:"Unordered Checklist",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449917936285",Alternative:"Petri Net",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449918016242",Alternative:"Coloured Petri Net",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449918106247",Alternative:"Flowchart",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449918186249",Alternative:"BPMN 2.0",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449918286245",Alternative:"IDEF0",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449918366269",Alternative:"IDEF3",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449918466271",Alternative:"YAWL",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449918536272",Alternative:"EPC",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449918646265",Alternative:"UML Activity Diagram",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449918726602",Alternative:"UML Use Case Diagram",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449918836627",Alternative:"UML State (Transition) Diagram",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449918926397",Alternative:"RAD",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449919026653",Alternative:"DFD",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449919136242",Alternative:"VSM (Value Stream Mapping)",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449919226240",Alternative:"Gantt Chart",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449919346676",Alternative:"BPEL (2.0)",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449919446598",Alternative:"BPML",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449919536707",Alternative:"EEML",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449919636672",Alternative:"ER/ERD",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449919726560",Alternative:"UML Sequence Diagram",Corporation:"NULL",Description:"(----------New Alternative--------)"},{AspectID:"637792449919846691",Alternative:"UML Communication Diagram",Corporation:"NULL",Description:"(----------New Alternative--------)"}];var Mapping_columns = [  { title: "AspectID", field: "AspectID", sorter: "string", width: 200, visible: false }, { title: "Alternative", field: "Alternative", sorter: "string", width: 225, headerFilter: "input", editor: "input" },{ title: "Communicatio...", field: "Communication", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444398226480", cell.getValue());
                    },
                    headerTooltip:"Communication" },{ title: "Analysis", field: "Analysis", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444399004101", cell.getValue());
                    },
                    headerTooltip:"Analysis" },{ title: "Enaction", field: "Enaction", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444399416121", cell.getValue());
                    },
                    headerTooltip:"Enaction" },{ title: "Control", field: "Control", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444399946113", cell.getValue());
                    },
                    headerTooltip:"Control" },{ title: "Functional", field: "Functional", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444400316493", cell.getValue());
                    },
                    headerTooltip:"Functional" },{ title: "Dynamic/Beha...", field: "Dynamic/Behavioural", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444400816183", cell.getValue());
                    },
                    headerTooltip:"Dynamic/Behavioural" },{ title: "Informationa...", field: "Informational/Resource", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444401486130", cell.getValue());
                    },
                    headerTooltip:"Informational/Resource" },{ title: "Organization...", field: "Organizational", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444402056117", cell.getValue());
                    },
                    headerTooltip:"Organizational" },{ title: "General-purp...", field: "General-purpose ML", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444402476144", cell.getValue());
                    },
                    headerTooltip:"General-purpose ML" },{ title: "Textual", field: "Textual", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444403264949", cell.getValue());
                    },
                    headerTooltip:"Textual" },{ title: "Graphical/Di...", field: "Graphical/Diagrammical", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444403645150", cell.getValue());
                    },
                    headerTooltip:"Graphical/Diagrammical" },{ title: "Tabular", field: "Tabular", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444404197072", cell.getValue());
                    },
                    headerTooltip:"Tabular" },{ title: "Mathematical", field: "Mathematical", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444404447087", cell.getValue());
                    },
                    headerTooltip:"Mathematical" },{ title: "Imperative", field: "Imperative", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444404937807", cell.getValue());
                    },
                    headerTooltip:"Imperative" },{ title: "Declarative", field: "Declarative", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444405400598", cell.getValue());
                    },
                    headerTooltip:"Declarative" },{ title: "Control...", field: "Control flow/Sequence", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444405790713", cell.getValue());
                    },
                    headerTooltip:"Control flow/Sequence" },{ title: "Information...", field: "Information flow/Message flow", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444406132675", cell.getValue());
                    },
                    headerTooltip:"Information flow/Message flow" },{ title: "Data flow", field: "Data flow", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444406412653", cell.getValue());
                    },
                    headerTooltip:"Data flow" },{ title: "Inclusive...", field: "Inclusive choice (OR)", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444406752226", cell.getValue());
                    },
                    headerTooltip:"Inclusive choice (OR)" },{ title: "Exclusive...", field: "Exclusive choice (XOR)", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444407222160", cell.getValue());
                    },
                    headerTooltip:"Exclusive choice (XOR)" },{ title: "Parallelism...", field: "Parallelism (AND)", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444407556418", cell.getValue());
                    },
                    headerTooltip:"Parallelism (AND)" },{ title: "Input", field: "Input", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444408009742", cell.getValue());
                    },
                    headerTooltip:"Input" },{ title: "Output", field: "Output", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444408379801", cell.getValue());
                    },
                    headerTooltip:"Output" },{ title: "External...", field: "External entities", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444408739670", cell.getValue());
                    },
                    headerTooltip:"External entities" },{ title: "Agent...", field: "Agent (Roles/Entitites)", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444409199329", cell.getValue());
                    },
                    headerTooltip:"Agent (Roles/Entitites)" },{ title: "Duration", field: "Duration", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444409559255", cell.getValue());
                    },
                    headerTooltip:"Duration" },{ title: "Deadline", field: "Deadline", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444410009265", cell.getValue());
                    },
                    headerTooltip:"Deadline" },{ title: "Business...", field: "Business rules", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444410408905", cell.getValue());
                    },
                    headerTooltip:"Business rules" },{ title: "Business...", field: "Business goals", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444410752360", cell.getValue());
                    },
                    headerTooltip:"Business goals" },{ title: "Annotation", field: "Annotation", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444411182406", cell.getValue());
                    },
                    headerTooltip:"Annotation" },{ title: "Task/Activit...", field: "Task/Activity", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444411802851", cell.getValue());
                    },
                    headerTooltip:"Task/Activity" },{ title: "Event/Trigge...", field: "Event/Trigger", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444412262813", cell.getValue());
                    },
                    headerTooltip:"Event/Trigger" },{ title: "Mappability", field: "Mappability", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444412702786", cell.getValue());
                    },
                    headerTooltip:"Mappability" },{ title: "Standardized...", field: "Standardized file format", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444413232420", cell.getValue());
                    },
                    headerTooltip:"Standardized file format" },{ title: "XML", field: "XML", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444414132791", cell.getValue());
                    },
                    headerTooltip:"XML" },{ title: "PNML", field: "PNML", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444414510682", cell.getValue());
                    },
                    headerTooltip:"PNML" },{ title: "XSD (XML...", field: "XSD (XML Schema Definition)", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444414830726", cell.getValue());
                    },
                    headerTooltip:"XSD (XML Schema Definition)" },{ title: "XMI (XML...", field: "XMI (XML Metadata Interchange)", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444415200737", cell.getValue());
                    },
                    headerTooltip:"XMI (XML Metadata Interchange)" },{ title: "yawl-XML", field: "yawl-XML", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444415491093", cell.getValue());
                    },
                    headerTooltip:"yawl-XML" },{ title: "EPML", field: "EPML", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444415781297", cell.getValue());
                    },
                    headerTooltip:"EPML" },{ title: "Execution...", field: "Execution Engine Availability", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444416130700", cell.getValue());
                    },
                    headerTooltip:"Execution Engine Availability" },{ title: "Simulation...", field: "Simulation support", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444416690677", cell.getValue());
                    },
                    headerTooltip:"Simulation support" },{ title: "Verification...", field: "Verification support", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444417221101", cell.getValue());
                    },
                    headerTooltip:"Verification support" },{ title: "True...", field: "True concurrency", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444417571109", cell.getValue());
                    },
                    headerTooltip:"True concurrency" },{ title: "System...", field: "System Interpretation", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444418001106", cell.getValue());
                    },
                    headerTooltip:"System Interpretation" },{ title: "Decompositio...", field: "Decomposition", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444418560711", cell.getValue());
                    },
                    headerTooltip:"Decomposition" },{ title: "High-level...", field: "High-level support", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444419550695", cell.getValue());
                    },
                    headerTooltip:"High-level support" },{ title: "Low-level...", field: "Low-level support", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444419890706", cell.getValue());
                    },
                    headerTooltip:"Low-level support" },{ title: "State-based", field: "State-based", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444420241106", cell.getValue());
                    },
                    headerTooltip:"State-based" },{ title: "Activity-bas...", field: "Activity-based", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444420640709", cell.getValue());
                    },
                    headerTooltip:"Activity-based" },{ title: "Novice", field: "Novice", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444421104649", cell.getValue());
                    },
                    headerTooltip:"Novice" },{ title: "Expert", field: "Expert", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444421575072", cell.getValue());
                    },
                    headerTooltip:"Expert" },{ title: "Graphical...", field: "Graphical economy", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444421864668", cell.getValue());
                    },
                    headerTooltip:"Graphical economy" },{ title: "Visual...", field: "Visual emphasis: colour", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444422875032", cell.getValue());
                    },
                    headerTooltip:"Visual emphasis: colour" },{ title: "Formality...", field: "Formality (clear definition of rules)", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444423255116", cell.getValue());
                    },
                    headerTooltip:"Formality (clear definition of rules)" },{ title: "Perceptual...", field: "Perceptual discriminatibility", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444423812271", cell.getValue());
                    },
                    headerTooltip:"Perceptual discriminatibility" },{ title: "Semantic...", field: "Semantic transparency", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444424432623", cell.getValue());
                    },
                    headerTooltip:"Semantic transparency" },{ title: "Organization...", field: "Organizational body", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444425052486", cell.getValue());
                    },
                    headerTooltip:"Organizational body" },{ title: "Conformity...", field: "Conformity to standard", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444425732451", cell.getValue());
                    },
                    headerTooltip:"Conformity to standard" },{ title: "Evolutionary", field: "Evolutionary", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444426592450", cell.getValue());
                    },
                    headerTooltip:"Evolutionary" },{ title: "Theoretical...", field: "Theoretical Foundation", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444426772446", cell.getValue());
                    },
                    headerTooltip:"Theoretical Foundation" },{ title: "Documentatio...", field: "Documentation availability", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444427672460", cell.getValue());
                    },
                    headerTooltip:"Documentation availability" },{ title: "Active...", field: "Active community", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444428772655", cell.getValue());
                    },
                    headerTooltip:"Active community" },{ title: "HR...", field: "HR availability", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444429752463", cell.getValue());
                    },
                    headerTooltip:"HR availability" },{ title: "Training...", field: "Training material availability (degree)", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444430382447", cell.getValue());
                    },
                    headerTooltip:"Training material availability (degree)" },{ title: "YouTube...", field: "YouTube availability", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444431462471", cell.getValue());
                    },
                    headerTooltip:"YouTube availability" },{ title: "Course...", field: "Course availability", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444432372523", cell.getValue());
                    },
                    headerTooltip:"Course availability" },{ title: "Blog/Article...", field: "Blog/Article availability", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444433311573", cell.getValue());
                    },
                    headerTooltip:"Blog/Article availability" },{ title: "Degree of...", field: "Degree of Popularity", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444434003266", cell.getValue());
                    },
                    headerTooltip:"Degree of Popularity" },{ title: "tool...", field: "tool availability (degree)", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444434603707", cell.getValue());
                    },
                    headerTooltip:"tool availability (degree)" },{ title: "free tools...", field: "free tools availability", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444435479426", cell.getValue());
                    },
                    headerTooltip:"free tools availability" },{ title: "open-source...", field: "open-source tools availability", align: "center", editor: true, formatter: "tickCross", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,"637792444436244682", cell.getValue());
                    },
                    headerTooltip:"open-source tools availability" }];Mapping_datatable = [ { id: 1,AspectID:"637792449917676250", Alternative: "Ordered Checklist", "Communication":false,"Analysis":false,"Enaction":true,"Control":false,"Functional":true,"Dynamic/Behavioural":true,"Informational/Resource":false,"Organizational":false,"General-purpose ML":true,"Textual":true,"Graphical/Diagrammical":false,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":false,"Data flow":false,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":false,"Parallelism (AND)":false,"Input":false,"Output":false,"External entities":false,"Agent (Roles/Entitites)":false,"Duration":false,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":true,"Task/Activity":true,"Event/Trigger":false,"Mappability":false,"Standardized file format":false,"XML":false,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":false,"Simulation support":false,"Verification support":false,"True concurrency":false,"System Interpretation":false,"Decomposition":false,"High-level support":false,"Low-level support":true,"State-based":false,"Activity-based":true,"Novice":true,"Expert":false,"Graphical economy":false,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":false,"Semantic transparency":false,"Organizational body":false,"Conformity to standard":false,"Evolutionary":false,"Theoretical Foundation":false,"Documentation availability":false,"Active community":false,"HR availability":false,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":false,"Blog/Article availability":true,"Degree of Popularity":false,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 2,AspectID:"637792449917796272", Alternative: "Unordered Checklist", "Communication":false,"Analysis":false,"Enaction":true,"Control":false,"Functional":true,"Dynamic/Behavioural":false,"Informational/Resource":false,"Organizational":false,"General-purpose ML":true,"Textual":true,"Graphical/Diagrammical":false,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":false,"Information flow/Message flow":false,"Data flow":false,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":false,"Parallelism (AND)":false,"Input":false,"Output":false,"External entities":false,"Agent (Roles/Entitites)":false,"Duration":false,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":true,"Task/Activity":true,"Event/Trigger":false,"Mappability":false,"Standardized file format":false,"XML":false,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":false,"Simulation support":false,"Verification support":false,"True concurrency":false,"System Interpretation":false,"Decomposition":false,"High-level support":false,"Low-level support":true,"State-based":false,"Activity-based":true,"Novice":true,"Expert":false,"Graphical economy":false,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":false,"Semantic transparency":false,"Organizational body":false,"Conformity to standard":false,"Evolutionary":false,"Theoretical Foundation":false,"Documentation availability":false,"Active community":false,"HR availability":false,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":false,"Blog/Article availability":true,"Degree of Popularity":false,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 3,AspectID:"637792449917936285", Alternative: "Petri Net", "Communication":false,"Analysis":true,"Enaction":true,"Control":true,"Functional":true,"Dynamic/Behavioural":true,"Informational/Resource":false,"Organizational":false,"General-purpose ML":true,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":true,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":true,"Data flow":true,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":true,"Parallelism (AND)":true,"Input":true,"Output":true,"External entities":false,"Agent (Roles/Entitites)":false,"Duration":false,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":false,"Task/Activity":true,"Event/Trigger":true,"Mappability":true,"Standardized file format":true,"XML":true,"PNML":true,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":true,"Simulation support":true,"Verification support":true,"True concurrency":true,"System Interpretation":true,"Decomposition":false,"High-level support":false,"Low-level support":true,"State-based":true,"Activity-based":false,"Novice":false,"Expert":true,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":false,"Conformity to standard":true,"Evolutionary":false,"Theoretical Foundation":true,"Documentation availability":true,"Active community":true,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":true,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 4,AspectID:"637792449918016242", Alternative: "Coloured Petri Net", "Communication":false,"Analysis":true,"Enaction":true,"Control":true,"Functional":true,"Dynamic/Behavioural":true,"Informational/Resource":false,"Organizational":false,"General-purpose ML":true,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":true,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":true,"Data flow":true,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":true,"Parallelism (AND)":true,"Input":true,"Output":true,"External entities":false,"Agent (Roles/Entitites)":false,"Duration":false,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":false,"Task/Activity":true,"Event/Trigger":true,"Mappability":false,"Standardized file format":true,"XML":true,"PNML":true,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":true,"Simulation support":true,"Verification support":true,"True concurrency":true,"System Interpretation":true,"Decomposition":false,"High-level support":false,"Low-level support":true,"State-based":true,"Activity-based":false,"Novice":false,"Expert":true,"Graphical economy":true,"Visual emphasis: colour":true,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":false,"Conformity to standard":true,"Evolutionary":false,"Theoretical Foundation":true,"Documentation availability":true,"Active community":true,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":true,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 5,AspectID:"637792449918106247", Alternative: "Flowchart", "Communication":true,"Analysis":true,"Enaction":false,"Control":true,"Functional":true,"Dynamic/Behavioural":false,"Informational/Resource":false,"Organizational":false,"General-purpose ML":true,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":false,"Data flow":false,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":true,"Parallelism (AND)":false,"Input":true,"Output":true,"External entities":false,"Agent (Roles/Entitites)":false,"Duration":false,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":true,"Task/Activity":true,"Event/Trigger":false,"Mappability":false,"Standardized file format":false,"XML":false,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":true,"Simulation support":false,"Verification support":false,"True concurrency":false,"System Interpretation":false,"Decomposition":false,"High-level support":false,"Low-level support":true,"State-based":false,"Activity-based":true,"Novice":true,"Expert":false,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":false,"Conformity to standard":true,"Evolutionary":false,"Theoretical Foundation":false,"Documentation availability":true,"Active community":true,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":true,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 6,AspectID:"637792449918186249", Alternative: "BPMN 2.0", "Communication":true,"Analysis":true,"Enaction":true,"Control":true,"Functional":true,"Dynamic/Behavioural":true,"Informational/Resource":false,"Organizational":true,"General-purpose ML":true,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":true,"Data flow":true,"Inclusive choice (OR)":true,"Exclusive choice (XOR)":true,"Parallelism (AND)":true,"Input":true,"Output":true,"External entities":true,"Agent (Roles/Entitites)":true,"Duration":false,"Deadline":true,"Business rules":true,"Business goals":false,"Annotation":true,"Task/Activity":true,"Event/Trigger":true,"Mappability":true,"Standardized file format":true,"XML":true,"PNML":false,"XSD (XML Schema Definition)":true,"XMI (XML Metadata Interchange)":true,"yawl-XML":false,"EPML":false,"Execution Engine Availability":true,"Simulation support":true,"Verification support":true,"True concurrency":false,"System Interpretation":true,"Decomposition":true,"High-level support":true,"Low-level support":true,"State-based":false,"Activity-based":true,"Novice":true,"Expert":true,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":true,"Conformity to standard":true,"Evolutionary":true,"Theoretical Foundation":true,"Documentation availability":true,"Active community":true,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":true,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 7,AspectID:"637792449918286245", Alternative: "IDEF0", "Communication":false,"Analysis":true,"Enaction":false,"Control":false,"Functional":true,"Dynamic/Behavioural":false,"Informational/Resource":false,"Organizational":false,"General-purpose ML":false,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":true,"Imperative":true,"Declarative":false,"Control flow/Sequence":false,"Information flow/Message flow":true,"Data flow":true,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":false,"Parallelism (AND)":false,"Input":true,"Output":true,"External entities":false,"Agent (Roles/Entitites)":false,"Duration":false,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":false,"Task/Activity":true,"Event/Trigger":false,"Mappability":false,"Standardized file format":false,"XML":false,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":false,"Simulation support":false,"Verification support":true,"True concurrency":false,"System Interpretation":false,"Decomposition":true,"High-level support":true,"Low-level support":true,"State-based":true,"Activity-based":false,"Novice":false,"Expert":true,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":false,"Conformity to standard":true,"Evolutionary":false,"Theoretical Foundation":true,"Documentation availability":true,"Active community":false,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":false,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":false,"open-source tools availability":false},{ id: 8,AspectID:"637792449918366269", Alternative: "IDEF3", "Communication":true,"Analysis":false,"Enaction":false,"Control":false,"Functional":false,"Dynamic/Behavioural":true,"Informational/Resource":false,"Organizational":false,"General-purpose ML":true,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":false,"Data flow":true,"Inclusive choice (OR)":true,"Exclusive choice (XOR)":true,"Parallelism (AND)":true,"Input":false,"Output":false,"External entities":false,"Agent (Roles/Entitites)":false,"Duration":false,"Deadline":false,"Business rules":true,"Business goals":false,"Annotation":false,"Task/Activity":true,"Event/Trigger":true,"Mappability":false,"Standardized file format":false,"XML":false,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":true,"Simulation support":false,"Verification support":true,"True concurrency":true,"System Interpretation":false,"Decomposition":true,"High-level support":true,"Low-level support":true,"State-based":true,"Activity-based":true,"Novice":false,"Expert":true,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":false,"Conformity to standard":false,"Evolutionary":false,"Theoretical Foundation":true,"Documentation availability":false,"Active community":false,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":false,"Course availability":false,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":false,"open-source tools availability":false},{ id: 9,AspectID:"637792449918466271", Alternative: "YAWL", "Communication":false,"Analysis":true,"Enaction":true,"Control":true,"Functional":true,"Dynamic/Behavioural":false,"Informational/Resource":true,"Organizational":false,"General-purpose ML":true,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":true,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":true,"Data flow":true,"Inclusive choice (OR)":true,"Exclusive choice (XOR)":true,"Parallelism (AND)":true,"Input":false,"Output":false,"External entities":false,"Agent (Roles/Entitites)":true,"Duration":false,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":false,"Task/Activity":true,"Event/Trigger":true,"Mappability":false,"Standardized file format":true,"XML":true,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":true,"EPML":false,"Execution Engine Availability":true,"Simulation support":true,"Verification support":true,"True concurrency":true,"System Interpretation":true,"Decomposition":true,"High-level support":false,"Low-level support":true,"State-based":true,"Activity-based":true,"Novice":false,"Expert":true,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":true,"Conformity to standard":false,"Evolutionary":true,"Theoretical Foundation":true,"Documentation availability":true,"Active community":true,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":true,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 10,AspectID:"637792449918536272", Alternative: "EPC", "Communication":true,"Analysis":true,"Enaction":false,"Control":false,"Functional":true,"Dynamic/Behavioural":true,"Informational/Resource":false,"Organizational":true,"General-purpose ML":true,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":false,"Data flow":true,"Inclusive choice (OR)":true,"Exclusive choice (XOR)":true,"Parallelism (AND)":true,"Input":true,"Output":true,"External entities":true,"Agent (Roles/Entitites)":true,"Duration":false,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":false,"Task/Activity":true,"Event/Trigger":true,"Mappability":true,"Standardized file format":false,"XML":true,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":true,"Execution Engine Availability":true,"Simulation support":false,"Verification support":true,"True concurrency":false,"System Interpretation":false,"Decomposition":false,"High-level support":false,"Low-level support":true,"State-based":false,"Activity-based":true,"Novice":true,"Expert":false,"Graphical economy":true,"Visual emphasis: colour":true,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":false,"Conformity to standard":false,"Evolutionary":false,"Theoretical Foundation":true,"Documentation availability":false,"Active community":false,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":true,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":false},{ id: 11,AspectID:"637792449918646265", Alternative: "UML Activity Diagram", "Communication":true,"Analysis":true,"Enaction":false,"Control":true,"Functional":true,"Dynamic/Behavioural":true,"Informational/Resource":false,"Organizational":true,"General-purpose ML":true,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":true,"Data flow":false,"Inclusive choice (OR)":true,"Exclusive choice (XOR)":true,"Parallelism (AND)":true,"Input":true,"Output":true,"External entities":true,"Agent (Roles/Entitites)":true,"Duration":false,"Deadline":true,"Business rules":false,"Business goals":false,"Annotation":true,"Task/Activity":true,"Event/Trigger":true,"Mappability":true,"Standardized file format":true,"XML":true,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":true,"yawl-XML":false,"EPML":false,"Execution Engine Availability":true,"Simulation support":false,"Verification support":false,"True concurrency":false,"System Interpretation":false,"Decomposition":false,"High-level support":true,"Low-level support":true,"State-based":false,"Activity-based":true,"Novice":true,"Expert":true,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":true,"Conformity to standard":true,"Evolutionary":true,"Theoretical Foundation":true,"Documentation availability":true,"Active community":true,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":true,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 12,AspectID:"637792449918726602", Alternative: "UML Use Case Diagram", "Communication":true,"Analysis":false,"Enaction":false,"Control":false,"Functional":false,"Dynamic/Behavioural":false,"Informational/Resource":false,"Organizational":true,"General-purpose ML":true,"Textual":true,"Graphical/Diagrammical":false,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":false,"Information flow/Message flow":true,"Data flow":true,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":true,"Parallelism (AND)":false,"Input":false,"Output":false,"External entities":true,"Agent (Roles/Entitites)":true,"Duration":false,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":true,"Task/Activity":true,"Event/Trigger":true,"Mappability":false,"Standardized file format":true,"XML":true,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":true,"yawl-XML":false,"EPML":false,"Execution Engine Availability":false,"Simulation support":false,"Verification support":false,"True concurrency":false,"System Interpretation":false,"Decomposition":false,"High-level support":true,"Low-level support":false,"State-based":true,"Activity-based":false,"Novice":true,"Expert":false,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":true,"Conformity to standard":true,"Evolutionary":true,"Theoretical Foundation":true,"Documentation availability":true,"Active community":true,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":true,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 13,AspectID:"637792449918836627", Alternative: "UML State (Transition) Diagram", "Communication":true,"Analysis":false,"Enaction":true,"Control":true,"Functional":false,"Dynamic/Behavioural":true,"Informational/Resource":true,"Organizational":false,"General-purpose ML":false,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":false,"Information flow/Message flow":false,"Data flow":true,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":true,"Parallelism (AND)":true,"Input":false,"Output":false,"External entities":false,"Agent (Roles/Entitites)":false,"Duration":false,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":false,"Task/Activity":false,"Event/Trigger":true,"Mappability":false,"Standardized file format":true,"XML":true,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":true,"yawl-XML":false,"EPML":false,"Execution Engine Availability":true,"Simulation support":false,"Verification support":false,"True concurrency":false,"System Interpretation":false,"Decomposition":true,"High-level support":false,"Low-level support":true,"State-based":true,"Activity-based":false,"Novice":false,"Expert":true,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":true,"Conformity to standard":true,"Evolutionary":true,"Theoretical Foundation":true,"Documentation availability":true,"Active community":true,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":true,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 14,AspectID:"637792449918926397", Alternative: "RAD", "Communication":true,"Analysis":true,"Enaction":false,"Control":false,"Functional":false,"Dynamic/Behavioural":true,"Informational/Resource":false,"Organizational":true,"General-purpose ML":true,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":true,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":true,"Data flow":true,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":true,"Parallelism (AND)":true,"Input":false,"Output":false,"External entities":false,"Agent (Roles/Entitites)":true,"Duration":false,"Deadline":false,"Business rules":true,"Business goals":true,"Annotation":false,"Task/Activity":true,"Event/Trigger":true,"Mappability":false,"Standardized file format":false,"XML":false,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":false,"Simulation support":true,"Verification support":true,"True concurrency":false,"System Interpretation":false,"Decomposition":false,"High-level support":false,"Low-level support":true,"State-based":true,"Activity-based":true,"Novice":false,"Expert":true,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":false,"Conformity to standard":false,"Evolutionary":false,"Theoretical Foundation":true,"Documentation availability":false,"Active community":false,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":false,"Course availability":true,"Blog/Article availability":false,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":false,"open-source tools availability":false},{ id: 15,AspectID:"637792449919026653", Alternative: "DFD", "Communication":true,"Analysis":false,"Enaction":true,"Control":true,"Functional":true,"Dynamic/Behavioural":false,"Informational/Resource":true,"Organizational":false,"General-purpose ML":true,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":false,"Information flow/Message flow":true,"Data flow":true,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":false,"Parallelism (AND)":false,"Input":true,"Output":true,"External entities":true,"Agent (Roles/Entitites)":true,"Duration":false,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":false,"Task/Activity":false,"Event/Trigger":false,"Mappability":false,"Standardized file format":false,"XML":false,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":false,"Simulation support":false,"Verification support":true,"True concurrency":false,"System Interpretation":false,"Decomposition":true,"High-level support":true,"Low-level support":true,"State-based":true,"Activity-based":false,"Novice":true,"Expert":true,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":false,"Conformity to standard":false,"Evolutionary":false,"Theoretical Foundation":true,"Documentation availability":false,"Active community":false,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":true,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 16,AspectID:"637792449919136242", Alternative: "VSM (Value Stream Mapping)", "Communication":false,"Analysis":true,"Enaction":false,"Control":false,"Functional":true,"Dynamic/Behavioural":false,"Informational/Resource":false,"Organizational":false,"General-purpose ML":false,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":false,"Information flow/Message flow":true,"Data flow":false,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":false,"Parallelism (AND)":false,"Input":false,"Output":false,"External entities":true,"Agent (Roles/Entitites)":true,"Duration":true,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":true,"Task/Activity":false,"Event/Trigger":false,"Mappability":false,"Standardized file format":false,"XML":false,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":false,"Simulation support":false,"Verification support":false,"True concurrency":false,"System Interpretation":false,"Decomposition":false,"High-level support":true,"Low-level support":false,"State-based":true,"Activity-based":false,"Novice":true,"Expert":false,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":false,"Conformity to standard":false,"Evolutionary":false,"Theoretical Foundation":true,"Documentation availability":false,"Active community":true,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":true,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":false},{ id: 17,AspectID:"637792449919226240", Alternative: "Gantt Chart", "Communication":true,"Analysis":false,"Enaction":false,"Control":true,"Functional":true,"Dynamic/Behavioural":false,"Informational/Resource":false,"Organizational":false,"General-purpose ML":false,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":false,"Data flow":false,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":false,"Parallelism (AND)":false,"Input":false,"Output":false,"External entities":false,"Agent (Roles/Entitites)":true,"Duration":true,"Deadline":true,"Business rules":false,"Business goals":false,"Annotation":false,"Task/Activity":true,"Event/Trigger":false,"Mappability":false,"Standardized file format":false,"XML":false,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":false,"Simulation support":false,"Verification support":false,"True concurrency":false,"System Interpretation":false,"Decomposition":false,"High-level support":false,"Low-level support":true,"State-based":false,"Activity-based":true,"Novice":true,"Expert":false,"Graphical economy":true,"Visual emphasis: colour":true,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":false,"Conformity to standard":false,"Evolutionary":false,"Theoretical Foundation":true,"Documentation availability":false,"Active community":true,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":false,"Blog/Article availability":true,"Degree of Popularity":false,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 18,AspectID:"637792449919346676", Alternative: "BPEL (2.0)", "Communication":false,"Analysis":false,"Enaction":true,"Control":false,"Functional":false,"Dynamic/Behavioural":true,"Informational/Resource":false,"Organizational":false,"General-purpose ML":true,"Textual":true,"Graphical/Diagrammical":false,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":true,"Data flow":true,"Inclusive choice (OR)":true,"Exclusive choice (XOR)":true,"Parallelism (AND)":true,"Input":true,"Output":true,"External entities":true,"Agent (Roles/Entitites)":true,"Duration":true,"Deadline":true,"Business rules":true,"Business goals":false,"Annotation":true,"Task/Activity":true,"Event/Trigger":true,"Mappability":true,"Standardized file format":true,"XML":true,"PNML":false,"XSD (XML Schema Definition)":true,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":true,"Simulation support":true,"Verification support":false,"True concurrency":true,"System Interpretation":true,"Decomposition":true,"High-level support":false,"Low-level support":true,"State-based":false,"Activity-based":true,"Novice":false,"Expert":true,"Graphical economy":false,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":false,"Semantic transparency":false,"Organizational body":true,"Conformity to standard":false,"Evolutionary":true,"Theoretical Foundation":true,"Documentation availability":true,"Active community":true,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":true,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 19,AspectID:"637792449919446598", Alternative: "BPML", "Communication":false,"Analysis":false,"Enaction":true,"Control":false,"Functional":false,"Dynamic/Behavioural":true,"Informational/Resource":false,"Organizational":false,"General-purpose ML":true,"Textual":true,"Graphical/Diagrammical":false,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":true,"Data flow":false,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":true,"Parallelism (AND)":true,"Input":true,"Output":true,"External entities":false,"Agent (Roles/Entitites)":false,"Duration":true,"Deadline":false,"Business rules":true,"Business goals":false,"Annotation":true,"Task/Activity":true,"Event/Trigger":false,"Mappability":true,"Standardized file format":true,"XML":true,"PNML":false,"XSD (XML Schema Definition)":true,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":false,"Simulation support":true,"Verification support":false,"True concurrency":true,"System Interpretation":true,"Decomposition":true,"High-level support":false,"Low-level support":true,"State-based":false,"Activity-based":true,"Novice":false,"Expert":true,"Graphical economy":false,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":false,"Semantic transparency":false,"Organizational body":false,"Conformity to standard":false,"Evolutionary":false,"Theoretical Foundation":true,"Documentation availability":false,"Active community":false,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":false,"Course availability":false,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 20,AspectID:"637792449919536707", Alternative: "EEML", "Communication":true,"Analysis":true,"Enaction":false,"Control":false,"Functional":true,"Dynamic/Behavioural":false,"Informational/Resource":false,"Organizational":true,"General-purpose ML":true,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":true,"Data flow":false,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":true,"Parallelism (AND)":true,"Input":true,"Output":true,"External entities":true,"Agent (Roles/Entitites)":true,"Duration":true,"Deadline":false,"Business rules":false,"Business goals":true,"Annotation":false,"Task/Activity":true,"Event/Trigger":false,"Mappability":false,"Standardized file format":false,"XML":false,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":false,"Simulation support":false,"Verification support":false,"True concurrency":false,"System Interpretation":false,"Decomposition":true,"High-level support":true,"Low-level support":true,"State-based":true,"Activity-based":false,"Novice":false,"Expert":true,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":false,"Conformity to standard":false,"Evolutionary":false,"Theoretical Foundation":true,"Documentation availability":false,"Active community":false,"HR availability":false,"Training material availability (degree)":false,"YouTube availability":false,"Course availability":false,"Blog/Article availability":false,"Degree of Popularity":false,"tool availability (degree)":true,"free tools availability":false,"open-source tools availability":false},{ id: 21,AspectID:"637792449919636672", Alternative: "ER/ERD", "Communication":true,"Analysis":false,"Enaction":false,"Control":false,"Functional":false,"Dynamic/Behavioural":false,"Informational/Resource":true,"Organizational":false,"General-purpose ML":false,"Textual":true,"Graphical/Diagrammical":false,"Tabular":true,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":false,"Information flow/Message flow":false,"Data flow":false,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":false,"Parallelism (AND)":false,"Input":false,"Output":false,"External entities":false,"Agent (Roles/Entitites)":true,"Duration":false,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":false,"Task/Activity":false,"Event/Trigger":false,"Mappability":false,"Standardized file format":false,"XML":false,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":false,"yawl-XML":false,"EPML":false,"Execution Engine Availability":false,"Simulation support":false,"Verification support":false,"True concurrency":false,"System Interpretation":false,"Decomposition":false,"High-level support":true,"Low-level support":false,"State-based":true,"Activity-based":false,"Novice":false,"Expert":true,"Graphical economy":false,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":false,"Semantic transparency":false,"Organizational body":false,"Conformity to standard":false,"Evolutionary":false,"Theoretical Foundation":false,"Documentation availability":true,"Active community":true,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":true,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 22,AspectID:"637792449919726560", Alternative: "UML Sequence Diagram", "Communication":true,"Analysis":false,"Enaction":false,"Control":false,"Functional":false,"Dynamic/Behavioural":true,"Informational/Resource":false,"Organizational":false,"General-purpose ML":false,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":true,"Information flow/Message flow":true,"Data flow":true,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":true,"Parallelism (AND)":true,"Input":false,"Output":false,"External entities":false,"Agent (Roles/Entitites)":true,"Duration":true,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":true,"Task/Activity":true,"Event/Trigger":false,"Mappability":false,"Standardized file format":true,"XML":true,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":true,"yawl-XML":false,"EPML":false,"Execution Engine Availability":true,"Simulation support":false,"Verification support":false,"True concurrency":false,"System Interpretation":false,"Decomposition":false,"High-level support":false,"Low-level support":true,"State-based":false,"Activity-based":true,"Novice":false,"Expert":true,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":true,"Conformity to standard":true,"Evolutionary":true,"Theoretical Foundation":true,"Documentation availability":true,"Active community":true,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":true,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true},{ id: 23,AspectID:"637792449919846691", Alternative: "UML Communication Diagram", "Communication":true,"Analysis":false,"Enaction":false,"Control":false,"Functional":false,"Dynamic/Behavioural":true,"Informational/Resource":false,"Organizational":false,"General-purpose ML":false,"Textual":false,"Graphical/Diagrammical":true,"Tabular":false,"Mathematical":false,"Imperative":true,"Declarative":false,"Control flow/Sequence":false,"Information flow/Message flow":true,"Data flow":false,"Inclusive choice (OR)":false,"Exclusive choice (XOR)":false,"Parallelism (AND)":false,"Input":false,"Output":false,"External entities":false,"Agent (Roles/Entitites)":true,"Duration":false,"Deadline":false,"Business rules":false,"Business goals":false,"Annotation":false,"Task/Activity":false,"Event/Trigger":false,"Mappability":false,"Standardized file format":true,"XML":true,"PNML":false,"XSD (XML Schema Definition)":false,"XMI (XML Metadata Interchange)":true,"yawl-XML":false,"EPML":false,"Execution Engine Availability":true,"Simulation support":false,"Verification support":false,"True concurrency":false,"System Interpretation":false,"Decomposition":false,"High-level support":true,"Low-level support":false,"State-based":false,"Activity-based":true,"Novice":true,"Expert":false,"Graphical economy":true,"Visual emphasis: colour":false,"Formality (clear definition of rules)":true,"Perceptual discriminatibility":true,"Semantic transparency":true,"Organizational body":true,"Conformity to standard":true,"Evolutionary":true,"Theoretical Foundation":true,"Documentation availability":true,"Active community":true,"HR availability":true,"Training material availability (degree)":true,"YouTube availability":true,"Course availability":false,"Blog/Article availability":true,"Degree of Popularity":true,"tool availability (degree)":true,"free tools availability":true,"open-source tools availability":true}];Table_Aspects.setData(Aspects_datatable);Table_Mapping.setData(Mapping_datatable); 