(function () {
    var leftArrow = document.getElementById("left");
    var rightArrow = document.getElementById("right");
    var image = document.getElementById("image");
    var imageNumber = 1;
    var maxImages = 4;

    rightArrow.onclick = function () {
        if (imageNumber >= maxImages) {
            imageNumber = 1;
        }
        else {
            imageNumber++;
        }

        image.src = "images/girl" + imageNumber + ".jpg";
        return false;
    }

    leftArrow.onclick = function () {
        if (imageNumber <= 1) {
            imageNumber = maxImages;
        }
        else {
            imageNumber--;
        }

        image.src = "images/girl" + imageNumber + ".jpg";
        return false;
    }
})();