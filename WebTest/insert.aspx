<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insert.aspx.cs" Inherits="WebTest.insert" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
            <tr>
                <td>ProductCode</td>
                <td><asp:TextBox ID="TextBoxProductCode" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>NAME</td>
                <td><asp:TextBox ID="TextBoxProductName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Price</td>
                <td><asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox></td>
            </tr>
        <tr>
                <td>Radio</td>
            
           <td><asp:RadioButtonList ID="YesNoRadio" runat="server"  Width="88px">
               <asp:ListItem>Y</asp:ListItem>
               <asp:ListItem>N</asp:ListItem>
               </asp:RadioButtonList></td> 
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:Button ID="ButtonAdd" runat="server" Text="Add" OnClick="ButtonAdd_Click"  /></td>
            </tr>
        </table>
    </div>
        <asp:GridView ID="GridViewData" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCancelingEdit="GridViewData_RowCancelingEdit" OnRowEditing="GridViewData_RowEditing" OnRowUpdated="GridViewData_RowUpdated" OnRowUpdating="GridViewData_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None" Height="180px" Width="414px" allowpaging="true" OnPageIndexChanging="GridViewData_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
             <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
              <%--     <asp:BoundField DataField="ProductCode" HeaderText="Product Code" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="ProductPrice" HeaderText="Product Price" />
                <asp:BoundField DataField="IsActive" HeaderText="IsActive" />--%>



                        <asp:TemplateField HeaderText="Name">  
                            <EditItemTemplate>  
                                <asp:TextBox ID="TextBox" runat="server" Text='<%# Bind("ProductCode") %>'>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProductCode") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">  
                            <EditItemTemplate>  
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ProductName") %>'>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("ProductName") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>    
                        <asp:TemplateField HeaderText="Email">  
                            <EditItemTemplate>  
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ProductPrice") %>'>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                   <ItemTemplate>  
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("ProductPrice") %>'>  
                                </asp:Label>  
                            </ItemTemplate> 
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Is Active">  
                            <EditItemTemplate>  
                                <asp:DropDownList ID="DropDownList2" runat="server"  SelectedValue='<%# Bind("IsActive") %>'>  
                                    <asp:ListItem>--Select Gender--</asp:ListItem>  
                                    <asp:ListItem>Y</asp:ListItem>  
                                    <asp:ListItem>N</asp:ListItem>  
                                </asp:DropDownList>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("IsActive") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
                

                <asp:CommandField HeaderText="Options" ShowEditButton="True" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            
            <pagersettings mode="Numeric" pagebuttoncount="10" position="Bottom" />

        <pagerstyle backcolor="LightBlue" height="30px" horizontalalign="Center" verticalalign="Bottom" />
        </asp:GridView>
    </form>
</body>
</html>
