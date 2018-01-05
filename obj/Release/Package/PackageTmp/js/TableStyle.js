(
    function () {
        $(".tabDate").find("tr").mouseover(function () {
            $(this).find("td").css("background-color", "#cbdae8"); //E3E3E3
        });
        $(".tabDate").find("tr").mouseout(function () {
            $(this).find("td").css("background-color", "#FFFFFF");
        });
    }
)();

    $(document).ready(function () {
        if (document.getElementById("Pager") == null)
            return;
        var Adiv = document.getElementById("Pager").getElementsByTagName("a");
        if (Adiv.length < 0)
            return;
        var DivWidth = $("#Pager").width() * 0.6;
        
        for (var i = 0; i < Adiv.length; i++) {
            var a = Adiv[i].innerHTML;
            if (IsNum(a)||a=="...") {
                if (DivWidth > 640) {
                    Adiv[i].style.cssText = "width : 36px;vertical-align: middle;"
                }
                else {
                    Adiv[i].style.cssText = "width : 25px;vertical-align: middle;"
                }
            }
            else {
                Adiv[i].style.cssText = "width : 45px;vertical-align: middle;"
            }
            
            var j = Adiv.length - 3;
        }

        function IsNum(s) {
            if (s != null) {
                var r, re;
                re = /\d*/i; //\d表示数字,*表示匹配多个数字
                r = s.match(re);
                return (r == s) ? true : false;
            }
            return false;
        }

       


    });