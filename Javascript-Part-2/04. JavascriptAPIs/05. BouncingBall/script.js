(function () {
    var ctx = document.getElementsByTagName("canvas")[0].getContext("2d");

    var directionTop = 1;
    var directionLeft = 1;
    var x = 20;
    var y = 100;

    setInterval(function () {
        ctx.fillStyle = "#FFF";
        ctx.strokeStyle = "#000";

        ctx.lineWidth = 15;
        ctx.fillRect(0, 0, 700, 500);
        ctx.strokeRect(0, 0, 700, 500);

        ctx.beginPath();

        ctx.arc(x, y, 15, 0, 2 * Math.PI, false);
        ctx.lineWidth = 3;
        ctx.stroke();

        y += directionTop;
        x += directionLeft;

        if (y == 480) {
            directionTop *= -1;
        }
        if (x == 680) {
            directionLeft *= -1;
        }
        if (y == 20) {
            directionTop *= -1;
        }
        if (x == 20) {
            directionLeft *= -1;
        }

    }, 2);
})();