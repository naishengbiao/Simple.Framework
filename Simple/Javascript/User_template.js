/*数据显示表格*/


var SysInfo = template("<tr>" + 
                           "<td class='chk'><input value='true' type='checkbox' rel='<%=id%>' name='CheckBox' class='check-box' /><input value='false' type='hidden' name='CheckBox' /></td>"+
                           " <td class='txt c'><a href='#' title='查看资料'><%=name%></a></td>"+
                            "<td class='txt160 c'><%=name%></td>" +
                            "<td class='txt40 c'><%=sex%></td>" +
                            "<td class='txt80 c'>&nbsp;</td>" +
                            "<td class='txt80 c'>&nbsp;</td>"+
                            "<td class='txt80 c'>测试用户&nbsp;</td>"+
                            "<td class='txt80 c'>正常</td>"+
                            "<td class='icon'><a class='opt' title='编辑' href=javascript:Index.Open('sys/SysInfoEdit.aspx?id=<%=id%>');><span class='icon-sprite icon-edit'></span></a></td>" +
                            "<td class='icon tail'><a class='opt' title='删除' href='javascript:void(0)' onclick='Deletes.DeleteById(<%=id%>)'><span class='icon-sprite icon-delete'></span></a></td>"+
                        "</tr>")
 

   

/*数据显示表格*/