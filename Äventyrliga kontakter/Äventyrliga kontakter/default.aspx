<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Äventyrliga_kontakter._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Äventyrliga kontakter</h1>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" />
            <%-- Listview med autoimplementerade hanterarmetoder. --%>
            <asp:ListView ItemType="Äventyrliga_kontakter.Model.Contact"
                ID="ContactListView" runat="server"
                SelectMethod="ContactListView_GetData"
                InsertMethod="ContactListView_InsertItem"
                UpdateMethod="ContactListView_UpdateItem"
                DeleteMethod="ContactListView_DeleteItem"
                DataKeyNames="ContactID"
                InsertItemPosition="FirstItem">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <th>Förnamn
                            </th>
                            <th>EfterNamn
                            </th>
                            <th>E-Post
                            </th>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
