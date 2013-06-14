var Url = Class.create({
    init: function (title, url) {
        this.title = title;
        this.url = url;
    }
});

var Folder = Class.create({
    init: function (title, urlSet) {
        this.title = title;
        this.urlSet = urlSet;
    }
});

var FavBar = Class.create({
    init: function (favBarContainerId, folderSet, urlSet) {
        this.favBar = document.createElement("ul");
        this.favBar.id = favBarContainerId;

        this.folderSet = folderSet;
        this.urlSet = urlSet;
    },

    render: function () {
        for (var i = 0; i < this.folderSet.length; i++) {
            var folderTitle = document.createElement("li");
            folderTitle.innerHTML = this.folderSet[i].title;
            folderTitle.id = "folder" + i;
            folderTitle.onclick = this._handleFolderClick;

            var folderMenu = document.createElement("ul");
            folderMenu.style.display = "none";

            for (var j = 0; j < this.folderSet[i].urlSet.length; j++) {
                var childUrl = "<li><a href=\"" + this.folderSet[i].urlSet[j].url + "\" target=\"_blank\">" + this.folderSet[i].urlSet[j].title + "</a></li>"
                $(childUrl).appendTo(folderMenu);
            }

            this.favBar.appendChild(folderTitle);
            this.favBar.appendChild(folderMenu);
        }

        for (i = 0; i < this.urlSet.length; i++) {
            childUrl = "<li><a href=\"" + this.urlSet[i].url + "\" target=\"_blank\">" + this.urlSet[i].title + "</a></li>"
            $(childUrl).appendTo(this.favBar);
        }

        document.body.appendChild(this.favBar);
    },

    _handleFolderClick: function () {
        $(this.nextSibling).slideToggle(100);
    }
});