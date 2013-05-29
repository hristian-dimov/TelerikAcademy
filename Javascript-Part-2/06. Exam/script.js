var controls = (function () {

    function escapeHtml(text) {
        return text
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#039;");
    }

    function Grid(selector) {
        var gridHolder = document.querySelector(selector);
        var itemsList = document.createElement("table");
        var items = [];

        function eventListener(ev) {
            if (!ev) {
                ev = window.event;
            }
            ev.stopPropagation();
            ev.preventDefault();

            var clickedItem = ev.target;

            if (!clickedItem.parentNode.nextElementSibling.hasAttribute('class')) {
                return;
            }

            if (!(clickedItem.parentNode instanceof HTMLTableRowElement) ||
                !(clickedItem instanceof HTMLTableCellElement)) {
                return;
            }

            var sublist = clickedItem.parentNode.nextElementSibling;

            if (sublist.style.display === "none") {
                sublist.style.display = "";
            } else {
                sublist.style.display = "none";
            }
        }


        //ie8 fix
        if (!gridHolder.addEventListener) {
            gridHolder.attachEvent("onclick", eventListener);
        }
        else {
            gridHolder.addEventListener("click", eventListener, false);
        }

        this.addHeader = function (name, location, totalStudents, speciality) {
            this.addRow(name, location, totalStudents, speciality, isHeader = true);
        }

        this.addRow = function (SchoolName, SchoolLocation, totalStudents, speciality, isHeader) {
            var newRow = new Row(SchoolName, SchoolLocation, totalStudents, speciality, isHeader);
            items.push(newRow);

            return newRow;
        }

        this.render = function () {
            while (gridHolder.firstChild) {
                gridHolder.removeChild(gridHolder.firstChild);
            }

            while (itemsList.firstChild) {
                itemsList.removeChild(itemsList.firstChild);
            }

            for (var i = 0; i < items.length; i += 1) {
                var domItem = items[i].render();
                itemsList.appendChild(domItem);
            }
            gridHolder.appendChild(itemsList);
            return this;
        }

        this.getGridViewData = function () {
            var serializedItems = [];
            for (var i = 0; i < items.length; i += 1) {
                serializedItems.push(items[i].getGridViewData());
            }
            return serializedItems;
        }
    }

    function Row() {
        var items = [];
        var functionArguments = arguments;

        this.addHeader = function (title, startDate, totalStudents) {
            this.addRow(title, startDate, totalStudents, isHeader = true);
        }

        this.addRow = function (title, startDate, totalStudents, isHeader) {
            var newRow = new Row(title, startDate, totalStudents, isHeader);
            items.push(newRow);

            return newRow;
        }

        this.getGridViewData = function () {
            var serialized = {
                arguments: functionArguments
            };

            if (items.length > 0) {
                for (var i = 0; i < items.length; i++) {
                    var serializedItems = [];
                    for (var i = 0; i < items.length; i += 1) {
                        var serItem = items[i].getGridViewData();
                        serializedItems.push(serItem);
                    }
                    serialized.items = serializedItems;
                }
            }

            return serialized;
        }

        this.getNestedGridView = function () {
            return this;
        }

        this.render = function () {
            var documentFragment = document.createDocumentFragment();

            var itemNode = document.createElement("tr");
            for (var i = 0; i < functionArguments.length - 1; i += 1) {
                var itemNodeChild;
    
                if (functionArguments[functionArguments.length - 1]) { // if the last argument is true the row is header
                    itemNodeChild = document.createElement("th");
                } else {
                    itemNodeChild = document.createElement("td");
                }

                itemNodeChild.innerHTML = escapeHtml(functionArguments[i]);

                itemNode.appendChild(itemNodeChild);

                documentFragment.appendChild(itemNode);
            }

            if (items.length > 0) {
                var createdTRholder = document.createElement("tr");
                createdTRholder.style.display = 'none';
                createdTRholder.className = 'sublist';
				
				var createTDholder = document.createElement("td");
				createTDholder.colSpan = functionArguments.length - 1;
				
				createdTRholder.appendChild(createTDholder);
				
                var createNestedTable = document.createElement("table");
                for (i = 0; i < items.length; i += 1) {
                    var subitem = items[i].render();
                    createNestedTable.appendChild(subitem);
                }
                createTDholder.appendChild(createNestedTable);

                documentFragment.appendChild(createdTRholder);
            }

            return documentFragment;
        }
    }

    return {
        getGridView: function (selector) {
            return new Grid(selector);
        },
        buildGridView: function (selector, data) {
            var accordion = this.getGridView(selector);
            return accordion;
        }
    };
})();

var schoolRepository = (function () {
    function Save(key, obj) {
        localStorage.setObject(key, obj);
    }

    function Load(key) {
        return localStorage.getObject(key);
    }

    return {
        save: Save,
        load: Load
    }
})();