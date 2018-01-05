jQuery.System = {
    IsShowConfirm: true,
    delconfirm: function (KeyValue, Type) {
        if ($.System.IsShowConfirm) {
            layer.confirm("确定要删除所有选中的记录吗？", { icon: 3, title: "系统提示" }, function (index) {
                jQuery.System.IsShowConfirm = false;
                layer.close(index);
                //$("#" + delobjId).click();
                $.get("/PublicPage/UpdateDataReocrd.aspx?ranvalue=" + Math.random() + "&Type=" + Type + "&KeyValue=" + KeyValue, function (Result) {
                    if (Result == "y") {
                        $.System.Alert("删除成功!");                     
                            location.href = location.href;
                    }
                    else {
                        $.System.ErrorAlert("删除失败！");
                    }
                });
            });
            return false;
        }
    },
    Alert: function (content, iconType) {
        content = content.replace(/\\n/gi, "<br/>");
        if (iconType != null && typeof (iconType) != "undefine")
            top.layer.alert(content, { icon: arguments[1], title: "系统提示" })
        top.layer.alert(content, { icon: 6, title: "系统提示" });
    },
    ErrorAlert: function (content) {
        top.layer.alert(content, { icon: 5, title: "系统提示" });
    },
    Confirm: function (clickobject,content, yesfn) {
        layer.confirm(content, { icon: 3, title: "系统提示" }, function (index) {
            layer.close(index);
            var obj = $("#" + clickobject.id);
            //$("#" + delobjId).click();
            obj.removeAttr("onclick");
            if (yesfn != null && yesfn != "undefined")
                yesfn();
            else
                obj.click();
        });
        return false;
    },
    Prompt: function (callback) {
        layer.config({
            extend: 'extend/layer.ext.js'
        });
        layer.prompt({ title: '请输入离开事由' }, function (value, index, elem) {
            callback(value);
            layer.close(index);
        });
    },
    AlertReturn: function (content, iconType,url) {
        content = content.replace(/\\n/gi, "<br/>");
        if (iconType != null && typeof (iconType) != "undefine")
            top.layer.alert(content, { icon: arguments[1], title: "系统提示" })
        top.layer.alert(content, {
            icon: 6, title: "系统提示", yes: function (index,layero) {
                //  window.location.href = document.referrer;
                top.layer.close(index);
                self.location = url;
               
            }
        });
    }
};