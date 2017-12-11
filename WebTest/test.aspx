<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebTest.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />

    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=TextBoxProductName.ClientID %>").autocomplete({
                source: function (request, response) {
                    debugger;
                    $.ajax({
                        type: "POST",
                        url: "test.aspx/GetProducts",
                        data: "{ 'prefix': '" + request.term + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            debugger;
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                };
                            }));
                        },
                        error: function (response) {

                        },
                        failure: function (response) {

                        }
                    });
                },
                select: function (e, i) {
                    $("#<%=hdnTextBoxProductName.ClientID %>").val(i.item.val);
            },
            minLength: 1
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Product Name</td>
                    <asp:HiddenField ID="hdnTextBoxProductName" runat="server" />
                    <td>
                        <asp:TextBox ID="TextBoxProductName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Quantity</td>
                    <td>
                        <asp:TextBox ID="TextBoxProductQuantity" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonAdd" runat="server" Text="Add" OnClick="ButtonAdd_Click" /></td>
                </tr>
            </table>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="GridViewShowData" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridViewShowData_RowCancelingEdit" OnRowDeleting="GridViewShowData_RowDeleting" OnRowEditing="GridViewShowData_RowEditing" OnRowUpdating="GridViewShowData_RowUpdating">
                <Columns>
    
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:CommandField HeaderText="Options" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
        </div>
    </form>


</body>
</html>
