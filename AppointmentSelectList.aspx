<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentSelectList.aspx.cs" Inherits="NumeralSceneMakeJy.AppointmentSelectList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="UTF-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
		<title>江油人社现场预约</title>
		<link rel="stylesheet" href="css/public.css" />
	   <script src="/Js/jquery-1.9.1.js" type="text/javascript"></script>
		<script type="text/javascript" src="js/layer/layer.js"></script>
		<link rel="stylesheet" href="js/layer/skin/layer.css" />
     
    <script src="/Js/PublicCommon.js" type="text/javascript"></script>
           <script src="/js/Sczy.Oos.System.js?version=1.0" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<div class="DateChoose" id="Update" style="width: 1100px; display:block">
			<div class="midOne">
				<div class="midOne_Mid">
					预约列表
				</div>
			</div>
                  <asp:Repeater ID="rptDept" runat="server">
            <HeaderTemplate>
			<table cellpadding="0" cellspacing="0" class="tabDate">
				<tr>
					<th width="5%">序号</th>
					<th width="10%">姓名</th>
					<th width="15%">日期</th>
					<th width="10%">开始时间</th>
					<th width="10%">结束时间</th>
					<th width="19%">手机号</th>
				<%--	<th width="15%">预约码</th>
					<th width="16%">操作</th>--%>
				</tr>
                   </HeaderTemplate>
            <ItemTemplate>
				<tr>
						<td> <%#Container.ItemIndex + 1%></td>
					<td><%# DataBinder.Eval(Container.DataItem, "AppointmentName").ToString()%></td>
					<td> <%# DateTime.Parse(time).ToString("yyyy年MM月dd日")%></td>
				<td><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "AppointmentStatTime").ToString()).ToString("HH:mm")%></td>
					<td><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "AppointmentEndTime").ToString()).ToString("HH:mm")%></td>
					<td><%# DataBinder.Eval(Container.DataItem, "AppointmentTel").ToString()%></td>
				<%--	<td>123456789</td>
					<td>
						<a href="#" class="yuyue" id="yuyueBian">变更</a>
						<a href="#" class="chakan">撤销</a>
					</td>--%>
				</tr>
		    </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
		</div>
    </div>
           
    </form>
</body>
</html>
