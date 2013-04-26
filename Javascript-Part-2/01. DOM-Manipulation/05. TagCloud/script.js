window.onload = function () {
    document.getElementById('submit').onclick = function () {
        var textarea = document.getElementById('text').value;
        
        var textareaTags = textarea.split(', ');
        var dictionaryTags = makeDictionary(textareaTags);

        generateTagCloud(dictionaryTags, 17, 42)
    }

    function generateTagCloud(tags, minFontSize, maxFontSize) {
        var i = 0;
        var currentFont = minFontSize;
        var currentTagOccurence;
        var firstTagOccurence = parseInt(tags[0][1]); // biggest occurence [the array is sorted]
        var createElementForTag;
        var container = document.getElementById('container');

        //clearing container...just in case
        container.innerHTML = '';

        if (firstTagOccurence == 1) {
            alert('You must enter an element with atleast 2 occurences');
        } else {
            for (i = 0; i < tags.length; i++) {
                currentTagOccurence = parseInt(tags[i][1]);

                currentFont = Math.floor((maxFontSize - minFontSize) / (firstTagOccurence - 1) * (currentTagOccurence - 1) + minFontSize);

                createElementForTag = document.createElement("p");
                createElementForTag.innerHTML = tags[i][0];
                createElementForTag.style.fontSize = currentFont + 'px';

                container.appendChild(createElementForTag);
            }
        }
    }

    function makeDictionary(tags) {
        var i = 0;

        // Make all the tags lower case
        for (i = 0; i < tags.length; i++) {
            tags[i] = tags[i].toLowerCase();
        }

        var tagCount = [];

        // Push the first tag to the "dictionary" so it has lenght > 0
        if (tagCount.length == 0) {
            tagCount.push([tags[0], 0]);
        }

        // Checks if a tags is already present and adds up to its count
        // otherwise pushes a new tag to the array
        for (i = 0; i < tags.length; i++) {

            var isFound = false;
            for (var j = 0; j < tagCount.length; j++) {
                if (tags[i] == tagCount[j][0]) {
                    tagCount[j][1]++;
                    isFound = true;
                    break;
                }
            }

            if (!(isFound)) {
                tagCount.push([tags[i], 1]);
                isFound = false;
            }
        }

        // Sorting the tags by occurance (not alphabetical order)
        tagCount.sort(function (a, b) { return (a[1] < b[1] ? -1 : (a[1] > b[1] ? 1 : 0)); });
        tagCount.reverse();

        return tagCount;
    }
}