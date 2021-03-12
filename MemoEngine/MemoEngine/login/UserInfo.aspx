<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="MemoEngine.login.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>회원 관리-회원 정보 보기</title>
    <link href="/Content/bootstrap.css" type="text/css" rel="stylesheet" />
</head>
    <body>
    <div class="container">
        <div class="row">
            <div style="margin-top: 50px;" class="col-md-4 col-md-offset-4">
                <form id="form2" runat="server">
                    <div class="panel panel-default">
                        <div class="panel-heading text-center">
                            <h1>회원 관리</h1>
                            <h2>회원 가입</h2>
                        </div>
                        <div class="panel-body">
                            <fieldset>
                                UID: <asp:Label ID="lblUID" runat="server"></asp:Label><br />
                                <div class="form-group">
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="이름"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="txtUserName" Display="None"
                                        ErrorMessage="이름을 입력하세요."></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control" placeholder="아이디"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valUserID" runat="server"
                                        ControlToValidate="txtUserID" Display="None"
                                        ErrorMessage="아이디를 확인하세요."></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="암호"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valPassword" runat="server"
                                        ControlToValidate="txtPassword" Display="None"
                                        ErrorMessage="암호를 입력하시오."></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtPasswordConfirm" runat="server" CssClass="form-control" placeholder="암호 확인"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valpassword2" runat="server"
                                    ControlToValidate="txtPasswordConfirm" Display="None"
                                     ErrorMessage="암호를 확인하시오."></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="varPasswordConfirm" runat="server"
                                        ControlToValidate="txtPasswordConfirm"
                                        ControlToCompare="txtPassword"
                                        SetFocuseOnError="true"
                                        ErrorMessage="암호를 다시 확인해 주세요."
                                        ForeColor="Red">
                                    </asp:CompareValidator>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="이메일"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="valEmail" runat="server"
                                        ErrorMessage="이메일을 정확히 입력하시오."
                                        ForeColor="Red"
                                        ControlToValidate="txtEmail"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtIntro" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="자기소개" Height="130px" ></asp:TextBox>
                                    <br />
                                        <asp:Button ID="btnModify" runat="server" CssClass="submit-btn btn-primary btn-block btn-lg" Text="정보 수정"
                                            OnClick="btnModify_Click" />
                                        <asp:ValidationSummary ID="valSummary" runat="server"
                                            ShowMessageBox="true"
                                            ShowSummary="false" />
                                    </div>
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