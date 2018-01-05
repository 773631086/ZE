<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeAppointmentList.aspx.cs" Inherits="NumeralSceneMakeJy.ChangeAppointmentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
					<th width="15%">开始时间</th>
					<th width="15%">结束时间</th>
					<th width="13%">手机号</th>
                    <th width="19%">身份证</th>
					<th width="7%">预约码</th>
					<th width="16%">操作</th>
				</tr>
                   </HeaderTemplate>
            <ItemTemplate>
				<tr>
						<td> <%#Container.ItemIndex + 1%></td>
					<td><%# DataBinder.Eval(Container.DataItem, "AppointmentName").ToString()%></td>
	
					<td><%#  DateTime.Parse(DataBinder.Eval(Container.DataItem, "AppointmentStatTime").ToString() ).ToString("yyyy-MM-dd HH:mm")%></td>
					<td><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "AppointmentStatTime").ToString() ).ToString("yyyy-MM-dd HH:mm")%></td>
					<td><%# DataBinder.Eval(Container.DataItem, "AppointmentTel").ToString()%></td>
					<td><%# DataBinder.Eval(Container.DataItem, "AppointmentCard").ToString()%></td>
                    	<td><%# DataBinder.Eval(Container.DataItem, "AppointmentVerification").ToString()%></td>
					<td>
						<a href="javascript:void(0);OpenDivPage('/AppointmentUpdate.aspx?Id=<%#DataBinder.Eval(Container.DataItem, "ID")%>',590,380,false,null)" class="yuyue" id="yuyueBian">变更</a>
						<a href="javascript:void(0);DelRecord1('undo','<%#DataBinder.Eval(Container.DataItem, "ID")%>',PageReload)" class="chakan" >作废</a>
					</td>
				</tr>
		    </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
		</div>
    </div>
         <script type="text/javascript">
             function DelRecord1(Type, KeyValue, fn) {
                 layer.confirm("确认作废以后将不可在本系统查询！", { icon: 3, title: "系统提示" }, function (index) {
                
                     $.get("/Ajax/AjaxOnLineDate.aspx?Action=" + Type + "&KeyValue=" + KeyValue, function (Result) {
                        
                         if (Result == "y") {
                             top.layer.alert("记录作废成功!", { icon: 6, title: "系统提示" });
                             if (fn != null)
                                 fn();
                             else
                                 location.href = location.href;
                         }
                       
                         else {
                             top.layer.alert("记录作废失败!", { icon: 5, title: "系统提示" });
                         }
                     });
                 });
             }

           
         </script>
    </form>
</body>
</html>
