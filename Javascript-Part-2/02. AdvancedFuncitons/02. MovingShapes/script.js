var movingShapes = (function () {

    function add(shape) {
        var createSpan = createSpanElement(shape);

        if (shape === 'ellipse') {
            parent = document.getElementById('circleContainer');
            parent.appendChild(createSpan);

            moveCircle(createSpan);
        } else if (shape === 'rect') {
            parent = document.getElementById('rectangleContainer');
            parent.appendChild(createSpan);

            moveRectangle(createSpan, 0, 0);
        }
    }

    function moveCircle(element) {
        var angle = 0;
        var radius = 50;

        setInterval(function () {
            element.style.left = Math.floor(Math.cos(angle + 2 * Math.PI) / radius * 10000, 2) + 'px';
            element.style.top = Math.floor(Math.sin(angle + 2 * Math.PI) / radius * 10000, 2) + 'px';

            angle += 0.2;
        }, 100);
    }

    function moveRectangle(element, topStractPosition, leftPos) {
        var top = topStractPosition;
        var left = leftPos;

        setInterval(function () {
            if (top <= 348 && left == 0) {
                top++;
            }
            else if (left <= 148 && top > 147) {
                left++;
            }
            else if (left > 148 && top >= 0) {
                top--;
            }
            else if (top < 1 && left >= 0) {
                left--;
            }

            element.style.top = top + "px";
            element.style.left = left + "px";
        }, 1);
    }

    function createSpanElement(shape) {
        var createSpan = document.createElement('span');

        createSpan.style.color = getRandomColor();
        createSpan.style.backgroundColor = getRandomColor();

        createSpan.style.borderStyle = ['solid', 'dashed', 'dotted'][getRandomInt(0, 2)];
        createSpan.style.borderWidth = 1 + "px";
        createSpan.style.borderColor = getRandomColor();

        var figure = (shape === 'ellipse' ? 'circle' : 'rectangle');
        createSpan.className = figure;
        createSpan.innerHTML = figure;

        return createSpan;
    }

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function getRandomColor() {
        var symbols = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 'A', 'B', 'C', 'D', 'E', 'F'];
        var index = 0;
        var color = '#';

        for (index = 0; index < 6; index++) {
            color += symbols[getRandomInt(0, symbols.length - 1)];
        }

        return color;
    }

    return {
        add: add,   
    };

})();