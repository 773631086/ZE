<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NumeralSceneMakeJy.index" %>

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

    <script type="text/javascript">
        function OptionsTop(SelectId) {
            var selectValue = $("#" + SelectId).find("option:selected").prev().val();
            if (selectValue != "") {
                $("#" + SelectId + " option[value='" + selectValue + "']").attr("selected", true);
                stdt();
            }
        }
        function OptionsUnder(SelectId) {
            var selectValue = $("#" + SelectId).find("option:selected").next().val();
            if (selectValue != "") {
                $("#" + SelectId + " option[value='" + selectValue + "']").attr("selected", true);
                stdt();
            }
        }
    </script>
    <style type="text/css">
        a{ 
        text-decoration:none; 
        color:#333; 
        } 

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<div class="wmain">
			<div class="main">
				<!--头部-->
				<div class="mainTop">
					<img src="images/icon_top.png" style="width: 100%;" />
				</div>
				<!--中间内容-->
				<div class="mainMiddle">
					<div class="midOne">
						<div class="midOne_Mid">
							部门事项选择
						</div>
					</div>
					<div class="midTwo">
						<div class="midTwo_One">
							<label>部门选择：</label>
							<select id="selectDept" class="slect" onchange="SelectAppProject('')">
								<option value="">请选择</option>
							
							</select>
						</div>
						<div class="midTwo_One" style="padding-left: 35px;">
							<label>事项选择：</label>
							<select id="selectAppProject" class="slect">
								<option value="">请选择</option>
								
							</select>
						</div>
						<div class="clear"></div>
					</div>
					<div class="midOne">
						<div class="midOne_Mid">
							日期选择
						</div>
					</div>
					<div class="midTwo">
						<div class="midTwo_Two">
							<div class="midTtwo_one">
								<a href="javascript:void(0);OptionsTop('ddlyears')">
									<</a>
										<div class="The">
										<%--	<select class="date">
												<option value="0">年份</option>
												<option value="1">2017年</option>
											</select>--%>
                                            <asp:DropDownList ID="ddlyears" runat="server" CssClass="date">
                    
                                 </asp:DropDownList>
										</div>
										<a href="javascript:void(0);OptionsUnder('ddlyears')">></a>
							</div>
							<div class="midTtwo_one" style="margin-left: 40px;">
										<a href="javascript:void(0);OptionsTop('ddlMonth')">
									<</a>
										<div class="The">
											<%--<select class="date">
												<option value="0">年份</option>
												<option value="1">2017年</option>
											</select>--%>
                                            <asp:DropDownList ID="ddlMonth" runat="server"   CssClass="date">
                    
            </asp:DropDownList>
										</div>
											<a href="javascript:void(0);OptionsUnder('ddlMonth')">></a>
							</div>
							<div class="midTwo_two" id="BianGeng">
								变更预约
							</div>
							<div class="clear"></div>
						</div>
						<table id="tableList" cellpadding="0" cellspacing="0" class="tablist">
							<tr>
								<th>星期天</th>
								<th>星期一</th>
								<th>星期二</th>
								<th>星期三</th>
								<th>星期四</th>
								<th>星期五</th>
								<th>星期六</th>
							</tr>
							<tr>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
								<td>
									<div class="appointment AppointmentFull">
										<div class="tablistNumber">1</div>
										<div class="tlistInformation">预约名额已满</div>
									</div>
								</td>
							</tr>
							<tr>
								<td>
									<div class="appointment AppointmentFull">
										<div class="tablistNumber">2</div>
										<div class="tlistInformation">预约名额已满</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentFull">
										<div class="tablistNumber">3</div>
										<div class="tlistInformation">预约名额已满</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">4</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">5</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">6</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">7</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">8</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
							</tr>
							<tr>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">9</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">10</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">11</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentYes">
										<div class="tablistNumber">12</div>
										<div class="tlistInformation">可预约16/100</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentYes">
										<div class="tablistNumber">13</div>
										<div class="tlistInformation">可预约25/100</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">14</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">15</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
							</tr>
							<tr>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">16</div>
										<div class="tlistInformation">预约名额已满</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentYesO">
										<div class="tablistNumber">17</div>
										<div class="tlistInformation">可预约50/100</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">18</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">19</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">20</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">21</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">22</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
							</tr>
							<tr>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">23</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentNo">
										<div class="tablistNumber">24</div>
										<div class="tlistInformation">不可预约</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentYesT">
										<div class="tablistNumber">25</div>
										<div class="tlistInformation">可预约60/100</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentYesT">
										<div class="tablistNumber">26</div>
										<div class="tlistInformation">可预约60/100</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentYesT">
										<div class="tablistNumber">27</div>
										<div class="tlistInformation">可预约60/100</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentYesT">
										<div class="tablistNumber">28</div>
										<div class="tlistInformation">可预约60/100</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentYesT">
										<div class="tablistNumber">29</div>
										<div class="tlistInformation">可预约60/100</div>
									</div>
								</td>
							</tr>
							<tr>
								<td>
									<div class="appointment AppointmentYesT">
										<div class="tablistNumber">30</div>
										<div class="tlistInformation">可预约60/100</div>
									</div>
								</td>
								<td>
									<div class="appointment AppointmentYesT">
										<div class="tablistNumber">31</div>
										<div class="tlistInformation">可预约60/100</div>
									</div>
								</td>
							</tr>
						</table>
					</div>
				</div>
				<!--底部-->
               
				<div class="mainBottom">
					版权所有：四川省江油市人力资源和社会保障局&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;联系电话：（028）86190174
				</div>
			</div>
		</div>
            <script type="text/javascript">
                function loadselectDept() {

                    $.get("/Ajax/AjaxOnLineDate.aspx?ranvalue=" + Math.random() + "&Action=GetDeptidList", function (Result) {
                        //JS返回值
                        $("#selectDept").empty();
                        if (Result.length > 0) {
                            var jsonS = jQuery.parseJSON(Result); //获取返回的JSON数据
                            if (jsonS.data.length > 0) {
                                for (var i = 0; i < jsonS.data.length; i++) {
                                    if (i == 0) {
                                        $("#selectDept").append("<option value=''>请选择</option>");
                                    }
                                    $("#selectDept").append("<option value='" + jsonS.data[i].DeptId + "'>" + jsonS.data[i].DeptName + "</option>");
                                }

                             

                            } else {
                                $("#selectDept").append("<option value=''>请选择</option>");
                            }

                        } else {
                            $("#selectDept").append("<option value=''>请选择</option>");
                        }
                    });
                }
                loadselectDept();


                function SelectAppProject(AppProject) {
                    var ddlDept = $("#selectDept").val();
                    $.get("/Ajax/AjaxOnLineDate.aspx?ranvalue=" + Math.random() + "&Action=SelectAppProject&ddlDept=" + ddlDept, function (Result) {
                        //JS返回值
                        $("#selectAppProject").empty();
                        if (Result.length > 0) {
                            var jsonS = jQuery.parseJSON(Result); //获取返回的JSON数据
                            if (jsonS.data.length > 0) {
                                for (var i = 0; i < jsonS.data.length; i++) {
                                    if (i == 0) {
                                        $("#selectAppProject").append("<option value=''>请选择事项</option>");
                                    }
                                    $("#selectAppProject").append("<option value='" + jsonS.data[i].AppProjectCodeID + "'>" + jsonS.data[i].AppProjectName + "</option>");
                                }


                            } else {
                                $("#selectAppProject").append("<option value=''>请选择事项</option>");
                            }

                        } else {
                            $("#selectAppProject").append("<option value=''>请选择事项</option>");
                        }

                    });

                }


                function stdt() {
                    //  alert($("#ddlyears").val());
                    var new_year = $("#ddlyears").val();
                    var new_month = $("#ddlMonth").val();
                    for (var i = 6; i >= 1; i--) {
                        $('#tableList tr:eq(' + i + ')').remove();
                    }
                    var AppProjectId = $("#selectAppProject").val();
                    var DeptId = $("#selectDept").val();
                    $.ajaxSettings.async = false;
                    $.get("/Ajax/AjaxOnLineDate.aspx?ranvalue=" + Math.random() + "&Action=selectDay&years=" + new_year + "&month=" + new_month + "&AppProjectId=" + AppProjectId + "&DeptId=" + DeptId, function (Result) {
                    //JS返回值
                    if (Result.length > 0) {
                        var jsonS = jQuery.parseJSON(Result);
                        if (jsonS.status != 0) {

                            for (var j = 1; j <= 6; j++) {
                                var trHTML = "<tr>"
                                for (var i = 1; i <= 7; i++) {
                                    var classname = "";
                                    var title = "";
                                    if (jsonS.data[(j - 1) * 7 + i - 1].type == 0) {
                                        classname = "class=\"appointment AppointmentNo\"";
                                        title = "不可预约";
                                       
                                    } else if (jsonS.data[(j - 1) * 7 + i - 1].type == 1) {
                                        if (jsonS.data[(j - 1) * 7 + i - 1].total > 0) {
                                            if (jsonS.data[(j - 1) * 7 + i - 1].num / jsonS.data[(j - 1) * 7 + i - 1].total < 0.4) {
                                                classname = "class=\"appointment AppointmentYes\"";
                                                title = "可预约" + jsonS.data[(j - 1) * 7 + i - 1].num + "/" + jsonS.data[(j - 1) * 7 + i - 1].total;
                                            } else if (jsonS.data[(j - 1) * 7 + i - 1].num / jsonS.data[(j - 1) * 7 + i - 1].total < 0.8) {
                                                classname = "class=\"appointment AppointmentYesO\"";
                                                title = "可预约" + jsonS.data[(j - 1) * 7 + i - 1].num + "/" + jsonS.data[(j - 1) * 7 + i - 1].total;
                                            } else if (jsonS.data[(j - 1) * 7 + i - 1].num / jsonS.data[(j - 1) * 7 + i - 1].total < 1) {
                                                classname = "class=\"appointment AppointmentYesT\"";
                                                title = "可预约" + jsonS.data[(j - 1) * 7 + i - 1].num + "/" + jsonS.data[(j - 1) * 7 + i - 1].total;
                                            }
                                            else {
                                                classname = "class=\"appointment AppointmentFull\"";
                                                title = "预约名额已满";
                                            }
                                        } else {
                                            classname = "class=\"appointment AppointmentYes\"";
                                            title = "无限制";
                                        }
                                        if (jsonS.data[(j - 1) * 7 + i - 1].select == 1) {
                                            classname = "class=\"appointment AppointmentNo\"";
                                            title = "超过预约日期";
                                        }
                                    }
                                  
                                    if (jsonS.data[(j - 1) * 7 + i - 1].day != "") {
                                        //   
                                        if (title == "不可预约") {
                                            trHTML = trHTML + "<td><div id=\"div" + jsonS.data[(j - 1) * 7 + i - 1].day + "\" " + classname + " title=\"" + "" + "\"> "
                                            + "<div class=\"tablistNumber\">" + jsonS.data[(j - 1) * 7 + i - 1].day + "</div>	<div class=\"tlistInformation\">" + title + "</div></div></td>";
                                        } else {
                                            trHTML = trHTML + "<td><a href=\"javascript:void(0);setDiv(" + jsonS.data[(j - 1) * 7 + i - 1].day + ")\"  ><div id=\"div" + ((j - 1) * 7 + i - 1) + "\" " + classname + " title=\"" + "" + "\"> "
                                             + "<div class=\"tablistNumber\">" + jsonS.data[(j - 1) * 7 + i - 1].day + "</div>	<div class=\"tlistInformation\">" + title + "</div></div></a></td>";
                                        }
                                    
                                     //   trHTML = trHTML + "<td><a href=\"javascript:void(0);setDiv(" + ((j - 1) * 7 + i - 1) + ")\"  ><div id=\"div" + ((j - 1) * 7 + i - 1) + "\" " + classname + " title=\"" + title + "\"> " + jsonS.data[(j - 1) * 7 + i - 1].day + "</div></a></td>";

                                    } else {
                                        trHTML = trHTML + "<td></td>";
                                    }
                                }
                                trHTML = trHTML + "</tr>";
                                $("#tableList").append(trHTML);
                            }

                        } else {
                            alert(jsonS.msg);
                        }


                    }

                });


            }
                stdt() ;


                $(document).ready(function () {
                    $("#ddlMonth").change(function () {

                        stdt();

                    });
                    $("#ddlyears").change(function () {

                        stdt();
                    });
                    $("#selectAppProject").change(function () {

                        stdt();
                    });
                    $("#selectDept").change(function () {

                        stdt();
                    });
                });

                function setDiv(day) {
                    var AppProjectId = $("#selectAppProject").val();
                    var DeptId = $("#selectDept").val();
                    var time = ($("#ddlyears").val() + "-" + $("#ddlMonth").val() + "-" + day);
                    var  Iframe1= OpenDivPage3('/AppointmentTimeList.aspx?day=' + day + "&AppProjectId=" + AppProjectId + "&DeptId=" + DeptId + "&time=" + time, 878, 400, false, null);
                    $("#hidIframe1").val(Iframe1);
                }


                function setChang(day) {
                    var AppProjectId = $("#selectAppProject").val();
                    var DeptId = $("#selectDept").val();
                    var time = ($("#ddlyears").val() + "-" + $("#ddlMonth").val() + "-" + day);
                    var iframe1 = OpenDivPage3('/AppointmentTimeList.aspx?day=' + day + "&AppProjectId=" + AppProjectId + "&DeptId=" + DeptId + "&time=" + time, 878, 400, false, null);


                }
                function OpenDivPage3(Url, Width, Height, Title, Fun) {
                    if (Url.indexOf("?") > 0)
                        Url = Url + "&ranvalue=" + Math.random();
                    else
                        Url = Url + "?ranvalue=" + Math.random();
                    var Iframe1= layer.open({
                        type: 2,
                        title: Title,
                        shadeClose: true,
                        shade: 0.4,

                        area: [Width + "px", Height + "px"],
                        content: Url, //iframe的url
                        end: function () {
                            try {
                              
                                parent.$("#hidIdCard").val("");
                                stdt();
                                window.external.StopScan();
                             
                            }catch(ex ){

                            }
                        }
                    });
                    return Iframe1;
                }
                $('#BianGeng').click(function () {
               

                    var hidUnfoIframe1 = OpenDivPage3('/ChangeAppointment.aspx', 600, 250, false, null);
                    $("#hidUnfoIframe1").val(hidUnfoIframe1);
                });

          
             </script>

         <!--耍身份证-->
        <input id="hidIdCard" type="hidden" value="AppointmentAdd" />
           <input id="hidIframe1" type="hidden" value="" />
           <input id="hidIframe2" type="hidden" value="" />
          <input id="hidUnfoIframe1" type="hidden" value="" />
          <script type="text/javascript">

              function readIdcard(name, Sex, Nation, Born, Address, IDCardNo, GrantDept, UserLifeBegin, UserLifeEnd) {
                 // alert($("#hidIframe1").val() + " " + $("#hidIframe2").val());
              
                //  $(window.frames["layui-layer-iframe" + $("#hidIframe1").val()].frames["layui-layer-iframe" + $("#hidIframe2").val()].document).find("#txtIdcard").val("5555");
                //  $(window.frames["layui-layer-iframe" + $("#hidIframe1").val()].frames["layui-layer-iframe" + $("#hidIframe2").val()].document).find("#txtName").val("5555");
                  if ($("#hidIdCard").val() == "AppointmentAdd") {
                      window.frames["layui-layer-iframe" + $("#hidIframe1").val()].frames["layui-layer-iframe" + $("#hidIframe2").val()].document.getElementById("txtIdcard").value = IDCardNo;
                      window.frames["layui-layer-iframe" + $("#hidIframe1").val()].frames["layui-layer-iframe" + $("#hidIframe2").val()].document.getElementById("txtName").value = name;
                  } else if ($("#hidIdCard").val() == "ChangeAppointment") {
                      window.frames["layui-layer-iframe" + $("#hidUnfoIframe1").val()].document.getElementById("IdCard").value = IDCardNo;
                  } else {

                  }
              
              }
          </script>




		<!--弹出层-->
		<!--正常选择-->
		<div class="DateChoose" id="myModal">
			<div class="midOne">
				<div class="midOne_Mid">
					预约选择
				</div>
			</div>
			<table cellpadding="0" cellspacing="0" class="tabDate">
				<tr>
					<th width="10%">序号</th>
					<th width="20%">日期</th>
					<th width="17%">开始时间</th>
					<th width="17%">结束时间</th>
					<th width="15%">剩余名额</th>
					<th width="21%">操作</th>
				</tr>
				<tr>
					<td>1</td>
					<td>2017年09月08日</td>
					<td>上午9：00</td>
					<td>下午4：00</td>
					<td>2个</td>
					<td>
						<a href="#" class="yuyue" id="Meyu">预约</a>
						<a href="#" class="chakan">查看</a>
					</td>
				</tr>
				<tr>
					<td>1</td>
					<td>2017年09月08日</td>
					<td>上午9：00</td>
					<td>下午4：00</td>
					<td>2个</td>
					<td>
						<a href="#" class="yuyue">预约</a>
						<a href="#" class="chakan">查看</a>
					</td>
				</tr>
				<tr>
					<td>1</td>
					<td>2017年09月08日</td>
					<td>上午9：00</td>
					<td>下午4：00</td>
					<td>2个</td>
					<td>
						<a href="#" class="yuyue">预约</a>
						<a href="#" class="chakan">查看</a>
					</td>
				</tr>
				<tr>
					<td>1</td>
					<td>2017年09月08日</td>
					<td>上午9：00</td>
					<td>下午4：00</td>
					<td>2个</td>
					<td>
						<a href="#" class="yuyue">预约</a>
						<a href="#" class="chakan">查看</a>
					</td>
				</tr>
			</table>
		</div>
		<!--变更查询-->
		<div class="DateChoose" id="myModalBiangeng" style="width: 592px;">
			<div class="midOne">
				<div id="Onem" class="midOne_MidA midOne_Mid">
					预约码查询
				</div>
				<div id="Twom" href="#" class="midOne_MidA">身份证号查询</div>
			</div>
			<div class="BiangengOne">
				<div class="midTwo_One" id="BiangengOne" style="width: 100%;margin-top: 20px;">
					<label>预约码查询：</label>
					<input type="text" class="slect" />
				</div>
				<div class="midTwo_One" id="BiangengTwo" style="width: 100%;margin-top: 20px;display: none;">
					<label>身份证号查询：</label>
					<input type="text" class="slect" />
				</div>
			</div>
			<div class="BtnBiangeng">
					<input type="button" value="变更查询" class="biangeng" />
			</div>
		</div>
		<!--变更预约列表-->
		<div class="DateChoose" id="Update" style="width: 1100px;">
			<div class="midOne">
				<div class="midOne_Mid">
					预约列表
				</div>
			</div>
			<table cellpadding="0" cellspacing="0" class="tabDate">
				<tr>
					<th width="5%">序号</th>
					<th width="10%">姓名</th>
					<th width="15%">日期</th>
					<th width="10%">开始时间</th>
					<th width="10%">结束时间</th>
					<th width="19%">身份证号</th>
					<th width="15%">预约码</th>
					<th width="16%">操作</th>
				</tr>
				<tr>
					<td>1</td>
					<td>刘安渊</td>
					<td>2017年09月08日</td>
					<td>上午9：00</td>
					<td>下午4：00</td>
					<td>1234567891234567</td>
					<td>123456789</td>
					<td>
						<a href="#" class="yuyue" id="yuyueBian">变更</a>
						<a href="#" class="chakan">撤销</a>
					</td>
				</tr>
			</table>
		</div>
		<!--填写预约信息-->
		<div class="DateChoose" id="Infor" style="width: 590px;">
			<div class="midOne">
				<div class="midOne_Mid">
					信息填写
				</div>
			</div>
			<div >
				<div class="InforLine">
					<label>姓名</label>
					<input type="text" placeholder="请输入姓名" />
				</div>
				<div class="InforLine">
					<label>身份证号</label>
					<input type="text" placeholder="请输入姓名" />
				</div>
				<div class="InforLine">
					<label>联系电话</label>
					<input type="text" placeholder="请输入姓名" />
				</div>
				<div class="InforLine">
					<label>预约日期</label>
					<select class="date" style="width: 400px;height: 42px;">
						<option value="0">请选择</option>
					</select>
				</div>
				<div class="InforLine">
					<label>预约时间</label>
					<select class="date" style="width: 400px;height: 42px;">
						<option value="0">请选择</option>
					</select>
				</div>
			</div>
			<div class="BtnBiangeng">
					<input type="button" value="确认变更" class="biangeng" />
			</div>
		</div>
		<!--我要预约-->
		<div class="DateChoose" id="MeYuyue" style="width: 590px;">
			<div class="midOne">
				<div class="midOne_Mid">
					我要预约
				</div>
			</div>
			<div>
				<div class="InforLine">
					<label>姓名</label>
					<input type="text" placeholder="请输入姓名" />
				</div>
				<div class="InforLine">
					<label>身份证号</label>
					<input type="text" placeholder="请输入姓名" />
				</div>
				<div class="InforLine">
					<label>联系电话</label>
					<input type="text" placeholder="请输入姓名" />
				</div>
			</div>
			<div class="BtnBiangeng">
					<input type="button" value="我要预约" class="biangeng" />
					<input type="button" value="取消预约" class="biangeng" style="margin-left: 30px;" />
			</div>
		</div>
    </div>

        <script>
            $(function () {
                /*预约*/
                $('.AppointmentYesT').click(function () {
                    layer.open({
                        type: 1,
                        title: false,
                        area: ['878px', '400px'],
                        content: $('#myModal')
                    });
                });
                $('.AppointmentYesO').click(function () {
                    layer.open({
                        type: 1,
                        title: false,
                        area: ['878px', '400px'],
                        content: $('#myModal')
                    });
                });
                $('.AppointmentYes').click(function () {
                    layer.open({
                        type: 1,
                        title: false,
                        area: ['878px', '400px'],
                        content: $('#myModal')
                    });
                });
                /*变更查询*/
            
                $('#Onem').click(function () {
                    $('.midOne_MidA').removeClass('midOne_Mid');
                    $('#BiangengOne').show();
                    $('#BiangengTwo').hide();
                    $(this).addClass('midOne_Mid');
                });
                $('#Twom').click(function () {
                    $('.midOne_MidA').removeClass('midOne_Mid');
                    $('#BiangengOne').hide();
                    $('#BiangengTwo').show();
                    $(this).addClass('midOne_Mid');
                });
                /*修改预约列表*/
                $('.AppointmentFull').click(function () {
                    layer.open({
                        type: 1,
                        title: false,
                        area: ['1100px', '300px'],
                        content: $('#Update')
                    });
                });
                /*变更填写信息*/
                $('#yuyueBian').click(function () {
                    layer.open({
                        type: 1,
                        title: false,
                        area: ['590px', '480px'],
                        content: $('#Infor')
                    });
                });
                /*我要预约*/
                $('#Meyu').click(function () {
                    layer.open({
                        type: 1,
                        title: false,
                        area: ['590px', '380px'],
                        content: $('#MeYuyue')
                    });
                })
            });
</script>
    </form>
</body>
</html>
