﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Äventyrliga_kontakter._default" ViewStateMode="Disabled" %>

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
            <%-- Validering på Clienten. --%>


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
                            <th>Efternamn
                            </th>
                            <th>E-Post
                            </th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </table>
                    <asp:DataPager ID="DataPager" runat="server" PageSize="20">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True" FirstPageText="Start"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField NextPageText=">" PreviousPageText="<" ButtonCount="3" />
                            <asp:NextPreviousPagerField ShowLastPageButton="True" LastPageText="Slut"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
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
                            <asp:LinkButton runat="server" CausesValidation="false" CommandName="Delete" Text="Radera"
                                OnClientClick='<%# String.Format("return confirm(\"Ta Kontakten {0} {1} {2}?\")", Item.FirstName, Item.LastName, Item.EmailAddress) %>'></asp:LinkButton>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="CP" runat="server" ErrorMessage="Förnamn fältet får ej lämnas tomt." ControlToValidate="FirstName" Text="*"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="CP" runat="server" ErrorMessage="Efternamn fältet får ej lämnas tomt." ControlToValidate="LastName" Text="*"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="CP" runat="server" ErrorMessage="E-Post fältet får ej lämnas tomt1." ControlToValidate="EmailAddress" Text="*" Display="Dynamic"></asp:RequiredFieldValidator>

                    <%-- Här ska mallen för raderna som man kan lägga in nya kontaktuppgifter vara. Hänger ihop med min FIrstItemPosition egenskap till listview --%>
                    <%-- Dessa renderas i toppen i min tabelll eftersom jag använder firstitemposition. --%>
                    <tr>
                        <td>
                            <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>' MaxLength="50"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="LastName" runat="server" Text='<%# BindItem.LastName %>' MaxLength="50"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="EmailAddress" runat="server" Text='<%# BindItem.EmailAddress %>' MaxLength="50"></asp:TextBox>
                        </td>
                        <td class="TopCommand">
                            <%-- Knappar för att kunna lägga till eller avbryta ändring av textfälten på toppen. Lägga till ska valideras andra ej. --%>
                            <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till"></asp:LinkButton>
                            <asp:LinkButton runat="server" CausesValidation="false" CommandName="Cancel" Text="Rensa"></asp:LinkButton>
                        </td>
                    </tr>
                </InsertItemTemplate>
                <EditItemTemplate>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Förnamn fältet får ej lämnas tomt." ControlToValidate="FirstName" Text="*"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Efternamn fältet får ej lämnas tomt." ControlToValidate="LastName" Text="*"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="E-Post fältet får ej lämnas tomt2." ControlToValidate="EmailAddress" Text="*"></asp:RequiredFieldValidator>
                    <%--      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="EmailAddress" ValidationExpression="^(?(&quot;&quot;)(&quot;&quot;.+?&quot;&quot;@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$" Display="Static"></asp:RegularExpressionValidator>--%>


                    <%-- Här redigerar jag kunduppgifter. samma ID men funkar eftersom dem inte används samtidigt som insertitemtemplate --%>
                    <tr>
                        <td>
                            <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="LastName" runat="server" Text='<%# BindItem.LastName %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="EmailAddress" runat="server" Text='<%# BindItem.EmailAddress %>' ValidationGroup="CpKontroller"></asp:TextBox>
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
