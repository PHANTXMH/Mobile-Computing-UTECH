<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="easternchamps.aspx.cs" Inherits="wpclass.easternchamps" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MCLAB3-1703882</title>  
    <link href="Styles/StyleSheet1.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, intial-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <div id="divMenu" class="div" runat="server">
                <br />
                <asp:Button ID="Button_maintenance_menu" class="button" runat="server" Text="Maintenance" OnClick="Button_maintenance_menu_Click" />
                <br /><br />
                <asp:Button ID="Button2" class="button" runat="server" Text="Log Out" />
            </div>
            <div id="divMaintenanceMenu" class="div" runat="server">
                <br />
                <asp:Button ID="Button_maintenance_event" class="button" runat="server" Text="Event" OnClick="Button_maintenance_event_Click" />
                <br /><br />
                <asp:Button ID="Button_maintenance_athlete" class="button" runat="server" Text="Athlete" OnClick="Button_maintenance_athlete_Click" />
            </div>
            <div id="divAthleteMaint" class="div" runat="server">
                <br />
                <asp:Label ID="Label1" runat="server" Text="ATHLETE MAINTENANCE"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Athlete"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList_athlete" CssClass="droplist" runat="server"  DataTextField="athletesummary" DataValueField="athlete num" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_athlete_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="Button_athlete_edit" class="button" runat="server" Text="Edit" OnClick="Button_athlete_edit_Click" />
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="High School"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList_highschool_athlete" CssClass="droplist" runat="server" DataTextField="hs name" DataValueField="hs num"></asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="First Name"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox_firstname" CssClass="textbox" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="Last Name"></asp:Label>
                <br />
                <asp:TextBox CssClass="textbox" ID="TextBox_lastname" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:CheckBox ID="CheckBox_gender" runat="server" />                
                <asp:Label ID="Label6" runat="server" Text="Male"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Text="Age"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList_age" CssClass="droplist" runat="server"></asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="Button_new" class="button" runat="server" Text="New" OnClick="Button_new_Click" />
                <br />
                <asp:Button ID="Button_add" class="button" runat="server" Text="Add" OnClick="Button_add_Click" />
                <br />
                <asp:Button ID="Button_update" class="button" runat="server" Text="Update" OnClick="Button_update_Click" />
                <br /><br />
                <asp:Label ID="Label_athlete_status" runat="server" Text="-"></asp:Label>
                <br /><br />
                <asp:Button ID="Button_goback" class="button" runat="server" Text="Go Back" OnClick="Button_goback_Click" />
            </div>
            <div id="divEventMaint" class="div" runat="server">
                <br />
                <asp:Label ID="Label8" runat="server" Text="EVENT MAINTENANCE"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label9" runat="server" Text="Event"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList_event" CssClass="droplist" runat="server" DataTextField="eventsummary" DataValueField="event num" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_event_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <br />                
                <asp:GridView ID="GridView_startinglist" class="gridview" runat="server" BorderStyle="None" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView_startinglist_SelectedIndexChanged">       
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="Button_remove" runat="server" Text="Remove" OnClick="Button_remove_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField ="assignment num" />
                        <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="lane num" HeaderText="Lane Number" HeaderStyle-CssClass="labelstuff" />             
                        <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="athlete" HeaderText="Athlete" HeaderStyle-CssClass="labelstuff" />   
                        <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="hs short name" HeaderText="High School" HeaderStyle-CssClass="labelstuff" />   
                    </Columns>
                </asp:GridView>
                <br /><br />
                <asp:Label ID="Label10" runat="server" Text="High School"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList_highschools" CssClass="droplist" runat="server" DataValueField="hs num" DataTextField="hs name" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_highschools_SelectedIndexChanged"></asp:DropDownList>
                <br /><br />
                <asp:Label ID="Label11" runat="server" Text="Athlete"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList_elegible_athlete" CssClass="droplist" runat="server" DataValueField="athlete num" DataTextField="athlete" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_elegible_athlete_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="Label12" runat="server" Text="Lane Number"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList_lanenumber" CssClass="droplist" runat="server" AutPostBack="true"></asp:DropDownList>
                <br /><br />
                <asp:Button ID="Button_event_new" class="button" runat="server" Text="New" OnClick="Button_event_new_Click" />
                <br />
                <asp:Button ID="Button_event_add" class="button" runat="server" Text="Add" OnClick="Button_event_add_Click" />
                <br /><br />
                <asp:Label ID="Label_event_status" class="button" runat="server" Text="-"></asp:Label>
                <br /><br />
                <asp:Button ID="Button_event_empty" class="button" runat="server" Text="Empty Start List" OnClick="Button_event_empty_Click" />
                <br />
                <br />
                <asp:Button ID="Button_goback1" class="button" runat="server" Text="Go Back" OnClick="Button_goback1_Click" />
            </div>            
        </center>        
    </form>
</body>
</html>
