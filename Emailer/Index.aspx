<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs"  ValidateRequest="false" Inherits="Emailer.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Checker </title>
    <link rel="shortcut icon" href="favicon.ico" />

    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" rel="stylesheet" />

</head>
<body  style="background-image:url('Emailer.jpg')">

    <div class="container">

        <div class="row" style="margin-top:15px;"> 

            <form id="form1" runat="server">

                 <div class="form-group">
                <asp:Button Text="Send Email" CssClass="btn btn-primary" id="btnsubmit" OnClick="btnsubmit_Click" runat="server" />
                     </div>
                 <div class="form-group">
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtbcc" aria-describedby="emailHelp" placeholder="BCC"/>
                   
                </div>

                <div class="form-group">
                    <asp:Label ForeColor="Red" Text="Please Paste html content to send it as an email!!" ID="lblMessage" runat="server" />
                    <asp:TextBox CssClass="form-control" runat="server" Columns="100" Rows="15" ID="txtemail" TextMode="MultiLine"  aria-describedby="emailHelp" placeholder="Email Content"/>
                    <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
                </div>
       
        

        

    </form>

        </div>

    </div>

    
</body>
</html>
