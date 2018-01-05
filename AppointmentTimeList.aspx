<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentTimeList.aspx.cs" Inherits="NumeralSceneMakeJy.AppointmentTimeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<div class="DateChoose" id="myModal" style="display:block">
			<div class="midOne">
				<div class="midOne_Mid">
					预约选择
				</div>
			</div>
             <input id="hidDay" type="hidden"  runat="server" />
             <script type="text/javascript">


                </script>
                 <asp:Repeater ID="rptDept" runat="server">
            <HeaderTemplate>
			<table cellpadding="0" cellspacing="0" class="tabDate" >
				<tr>
					<th width="10%">序号</th>
					<th width="20%">日期</th>
					<th width="17%">开始时间</th>
					<th width="17%">结束时间</th>
					<th width="15%">剩余名额</th>
					<th width="21%">操作</th>
				</tr>
                   </HeaderTemplate>
            <ItemTemplate>
				<tr>
					<td> <%#Container.ItemIndex + 1%></td>
					<td> <%# DateTime.Parse(time).ToString("yyyy年MM月dd日")%></td>
					<td><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "MakeStartTime").ToString()).ToString("HH:mm")%></td>
					<td><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "MakeEndTime").ToString()).ToString("HH:mm")%></td>
					<td><%#Remai(Eval("XCDetpMakeTimeID").ToString(),DateTime.Parse(DataBinder.Eval(Container.DataItem, "MakeStartTime").ToString()).ToString("HH:mm"),DateTime.Parse(DataBinder.Eval(Container.DataItem, "MakeEndTime").ToString()).ToString("HH:mm")) %></td>
					<td >
						<a style="display:<%=DateTime.Parse(time)<DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"))?"none":"" %>" href="javascript:void(0);setAdd('<%#time %>','<%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "MakeStartTime").ToString()).ToString("HH:mm")%>','<%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "MakeEndTime").ToString()).ToString("HH:mm")%>','<%# DataBinder.Eval(Container.DataItem, "XCDetpMakeTimeID")%>')" class="yuyue" id="Meyu">预约</a>
					<%--	<a style="margin-left:<%=DateTime.Parse(time)<DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"))?"56px":"" %>" href="javascript:void(0);setView('<%#time %>','<%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "MakeStartTime").ToString()).ToString("HH:mm")%>','<%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "MakeEndTime").ToString()).ToString("HH:mm")%>')" class="chakan">查看</a>--%>
					</td>
				</tr>
		
		      </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
             <table cellpadding="0" cellspacing="0" class="tabDate" style="display:<%= ListCount==0?"":"none"%>"><tr><td>未配置取号数据，请配置后再预约</td></tr></table>
		</div>
               <script type="text/javascript">
                  
                   var DeptId =<%="'"+DeptId+"'"  %> +"";
                   var AppProjectId =<%="'"+AppProjectId +"'"  %> +"";
                   var DeptName = parent.$("#selectDept").find("option:selected").text(); 
                   function setView(time, Statime, endTime) {
                
                       parent.OpenDivPage("/AppointmentSelectList.aspx?DeptId=" + DeptId + "&AppProjectId=" + AppProjectId + "&time=" + time + "&Statime=" + Statime + "&endTime=" + endTime + "&DeptName=" + DeptName, 1100, 600, false, null);
                   }
                   function setAdd(time, Statime, endTime, XCDetpMakeTimeID) {
              

                       var Iframe2 = OpenDivPage3("/AppointmentAdd.aspx?DeptId=" + DeptId + "&AppProjectId=" + AppProjectId + "&time=" + time + "&Statime=" + Statime + "&endTime=" + endTime + "" + "&DeptName=" + DeptName + "&XCDetpMakeTimeID=" + XCDetpMakeTimeID, 590, 380, false, null);

                       parent.$("#hidIframe2").val(Iframe2);
                    
                   }
                   function OpenDivPage3(Url, Width, Height, Title, Fun) {
                       if (Url.indexOf("?") > 0)
                           Url = Url + "&ranvalue=" + Math.random();
                       else
                           Url = Url + "?ranvalue=" + Math.random();
                       var Iframe2=   layer.open({
                           type: 2,
                           title: Title,
                           shadeClose: true,
                           shade: 0.4,

                           area: [Width + "px", Height + "px"],
                           content: Url, //iframe的url
                           end: function () {
                               try {
                                   parent.$("#hidIdCard").val(""); //清空身份证方法
                                   window.external.StopScan();
                          
                               }catch(ex){
                                  // alert(ex);
                               }
                        
                           }
                       });
                       return Iframe2;
                   }
               
              </script>
    </div>
    </form>
</body>
</html>
