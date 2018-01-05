/*******************************************************************************
* KindEditor - WYSIWYG HTML Editor for Internet
* Copyright (C) 2006-2011 kindsoft.net
*
* @author Roddy <luolonghao@gmail.com>
* @site http://www.kindsoft.net/
* @licence http://www.kindsoft.net/license.php
*******************************************************************************/

KindEditor.plugin('iframe', function (K) {
    var self = this, name = 'iframe';
    self.plugin.iframe = {
        edit: function () {
            
		    var lang = self.lang(name + '.'),
				html = '<div style="padding:20px;">' +
					//url
					'<div class="ke-dialog-row">' +
					'<label for="keUrl" style="width:60px;">URL地址</label>' +
					'<input class="ke-input-text" type="text" id="keUrl" name="url" value="" style="width:260px;" /></div>' +
					//type
					'<div class="ke-dialog-row"">' +
					'<label for="keType" style="width:60px;">显示宽度</label>' +
					'<input id="iframe_width" type="text" style="width:80px"></select>' +
                    '&nbsp;&nbsp;<label for="keType" style="width:60px;">显示高度</label>' +
					'<input id="iframe_height" type="text" style="width:80px"/>' +
					'</div>' +
					'</div>',
				dialog = self.createDialog({
				    name: name,
				    width: 450,
				    title: self.lang(name),
				    body: html,
				    yesBtn: {
				        name: self.lang('yes'),
				        click: function (e) {
				            var url = K.trim(urlBox.val());
				            if (url == 'http://' || K.invalidUrl(url)) {
				                alert(self.lang('invalidUrl'));
				                urlBox[0].focus();
				                return;
				            }
                            
				            var iframeHtml = "<iframe width='" + width.val() + "' height='" + height.val() + "' src='" + urlBox.val() + "' frameborder='0' marginwidth='0' marginheight='0' scrolling='no'></iframe>";
				            self.insertHtml(iframeHtml).hideDialog().focus();
				        }
				    }
				}),
				div = dialog.div,
				urlBox = K('input[name="url"]', div),
                width = K('input[id="iframe_width"]', div),
				height = K('input[id="iframe_height"]', div);
		    urlBox.val('http://');
		    width.val(300);
		    height.val(300);
		}
	};
	self.clickToolbar(name, self.plugin.iframe.edit);
});
