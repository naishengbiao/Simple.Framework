<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Simple.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Simple.Framework框架</title>
    <link href="css/admin.global.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.index.css" rel="stylesheet" type="text/css" />
    <link href="artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Javascript/jquery-1.6.min.js"></script>
    <script type="text/javascript" src="artDialog4.1.6/jquery.artDialog.source.js"></script>
    <script type="text/javascript" src="artDialog4.1.6/plugins/iframeTools.js"></script>
    <script type="text/javascript" src="Javascript/json2.js"></script>
    <script type="text/javascript" src="Javascript/adc.utils.js"></script>
    <script type="text/javascript" src="Javascript/admin.js"></script>
    
    <script type="text/javascript">
    
        // 初始化下面的变量
        Admin.IsIndexPage = true;
        Admin.IndexStartPage = 'Main_index.aspx';
        Admin.LogoutUrl = 'Login.aspx';
    </script>
</head>
<body>
    <div id="header">
        <div id="header-logo">
            <img src="images/logo.gif" alt="logo" width="59" height="64" border="0" /></div>
        <div id="header-title">
            Simple.Framework框架</div>
        <div id="header-info">
            <span style="margin-right: 50px; color: #fff;">管理员：<b>net_nai</b> 您好，欢迎登陆使用！</span>
            <span style="margin-right: 50px; color: #fff;">当前版本：1.0</span> <a href="javascript:Index.Open('Main_index.aspx');"
                style="margin-right: 10px; color: #fff; font-weight: bold;">后台首页</a> <a href="javascript:Index.Open('welcome.html');"
                    style="margin-right: 10px; color: #fff; font-weight: bold;">修改密码</a> <a href="javascript:Admin.Logout();">
                        <img src="images/out.gif" class="middle" alt="安全退出" width="46" height="20" border="0" /></a>
        </div>
    </div>
    <!--//#header-->
    <div id="main">
        <div id="left">
            <div id="menu-container">
                <div class="menu-tit">
                    系统管理</div>
                <div class="menu-list">
                    <div class="top-line">
                    </div>
                    <ul class="nav-items">
                        <li><a href="sys/SysInfo.aspx" target="content">基础操作</a></li>
                        <li><a href="uploader/uploadimg_1.aspx" target="content">图片上传</a></li>
                        <li><a href="http://www.baidu.com" target="content">图片上传</a></li>
                        <li><a href="http://www.baidu.com" target="content">百度两下</a></li>
                        <li><a href="http://www.google.hk" target="_blank">谷歌两下</a></li>
                        <li><a href="http://www.kudystudio.com" target="_blank">本岛两下</a></li>
                    </ul>
                </div>
                <div class="menu-tit">
                    栏目管理</div>
                <div class="menu-list hide">
                    <div class="top-line">
                    </div>
                    <ul class="nav-items">
                        <li><a href="http://www.kudystudio.com" target="content">XX管理</a></li>
                        <li><a href="http://www.kudystudio.com" target="content">XX管理</a></li>
                        <li><a href="http://www.kudystudio.com" target="content">XX管理</a></li>
                        <li><a href="http://www.kudystudio.com" target="content">XX管理</a></li>
                        <li><a href="http://www.kudystudio.com" target="content">XX管理</a></li>
                        <li><a href="http://www.kudystudio.com" target="content">XX管理</a></li>
                    </ul>
                </div>
                <div class="menu-tit">
                    内容管理</div>
                <div class="menu-list hide">
                    <div class="top-line">
                    </div>
                    <ul class="nav-items">
                        <li><a href="http://www.kudystudio.com" target="content">XX管理</a></li>
                        <li><a href="http://www.kudystudio.com" target="content">XX管理</a></li>
                        <li><a href="http://www.kudystudio.com" target="content">XX管理</a></li>
                        <li><a href="http://www.kudystudio.com" target="content">XX管理</a></li>
                        <li><a href="http://www.kudystudio.com" target="content">XX管理</a></li>
                        <li><a href="http://www.kudystudio.com" target="content">XX管理</a></li>
                    </ul>
                </div>
            </div>
            <div id="menu-bottom">
            </div>
        </div>
        <!--//#left-->
        <div id="right">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="index-table-top-left">
                    </td>
                    <td class="index-table-top-center">
                        <div class="index-table-welcome-left">
                        </div>
                        <div class="index-table-welcome-center" id="index-title">
                            欢迎登录</div>
                        <div class="index-table-welcome-right">
                        </div>
                        <div class="clear">
                        </div>
                    </td>
                    <td class="index-table-top-right">
                    </td>
                </tr>
                <tr>
                    <td class="index-table-middle-left">
                    </td>
                    <td class="index-table-middle-center" valign="top" id="content-container">
                        <div id="loading">
                            <img src="images/loading.gif" alt="loading" border="0" /></div>
                        <script type="text/javascript">
                            Index.OutputIframe();
                        </script>
                    </td>
                    <td class="index-table-middle-right">
                    </td>
                </tr>
                <tr>
                    <td class="index-table-bottom-left">
                    </td>
                    <td class="index-table-bottom-center">
                    </td>
                    <td class="index-table-bottom-right">
                    </td>
                </tr>
            </table>
        </div>
        <!--//#right-->
        <div class="clear">
        </div>
    </div>
    <!--//#main-->
    <div id="footer">
        <div id="footer-msg">
            建议使用 IE8 以上版本或其它主流浏览器，分辨率 1024x768 或更高。 | Copyright &copy; 2005-2012 www.cnblogs.com/net-nai/
            All Rights Reserved.</div>
        <%--  <div id="footer-lang">
            <select style="height: 19px; line-height: 19px; margin-top: 3px;">
                <option value="zh-cn" selected="selected">简体中文</option>
                <option value="zh-tw">繁體中文</option>
                <option value="en-us">English</option>
            </select></div>--%>
    </div>
    <!--//#footer-->
</body>
</html>
