<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MemoEngine._Default" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<style type="text/css">
      .jumbotron{
        background-image: url('DotNetNote/images/dnn/1.PNG');
        background-size: cover;
        text-shadow: black 0.2em 0.2em 0.2em;
        color:white;
        width:auto;
        height:300px;
      }
</style>

     <div class="jumbotron">
         <!--<img src="DotNetNote/images/dnn/1.PNG" width="100%" />-->
    </div>
    <br />
    <h1 style="text-align:center"><strong>제품 설명</strong></h1>
    <br />
    <br />
    <div style="text-align:center" class="row">
        <div class="col-md-4">
            <img src="DotNetNote/images/dnn/2.PNG" width="300" height="300"/>
            <h3>문서 분석</h3>
            <p>
              문서에 관련된 빅데이터 수집 및 저장<br />그리고 텍스트 검색            
            </p>
        </div>        
        <div class="col-md-4">
        <img src="DotNetNote/images/dnn/3.PNG"  width="300" height="300"/>
            <h3>디지털 서명</h3>
            <p>
                디지털 문서에 대한 웹기반<br />인증서 서명 시스템            
            </p>
        </div>
        <div class="col-md-4">
        <img src="DotNetNote/images/dnn/4.PNG" width="300" height="300"/>
            <h3>DT Portal</h3>
            <p>
                빅데이터 및 AI 시스템에 대한<br /> 데이터 수집 및 저장 그리고 모델 개발          
            </p>
        </div>
    </div>
    <br />
    <br />
</asp:Content>
