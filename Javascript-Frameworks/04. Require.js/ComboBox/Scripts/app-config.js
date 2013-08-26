/// <reference path="libs/require.js" />
require.config({
    paths: {
        jquery: "libs/jquery-2.0.3",
        mustache: "libs/mustache",
    }
});

require(["jquery", "mustache", "app/controls"], function ($, mustache, controls) {
    var people = [
        { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "Images/icon.png" },
        { id: 2, name: "Georgi Georgiev", age: 19, avatarUrl: "Images/icon.png" },
        { id: 3, name: "Ivan Ivanov", age: 22, avatarUrl: "Images/icon.png" },
        { id: 4, name: "Peter Petrov", age: 33, avatarUrl: "Images/icon.png" },
        { id: 6, name: "Slavi Slavov", age: 44, avatarUrl: "Images/icon.png" },
        { id: 7, name: "Stefan Stefanov", age: 25, avatarUrl: "Images/icon.png" },
        { id: 8, name: "Stoqn Stoqnov", age: 29, avatarUrl: "Images/icon.png" },
        { id: 9, name: "Kalin Kalinov", age: 27, avatarUrl: "Images/icon.png" },
    ];

    var container = document.getElementById("content");

    var comboBox = controls.ComboBox(people);
    var template = $("#items-template").html();
    var comboBoxHtml = comboBox.render(template);
    container.innerHTML = comboBoxHtml;

    (function () {
        $("body").on('click', '#selectWindow', function () {
            if ($("#content").css("display") == "none") {
                $(this).css("border-bottom", "none");
                $("#content").show();
            }
            else {
                $("#selectWindow").css("border-bottom", "1px solid black");
                $("#content").hide();
            }
        });

        $("body").on('click', '.person-item', function () {
            $("#selectWindow").html($(this).html());

            $("#content").hide();
            $("#selectWindow").css("border-bottom", "1px solid black");
        });
    }());
});