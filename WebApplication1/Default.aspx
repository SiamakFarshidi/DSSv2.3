<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>



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
                        <a class="nav-link active" href="Default.aspx">
                            <i class="fas fa-sitemap"></i>
                            Decision Models
                                <span class="sr-only">(current)</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="CaseDefinition.aspx?CreateNewDecisionModel=NEWMODEL&PageCaption=A decision model for an MCDM problem">
                            <i class="fas fa-cogs"></i>
                            New Decision Model
                        </a>
                    </li>
                    <li class="nav-item dropdown">

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
                            <a onclick="$('#cover').show();" class="dropdown-item" href="DecisionModel.aspx?View=MDDMODEL&PageCaption=MDD Platforms">MDD Platforms</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="DecisionModel.aspx?View=BPMLMODEL&PageCaption=BP Modeling Languages">BP Modeling Languages</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="DecisionModel.aspx?View=DAOMODEL&PageCaption=DAO Platforms">DAO Platforms</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="DecisionModel.aspx?View=QAMODEL&PageCaption=QA Models">QA Models</a>                            
                        </div>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown"
                            aria-haspopup="true" aria-expanded="false">
                            <i class="fas fa-life-ring"></i>
                            <span>Help<i class="fas fa-angle-down"></i>
                            </span>
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <a onclick="$('#cover').show();" class="dropdown-item" href="#">Decision Model</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="#">Software Quality Model</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="#">Domain-Description</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="#">Feature-Values</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="#">Features</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="#">Alternatives</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="#">Mappings</a>
                            <a onclick="$('#cover').show();" class="dropdown-item" href="#">MoSCoW</a>
                        </div>
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
                            <a  onclick="$('#cover').show();" class="nav-link" href="Login.aspx">
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

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <div class="MainMenuItems" id="StandardDecisionModelsListButton">
            <div class="row" style="margin-bottom: 10px; margin-top: 10px;">
                <div class="col">
                    <a href="#">

                        <div>
                            <div style="float: left; width: 50px; height: 50px; border-radius: 50%; background-color: orange; padding-top: 1px; color: black; font-weight: bold; text-align: center;">
                                <span style="font-size: xx-large;"><i class="fas fa-check"></i></span>
                            </div>

                            <div class="MainItemsSelection" style="float: left; width: 300px; height: 50px; padding-left: 10px; margin: 10px; padding-top: 0px; color: orange; font-weight: bold; font-size: x-large; text-align: left;">
                                <span class="MainItemsSelection">Make a new decision</span>
                            </div>
                        </div>
                    </a>
                </div>
            </div>

            <!-- row -->
            <div class="row tm-content-row" style="display: none;" id="StandardDecisionModelsList">
                <div onclick="$('#cover').show(); window.location = 'CaseDefinition.aspx?CreateNewDecisionModel=DBMSMODEL&PageCaption=Database Technology Selection'"
                    class="col-sm-12 col-md-12 col-lg-3 col-xl-3 tm-block-col">
                    <div class="tm-bg-primary-dark tm-block" style="text-align: center;">
                        <h2 class="tm-block-title">Database Technology Selection</h2>
                        <div class="tm-avatar-container">
                            <span class="DecisionModelsIcon"><i class="fas fa-database"></i></span>
                            <a href="CaseDefinition.aspx?CreateNewDecisionModel=DBMSMODEL&PageCaption=Database Technology Selection" class="tm-avatar-delete-link">
                                <img src="Image/Add_icon.png" style="width: 60px; height: 60px; padding: 0px; margin: -22px; margin-top: -23px;" />
                            </a>
                        </div>

                    </div>
                </div>

                <div class="col-sm-12 col-md-12 col-lg-3 col-xl-3 tm-block-col">
                    <div onclick="$('#cover').show();window.location = 'CaseDefinition.aspx?CreateNewDecisionModel=CSPMODEL&PageCaption=Cloud Service Provider Selection'"
                        class="tm-bg-primary-dark tm-block" style="text-align: center;">
                        <h2 class="tm-block-title">Cloud Service Provider Selection</h2>
                        <div class="tm-avatar-container">
                            <span class="DecisionModelsIcon"><i class="fas fa-cloud"></i></span>
                            <a href="CaseDefinition.aspx?CreateNewDecisionModel=CSPMODEL&PageCaption=Cloud Service Provider Selection" class="tm-avatar-delete-link">
                                <img src="Image/Add_icon.png" style="width: 60px; height: 60px; padding: 0px; margin: -22px; margin-top: -23px;" />
                            </a>
                        </div>
                    </div>
                </div>

                <div class="col-sm-12 col-md-12 col-lg-3 col-xl-3 tm-block-col">
                    <div onclick="$('#cover').show();window.location = 'CaseDefinition.aspx?CreateNewDecisionModel=BPMODEL&PageCaption=Blockchain Platform Selection'"
                        class="tm-bg-primary-dark tm-block" style="text-align: center;">
                        <h2 class="tm-block-title">Blockchain Platform Selection</h2>
                        <div class="tm-avatar-container">
                            <span class="DecisionModelsIcon"><i class="fas fa-cubes"></i></span>
                            <a href="CaseDefinition.aspx?CreateNewDecisionModel=BPMODEL&PageCaption=Blockchain Platform Selection" class="tm-avatar-delete-link">
                                <img src="Image/Add_icon.png" style="width: 60px; height: 60px; padding: 0px; margin: -22px; margin-top: -23px;" />
                            </a>
                        </div>
                    </div>
                </div>

                <div class="col-sm-12 col-md-12 col-lg-3 col-xl-3 tm-block-col">
                    <div onclick="$('#cover').show();window.location = 'CaseDefinition.aspx?CreateNewDecisionModel=SWAPMODEL&PageCaption=Software Architecture Pattern Selection'"
                        class="tm-bg-primary-dark tm-block" style="text-align: center;">
                        <h2 class="tm-block-title">Software Architecture Pattern Selection</h2>
                        <div class="tm-avatar-container">
                            <span class="DecisionModelsIcon"><i class="fas fa-puzzle-piece"></i></span>
                            <a href="CaseDefinition.aspx?CreateNewDecisionModel=SWAPMODEL&PageCaption=Software Architecture Pattern Selection" class="tm-avatar-delete-link">
                                <img src="Image/Add_icon.png" style="width: 60px; height: 60px; padding: 0px; margin: -22px; margin-top: -23px;" />
                            </a>
                        </div>
                    </div>
                </div>


                <div class="col-sm-12 col-md-12 col-lg-3 col-xl-3 tm-block-col">
                    <div onclick="$('#cover').show(); window.location = 'CaseDefinition.aspx?CreateNewDecisionModel=PLMODEL&PageCaption=Programming Language Selection'"
                        class="tm-bg-primary-dark tm-block" style="text-align: center;">
                        <h2 class="tm-block-title">Programming Language Selection</h2>
                        <div class="tm-avatar-container">
                            <span class="DecisionModelsIcon"><i class="fas fa-code"></i></span>
                            <a href="CaseDefinition.aspx?CreateNewDecisionModel=PLMODEL&PageCaption=Programming Language Selection" class="tm-avatar-delete-link">
                                <img src="Image/Add_icon.png" style="width: 60px; height: 60px; padding: 0px; margin: -22px; margin-top: -23px;" />
                            </a>
                        </div>
                    </div>
                </div>

                <div class="col-sm-12 col-md-12 col-lg-3 col-xl-3 tm-block-col">
                    <div onclick="window.location = 'CaseDefinition.aspx?CreateNewDecisionModel=MDDMODEL&PageCaption=MDD Platform Selection'"
                        class="tm-bg-primary-dark tm-block" style="text-align: center;">
                        <h2 class="tm-block-title">MDD Platform Selection</h2>
                        <div class="tm-avatar-container">
                            <span class="DecisionModelsIcon"><i class="fab fa-codepen"></i></span>
                            <a href="CaseDefinition.aspx?CreateNewDecisionModel=MDDMODEL&PageCaption=MDD Platform Selection" class="tm-avatar-delete-link">
                                <img src="Image/Add_icon.png" style="width: 60px; height: 60px; padding: 0px; margin: -22px; margin-top: -23px;" />
                            </a>
                        </div>
                    </div>
                </div>

                <div class="col-sm-12 col-md-12 col-lg-3 col-xl-3 tm-block-col">
                    <div onclick="window.location = 'CaseDefinition.aspx?CreateNewDecisionModel=BPMLMODEL&PageCaption=BPML Selection'"
                        class="tm-bg-primary-dark tm-block" style="text-align: center;">
                        <h2 class="tm-block-title">BPML Selection</h2>
                        <div class="tm-avatar-container">
                            <span class="DecisionModelsIcon"><i class="fab fa-linode"></i></span>
                            <a href="CaseDefinition.aspx?CreateNewDecisionModel=BPMLMODEL&PageCaption=BPML Selection" class="tm-avatar-delete-link">
                                <img src="Image/Add_icon.png" style="width: 60px; height: 60px; padding: 0px; margin: -22px; margin-top: -23px;" />
                            </a>
                        </div>
                    </div>
                </div>


                <div class="col-sm-12 col-md-12 col-lg-3 col-xl-3 tm-block-col">
                    <div onclick="window.location = 'CaseDefinition.aspx?CreateNewDecisionModel=QAMODEL&PageCaption=QA Model Selection'"
                        class="tm-bg-primary-dark tm-block" style="text-align: center;">
                        <h2 class="tm-block-title">QA Model Selection</h2>
                        <div class="tm-avatar-container">
                            <span class="DecisionModelsIcon"><i class="fas fa-certificate"></i></span>
                            <a href="CaseDefinition.aspx?CreateNewDecisionModel=QAMODEL&PageCaption=QA Model Selection" class="tm-avatar-delete-link">
                                <img src="Image/Add_icon.png" style="width: 60px; height: 60px; padding: 0px; margin: -22px; margin-top: -23px;" />
                            </a>
                        </div>
                    </div>
                </div>

                <div class="col-sm-12 col-md-12 col-lg-3 col-xl-3 tm-block-col">
                    <div onclick="window.location = 'CaseDefinition.aspx?CreateNewDecisionModel=DAOMODEL&PageCaption=DAO Platform Selection'"
                        class="tm-bg-primary-dark tm-block" style="text-align: center;">
                        <h2 class="tm-block-title">DAO Platform Selection</h2>
                        <div class="tm-avatar-container">
                            <span class="DecisionModelsIcon"><i class="fas fa-gavel"></i></span>
                            <a href="CaseDefinition.aspx?CreateNewDecisionModel=DAOMODEL&PageCaption=DAO Platform Selection" class="tm-avatar-delete-link">
                                <img src="Image/Add_icon.png" style="width: 60px; height: 60px; padding: 0px; margin: -22px; margin-top: -23px;" />
                            </a>
                        </div>
                    </div>
                </div>



                
            </div>
        </div>
        <br />
        <div class="MainMenuItems" id="RecentDecisionModelsListButton">

            <div class="row" style="margin-bottom: 10px; margin-top: 10px;">
                <div class="col">
                    <a href="#">
                        <div style="float: left; width: 50px; height: 50px; border-radius: 50%; background-color: orange; padding-top: 1px; color: black; font-weight: bold; text-align: center;">
                            <span style="font-size: xx-large;"><i class="fas fa-check"></i></span>
                        </div>

                        <div class="MainItemsSelection" style="float: left; width: 300px; height: 50px; padding-left: 10px; margin: 10px; padding-top: 0px; color: orange; font-weight: bold; font-size: x-large; text-align: left;">
                            <span class="MainItemsSelection">My decisions</span>
                        </div>
                    </a>
                </div>
            </div>
            <!-- row -->
            <div class="row tm-content-row" id="RecentDecisionModelsList" style="display: none;">

                <% 
                    Response.Write(RecentDecisionModels.Value);
                %>
            </div>
        </div>
        <br />
        <div class="MainMenuItems" id="ViewDecisionModelsListButton">
            <div class="row" style="margin-bottom: 10px; margin-top: 10px;">
                <div class="col">
                    <a href="#">
                        <div style="float: left; width: 50px; height: 50px; border-radius: 50%; background-color: orange; padding-top: 1px; color: black; font-weight: bold; text-align: center;">
                            <span style="font-size: xx-large;"><i class="fas fa-check"></i></span>
                        </div>

                        <div class="MainItemsSelection" style="float: left; width: 300px; height: 50px; padding-left: 10px; margin: 10px; padding-top: 0px; color: orange; font-weight: bold; font-size: x-large; text-align: left;">
                            <span class="MainItemsSelection">View decisions</span>

                        </div>
                    </a>
                </div>
            </div>
            <div class="row tm-content-row" id="ViewDecisionModelsList" style="display: none;">
                <% 
                    Response.Write(ViewDecisionModels.Value);
                %>
            </div>
        </div>
    </div>
    <form runat="server">
        <asp:HiddenField ID="ViewDecisionModels" runat="server" />
        <asp:HiddenField ID="RecentDecisionModels" runat="server" />
    </form>
    <script>
        //---------------------------------------------------- 
        $(document).ready(function () {
            $("#StandardDecisionModelsListButton").click(function () {
                $("#StandardDecisionModelsList").toggle(500);
                $("#RecentDecisionModelsList").hide(500);
                $("#ViewDecisionModelsList").hide(500);
            });

            $("#RecentDecisionModelsListButton").click(function () {
                $("#StandardDecisionModelsList").hide(500);
                $("#RecentDecisionModelsList").toggle(500);
                $("#ViewDecisionModelsList").hide(500);
            });

            $("#ViewDecisionModelsListButton").click(function () {
                $("#StandardDecisionModelsList").hide(500);
                $("#RecentDecisionModelsList").hide(500);
                $("#ViewDecisionModelsList").toggle(500);
            });
        });

        //---------------------------------------------------- Ajax

        function DeleteCase(id) {
            JsonCase = { "id": id };
            var postdata = JSON.stringify(JsonCase);

            try {
                $.ajax({
                    type: "POST",
                    url: "GenericHandlers/DeleteCase.ashx",
                    cache: false,
                    data: postdata,
                    success: getSuccess,
                    error: getFail
                });
            } catch (e) {
                alert(e);
            }
            function getSuccess(data, textStatus, jqXHR) {

                showMessageBox("Update", "The case was successfully deleted!");
                var elem = document.getElementById(id);
                elem.parentNode.removeChild(elem);
            };
            function getFail(jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            };
        }

    </script>
</asp:Content>
