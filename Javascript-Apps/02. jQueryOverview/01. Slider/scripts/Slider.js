var SlideContent = Class.create({
    init: function (title, desctiption, imagePath) {
        this.title = title;
        this.desctiption = desctiption;
        this.image = imagePath;
        this.id = "";
    }
});

var Slider = Class.create({
    init: function (containerId) {
        this.container = $("<div></div>").appendTo(document.body);
        $(this.container).attr("id", containerId);

        this.slidesArray = [];
    },

    addSlide: function (slideContent) {
        this.slidesArray.push(slideContent);
    },

    render: function () {
        // adding prev button
        var prevButton = $("<a></a>");
        prevButton.attr("href", "#");
        prevButton.attr("id", "prevButton");
        prevButton.addClass("button");
        prevButton.text("<");
        prevButton.appendTo(this.container);
        prevButton.on("click", function (e) {
            e.preventDefault();
            var prevSlide = $(".current").prev();

            if (prevSlide.length > 0) {
                $(".current").removeClass("current");
                prevSlide.addClass("current");
            }
            else {
                $(".current").removeClass("current");
                $("#slider #slidesHolder div").last().addClass("current");
            }
        });

        // displaying slides
        var slidesHolder = $("<div></div>");
        slidesHolder.attr("id", "slidesHolder");

        for (var i = 0; i < this.slidesArray.length; i++) {
            var slideElement = $("<div></div>");
            var slideContent = this.slidesArray[i];
            slideContent.id = "slide" + i;

            slideElement.append("<h1>" + slideContent.title + "</h1>");
            slideElement.append("<p>" + slideContent.desctiption + "</p>");
            slideElement.append("<img src=\"" + slideContent.image + "\" />");

            slideElement.appendTo(slidesHolder);
        }

        slidesHolder.appendTo(this.container);

        $("#slider #slidesHolder div").first().addClass("current");

        // adding next button
        var nextButton = $("<a></a>");
        nextButton.attr("href", "#");
        nextButton.attr("id", "nextButton");
        nextButton.addClass("button");
        nextButton.text(">");
        nextButton.appendTo(this.container);
        nextButton.on("click", function (e) {
            e.preventDefault();
            var nextSlide = $(".current").next();

            if (nextSlide.length > 0) {
                $(".current").removeClass("current");
                nextSlide.addClass("current");
            }
            else {
                $(".current").removeClass("current");
                $("#slider #slidesHolder div").first().addClass("current");
            }
        });

        this._autoChange(nextButton);
    },

    _autoChange: function (nextButton) {
        setInterval(function () {
            $(nextButton).trigger('click')
        }, 5000);
    }

});