toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

function messageSuccess(message) {
    toastr["success"](message);
}
function messageError(message) {

    toastr["error"](message);
}
function messageWarning(message) {
    toastr["warning"](message);
}
function objectifyForm(formArray) {//serialize data function

    var returnArray = {};
    for (var i = 0; i < formArray.length; i++) {
        returnArray[formArray[i]['name']] = formArray[i]['value'];
    }
    return returnArray;
}
function isEmpty(value) {
    return typeof value == 'string' && !value.trim() || typeof value == 'undefined' || value === null;
}
function ShowPopupAddOrEdit(url, parameter, typeName, titleModelName, readonly) {
    // typeName: complex
    // typeName + "Model" = divComplexModel
    // title + typeName + "Model" = complexTitleModel
    // body + typeName + "Model" = complexBodyModel
    var modelContainer = $("#" + typeName + "Model");
    var titleModel = $("#" + typeName + "TitleModel");
    var bodyModel = $("#" + typeName + "BodyModel");
    $.ajax({
        url: url,
        type: "POST",
        data: parameter,
        success: function (data) {
            modelContainer.modal("show");
            titleModel.html(titleModelName);
            bodyModel.html(data);
            if (readonly === true) {
                $("#" + typeName + "BodyModel .js-responsive").prop("disabled", true);
                $("div.add-or-edit-form-container :button").attr("disabled", "disabled");
                $("div.add-or-edit-form-container :button.show-when-view-only").removeAttr("disabled");
                $(".hide-when-disable-form").css("display", "none");
                //$("div.add-or-edit-form-container :button").css("display", "none");
                $("div.add-or-edit-form-container input[type=text], textarea").attr("disabled", "disabled");
                $("div.add-or-edit-form-container input[type='radio']").prop("disabled", true);
                $("div.add-or-edit-form-container input[type='checkbox']").prop("disabled", "disabled");
                $("div.add-or-edit-form-container input[type='checkbox']").prop("readonly", true);
                // for form addoredit of mr Quang
                $("#" + typeName + "BodyModel :button").attr("disabled", "disabled");
                $("#" + typeName + "BodyModel :button.show-when-view-only").removeAttr("disabled");

                //$("#" + typeName + "BodyModel :button").css("display", "none");
                $("#" + typeName + "BodyModel select").attr("disabled", true);
                $("#" + typeName + "BodyModel input[type=text], textarea").attr("disabled", "disabled");
                $("#" + typeName + "BodyModel input[type='radio']").prop("disabled", true);
            }
        },
        error: function () {
        }
    });
};
function confirmDelete(title, message, callback) {

    bootbox.confirm({
        title: title,
        message: message,
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> Thoát',
                className: 'btn-sm'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Đồng ý',
                className: 'btn btn-sm btn-blue'
            }
        },
        callback: callback
    });
}
function getTableConfig() {

    return {
        language: {
            "sProcessing": "Đang xử lý...",
            "sLengthMenu": "Xem _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Tiếp",
                "sLast": "Cuối"
            }
        },
        pageLength : 50

    }
}

function getTableConfigNoSort() {

    return {
        language: {
            "sProcessing": "Đang xử lý...",
            "sLengthMenu": "Xem _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Tiếp",
                "sLast": "Cuối"

            }
        },

        'ordering': false,
        "iDisplayLength": "50"
    }
}
function getFileInputConfig() {
    return {
        style: 'well',
        btn_choose: 'Thả tập tin hoặc click để chọn',
        btn_change: null,
        no_icon: 'ace-icon fa fa-cloud-upload',
        droppable: true,
        thumbnail: 'large'
    }
}
function ajaxPost(url, data, success, failure) {

    var ajaxConfig = {
        type: "POST",
        url: url,
        data: data,
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: success,
        error: failure

    };

    $.ajax(ajaxConfig);
}


function ajaxPostWithEnctype(url, data, success, failure) {

    var ajaxConfig = {
        type: "POST",
        url: url,
        data: data,
        dataType: "json",
        contentType: false,
        processData: false,
        success: success,
        error: failure
    };

    $.ajax(ajaxConfig);
}
function ajaxGet(url, data, dataType, success, failure) {

    var ajaxConfig = {
        type: "GET",
        url: url,
        data: data,
        dataType: dataType,
        success: success,
        error: failure,
        beforeSend: function () {
            $('#divAjaxLoading-Lg').show();
        },
        complete: function () {
            $('#divAjaxLoading-Lg').hide();
        }
    };

    $.ajax(ajaxConfig);
}

function ajaxGetArrayParam(url, data, dataType, success, failure) {

    var ajaxConfig = {
        type: "POST",
        url: url,
        traditional: true,
        data: data,
        dataType: dataType,
        success: success,
        error: failure,
        beforeSend: function () {
            $('#divAjaxLoading-Lg').show();
        },
        complete: function () {
            $('#divAjaxLoading-Lg').hide();
        }
    };

    $.ajax(ajaxConfig);
}


function datePicker() {
    $('.date-picker').datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    }).next().on(ace.click_event,
        function () {
            $(this).prev().focus();
        });
}

function setDatePicker(ctr) {

    $('#' + ctr).datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    }).next().on(ace.click_event,
        function () {
            $(this).prev().focus();
        });
}

function multiSelectDropDown() {
    $('.multiselect').multiselect({
        enableFiltering: true,
        enableHTML: true,
        includeSelectAllOption: true,
        nonSelectedText: "Chọn kết quả",
        selectAllText: "Chọn tất cả",
        buttonWidth: "100%",
        buttonClass: 'btn btn-white btn-primary',
        templates: {
            button:
            '<button type="button" class="multiselect dropdown-toggle" data-toggle="dropdown"><span class="multiselect-selected-text"></span> &nbsp;<b class="fa fa-caret-down"></b></button>',
            ul: '<ul class="multiselect-container dropdown-menu"></ul>',
            filter:
            '<li class="multiselect-item filter"><div class="input-group"><span class="input-group-addon"><i class="fa fa-search"></i></span><input class="form-control multiselect-search" type="text"></div></li>',
            filterClearBtn:
            '<span class="input-group-btn"><button class="btn btn-default btn-white btn-grey multiselect-clear-filter" type="button"><i class="fa fa-times-circle red2"></i></button></span>',
            li: '<li><a tabindex="0"><label></label></a></li>',
            divider: '<li class="multiselect-item divider"></li>',
            liGroup: '<li class="multiselect-item multiselect-group"><label></label></li>'
        }
    });
}
function appendLoading(id) {
    var divLoading = "<div class=\"t-loading-panel\" id=\"" + id + "\"></div>";
    $("#" + id).append(divLoading);
};
function appendTextLoading(id, parent) {
    var divLoading = "<label class=\"t-loading-text control-label t-overwrite-label\" id=\"" + id + "\">Đang tải dữ liệu...</label>";
    $("#" + parent).append(divLoading);
};

function removeTextLoading(id) {
    $("label#" + id).remove();
};
function removeLoading(id) {
    $("div#" + id).remove();
    $("div#" + id).fadeOut("fast", "swing", function () { $("div#" + id).remove(); });
};

