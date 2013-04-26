$(function() {
    $("#FileUpload").bind("change", function() {
        //开始提交
        $("#form1").ajaxSubmit({
            beforeSubmit: function(formData, jqForm, options) {
                //隐藏上传按钮
                $(".upfiles").hide();
                //显示LOADING图片
                $("#idProcess").show();
            },
            success: showResponse,
            error: function(data, status, e) {
                alert("上传失败，错误信息：" + e);
                $(".upfiles").show();
                $("#idProcess").hide();
            },
            url: "../../Tools/MultipleUpload.ashx",
            type: "post",
            dataType: "json",
            timeout: 60000
        });
    });

    //取第一张图片载入预览图
    var loadBoxUrl = $(".imgItems ul img").eq(0).attr("src");
    if (loadBoxUrl != null) {
        ChangePreview(loadBoxUrl);
    }
});

//上传图片成功的处理类
function showResponse(data, textStatus) {
    if (data.msg == 1) {
        var str = "<li><img src=\"" + data.msbox + "\" onmouseover=\"ChangePreview('" + data.msbox + "');\" /><a onclick=\"dlstItems_Command(this,'" + data.msgid + "','" + data.msbox + "');\">删除</a><input name=\"hideFiles\" type=\"hidden\" value=\"" + data.msbox + "\"></li>";
        $(".imgItems ul").append(str);
        ChangePreview(data.msbox);
    } else {
        alert(data.msbox);
    }
    $(".upfiles").show();
    $("#idProcess").hide();
}

//删除图片及删除数据库处理方法
function dlstItems_Command(obj, fileid, imgurl) {
    var node = $(obj).parent(); //要删除的LI节点
    //var iNum = $(".imgItems ul li").index(node); //所在集合的索引

    //开始提交删除
    $.ajax({
        type: "post",
        url: "../../Tools/DeleteAlbumFile.ashx",
        data: {
            fileid: function() {
                return fileid;
            },
            delfile: function() {
                return imgurl;
            }
        },
        dataType: "json",
        success: function(data, textStatus) {
            if (data.msg == 0) {
                alert(data.msbox);
            }
        },
        error: function(data, status, e) {
            alert("删除文件失败:" + e);
        }
    });

    //删除该无素父节点
    node.remove();
    //预览图指向第一张图片
    var firstImgurl = $(".imgItems ul li img").eq(0).attr("src");
    if (firstImgurl == null) {
        $(".imgbox").empty();
        $(".imgbox").css({ background: "url(../images/noimg.gif) no-repeat center center" });
    } else {
        ChangePreview(firstImgurl);
    }
}

//光标经过图片时显示预览图
function ChangePreview(imgurl) {
    $(".imgbox").empty();
    $(".imgbox").css({ background: "none" });
    $(".imgbox").append("<img src=\"" + imgurl + "\" />");
}