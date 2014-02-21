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
                DataKeyNames="ContactID"
                InsertItemPosition="FirstItem" ViewStateMode="Enabled">

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
                    <asp:DataPager ID="DataPager" runat="server" PageSize="20" > 
                       <Fields>
                           <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowLastPageButton="True"  />
                           <asp:NumericPagerField />
                          
                       </Fields>
                    </asp:DataPager>
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
                        <td class="SidoCommand">
                            <%-- Knappar för ta bort och redigera kontaktuppgifter, det är dessa som renderas till höger i tabellen. --%>
                            <asp:LinkButton runat="server" CausesValidation="false" CommandName="Delete" Text="Radera"></asp:LinkButton>
                            <asp:LinkButton runat="server" CausesValidation="false" CommandName="Edit" Text="Redigera"></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <%-- Om nulldata --%>
                    <table>
                        <tr>
                            <td>Kontaktuppgifter saknas.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <%-- Här ska mallen för raderna som man kan lägga in nya kontaktuppgifter vara. Hänger ihop med min FIrstItemPosition egenskap till listview --%>
                    <%-- Dessa renderas i toppen i min tabelll eftersom jag använder firstitemposition. --%>
                    <tr>
                        <td>
                            <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="LastName" runat="server" Text='<%# BindItem.LastName %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="EmailAddress" runat="server" Text='<%# BindItem.EmailAddress %>'></asp:TextBox>
                        </td>
                        <td class="TopCommand">
                            <%-- Knappar för att kunna lägga till eller avbryta ändring av textfälten på toppen. Lägga till ska valideras andra ej. --%>
                            <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till"></asp:LinkButton>
                            <asp:LinkButton runat="server" CausesValidation="false" CommandName="Cancel" Text="Rensa"></asp:LinkButton>
                        </td>
                    </tr>
                </InsertItemTemplate>
                <EditItemTemplate>
                    <%-- Här redigerar jag kunduppgifter. samma ID men funkar eftersom dem inte används samtidigt som insertitemtemplate --%>
                    <tr>
                        <td>
                            <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="LastName" runat="server" Text='<%# BindItem.LastName %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="EmailAddress" runat="server" Text='<%# BindItem.EmailAddress %>'></asp:TextBox>
                        </td>
                        <td>
                            <%-- Knappar för uppdatera en kunduppgift och avbryta. --%>
                            <asp:LinkButton runat="server" CommandName="Update" Text="Spara"></asp:LinkButton>
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Ångra" CausesValidation="false"></asp:LinkButton>
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
