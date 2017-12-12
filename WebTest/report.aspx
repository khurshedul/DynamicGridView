﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="WebTest.report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
    <div>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" DisplayToolbar="False" ReportSourceID="CrystalReportSource1" ToolPanelView="None" />

        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="productSell.rpt">
            </Report>
        </CR:CrystalReportSource>
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
