<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Äventyrliga_kontakter._default" ViewStateMode="Disabled" %>

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
            <asp:ListView ItemType="Äventyrliga_kontakter.Model.Contact" runat="server" ID="ContactListView"
                SelectMethod="ContactListView_GetData"
                InsertMethod="ContactListView_InsertItem"
                UpdateMethod="ContactListView_UpdateItem"
                DeleteMethod="ContactListView_DeleteItem"
                DataKeyNames="ContactID">
               <%-- InsertItemPosition="FirstItem">--%>

                <%-- Tom tabell som ska fyllas. --%>
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
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Item.FirstName %>
                        </td>
                        <td>
                            <%# Item.LastName %> 
                        </td>
                        <td>
                            <%# Item.EmailAddress %> 
                        </td>
                        <td class="command" >
                            <asp:LinkButton runat="server" CausesValidation="false" CommandName="Delete" Text="Radera"></asp:LinkButton >
                            <asp:LinkButton runat="server" CausesValidation="false" CommandName="Edit" Text="Redigera"></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
