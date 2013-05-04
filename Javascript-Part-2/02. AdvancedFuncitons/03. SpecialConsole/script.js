var specialConsole = (function () {

    /* Replacing the placeholders if there are any */
    function replacePlaceholdersIfAny(template, args) {
        template = template.replace(/{([0-9]+)}/g, function (full, placeholderID) {
            return args[++placeholderID]; // this return is only for the anonymous function
        });

        return template;
    }

    function writeLine(template) {
        var text = replacePlaceholdersIfAny(template, arguments);
        console.log(text);
    }

    function writeError(template) {
        var text = replacePlaceholdersIfAny(template, arguments);
        console.error(text);
    }

    function writeWarning(template) {
        var text = replacePlaceholdersIfAny(template, arguments);
        console.warn(text);
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };

})();