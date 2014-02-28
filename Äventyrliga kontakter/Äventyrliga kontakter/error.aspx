<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="Äventyrliga_kontakter.error" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Äventyrliga kontakter</h1>
    <p>Ett oväntat fel har tyvärr inträffat, Gå tillbaka till startsida och försök igen.</p>
    <p>
        <a href='<%$ RouteUrl:routename=Start %>' runat="server">Tillbaka till startsidan</a>
    </p>
    <%-- Fixa länk tillbaka till startsida.  --%>
    <form id="form1" runat="server" visible="false">
    <div>
    </div>
    </form>
</body>
</html>
