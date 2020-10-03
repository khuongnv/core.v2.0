var cssSortAsc = "sorting_asc";
var cssSortDesc = "sorting_desc";
var cssSort = "sorting";
var countMessage = 0;

function clickSort(item) {
    var parent = item.parentElement.children;
    for (ch in item.parentElement.children) {

        if (parseInt(ch) !== item.cellIndex && (parent[ch].className.indexOf(cssSortAsc) !== -1 || parent[ch].className.indexOf(cssSortDesc) !== -1 || parent[ch].className.indexOf(cssSort) !== -1)) {
            parent[ch].className = "sorting";
        }
    }

    if (item.className.indexOf("sorting_asc") !== -1) {
        //item.className = "sorting_desc";
        item.className = _.replace(item.className, "sorting_asc", "sorting_desc");
    } else if (item.className.indexOf("sorting") !== -1) {
        //item.className = "sorting_asc";
        item.className = _.replace(item.className, "sorting", "sorting_asc");

    } else if (item.className.indexOf("sorting_desc")) {
        item.className = _.replace(item.className, "sorting_desc", "sorting_asc");
    }
}


function callMessage(type, message) {
    //if (message.trim() === "") {
    //    return false;
    //}
    countMessage = countMessage + 1;
    //var message = "@ViewBag.UpdateMessage";
    var item = "alert-success";
    var idRemove = "message_" + countMessage;
    var itemClass = "";
    if (parseInt(type) === 1) {
        itemClass = "alert-success";
    } else {
        itemClass = "alert-danger";
    }
    item = "<div id='message_" + countMessage + "' class='alert " + itemClass + " fade in alert-dismissible'><a href='#' class='close' data-dismiss='alert' aria-label='close' title='đóng'>×</a>" + message + "</div>";

    $("#divshowmessage ").append(item);

    setTimeout(function () {
        $("#divshowmessage #" + idRemove).remove();
    }, 6000);


    // $.ajax({
    //    url: '@Url.Action("_Notification","Common")',
    //    type: "GET",
    //     data: {
    //         "type": type,
    //        "message": message
    //    },
    //    success: function (data) {
    //        $("#divModel").modal("show");
    //    }
    //});
};

function reCaptchaClientSide(sitekey) {

}

function GetParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return "";
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}
function ObjectifyForm(formArray) {//serialize data function

    var returnArray = {};
    for (var i = 0; i < formArray.length; i++) {
        returnArray[formArray[i]["name"]] = formArray[i]["value"];
    }
    return returnArray;
}
function IsJson(str) {
    try {
        JSON.parse(str);
    } catch (e) {
        return false;
    }
    return true;
}
