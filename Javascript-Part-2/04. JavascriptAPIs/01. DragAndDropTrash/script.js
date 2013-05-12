(function () {
    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function generateRandomTrash() {
        var container = document.getElementById('wrapper');
        var createImgElement = {};

        for (var i = 1; i <= trashCount; i++) {
            createImgElement = document.createElement('img');
            createImgElement.src = 'images/trash.png';
            createImgElement.draggable = true;
            createImgElement.className = 'trash';
            createImgElement.id = 'trash' + i;

            createImgElement.style.position = 'absolute';
            createImgElement.style.top = getRandomInt(50, window.innerHeight  / 2) + 'px';
            createImgElement.style.left = getRandomInt(250, window.innerWidth - 100) + 'px';

            container.appendChild(createImgElement);
        }
    }

    function displayScoreboard() {
        var topPlayers = [];

        for (var player in localStorage) {
            topPlayers.push([player, localStorage[player]]);
        }
        topPlayers.sort(function (a, b) { return a[1] - b[1] });

        var loopLength = (topPlayers.length > 5 ? 5 : topPlayers.length) | 0;

        var highScore = document.getElementById("highScore");
        highScore.innerHTML = '';

        for (var i = 0; i < loopLength; i++) {
            highScore.innerHTML += '<li>' + topPlayers[i][0] + ": " + topPlayers[i][1] + "</li>";
        }
    }

    function insertNewRecord(score) {
        var userName = prompt('Your highscore is: ' + score + ' ! Enter your name ');
        localStorage.setItem(userName, score);
    }

    var trashCount = 5;
    var startTime = 0;
    var finishTime = 0;
    var score = 0;

    displayScoreboard();
    generateRandomTrash();

    var bucket = document.getElementById("bucket");
    var trash = document.getElementsByClassName("trash");

    var onDragStart = function (ev) {
        ev.dataTransfer.setData("dragged-id", ev.target.id);

        var getAllTrashLength = document.getElementsByClassName("trash").length;

        if (getAllTrashLength == trashCount) {
            startTime = Date.now();
        }
    }

    for (var i = 0; i < trash.length; i++) {
        trash[i].addEventListener("dragstart", onDragStart, false);
    }

    bucket.ondragover = function (ev) {
        ev.preventDefault();
        bucket.src = "images/opened.png";
    }

    bucket.ondrop = function (ev) {
        ev.preventDefault();

        var data = ev.dataTransfer.getData("dragged-id");
        var trashElement = document.getElementById(data);
        trashElement.parentNode.removeChild(trashElement);

        var getAllTrash = document.getElementsByClassName("trash");
        if (typeof getAllTrash[0] === 'undefined') {
            finishTime = Date.now() - startTime;
            score = Math.floor(finishTime / 10);
            
            insertNewRecord(score);
            displayScoreboard();
        }

        bucket.src = "images/closed.png";
    }
})();