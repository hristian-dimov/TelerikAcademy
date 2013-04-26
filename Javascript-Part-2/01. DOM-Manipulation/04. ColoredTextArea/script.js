window.onload = function () {
    var textColor = document.getElementById('textColor');
    var backgroundColor = document.getElementById('backgroundColor');
    var textarea = document.getElementById('text');

    textColor.onchange = function () {
        textarea.style.color = textColor.value;
    }

    backgroundColor.onchange = function () {
        textarea.style.backgroundColor = backgroundColor.value;
    }
}