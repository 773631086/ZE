<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentUpdate.aspx.cs" Inherits="NumeralSceneMakeJy.AppointmentUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
		<meta charset="UTF-8">
	     <meta http-equiv="X-UA-Compatible" content="IE=10" />    <%--获取KindEditor数据需要兼容模式保存--%>
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
		<title>江油人社现场预约</title>
		<link rel="stylesheet" href="css/public.css" />
	   <script src="/Js/jquery-1.9.1.js" type="text/javascript"></script>
		<script type="text/javascript" src="js/layer/layer.js"></script>
		<link rel="stylesheet" href="js/layer/skin/layer.css" />
     
    <script src="/Js/PublicCommon.js" type="text/javascript"></script>
           <script src="/js/Sczy.Oos.System.js?version=1.0" type="text/javascript"></script>
    <script type="text/javascript">
       function DivClose(){
           DivClose();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    		<!--我要预约-->
		<div class="DateChoose" id="MeYuyue" style="width: 590px; display:block">
			<div class="midOne">
				<div class="midOne_Mid">
					变更预约
				</div>
			</div>
			<div>
				<div class="InforLine">
					<label>姓名</label>
					
                    <asp:TextBox ID="txtName" runat="server" placeholder="请输入姓名"></asp:TextBox>
				</div>
				<div class="InforLine">
					<label>身份证号</label>
				
                     <asp:TextBox ID="txtIdcard" runat="server" placeholder="请输入身份证号或者刷身份证"></asp:TextBox>
				</div>
				<div class="InforLine">
					<label>联系电话</label>
				
                     <asp:TextBox ID="txtPhone" runat="server" placeholder="请输入手机号"></asp:TextBox>
				</div>
			</div>
			<div class="BtnBiangeng">
		
                <asp:Button ID="btnSave" runat="server" Text="确认变更" class="biangeng" OnClick="btnSave_Click" style="margin-left:30px" />
				<%--	<input type="button" value="取消变更" class="biangeng" style="margin-left: 30px;" onclick="DivClose()" />--%>
			</div>
		</div>
         <input type="hidden" value="" id="hidAppProjectName" runat="server" />
      <script type="text/javascript">
       
          $("#hidAppProjectName").val(parent.parent.parent.$("#selectAppProject").find("option:selected").text());

      </script>
    </div>
    </form>
</body>
</html>
