<%@ Page Title="" Language="C#" MasterPageFile="~/Box.Master" CodeBehind="SysInfo.aspx.cs"
    Inherits="Simple.sys.SysInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        Index.SetTitle("用户列表");
        $(function () {
            var temp = "";
            var url = "../Handle/SysInfoHandle.ashx";
            $(document).ready(function () {

                Pager.GetPageInfo(base.config.pagesize, base.config.pageindex, url);
                ShowPageInfo = function (data) {
                    temp = "";
                    if (data == "") $("#alert").show();
                    else
                        $("#alert").hide();
                    $.each(data, function (i, n) {

                        temp += SysInfo({
                            'name': n.AdcName,
                            'sex': n.AdcSex,
                            'id': n.Aid

                        });
                    })

                    $("#data-table tr:gt(0)").remove();
                    $("#data-table").append(temp);
                    $("#box").PullBox({ dv: $("#box"), obj: $("#data-table tr") });

                };

                //搜索
                $("#Search").click(function () {
                    var json = $("#serform").serializeArray();
                    json = adc.base.FormatSerializeJSON(json);
                    Pager.GetPageInfo(base.config.pagesize, base.config.pageindex, url, json);

                })
            });

        });


        
    </script>
    <div class="container" id="box">
        <div class="location">
            当前位置：系统管理 -&gt; 用户列表</div>
        <div class="blank10">
        </div>
        <div class="search block">
            <div class="h">
                <span class="icon-sprite icon-magnifier"></span>
                <h3>
                    快速搜索</h3>
            </div>
            <div class="tl corner">
            </div>
            <div class="tr corner">
            </div>
            <div class="bl corner">
            </div>
            <div class="br corner">
            </div>
            <div class="cnt-wp">
                <div class="cnt">
                    <form id="serform" action="#">
                    <div class="search-bar">
                        <label class="first txt-green">
                            用户名：</label>
                        <input value="" type="text" name="AdcName" id="AdcName" class="input-small" />
                        <label class="txt-green">
                            性别：</label>
                        <select name="AdcSex" id="AdcSex">
                            <option value="">不限</option>
                            <option value="男">男</option>
                            <option value="女">女</option>
                        </select>
                        <label>
                            <a class="btn-lit btn-middle" id="Search" href="javascript:void(0)"><span>搜索</span></a></label>
                    </div>
                    </form>
                </div>
            </div>
        </div>
        <div class="blank10">
        </div>
        <div class="block" id="select-box">
            <div class="h">
                <span class="icon-sprite icon-list"></span>
                <h3>
                    用户列表</h3>
                <div class="bar">
                    <a class="btn-lit" href="javascript:Index.Open('sys/SysInfoEdit.aspx');"><span>新增</span></a>
                    <a class="btn-lit" href="javascript:void(0);" onclick="Deletes.DeleteAllId('data-table')">
                        <span>删除选中</span></a>
                </div>
            </div>
            <div class="tl corner">
            </div>
            <div class="tr corner">
            </div>
            <div class="bl corner">
            </div>
            <div class="br corner">
            </div>
            <div class="cnt-wp">
                <div class="cnt">
                    <table class="data-table" id="data-table" width="100%" border="0" cellspacing="0"
                        cellpadding="0">
                        <tr>
                            <th scope="col">
                                <input value="true" type="checkbox" title="全选/不选" onclick="CheckBoxs.CheckAll(this);"
                                    name="CheckAll" id="CheckAll" /><input value="false" type="hidden" name="CheckAll" />
                            </th>
                            <th scope="col">
                                用户
                            </th>
                            <th scope="col">
                                姓名
                            </th>
                            <th scope="col">
                                性别
                            </th>
                            <th scope="col">
                                邮箱
                            </th>
                            <th scope="col">
                                手机
                            </th>
                            <th scope="col">
                                备注信息
                            </th>
                            <th scope="col">
                                状态
                            </th>
                            <th scope="col">
                                编辑
                            </th>
                            <th scope="col">
                                删除
                            </th>
                        </tr>
                    </table>
                </div>
                <div id="alert" class="alert" style="display: none">
                    <i class="icon-info-sign"></i>没有找到任何数据
                </div>
                <div id="pager">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
