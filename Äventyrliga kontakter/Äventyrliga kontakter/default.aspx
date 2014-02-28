<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Äventyrliga_kontakter._default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/style.css" rel="stylesheet" />
</head>
<body>
    <h1>Äventyrliga kontakter</h1>
    <div id="moose">
        <img src="Style/moose.gif" />
    </div>

    <form id="form1" runat="server">
        <div>
            <%-- ValidationSummary för de 2 olika validationgrupperna. Samt Rättmeddelande under. --%>
            <asp:ValidationSummary ID="ValidationSummary" ValidationGroup="Insert" runat="server" />
            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Update" runat="server" />

            <%-- Placeholder to handle confirmationmessages. --%>
            <asp:PlaceHolder ID="PlaceHolder" runat="server" Visible="false">
                <asp:Literal ID="ConfirmationMessage" runat="server"></asp:Literal></asp:PlaceHolder>


            <%-- Listview With Methods to initialize Code --%>
            <asp:ListView ItemType="Äventyrliga_kontakter.Model.Contact" runat="server" ID="ContactListView"
                SelectMethod="ContactListView_GetData"
                InsertMethod="ContactListView_InsertItem"
                UpdateMethod="ContactListView_UpdateItem"
                DeleteMethod="ContactListView_DeleteItem"
                DataKeyNames="ContactID"
                InsertItemPosition="FirstItem" ViewStateMode="Enabled" OnPagePropertiesChanged="ContactListView_PagePropertiesChanged">

                <%-- Emty table which is filled. --%>
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
                            <asp:NextPreviousPagerField ShowFirstPageButton="True" FirstPageText="Start" ButtonCssClass="nav"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField NextPageText=">" PreviousPageText="<" ButtonCount="3" />
                            <asp:NextPreviousPagerField ShowLastPageButton="True" LastPageText="Slut" ButtonCssClass="nav"
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

                            <%-- Buttons to remove and edit contacts in the list, they are rendered to the right in table. --%>
                            <asp:LinkButton runat="server" CausesValidation="false" CommandName="Delete" Text="Radera"
                                OnClientClick='<%# String.Format("return confirm(\"Ta Kontakten {0} {1} {2}?\")", Item.FirstName, Item.LastName, Item.EmailAddress) %>'></asp:LinkButton>
                            <asp:LinkButton runat="server" CausesValidation="false" CommandName="Edit" Text="Redigera"></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <%-- If null replace with this (Not implemented)--%>
                    <table>
                        <tr>
                            <td>Kontaktuppgifter saknas.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>

                    <%-- 4 Controls that work with validationgroup "insert" and validationsummary Insert. --%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Förnamn fältet får ej lämnas tomt." ControlToValidate="FirstName" Text="*" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Efternamn fältet får ej lämnas tomt." ControlToValidate="LastName" Text="*" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="E-Post fältet får ej lämnas tomt." ControlToValidate="EmailAddress" Text="*" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ErrorMessage="Ingen giltig E-Post, Försök igen"
                        ControlToValidate="EmailAddress" Text="*" ValidationGroup="Insert"
                        ValidationExpression="^[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}$"
                        Display="Dynamic"></asp:RegularExpressionValidator>

                    <%-- This is how it is rendered into table, with using BindItem links to the different propertie name from columns. --%>

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
                            <%-- Buttons to control insertion of rows into table, they are rendered in top of table because of the FirstItem postion --%>
                            <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" ValidationGroup="Insert"></asp:LinkButton>
                            <asp:LinkButton runat="server" CausesValidation="false" CommandName="Cancel" Text="Rensa"></asp:LinkButton>
                        </td>
                    </tr>
                </InsertItemTemplate>
                <EditItemTemplate>
                    <%-- 4 Controls that work with validationgroup "Update" and validationsummary Update. --%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Förnamn fältet får ej lämnas tomt." ControlToValidate="FirstName" Text="*" ValidationGroup="Update"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Efternamn fältet får ej lämnas tomt." ControlToValidate="LastName" Text="*" ValidationGroup="Update"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="E-Post fältet får ej lämnas tomt." ControlToValidate="EmailAddress" Text="*" ValidationGroup="Update"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="EmailAddress" ValidationGroup="Update"
                        ValidationExpression="^[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}$"
                        Display="Dynamic"></asp:RegularExpressionValidator>

                    <%-- Here i edit my columns it uses same ID on controls as insert, but works as they are't used at same time. --%>
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
                            <%-- BUttons to Edit a contact and abort to cancel the editing. --%>
                            <asp:LinkButton runat="server" CommandName="Update" Text="Spara" ValidationGroup="Update"></asp:LinkButton>
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Ångra" CausesValidation="false"></asp:LinkButton>
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
