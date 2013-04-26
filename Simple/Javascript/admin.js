///<reference path="jquery-1.6.min.js">
///<reference path="adc.utils.js">

var Admin = {};
var Login = {};
var Index = {};
var Pager = {};
var CheckBoxs = {};
var Deletes = {};
var base = {};
var insert = {};
var update = {};
var keydow = {};
//参数.config
base.config = {
    pagesize: 10,
    pageindex: 1,
    pagecount: 0,
    url: "",
    json: "",
    rowCount: 0
};

Admin.Loaded = false;
Admin.Init = function () {
    $('a').live('focus', function () {
        $(this).blur();
    });
    $('input[type=radio]').live('focus', function () {
        $(this).blur();
    });
    $('input[type=checkbox]').live('focus', function () {
        $(this).blur();
    });
    $('input[type=checkbox]').css('border', 'none');
    $('.btn-middle').css({
        'margin-bottom': (adc.base.IsIE6 ? 1 : 3) + 'px'
    });
    $('.btn').live('mousedown', function () {
        $(this).addClass('btn-active');
    }).live('mouseup', function () {
        $(this).removeClass('btn-active');
    }).live('mouseover', function () {
        $(this).addClass('btn-hover');
    }).live('mouseout', function () {
        $(this).removeClass('btn-active');
        $(this).removeClass('btn-hover');
    });
    $('.btn-lit').live('mousedown', function () {
        $(this).addClass('btn-lit-active');
    }).live('mouseup', function () {
        $(this).removeClass('btn-lit-active');
    }).live('mouseover', function () {
        $(this).addClass('btn-lit-hover');
    }).live('mouseout', function () {
        $(this).removeClass('btn-lit-active');
        $(this).removeClass('btn-lit-hover');
    });
    $(document).keydown(function () {
        keydow.DelGrid("data-table");
    })

    $(window).bind('resize', function () {
        if ((Admin.Loaded || $.browser.mozilla) && (Admin.IsLoginPage || Admin.IsIndexPage)) {
            var url = window.location.href;
            var pos = url.indexOf('#');
            window.location = pos > -1 ? url.substring(0, pos) : url;
        }
        Admin.Loaded = true;
    });
};
Admin.Logout = function () {
    art.dialog.confirm('你确定退出系统？', function () {
        location.href = Admin.LogoutUrl;
    });
};

Index.MenuIndex = 0;
Index.MenuSpeed = 250;
Index.Init = function () {
    var win = $(window);
    var width = win.width() - 182 - 0 - 2;
    var height = win.height() - 64 - 2 - 33;
    var height_c = height - 29 - 8 - 7;
    $('#left').height(height);
    $('#right').height(height).width(width);
    $('#menu-container').height(height - 3);
    $('#content-container').height(height_c);
    $('#loading').css('padding-top', height_c / 2);
    var tits = $('.menu-tit');
    var lists = $('.menu-list').hide();
    $(lists[0]).slideDown(Index.MenuSpeed);
    $.each(tits, function (i, el) {
        $(el).attr('index', i);
    });
    tits.click(function (e) {
        var me = $(this);
        var index = parseInt(me.attr('index'));
        if (index != Index.MenuIndex) {
            var last = Index.MenuIndex;
            Index.MenuIndex = index;
            $(lists[last]).slideUp(Index.MenuSpeed);
            $(lists[index]).slideDown(Index.MenuSpeed);
        }
    });
    var links = $('a[target=content]');
    if (links.length > 0) {
        links.bind('click', function (e) {
            if (e.preventDefault)
                e.preventDefault();
            else
                e.returnValue = false;
            Index.Open($(this).attr('href'));
        });
    }
    Index.Open(Admin.IndexStartPage);
};
Index.OutputIframe = function () {
    var scrolling = $.isIE6 == true ? 'yes' : 'auto';
    document.write('<iframe id="content" width="100%" height="100%" class="hide" marginwidth="0" marginheight="0" frameborder="0" scrolling="' + scrolling + '" onload="$(\'#loading\').hide();$(this).show();" src=""></iframe>');
};
Index.Open = function (url) {

    if (url != '') {
        //打开窗口时隐藏iframe以防止loading和iframe同时出现
        top.$('#content').hide();
        top.$('#loading').show();
        if (url.indexOf('#') == -1) {
            url = url + (url.indexOf('?') == -1 ? '?___t=' : '&___t=') + Math.random() + '&url=' + adc.base.GetUrl(document.location.href);
        } else {
            var arr = url.split('#');
            url = arr[0] + (arr[0].indexOf('?') == -1 ? '?___t=' : '&___t=') + Math.random() + '&url=' + adc.base.GetUrl(document.location.href) + '#' + arr[1];
        }
        top.$('#content').attr('src', url);

    }
};
Index.SetTitle = function (title) {
    top.$('#index-title').html(title);

};
Index.Back = function (obj) {
    var url = adc.base.GetParamUrl(obj);
    location.href = url;
}

Index.RemoveClass = function (obj, Classname) {
    $("#" + obj).removeClass(Classname);
}

/*-------分页方法----------*/
var Mydialog;
Pager.GetPageInfo = function (pagesize, pageindex, url, json) {
    base.config.url = url;
    var par;
    if (json == undefined) {
        par = adc.base.FormatString("pageindex={0}&pagesize={1}&type=List", pageindex, pagesize);
    } else {

        par = adc.base.FormatString("pageindex={0}&pagesize={1}&json={2}&type=List", pageindex, pagesize, encodeURIComponent(json));
        base.config.json = json;

    }

    adc.base.ajaxjson(url, par, function (data) {

        ShowPageInfo(data.o);
        base.config.pagecount = data.j;
        base.config.rowCount = data.c;
        Pager.SetPage(pageindex, data.j, url, data.c);

    }, function () {
        art.dialog.tips('请求出错请刷新页面', 2);
    },
		'get',
		function () {
		    Mydialog = art.dialog({
		        title: false

		    });
		},
		function () {
		    $('table.data-table tr:even').addClass('even');
		    Mydialog.hide();
		});
}
PageClick = function (pageclickednumber) {

    $("#pager").pager({
        pagenumber: pageclickednumber,
        pagecount: base.config.pagecount,
        rowCount: base.config.rowCount,
        buttonClickCallback: PageClick
    });
    if (base.config.json == "") {
        Pager.GetPageInfo(base.config.pagesize, pageclickednumber, base.config.url);
    } else {
        Pager.GetPageInfo(base.config.pagesize, pageclickednumber, base.config.url, base.config.json);
    }

}
Pager.SetPage = function (index, pagecount, url, rowCount) {

    $("#pager").pager({
        pagenumber: index,
        pagecount: pagecount,
        rowCount: rowCount,
        buttonClickCallback: PageClick
    });
}

/*-------操作CheckBox-----------*/
CheckBoxs.CheckAll = function (checkBox, containerId) {
    if (containerId == undefined)
        $("input[type=checkbox]").each(function () {
            this.checked = checkBox.checked;
        });
    else {
        $("#" + containerId + " input[type=checkbox]").each(function () {
            this.checked = checkBox.checked;
        });
    }
};
CheckBoxs.GetCheckedIds = function (containerId) {
    if (containerId == undefined)
        return $("input.check-box:checked").map(function () {
            return $(this).attr("rel");
        }).get();
    else
        return $("#" + containerId + " input.check-box:checked").map(function () {
            return $(this).attr("rel");
        }).get();
};
CheckBoxs.IsSelect = function (containerId) {
    if (containerId) {
        var b = false;
        $("#" + containerId + " input.check-box:checked").each(function () {
            b = true;
        });
        return b;
    }
}
CheckBoxs.CancelCheck = function (containerId) {
    if (containerId) {
        $("#" + containerId + " input:checked").each(function () {

            $(this).prop("checked", false);
        });
    }
}

/*-------执行删除-----------*/
Deletes.DeleteById = function (Id) {
    var throughBox = art.dialog.through;
    if (Id) {
        $("input[type=checkbox]").each(function () {
            if ($(this).attr("rel") == Id) {
                var Check = $(this);
                this.checked = true;
                throughBox({
                    content: '你确定删除数据',
                    lock: true,
                    icon: 'question',
                    ok: function () {
                        this.hide();
                        Deletes.DeleteAllId();
                    },
                    cancel: function () {
                        Check.prop("checked", false);
                    }
                });
            }
        })
    }
};
Deletes.DeleteAllId = function (containerId, event) {
    var throughBox = art.dialog.through;
    if (containerId == undefined) {
        var map = CheckBoxs.GetCheckedIds();
        alert(map);
    } else {
        if (!CheckBoxs.IsSelect(containerId)) {
            throughBox({
                id: 'DD',
                content: '还没有选择数据',
                lock: true,
                icon: 'warning',
                ok: true
            });
        } else {

            throughBox({
                content: '你确定删除数据',
                lock: true,
                icon: 'question',
                ok: function () {
                    this.hide();
                    var map = CheckBoxs.GetCheckedIds(containerId);
                    alert(map);
                    CheckBoxs.CancelCheck(containerId);

                },
                cancel: function () {

                    CheckBoxs.CancelCheck(containerId);

                }
            });

        }
    }
    //清理框选的背景颜色
    Index.RemoveClass("data-table tr", "pullbox-selected");
    adc.base.stopBubble(event);
}

/*插入方法*/
insert.add = function (url, json) {
    if (!json)
        return;
    var json = {
        type: "insert",
        json: json
    };
    adc.base.ajaxjson(url, json, function (data) {
        if (data.o == "ok") {
            art.dialog({
                id: 'ins',
                content: '保存成功',
                icon: 'succeed',
                lock: true,
                button: [{
                    name: '继续添加',
                    callback: function () {
                        this.hide();
                        adc.base.reset();

                    },
                    focus: true
                }, {
                    name: '返回',
                    callback: function () {
                        this.hide();
                        Index.Back('url');
                    }
                }
				]
            });
        } else {
            console.log(data.error);
        }

    }, function () {
        art.dialog.tips('请求出错请重试!', 2);
    },
		'POST',
		function () {
		    Mydialog = art.dialog({
		        title: false

		    });
		},
		function () {

		    Mydialog.hide();
		});

}

/*编辑方法*/
update.Edit = function () { }

/*键盘事件*/
keydow.DelGrid = function (obj, event) {
    var e = event || window.event
    if (CheckBoxs.IsSelect(obj) && e && e.keyCode == 46) {

        Deletes.DeleteAllId(obj);
    };

};

/*-------Load------------*/
$(function () {
    Admin.Init();
    if (Admin.IsLoginPage) {
        Login.Init();
    }
    if (Admin.IsIndexPage) {
        Index.Init();
    }
});
