var styleTree = "../Scripts/dhtmlxSuite/skins/skyblue/imgs/dhxtree_skyblue/";
var styleToolbar = "../Scripts/dhtmlxSuite/skins/skyblue/imgs/";
var myWindows = new dhtmlXWindows(); //------Cửa sổ chính của trang
var myTree;
var myForm;
//-----Tải dữ liệu cho trang
function doLoadPage() {
    myWindows.createWindow(idForm, 0, 0, 100, 100);
    myWindows.window(idForm).setText(titleForm);
    myWindows.window(idForm).button("help").show();
    myWindows.window(idForm).button("park").hide();
    myWindows.window(idForm).button("minmax").hide();
    myWindows.window(idForm).setModal(true);
    myWindows.window(idForm).maximize();
    myWindows.window(idForm).button("help").attachEvent("onClick", function (win, button) {
        doLoadHelp(title_help + " " + titleForm);
    });
}
//------Hiển thị trang trợ giúp
function doLoadHelp(title) {
    var _id_windows = "Help";
    var w = Number(390);
    var h = Number(340);
    var x = Number(0);
    var y = Number(0);
    var myWindowsHelp = new dhtmlXWindows();
    myWindowsHelp.createWindow(_id_windows, x, y, w, h);
    myWindowsHelp.window(_id_windows).setText(title);
    myWindowsHelp.window(_id_windows).centerOnScreen();
    myWindowsHelp.window(_id_windows).attachURL(helpForm);
}
//------Hiển thị thông báo
function doLoadMessage(type,message) {
    dhtmlx.message({
        type: type,
        text: message,
        expire: 5000
    });
}
//------Hiển thị thông báo cần xác nhận
function doLoadConfirm(type, message,title) {
    dhtmlx.confirm({
        title: title,
        type: type,
        text: message,
        callback: function (result) { return result; }
    });
}
//------Tải dữ liệu cho Tree
function doLoadTree() {
    $.ajax({
        type: 'GET',
        url: apiListData,
        dataType: 'xml',
        contentType: 'text/plain; charset=utf-8',
        success: function (xmlTree) {
            myTree.destructor()
            myTree = myWindows.window(idForm).attachTree();
            myTree.setImagePath(styleTree);
            myTree.parse(xmlTree, "xml");
            myTree.openAllItems("0");
            myTree.attachEvent("onClick", function (id) {
                doClickTree(id);
            });
        },
        error: function (error) {
            doLoadMessage("error",error);
        }
    });
}
//------Tải dữ liệu cho Toolbar
function doLoadToolbar(toolbar,idForm,idAction) {
    toolbar.clearAll();
    $.ajax({
        type: 'GET',
        url: '../Common/Toolbar?idForm=' + idForm + '&idAction=' + idAction,
        dataType: 'xml',
        contentType: 'text/plain; charset=utf-8',
        success: function (xmlToolbar) {
            toolbar.setIconsPath(styleToolbar);
            toolbar.loadStruct(xmlToolbar);
            toolbar.attachEvent("onClick", function (id) {
                $.ajax({
                    url: '../Common/ToolbarAction?idForm=' + idForm + '&idParrentAction=' + idAction + '&idAction=' + id,
                    type: 'GET',
                    dataType: 'text',
                    success: function (result) {
                        eval(result);
                    },
                    error: function (error) {
                        doLoadMessage("error", error);
                    }
                });
            });
        },
        error: function (error) {
            doLoadMessage("error", error);
        }
    });
}
//-----Tạo một cửa sổ mới
function doLoadWindows(idNewWindows,width,height) {
    myWindows.createWindow(idNewWindows, 0, 0, width, height);
    myWindows.window(idNewWindows).setText(titleForm);
    myWindows.window(idNewWindows).button("help").hide();
    myWindows.window(idNewWindows).button("park").hide();
    myWindows.window(idNewWindows).button("minmax").hide();
    myWindows.window(idNewWindows).setModal(true);
    myWindows.window(idNewWindows).centerOnScreen();
}
//-----Tải các control của Form thêm mới
function doLoadFormAdd(url) {
    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'xml',
        contentType: 'text/plain; charset=utf-8',
        success: function (xmlTree) {
            myForm.loadStruct(xmlTree);
            myForm.forEachItem(function (name) {
                switch (myForm.getItemType(name)) {
                    case "fieldset":
                        break;
                    case "container":
                        var hdTypeControl = myForm.getItemValue("hdTypeControl_" + name);
                        var hdApiName = myForm.getItemValue("hdApiName_" + name);
                        var hdDisplayText = myForm.getItemValue("hdDisplayText_" + name);
                        var hdValueText = myForm.getItemValue("hdValueText_" + name);
                        var hdValueChild = myForm.getItemValue("hdValueChild_" + name);
                        var link = '../Common/TreeView?ApiName=' + hdApiName + '&DisplayText=' + hdDisplayText + '&ValueText=' + hdValueText + '&ValueChild=' + hdValueChild;
                        switch (hdTypeControl) {
                            case "tree":
                                $.ajax({
                                    type: 'GET',
                                    url: link,
                                    dataType: 'xml',
                                    contentType: 'text/plain; charset=utf-8',
                                    success: function (xmlTree) {
                                        var parentTree = new dhtmlXTreeObject(myForm.getContainer(name), "100%", "100%", 0);
                                        parentTree.setImagePath(styleTree);
                                        parentTree.parse(xmlTree, "xml");
                                        parentTree.openAllItems("0");
                                        parentTree.attachEvent("onClick", function (id) {
                                            myForm.setItemValue("hdValue_" + name, id);
                                        });
                                        myFormTree.set(name, parentTree);
                                    },
                                    error: function (error) {
                                        doLoadMessage("error", error);
                                    }
                                });
                                break;
                        }
                        break;
                    case "calendar":
                        var itemcalendar = document.getElementsByName(name);
                        $(itemcalendar).attr('autocomplete', 'off');
                        break;
                    default:
                        break;
                }
            });
        },
        error: function (error) {
            doLoadMessage("error", error);
        }
    });
}
//-----Tải các control cho Form chi tiết
function doLoadFormDetail(id, url) {
    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'xml',
        contentType: 'text/plain; charset=utf-8',
        success: function (xmlTree) {
            myForm.loadStruct(xmlTree);
            myForm.forEachItem(function (name) {
                switch (myForm.getItemType(name)) {
                    case "fieldset":
                        break;
                    case "container":
                        var hdTypeControl = myForm.getItemValue("hdTypeControl_" + name);
                        var hdApiName = myForm.getItemValue("hdApiName_" + name);
                        var hdDisplayText = myForm.getItemValue("hdDisplayText_" + name);
                        var hdValueText = myForm.getItemValue("hdValueText_" + name);
                        var hdValueChild = myForm.getItemValue("hdValueChild_" + name);
                        var link = '../Common/TreeView?ApiName=' + hdApiName + '&DisplayText=' + hdDisplayText + '&ValueText=' + hdValueText + '&ValueChild=' + hdValueChild;
                        switch (hdTypeControl) {
                            case "tree":
                                $.ajax({
                                    type: 'GET',
                                    url: link,
                                    dataType: 'xml',
                                    contentType: 'text/plain; charset=utf-8',
                                    success: function (xmlTree) {
                                        var parentTree = new dhtmlXTreeObject(myForm.getContainer(name), "100%", "100%", 0);
                                        parentTree.setImagePath(styleTree);
                                        parentTree.parse(xmlTree, "xml");
                                        parentTree.openAllItems("0");
                                        parentTree.attachEvent("onClick", function (id) {
                                            myForm.setItemValue("hdValue_" + name, id);
                                        });
                                        myFormTree.set(name, parentTree);
                                    },
                                    error: function (error) {
                                        doLoadMessage("error", error);
                                    }
                                });
                                break;
                        }
                        break;
                    case "calendar":
                        var itemcalendar = document.getElementsByName(name);
                        $(itemcalendar).attr('autocomplete', 'off');
                        break;
                    default:
                        break;
                }
            });
            setTimeout(function () {
                doLoadDataForm(id);
            }, 2000);
        },
        error: function (error) {
            doLoadMessage("error", error);
        }
    });
}
//-----Tải dữ liệu cho Form chi tiết
function doLoadDataForm(id) {
    var link = '../Common/DataForm?ApiName=' + apiData + '&id=' + id;
    $.ajax({
        type: 'GET',
        url: link,
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (jsonData) {
            $(jsonData).each(function (index, obj) {
                var name = obj.NameControl;
                var value = obj.ValueControl;
                var type = myForm.getItemType(name);
                switch (type) {
                    case "container":
                        var hdTypeControl = myForm.getItemValue("hdTypeControl_" + name);
                        switch (hdTypeControl) {
                            case "tree":
                                var parentTree = myFormTree.get(name);
                                var hdValueChild = myForm.getItemValue("hdValueChild_" + name);
                                if (obj.ValueControl !== "") {
                                    parentTree.focusItem(value);
                                    parentTree.selectItem(value);
                                    myForm.setItemValue("hdValue_" + name, value);
                                } else {
                                    var hdApiName = myForm.getItemValue("hdApiName_" + name);
                                    var hdDisplayText = myForm.getItemValue("hdDisplayText_" + name);
                                    var hdValueText = myForm.getItemValue("hdValueText_" + name);
                                    var link = '../Common/TreeView?ApiName=' + hdApiName + '&DisplayText=' + hdDisplayText + '&ValueText=' + hdValueText + '&ValueChild=' + hdValueChild;
                                    $.ajax({
                                        type: 'GET',
                                        url: link,
                                        dataType: 'xml',
                                        contentType: 'text/plain; charset=utf-8',
                                        success: function (xmlTree) {
                                            parentTree.destructor()
                                            parentTree = new dhtmlXTreeObject(myForm.getContainer(name), "100%", "100%", 0);
                                            parentTree.setImagePath(styleTree);
                                            parentTree.parse(xmlTree, "xml");
                                            parentTree.openAllItems("0");
                                            parentTree.attachEvent("onClick", function (id) {
                                                myForm.setItemValue("hdValue_" + name, id);
                                            });
                                            myFormTree.set(name, parentTree);
                                        },
                                        error: function (error) {
                                            doLoadMessage("error", error);
                                        }
                                    });
                                    myForm.setItemValue("hdValue_" + name, value);
                                }
                                break;
                        }
                        break;
                    case "checkbox":
                        myForm.setItemValue(name, value === "True" ? 1 : 0);
                        break;
                    default:
                        myForm.setItemValue(name, value);
                        break;
                }
            });
        },
        error: function (error) {
            doLoadMessage("error", error);
        }
    });
}
//-----Sự kiến ấn vào nút thêm mới
function doAdd(idAction) {
    doLoadWindows("new", 660, 500)
    myForm = myWindows.window("new").attachForm();
    myWindows.window("new").progressOn();
    doLoadFormAdd('../Common/Form?idForm=' + idForm + '&idAction=' + idAction);
    var myToolbar = myWindows.window("new").attachToolbar();
    doLoadToolbar(myToolbar, idForm, idAction);
    setTimeout(function () {
        var width = $("fieldset").css("width");
        width = parseInt(width.substr(0, width.length - 2)) + 40;
        myWindows.window("new").setDimension(width);
        myWindows.window("new").progressOff();
    }, 1000);
}
//-----Sự kiện ấn vào nút xem chi tiết
function doDetail(idAction) {
    var id = myTree.getSelected();
    if (id === "") {
        return dhtmlx.alert({
            title: title_detail,
            type: "alert",
            text: message_detail
        });
    }
    doLoadWindows("edit", 660, 500)
    myForm = myWindows.window("edit").attachForm();
    myWindows.window("edit").progressOn();
    doLoadFormDetail(id, '../Common/Form?idForm=' + idForm + '&idAction=' + idAction);
    var myToolbar = myWindows.window("edit").attachToolbar();
    doLoadToolbar(myToolbar, idForm, idAction);
    setTimeout(function () {
        var width = $("fieldset").css("width");
        width = parseInt(width.substr(0, width.length - 2)) + 40;
        myWindows.window("edit").setDimension(width);
        myWindows.window("edit").progressOff();
    }, 2000);
}