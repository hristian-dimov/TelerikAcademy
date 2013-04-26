window.onload = function () {
    document.getElementById('submit').onclick = function () {
        var i = 0;
        var createDiv = {};
        var number = document.getElementById('number').value;
        var container = document.getElementById('container');

        //clearing container...just in case
        container.innerHTML = '';

        for (i = 0; i < number; i++) {
            createDiv = document.createElement('div');
            
            createDiv.style.width = getRandomInt(20, 100) + 'px';
            createDiv.style.height = getRandomInt(20, 100) + 'px';

            createDiv.style.backgroundColor = getRandomColor();
            createDiv.style.color = getRandomColor();

            createDiv.style.position = 'absolute';
            createDiv.style.top = getRandomInt(50, window.innerHeight - 100) + 'px';
            createDiv.style.left = getRandomInt(50, window.innerWidth - 100) + 'px';

            createDiv.appendChild(createStrongElement()); // creating a strong element with 'div' text inside.

            createDiv.style.borderStyle = ['solid', 'dashed', 'dotted'][getRandomInt(0, 2)];
            createDiv.style.borderRadius = getRandomInt(0, 30) + "px";
            createDiv.style.borderWidth = getRandomInt(1, 20) + "px";
            createDiv.style.borderColor = getRandomColor();

            container.appendChild(createDiv);
        }
    }

    function createStrongElement() {
        var text = 'div';
        var element = document.createElement('strong');
        var textNode = document.createTextNode(text);
        element.appendChild(textNode);

        return element;
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
}