﻿//$(document).ready(function() {
//    $("body").on("click", "div .content", function() {
//        $('.ui.sidebar').sidebar('toggle');
//    });
//});

function showComplete() {
    var completed = document.getElementById("completed");
    if (completed.style.display === "none") {
        completed.style.display = "inherit";
    } else {
        completed.style.display = "none";
    }
};

$(document).ready(function () {
    $("#username").click(function() {
        $('#profileWindow').modal('show');
    });
});

$(document).ready(function() {
    $("#createListButton").click(function() {
        $('#createListWindow').modal('show');
    });
});

$(document).ready(function() {
    $(".ui.ignored.positive.icon.message").click(function() {
        $('.ui.sidebar').sidebar('toggle');
    });
});

var content = [
    { title: 'Andorra' },
    { title: 'United Arab Emirates' },
    { title: 'Afghanistan' },
    { title: 'Antigua' },
    { title: 'Anguilla' },
    { title: 'Albania' },
    { title: 'Armenia' },
    { title: 'Netherlands Antilles' },
    { title: 'Angola' },
    { title: 'Argentina' },
    { title: 'American Samoa' },
    { title: 'Austria' },
    { title: 'Australia' },
    { title: 'Aruba' },
    { title: 'Aland Islands' },
    { title: 'Azerbaijan' },
    { title: 'Bosnia' },
    { title: 'Barbados' },
    { title: 'Bangladesh' },
    { title: 'Belgium' },
    { title: 'Burkina Faso' },
    { title: 'Bulgaria' },
    { title: 'Bahrain' },
    { title: 'Burundi' }
    // etc
];
$('.ui.search')
    .search({
        source: content
    });

//$(document).ready(function () {
//    $("#addNewItem").click(function () {
//        var title = $("#todoTitle").val();
//        var todo = "<div class='ui ignored positive icon message' id='0'>" +
//            "<button class='completeit' style='height: 16px;'></button>" +
//            "<div class='content' style='margin-left: 20px;'>" +
//                "<h3 class='header'>" + title + "<i class='trash icon' style='float: right'></i></h3>" +
//            "</div></div>";
//        //var todo = "<div class='ui ignored positive icon message' id='0'>" +
//        //    "<button class='completeit' style='height: 16px;' onclick='completeit(this)'></button>" +
//        //    "<div class='content' style='margin-left: 20px;'>" +
//        //    "<h3 class='header'>" + title + "</h3></div></div>";
//        $("#todoTitle").val('');
//        $("#todos").append(todo);
//    });
//});