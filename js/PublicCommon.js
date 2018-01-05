function OpenDivPage(Url, Width, Height, Title,Fun) {
    if (Url.indexOf("?") > 0)
        Url = Url + "&ranvalue=" + Math.random();
    else
        Url = Url + "?ranvalue=" + Math.random();
    layer.open({
        type: 2,
        title:Title,
        shadeClose: true,
        shade: 0.4,
       
        area: [Width + "px", Height + "px"],
        content:Url //iframe的url
    });
}
function OpenDivPage2(Url, Width, Height, Title, Fun) {
    if (Url.indexOf("?") > 0)
        Url = Url + "&ranvalue=" + Math.random();
    else
        Url = Url + "?ranvalue=" + Math.random();
    layer.open({
        type: 2,
        title: Title,
        shadeClose: true,
        shade: 0.4,
        closeBtn: 0, //不显示关闭按钮
        area: [Width + "px", Height + "px"],
        content: Url //iframe的url
    });
}
function OpenPage(Url, Width, Height) {
    var Top = (window.screen.availHeight-Height) / 2;
    var Left = (window.screen.availWidth - Width) / 2;
    window.open(Url, "", "width=" + Width + ",height=" + Height+",top="+top+",left="+Left);
}
function PageClose() {
    window.close();
}
function DivClose() {
    try{
        if (parent.layer != null) {
            var i = parent.layer.getFrameIndex(window.name);
            parent.layer.close(i);
        }
    } catch (ex) {

    }
}
function DelRecord(Type, KeyValue, fn) {
    layer.confirm("确认要删除该条记录吗？", { icon: 3, title: "系统提示" }, function (index) {
        $.get("/PublicPage/DelDataReocrd.aspx?Type=" + Type + "&KeyValue=" + KeyValue, function (Result) {
            if (Result == "y") {
                top.layer.alert("记录删除成功!", { icon: 6, title: "系统提示" });
                if (fn != null)
                    fn();
                else
                    location.href = location.href;
            }
            else if (Result == "yn") {
                top.layer.alert("记录删除成功,但事项内容未配置!", { icon: 6, title: "系统提示" });
                location.href = location.href;
            }
            else {
                top.layer.alert("记录删除失败!", { icon: 5, title: "系统提示" });
            }
        });
    });    
}
/*
    功能：删除数据记录
    参数：
    Url:删除记录调用的页面
    Type:删除类型
    KeyValue:删除的主键直
    fn:回调方法，删除成功后调用的方法
*/
function DelDataRecord(Url,Type, KeyValue, fn) {
    layer.confirm("确认要删除该条记录吗？", { icon: 3, title: "系统提示" }, function (index) {
    $.get(Url+"?Type=" + Type + "&KeyValue=" + KeyValue, function (Result) {
        if (Result == "y") {
            top.layer.alert("记录删除成功!", { icon: 6, title: "系统提示" });
            if (fn != null)
                fn();
            else
                location.href = location.href;
        }
        else {
            top.layer.alert("记录删除失败!", { icon: 5, title: "系统提示" });
        }
    });
});
}
//刷新
function PageReload(objId) {
    if (arguments.length < 1) {
        document.location.href = document.location.href;
    }
    else {
        $("#" + objId).click();
    }
}
function Tips(TipsMess) {
    var i = layer.load(0, { time: 120 * 1000 });
    //var i = $.layer({
    //    type: 1,
    //    title: false,
    //    closeBtn: false,
    //    border: [1, 0.5, '#666', true],
    //    offset: ['50%', '50%'],
    //    move: ['.juanmove', true],
    //    area: ['150px', '30px'],
    //    page: {
    //        html: "<div style='padding-top:8px;text-align:center;width:150px'>" + TipsMess + "</div>"
    //    }
    //});
    return i;
}
function TipsClose(Index) {
    layer.close(Index)
}
//全选
function SelectAllChk(objId) {
    $("input[type=checkbox]").prop('checked', objId.checked);
    objId.checked = objId.checked;
}
//修改
function UpdateRecord(Type, KeyValue, fn) {
    if (!confirm("确定要修改该条记录吗？"))
        return false;
    $.get("/PublicPage/UpdateDataReocrd.aspx?Type=" + Type + "&KeyValue=" + KeyValue, function (Result) {
        if (Result == "y") {
            alert("记录修改成功!");
            if (fn != null)
                fn();
            else
                location.href = location.href;
        }
        else {
            alert("记录修改失败!如果是修改问题状态‘以确定’，该问题之前的状态必须是‘以处理’");
        }
    });
}
function UpdateValue(Type, KeyValue, fn) {
    $.get("/PublicPage/UpdateDataReocrd.aspx?Type=" + Type + "&KeyValue=" + KeyValue, function (Result) {
        if (Result == "y") {
            if (fn != null)
                fn();
            else
                location.href = location.href;
        }
        else {

        }
    });
}
//获取url中的参数
function getUrlParam(query, name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = query.substr(1).match(reg);  //匹配目标参数
    if (r != null)
        return unescape(r[2]);
    return null; //返回参数值
}