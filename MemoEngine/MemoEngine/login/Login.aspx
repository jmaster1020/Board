<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MemoEngine.login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/Content/bootstrap.css" type="text/css" rel="stylesheet" />
    <link href="/Content/login.css" type="text/css" rel="stylesheet" />
    <title>회원 관리 - 로그인</title>
</head>
<body>
    <div class="container">
        <div class="row">
            <div style="margin-top:50px;" class="col-md-4 col-md-offset-4">
                <form id="form1" runat="server">
                    <div class="panel panel-default">
                        <div class="panel-heading text-center">
                            <h1>회원 관리</h1>
                            <h2>로그인</h2>
                        </div>
                        <div class="panel-body">
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control" placeholder="아이디"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="비밀번호"
                                        TextMode="Password"></asp:TextBox>
                                </div>
                                <asp:Button ID="btnLogin" runat="server" Text="로그인" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnLogin_Click" />
                            </fieldset>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</body>
</html>

