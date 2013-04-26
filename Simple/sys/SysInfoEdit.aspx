<%@ Page Title="" Language="C#" MasterPageFile="~/Box.Master" CodeBehind="SysInfoEdit.aspx.cs"
    Inherits="Simple.sys.SysInfoEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        Index.SetTitle("用户编辑");
        var v = "";
        var url = "../Handle/SysInfoHandle.ashx";
        $(function () {
          
            v = $("#edit-info").validate({ //valtate表单验证
                //出错时添加的标签
                errorElement: "span",
                success: function (label) {
                    label.text("").addClass("success");
                },
                rules: {
                    AdcAge: {
                        required: true,
                        AdcAge: true

                    }
                }

            });
            jQuery.validator.addMethod("AdcAge", function (value, element) {
                var length = value.length;
                var mobile = /^(((13[0-9]{1})|(15[0-9]{1}))+\d{8})$/
                return this.optional(element) || (length <=3 && adc.base.IsIntPositive(value));
            }, "年龄错误");
        });

        var SubmitForm = function () {

            if (v.form()) {
                add();
            }
          
        }

        var add = function () {
            var json = $("#edit-info").serializeArray();
            json = adc.base.FormatSerializeJSON(json);
            insert.add(url, json);

        }

    </script>
    <div class="container">
        <div class="location">
            当前位置：系统管理 -&gt; 用户编辑</div>
        <div class="blank10">
        </div>
        <div class="blank10">
        </div>
        <div class="block">
            <div class="h">
                <span class="icon-sprite icon-list"></span>
                <h3>
                    用户编辑</h3>
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
                    <form id="edit-info" action="#">
                    <table class="data-table" id="data-table" width="100%" border="0" cellspacing="0"
                        cellpadding="5">
                        <tr>
                            <td class="txt80 c black">
                                用户:
                            </td>
                            <td class="txt400 l">
                            
                                <input name="AdcName" class="input-normal txt input required" />
                            </td>
                            <td class="txt80 c black">
                                年龄:
                            </td>
                            <td class=" l">
                                <input name="AdcAge"   class="input-normal" />
                            </td>
                        </tr>
                        <tr>
                            <td class="txt80 c black">
                                性别:
                            </td>
                            <td class="l">
                                <select name="AdcSex" class="required">
                                    <option value="">==请选择==</option>
                                    <option value="男">男</option>
                                    <option value="女">女</option>
                                </select>
                            </td>
                            <td class="txt80 c black">
                                状态:
                            </td>
                            <td class=" l">
                                <select name="AdcStatus" class="required">
                                    <option value="">==请选择==</option>
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                </select>
                            </td>
                        </tr>
                    </table>
                    </form>
                    <div class="btn-sub">
                        <a class="btn-lit" href="javascript:SubmitForm();"><span>确定</span></a>&nbsp;&nbsp;
                        <a class="btn-lit" href="javascript:Index.Back('url');"><span>返回</span></a></div>
                </div>
                <div id="alert" class="alert" style="display: none">
                    <i class="icon-info-sign"></i>没有找到任何数据
                </div>
               
            </div>
        </div>
    </div>
</asp:Content>
