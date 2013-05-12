(function () {
    CanvasRenderingContext2D.prototype.drawEllipse = function (x, y, w, h, isBlank) {
        var kappa = .5522848,
            ox = (w / 2) * kappa, // control point offset horizontal
            oy = (h / 2) * kappa, // control point offset vertical
            xe = x + w, // x-end
            ye = y + h, // y-end
            xm = x + w / 2, // x-middle
            ym = y + h / 2; // y-middle

        this.beginPath();
        this.moveTo(x, ym);
        this.bezierCurveTo(x, ym - oy, xm - ox, y, xm, y);
        this.bezierCurveTo(xm + ox, y, xe, ym - oy, xe, ym);
        this.bezierCurveTo(xe, ym + oy, xm + ox, ye, xm, ye);
        this.bezierCurveTo(xm - ox, ye, x, ym + oy, x, ym);
        this.closePath();
        this.stroke();
        if (isBlank === undefined || !isBlank) {
            this.fill();
        }
    };

    CanvasRenderingContext2D.prototype.drawRect = function (fromX, fromY, toX, toY, fill, stroke, lineWidth) {
        this.beginPath();
        this.rect(fromX, fromY, toX, toY);
        if (fill != undefined) {
            this.fillStyle = fill;
        }
        if (stroke != undefined) {
            this.strokeStyle = stroke;
        }
        if (lineWidth != undefined) {
            this.lineWidth = lineWidth;
        }
        this.closePath();
        this.stroke();
        this.fill();
    };

    CanvasRenderingContext2D.prototype.drawLine = function (fromX, fromY, toX, toY, fill, stroke, lineWidth) {
        this.beginPath();
        this.moveTo(fromX, fromY);
        this.lineTo(toX, toY);
        if (fill != undefined) {
            this.fillStyle = fill;
        }
        if (stroke != undefined) {
            this.strokeStyle = stroke;
        }
        if (lineWidth != undefined) {
            this.lineWidth = lineWidth;
        }
        this.closePath();
        this.stroke();
    };

    var ctx = document.getElementsByTagName("canvas")[0].getContext("2d");
    ctx.fillStyle = "#000";
    ctx.fillRect(0, 0, ctx.canvas.width, ctx.canvas.height)

    //face
    ctx.lineWidth = 4;
    ctx.strokeStyle = '#72AAB6';
    ctx.fillStyle = "#90CAD7";
    //head
    ctx.drawEllipse(95, 150, 160, 140);
    ctx.fill();
    //left eye
    ctx.drawEllipse(120, 190, 25, 15);
    ctx.fill();
    //right eye
    ctx.drawEllipse(180, 190, 25, 15);
    ctx.fill();
    //left eye
    ctx.drawEllipse(126, 193, 6, 9);
    ctx.fillStyle = '#72AAB6';
    ctx.fill();
    //right eye
    ctx.drawEllipse(186, 193, 6, 9);
    ctx.fill();
    //mounth
    ctx.save();
    ctx.rotate(10 * Math.PI / 180);
    ctx.fillStyle = "#90CAD7";
    ctx.drawEllipse(170, 220, 65, 20);
    ctx.fill();
    ctx.restore();
    ctx.lineWidth = 2;
    //nouse
    ctx.drawLine(160, 200, 140, 235);
    ctx.drawLine(140, 235, 160, 235);
    //hat
    ctx.strokeStyle = '#000';
    ctx.fillStyle = "#396693";
    ctx.drawEllipse(95, 150, 155, 30);
    ctx.drawEllipse(135, 137, 85, 30);
    ctx.strokeRect(135, 62, 85, 90);
    ctx.fillRect(136, 64, 83, 90);
    ctx.strokeStyle = '#000';
    ctx.fillStyle = "#396693";
    ctx.drawEllipse(135, 46, 85, 30);


    //Bicycle
    ctx.beginPath();
    ctx.lineWidth = 3;

    ctx.fillStyle = "rgb(144, 202, 215)";
    ctx.strokeStyle = "rgb(55, 133, 152)";

    ctx.arc(200, 435, 55, 0, 2 * Math.PI, false);
    ctx.fill();
    ctx.moveTo(480, 435);
    ctx.arc(425, 435, 55, 0, 2 * Math.PI, false);
    ctx.fill();

    ctx.moveTo(200, 435);
    ctx.lineTo(270, 360);
    ctx.lineTo(415, 360);
    ctx.lineTo(305, 435);
    ctx.lineTo(200, 435);

    ctx.moveTo(305, 435);
    ctx.lineTo(255, 330);
    ctx.lineTo(280, 330);
    ctx.lineTo(230, 330);

    ctx.moveTo(320, 435);
    ctx.arc(305, 435, 15, 0, 2 * Math.PI, false);

    ctx.moveTo(315, 444);
    ctx.lineTo(329, 458);

    ctx.moveTo(295, 424);
    ctx.lineTo(283, 409);

    ctx.moveTo(428, 430);
    ctx.lineTo(413, 315);
    ctx.lineTo(360, 331);

    ctx.moveTo(413, 315);
    ctx.lineTo(440, 280);

    ctx.stroke();


    //house
    ctx.beginPath();
    ctx.lineWidth = 4;
    ctx.strokeStyle = '#000';
    ctx.drawRect(600, 150, 320, 240, '#975B5B');
    ctx.fillStyle = '#000';
    ctx.fillRect(625, 175, 55, 40);
    ctx.fillRect(682, 175, 55, 40);
    ctx.fillRect(625, 217, 55, 40);
    ctx.fillRect(682, 217, 55, 40);

    ctx.fillRect(785, 175, 55, 40);
    ctx.fillRect(842, 175, 55, 40);
    ctx.fillRect(785, 217, 55, 40);
    ctx.fillRect(842, 217, 55, 40);

    ctx.fillRect(785, 280, 55, 40);
    ctx.fillRect(842, 280, 55, 40);
    ctx.fillRect(785, 322, 55, 40);
    ctx.fillRect(842, 322, 55, 40);
    ctx.fillRect(842, 322, 55, 40);

    ctx.lineWidth = 2;
    ctx.strokeRect(640, 296, 85, 95);
    ctx.fillStyle = '#975B5B';
    ctx.drawEllipse(641, 276, 83, 43);
    ctx.drawRect(642, 296, 81, 91, '#975B5B', '#975B5B', 2);
    ctx.drawLine(682, 276, 682, 390, '#975B5B', '#000');
    ctx.lineWidth = 4;
    ctx.drawEllipse(690, 360, 10, 10);
    ctx.drawEllipse(665, 360, 10, 10);

    ctx.beginPath();
    ctx.moveTo(600, 149);
    ctx.lineTo(760, 50);
    ctx.lineTo(918, 149);
    ctx.lineTo(600, 149);
    ctx.fillStyle = '#975B5B';
    ctx.fill();
    ctx.stroke();
    ctx.closePath();

    ctx.strokeRect(800, 60, 40, 70);
    ctx.fillRect(802, 62, 36, 70);
    ctx.drawEllipse(801, 53, 38, 10);
})();