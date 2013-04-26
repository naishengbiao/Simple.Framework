<%@ Page Title="" Language="C#" MasterPageFile="~/Box.Master" AutoEventWireup="true"
    CodeBehind="uploadimg_1.aspx.cs" Inherits="Simple.uploader.uploadimg_1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Javascript/fineuploader-3.4.1.js"></script>
    <script>
        $(function () {

            $fub = $('#fine-uploader-basic');
            $messages = $('#messages');

            var uploader = new qq.FineUploaderBasic({
                button: $fub[0],
                request: {
                    endpoint: '../Handle/uploader.ashx?type=up'
                },
                validation: {
                    allowedExtensions: ['jpeg', 'jpg', 'gif', 'png'],
                    sizeLimit: 10480000
                    

                },
                callbacks: {
                    onSubmit: function (id, fileName) {
                        var itemlength = $messages.find(".imgbox").length;
                        if (itemlength > 5) return false;
                        $messages.append('<div class="imgbox"><div id="file-' + id + '" class="show-imgbox"></div></div>');
                        $(".err").hide();
                    },
                    onUpload: function (id, fileName) {

                        $('#file-' + id).html('<span class="item-box item-loading">上传中...</span> ');
                    },
                    onComplete: function (id, fileName, responseJSON) {
                        if (responseJSON.success) {
                            $('#file-' + id).html('<a class="item-close" href="javascript:void(0)"></a><span class="item-box">' +
                            '<img src="' + responseJSON.src + '" width="80" height="60" alt="' + responseJSON.abs + '"></span>');
                        } else {
                            $(".err").show().html(responseJSON.mes);

                        }
                    }, onError: function (id, name, reason, maybeXhr) {

                        if (maybeXhr == undefined) {
                            $(".err").show().html(reason);
                        }


                    }



                }

            });


            $(".item-close").live("click", function () {

                var $his = $(this);

                $.ajax({
                    type: 'get',
                    url: '../Handle/uploader.ashx?type=' + $(this).siblings().find("img").attr("alt"),
                    cache: false,
                    dataType: 'json',
                    success: function (data, textStatus) {

                        if (data.success) {

                            $his.parent().parent().remove();
                           
                        }

                    }

                })
            });
        })
        
    </script>
    <div class="container">
        <input type="hidden" id="ss" />
        <div class="location">
            当前位置：系统管理 -&gt; 图片上传-样式1</div>
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
                <div class="cnt" style="height: 300px">
                    <div id="fine-uploader-basic" class="bts btn-success">
                        <div>
                            点击上传</div>
                    </div>
                    <div class="err">
                    </div>
                    <div id="messages" class="mess">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
