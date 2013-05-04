var domModule = (function () {

    function getElement(selector) {
        return document.querySelector(selector);
    }

    function getElements(selector) {
        return document.querySelectorAll(selector);
    }

    function appendChild(childElement, parentElement) {
        var parent = getElement(parentElement);

        parent.appendChild(childElement);
    }

    function removeChild(parentElement, childElement) {
        var childs = getElements(parentElement + " " + childElement);

        for (var i = 0; i < childs.length; i++) {
            childs[i].parentNode.removeChild(childs[i]);
        }
    }

    function addHandler(elementSelector, handlerType, handlerFunction) {
        var elements = getElements(elementSelector);

        for (var i = 0; i < elements.length; i++) {
            elements[i].addEventListener(handlerType, handlerFunction, false);
        }
    }

    var buffer = [];
    var BUFFER_MAX_SIZE = 100;

    function flushBuffer() {
        for (var i = 0; i < buffer.length; i++) {
            var parent = buffer[i].parent;
            var element = buffer[i].element;
            parent.appendChild(element);
        }

        buffer = [];
    }

    function appendToBuffer(selector, element) {
        var parent = getElement(selector);

        buffer.push({ parent: parent, element: element });

        if (buffer.length === BUFFER_MAX_SIZE) {
            flushBuffer();
        }
    }

    return {
        getElement: getElement,
        getElements: getElements,
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer
    };
})();