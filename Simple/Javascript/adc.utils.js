///<reference path="jquery-1.6.min.js">
/*
*名称：工具包
*
*/

var adc = adc || {};
/*
** 基类方法
*/
adc.base = (function () {
    return {
        IsIE: $.browser.msie != undefined,
        IsIE6: $.browser.msie && parseInt($.browser.version) === 6,
        StringToDate: function (obj) {
            ///	<summary>
            ///		将字符转换为Date类型
            ///	</summary>
            ///	<returns type="Date" />
            ///	<param name="obj" type="String">
            ///		需转换的字符。
            ///	</param>
            if (!obj)
                return null;
            obj = obj.replace(/-/g, " ").replace(/:/g, " ");
            obj = obj.split(" ");
            return new Date(obj[0], obj[1] - 1, obj[2], obj[3], obj[4], obj[5]);

        },
        GetJSON: function (obj) {
            ///	<summary>
            ///		将字符转串换为JSON对象
            ///	</summary>
            ///	<returns type="Object" />
            ///	<param name="obj" type="String">
            ///		需转换的字符串。
            ///	</param>
            if (!obj)
                return null;
            var JSON = $.parseJSON(obj);
            return JSON;

        },
        IsContinuousChar: function (obj) {
            ///	<summary>
            ///		验证字符串是否连续如：“ABCDEFG“-”123456“
            ///	</summary>
            ///	<returns type="bool" />
            ///	<param name="obj" type="String">
            ///		需验证的字符串。
            ///	</param>
            if (!obj)
                return null;
            var str = obj.toLowerCase();
            var flag = 0;
            for (var i = 0; i < str.length; i++) {
                if (str.charCodeAt(i) != flag + 1 && flag != 0)
                    return false;
                else
                    flag = str.charCodeAt(i);
            }
            return true;

        },
        IsSameChar: function (obj) {
            ///	<summary>
            ///		验证字符串是否重复如：“AAAAAAAA”
            ///	</summary>
            ///	<returns type="bool" />
            ///	<param name="obj" type="String">
            ///		需验证的字符串。
            ///	</param>
            if (!obj)
                return null;
            var str = obj.toLowerCase();
            var flag = 0;
            for (var i = 0; i < str.length; i++) {
                if (str.charCodeAt(i) != flag && flag != 0)
                    return false;
                else
                    flag = str.charCodeAt(i);
            }
            return true;

        },
        IsInt: function (str) {
            ///	<summary>
            ///		验证对象是否int类型
            ///	</summary>
            ///	<returns type="bool" />
            ///	<param name="str" type="object">
            ///		需验证的对象。
            ///	</param>
            return /^-?\d+$/.test(str);
        },
        IsFloat: function (str) {
            ///	<summary>
            ///		验证对象是否单精度数
            ///	</summary>
            ///	<returns type="bool" />
            ///	<param name="str" type="object">
            ///		需验证的对象。
            ///	</param>
            return /^(-?\d+)(\.\d+)?$/.test(str);
        },
        IsIntPositive: function (str) {
            ///	<summary>
            ///		验证对象是正整数
            ///	</summary>
            ///	<returns type="bool" />
            ///	<param name="str" type="object">
            ///		需验证的对象。
            ///	</param>
            return /^[0-9]*[1-9][0-9]*$/.test(str);
        },
        IsFloatPositive: function (str) {
            ///	<summary>
            ///		验证对象是否单精度正整数
            ///	</summary>
            ///	<returns type="bool" />
            ///	<param name="str" type="object">
            ///		需验证的对象。
            ///	</param>
            return /^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test(str);
        },
        IsLetter: function (str) {
            ///	<summary>
            ///		验证对象是否英文字母
            ///	</summary>
            ///	<returns type="bool" />
            ///	<param name="str" type="object">
            ///		需验证的对象。
            ///	</param>
            return /^[A-Za-z]+$/.test(str);
        },
        IsChinese: function (str) {
            ///	<summary>
            ///		验证对象是否中文
            ///	</summary>
            ///	<returns type="bool" />
            ///	<param name="str" type="object">
            ///		需验证的对象。
            ///	</param>
            return /^[\u0391-\uFFE5]+$/.test(str);
        },
        IsZipCode: function (str) {
            ///	<summary>
            ///		验证对象是否是邮编(中国)
            ///	</summary>
            ///	<returns type="bool" />
            ///	<param name="str" type="object">
            ///		需验证的对象。
            ///	</param>
            return /^[1-9]\d{5}$/.test(str);
        },
        IsEmail: function (str) {
            ///	<summary>
            ///		验证对象EMAIL格式是否正确
            ///	</summary>
            ///	<returns type="bool" />
            ///	<param name="str" type="object">
            ///		需验证的对象。
            ///	</param>
            return /^[A-Z_a-z0-9-\.]+@([A-Z_a-z0-9-]+\.)+[a-z0-9A-Z]{2,4}$/.test(str);
        },
        IsMobile: function (str) {
            ///	<summary>
            ///		验证对象是否手机号码(中国)
            ///	</summary>
            ///	<returns type="bool" />
            ///	<param name="str" type="object">
            ///		需验证的对象。
            ///	</param>
            return /^((\(\d{2,3}\))|(\d{3}\-))?((1[35]\d{9})|(18[89]\d{8}))$/.test(str);
        },
        IsUrl: function (str) {
            ///	<summary>
            ///		验证对象是否正确URL
            ///	</summary>
            ///	<returns type="bool" />
            ///	<param name="str" type="object">
            ///		需验证的对象。
            ///	</param>
            return /^(http:|ftp:)\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"])*$/.test(str);
        },
        IsIpAddress: function (str) {
            ///	<summary>
            ///		验证对象是否正确IP地址
            ///	</summary>
            ///	<returns type="bool" />
            ///	<param name="str" type="object">
            ///		需验证的对象。
            ///	</param>
            return /^(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5])$/.test(str);
        },
        Encode: function (str) {
            ///	<summary>
            ///		将字符参数编码
            ///	</summary>
            ///	<returns type="String" />
            ///	<param name="str" type="object">
            ///		需编码的对象。
            ///	</param>
            return encodeURIComponent(str);
        },
        Decode: function (str) {
            ///	<summary>
            ///		将字符参数解码
            ///	</summary>
            ///	<returns type="String" />
            ///	<param name="str" type="object">
            ///		需解码编码的对象。
            ///	</param>
            return decodeURIComponent(str);
        },
        FormatString: function () {
            ///	<summary>
            ///		将字符串格式化
            ///     adc.base.FormatString("你好{0}","吗")
            ///	</summary>
            ///	<returns type="String" />
            ///		 格式对象字符
            ///	</param>
            if (arguments.length == 0)
                return '';
            if (arguments.length == 1)
                return arguments[0];
            var args = this.CloneArray(arguments);
            args.splice(0, 1);
            return arguments[0].replace(/{(\d+)?}/g, function ($0, $1) {
                return args[parseInt($1)];
            });
        },
        CloneArray: function (arr) {
            ///	<summary>
            ///		克隆数组
            ///	</summary>
            ///	<returns type="new Array()" />
            ///	<param name="arr" type="Array">
            ///		返回一个和对象一样结构的数组。
            ///	</param>
            var cloned = [];
            for (var i = 0, j = arr.length; i < j; i++) {
                cloned[i] = arr[i];
            }
            return cloned;
        },
        isArray: function (obj) {
            ///	<summary>
            ///		检测对象是否数组对象
            ///	</summary>
            ///	<returns type="bool" />
            ///	<param name="obj" type="object">
            ///		需检测对象。
            ///	</param>
            if (obj && Object.prototype.toString.call(obj) === '[object Array]') {
                return Object.prototype.toString.call(obj) === '[object Array]';
            }
            return false;

        },
        ajaxjson: function (url, data, success, error, method, beforeSend, complete) {
            ///	<summary>
            ///		ajax方法
            ///	</summary>
            ///	<returns type="function" />
            ///	<param name="url" type="String">
            ///		url
            ///	</param>
            ///	<param name="data" type="object">
            ///		即将发送到服务器的数据
            ///	</param>
            ///	<param name="success" type="function">
            ///		回调函数
            ///	</param>
            ///	<param name="error" type="function">
            ///		失败函数
            ///	</param>
            ///	<param name="method" type="String">
            ///		请求方式POST GET
            ///	</param>
            ///	<param name="beforeSend" type="function">
            ///		请求前函数
            ///	</param>
            ///	<param name="complete" type="function">
            ///		请求完成函数
            ///	</param>
            var op = {
                type: method,

                url: url,
                data: data,
                cache: false,
                dataType: 'json',
                beforeSend: beforeSend,
                success: function (data, textStatus) {
                    if (data == null || data == undefined) {

                        if (typeof error == 'function')

                            error();

                    } else {

                        if (typeof error == 'function')

                            success(data, textStatus);

                    }

                },
                complete: complete,
                error: error

            };

            $.ajax(op);

        },
        GetRootPath: function (o) {
            ///	<summary>
            ///		获取网站虚拟路径
            ///	</summary>
            ///	<returns type="String" />
            ///	<param name="o" type="object">
            ///		跟路径名称。
            ///	</param>
            if (o == undefined) {
                var pathName = window.location.pathname.substring(1);
                var webName = pathName == '' ? '' : pathName.substring(0, pathName.indexOf('/'));
                //return window.location.protocol + '//' + window.location.host + '/'+ webName + '/';
                return '/' + webName + '/';
            } else {
                var pathName = window.location.pathname.substring(1);
                var webName = pathName == '' ? '' : pathName.substring(0, pathName.indexOf('/'));
                //return window.location.protocol + '//' + window.location.host + '/'+ webName + '/';
                return webName == o ? "" : '/' + webName + '/';
            }
        },
        GetUrl: function (obj) {
            ///	<summary>
            ///		获取不带参数的url
            ///	</summary>
            ///	<returns type="String" />
            ///	<param name="obj" type="object">
            ///		url。
            ///	</param>
            if (!obj)
                return "";
            var arr = obj;
            if (obj.indexOf('?') > -1)
                return arr = arr.split('?')[0];

            return arr;
        },
        GetParamUrl: function (name) {
            ///	<summary>
            ///		获取URL参数
            ///	</summary>
            ///	<returns type="String" />
            ///	<param name="name" type="object">
            ///		参数名称。
            ///	</param>
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null)
                return unescape(r[2]);
            return null;
        },
        FormatSerializeJSON: function (obj) {
            ///	<summary>
            ///		格式化Jquery serializeArray()方法序列化表单的JSON
            ///     格式前：{"name":"sex","value":"男"},{"name":"age","value":"12"}
            ///     格式后: {"sex":"男","age":"12"}
            ///	</summary>
            ///	<returns type="String" />
            ///	<param name="obj" type="object">
            ///		JSON对象
            ///	</param>
            var Result = "";
            if (obj && adc.base.isArray(obj) && obj.length > 0) {
                Result = "{";
                for (var i = 0, len = obj.length; i < len; i++) {
                    Result += adc.base.FormatString('"{0}":"{1}",', obj[i].name, obj[i].value);
                }
                Result = Result.substr(0, Result.length - 1) + "}";
            }
            return Result;
        },
        reset: function () {
            ///	<summary>
            ///		清空表单
            ///	</summary>
            ///	<returns type="void" />
            $(':input', 'form')
			.not(':button, :submit, :reset, :hidden')
			.val('')
			.removeAttr('checked')
			.removeAttr('selected');
        },
        stopBubble: function (e) {
            //如果提供了事件对象，则这是一个非IE浏览器
            if (e && e.stopPropagation)
            //因此它支持W3C的stopPropagation()方法
                e.stopPropagation();
            else
            //否则，我们需要使用IE的方式来取消事件冒泡
                window.event.cancelBubble = true;
        }

    };

})();

/*
**时间操作
*/
adc.DateUtil = (function (base) {
    return {
        Interval: function (Userdate) {
            ///	<summary>
            ///		返回时间间隔值，某天前-某时前-某秒前
            ///	</summary>
            ///	<returns type="String" />
            ///	<param name="Userdate" type="object">
            ///		用户时间对象。
            ///	</param>
            var Result = "";
            var Between = parseInt((base.StringToDate(this.GetSysdate("yyyy-MM-dd HH:mm:ss")).getTime() - base.StringToDate(Userdate).getTime()) / 1000);

            if (Between < 0)
                return Result = "未知";
            if (Between >= 24 * 60 * 60 * 30) {
                Result = parseInt(Between / (60 * 60 * 24 * 30)) + "个月";
            } else
                if (Between >= 60 * 60 * 24) {
                    Result = parseInt(Between / (60 * 60 * 24)) + "天";
                } else if (Between >= 60 * 60) {
                    Result = parseInt(Between / (60 * 60)) + "小时";
                } else if (Between >= 60) {
                    Result = parseInt(Between / 60) + "分钟";
                } else {
                    Result = Between + "秒";
                }
            return Result += "前";
        },
        GetSysdate: function () {
            ///	<summary>
            ///		获取系统时间
            ///	</summary>
            ///	<returns type="String" />
            if (arguments[0].constructor == String && arguments[0] === "yyyy-MM-dd HH:mm:ss") {
                return new Date().getFullYear() + "-" + (new Date().getMonth() + 1) + "-" + new Date().getDate() + " " + new Date().toLocaleTimeString();
            } else if (arguments[0].constructor == String && arguments[0] === "yyyy-MM-dd") {
                return new Date().getFullYear() + "-" + (new Date().getMonth() + 1) + "-" + new Date().getDate();
            } else if (arguments[0].constructor == String && arguments[0] === "HH:mm:ss") {
                return new Date().toLocaleTimeString()
            } else {
                return null;
            }
        }

    };

})(adc.base);
