window.onload = function () {
    var i = 0;
    var createDiv = {};

    for (i = 0; i < 5; i++) {
        createDiv = document.createElement('div');
            
        createDiv.style.width = '50px';
        createDiv.style.height = '50px';
        createDiv.style.margin = '250px';
        createDiv.style.position = "absolute";

        document.body.appendChild(createDiv);
    }

    var divList = document.getElementsByTagName('div');
    var angle = 0;
    var radius = 50;

    setInterval(function () {
        for (i = 0; i < 5; i++) {
            divList[i].style.left = Math.cos(angle + 2 * Math.PI / divList.length * i) / radius * 10000 + 'px';
            divList[i].style.top = Math.sin(angle + 2 * Math.PI / divList.length * i) / radius * 10000 + 'px';
            divList[i].style.backgroundColor = getRandomColor();
        }
        angle += 0.1;
    }, 100);

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