<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="MART391TestApp3.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Label ID="lblFileMessage" runat="server" Text="Upload a replay!"></asp:Label><br />
            <asp:FileUpload ID="fileupReplay" runat="server" />
            <asp:Button ID="btnUploadReplay" runat="server" Text="Upload" OnClick="btnUploadReplay_Click" />
            <br />
            <asp:GridView ID="gdvReplays" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvReplays_RowCommand" OnSelectedIndexChanged="gdvReplays_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="File">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("File") %>' CommandName="Download" Text='<%# Eval("File") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Size" HeaderText="Size In Bytes" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="lblSearch" runat="server" Text="Search"></asp:Label>
            <br />
            
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnAddChampions" runat="server" OnClick="btnAddChampions_Click" Text="Add Champions" />
            <br />
            <asp:Button ID="btnTestInsertMatch" runat="server" Text="Insert Match (Not Participants/Stats)" OnClick="btnTestInsertMatch_Click" />
            <br />
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search Summoner" />
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
