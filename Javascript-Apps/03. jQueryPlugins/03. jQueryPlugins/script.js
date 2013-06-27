(function ($) {
    $.fn.treeView = function () {
        $(this).children().click(function (event) {
            $(event.target).children("ul").slideToggle(500);
        });
    }
})(jQuery);