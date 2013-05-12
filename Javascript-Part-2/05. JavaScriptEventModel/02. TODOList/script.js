(function () {
    var addButton = document.getElementById('addButton');
    var deleteButton = document.getElementById('deleteButton');
    var showHideButton = document.getElementById('showHideButton');
    var todoContainer = document.getElementById('todoContainer');
    var uniqueID = 1;

    addButton.onclick = function () {
        var getAllListItem = document.getElementsByTagName('li');
        if (getAllListItem.length > 0) {
            for (var i = 0; i < getAllListItem.length; i++) {
                getAllListItem[i].style.display = "block";
            }
        }

        var todoText = document.getElementById('todoText').value;

        var todoListItemRadioButton = document.createElement('input');
        todoListItemRadioButton.type = 'radio';
        todoListItemRadioButton.name = 'todoListItem';
        todoListItemRadioButton.id = 'todoListItemID-' + uniqueID++;

        var todoListItem = document.createElement("li");
        todoListItem.appendChild(todoListItemRadioButton);
        todoListItem.style.display = "block"
        todoListItem.innerHTML += todoText;

        todoContainer.appendChild(todoListItem);

    }

    deleteButton.onclick = function () {
        var getAllListItem = document.getElementsByTagName('input');
        var selectedRadio = {};

        for (var i = 0; i < getAllListItem.length; i++) {
            if (getAllListItem[i].type == 'radio' && getAllListItem[i].checked) {
                selectedRadio = document.getElementById(getAllListItem[i].id);
                todoContainer.removeChild(selectedRadio.parentNode);
            }
        }
    }

    showHideButton.onclick = function () {
        var getAllListItem = document.getElementsByTagName('li');

        for (var i = 0; i < getAllListItem.length; i++) {
            if (getAllListItem[i].style.display == "block") {
                getAllListItem[i].style.display = "none";
            }
            else {
                getAllListItem[i].style.display = "block";
            }
        }
    }

})();