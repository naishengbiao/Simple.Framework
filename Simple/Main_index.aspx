<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_index.aspx.cs" Inherits="Simple.Main_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Simple.Framework框架后台</title>
    <link href="css/tabsmain.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.global.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.content.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Javascript/jquery-1.6.min.js"></script>
    <script type="text/javascript" src="Javascript/adc.utils.js"></script>
    <script type="text/javascript" src="Javascript/adc.extend.js"></script>
    <script type="text/javascript" src="Javascript/admin.js"></script>
    <script type="text/javascript">

        Index.SetTitle('后台首页');
        $(function () {
            $("#usual1 ul").idTabs();
        })
       
    </script>
</head>
<body>
    <div class="container">
        <div class="location">
            当前位置：后台首页</div>
        <table class="hide" width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="62" height="55" valign="middle">
                    <img src="Images/title.gif" width="54" height="55" alt="" />
                </td>
                <td valign="top" style="line-height: 20px;">
                    为了账号的安全，如果下面的登录情况不正常，建议您马上<a href="" class="txt-blue">修改密码</a>。
                </td>
            </tr>
        </table>
        <div class="blank10">
        </div>
        <div class="box">
            <div class="box-title txt-blue-b">
                您的角色</div>
            <div class="box-content">
                <i>高级管理员</i>
            </div>
        </div>
        <div class="blank10">
        </div>
        <div id="usual1" class="usual">
            <ul>
                <li><a href="#tab1" class="selected">登录情况</a></li>
                <li><a href="#tab2">修改密码</a></li>
                <li><a href="#tab3">全局设置</a></li>
            </ul>
            <div id="tab1" style="display: block;">
              
                    <i>登录总数：</i>13 次<br />
                    <i>本次登录IP：</i>127.0.0.1<br />
                    <i>本次登录时间：</i>2012/6/19 9:58:33<br />
                    <i>上次登录IP：</i>127.0.0.1<br />
                    <i>上次登录时间：</i>2012/6/18 19:40:16
               
            </div>
            <div id="tab2" style="display: none;">
                More content in tab 2.</div>
            <div id="tab3" style="display: none;">
                Tab 3 is always last!</div>
        </div>
        <div class="blank10">
        </div>
        <img src="Images/ts.gif" style="margin-bottom: -2px;" width="16" height="16" alt="tip" />
        提示：为了账号的安全，如果上面的登录情况不正常，建议您马上<a href="#">修改密码</a>。
        <div class="blank10">
        </div>
        <div class="line">
        </div>
        <div class="blank10">
        </div>
        <img src="Images/icon-mail.gif" style="margin-bottom: -1px;" width="16" height="11"
            alt="mail" />
        联系：kudychen@gmail.com<br />
        <img src="Images/icon-phone.gif" style="margin-bottom: -2px;" width="17" height="14"
            alt="phone" />
        网站：<a href="http://www.kudystudio.com" target="_blank">http://www.kudystudio.com</a>
    </div>
</body>
</html>
