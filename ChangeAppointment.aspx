<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeAppointment.aspx.cs" Inherits="NumeralSceneMakeJy.ChangeAppointment" %>

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
    	<div class="DateChoose" id="myModalBiangeng" style="width: 592px; display:block">
			<div class="midOne">
				<div id="Onem" class="midOne_MidA midOne_Mid">
					预约码查询
				</div>
				<div id="Twom" href="#" class="midOne_MidA">身份证号查询</div>
			</div>
			<div class="BiangengOne">
				<div class="midTwo_One" id="BiangengOne" style="width: 100%;margin-top: 20px;">
					<label>预约码查询：</label>
					<input type="text" class="slect" id="val" />
				</div>
				<div class="midTwo_One" id="BiangengTwo" style="width: 100%;margin-top: 20px;display: none;">
					<label>身份证号查询：</label>
					<input type="text" class="slect" " id="IdCard"  />
				</div>
			</div>
			<div class="BtnBiangeng">
			<input type="button" value="变更查询" class="biangeng" onclick="javascript:void(0);setView()" />
             
			</div>
		</div>
           <input type="hidden" value="1" id="hidApp" runat="server" />
    </div>
        <script type="text/javascript">

          
            try {
                parent.$("#hidIdCard").val("ChangeAppointment");
                window.external.SunScan();
            } catch (ex) {

            }
            $('#Onem').click(function () {
                $('.midOne_MidA').removeClass('midOne_Mid');
                $('#BiangengOne').show();
                $('#BiangengTwo').hide();
                $('#hidApp').val(1);
                $(this).addClass('midOne_Mid');
            });
            $('#Twom').click(function () {
                $('.midOne_MidA').removeClass('midOne_Mid');
                $('#BiangengOne').hide();
                $('#BiangengTwo').show();
                $('#hidApp').val(2);
                $(this).addClass('midOne_Mid');
            });
         

            function setView() {
              
                parent.OpenDivPage("/ChangeAppointmentList.aspx?type=" + $('#hidApp').val() + "&val=" + $('#val').val() + "&IdCard=" + $('#IdCard').val(), 1100, 600, false, null);
            }
        </script>
    </form>
</body>
</html>
