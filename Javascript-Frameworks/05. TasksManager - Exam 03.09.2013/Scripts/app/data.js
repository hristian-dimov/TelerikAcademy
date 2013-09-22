/// <reference path="../libs/_references.js" />

window.persisters = (function () {
    var usernameSaved = localStorage.getItem("username");
    var tokenKeySaved = localStorage.getItem("accessToken");

    function saveUserData(userData) {
        localStorage.setItem("username", userData.username);
        localStorage.setItem("accessToken", userData.accessToken);
        usernameSaved = userData.username;
        tokenKeySaved = userData.accessToken;
    }

    function clearUserData() {
        localStorage.removeItem("username");
        localStorage.removeItem("accessToken");
        usernameSaved = "";
        tokenKeySaved = "";
    }

    function getJSON(requestUrl) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "GET",
                dataType: "json",
                headers: { "X-accessToken": tokenKeySaved },
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function postJSON(requestUrl, data) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                headers: { "X-accessToken": tokenKeySaved },
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function putJSON(requestUrl, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "PUT",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        login: function (username, password, email) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString(),
                email: email
            };

            return postJSON(this.apiUrl + "auth/token", user)
            .then(function (data) {
                saveUserData(data);
                return data.username;
            });
        },
        register: function (username, password, email) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString(),
                email: email
            };

            return postJSON(this.apiUrl + "users/register", user)
            .then(function (data) {
                saveUserData(data);
                return data.username;
            });
        },
        logout: function () {
            if (!tokenKeySaved) {
                alert("Cannot log out. Your session key is invalid");
            }
            else {
                var headers = {
                    "X-accessToken": tokenKeySaved
                };

                clearUserData();
                return putJSON(this.apiUrl + "users/logout", {}, headers);
            }
        },
        currentUser: function () {
            return tokenKeySaved;
        }
    });

    var AppointmentsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl + "appointments/";
        },
        all: function () {
            return getJSON(this.apiUrl + "all");
        },
        create: function (appointmentData) {
            return postJSON(this.apiUrl, appointmentData);
        },
        comming: function () {
            return getJSON(this.apiUrl + "comming");
        },
        byDate: function (dd, mm, yyyy) {
            return getJSON(this.apiUrl + "?date=" + dd + "-" + mm + "-" + yyyy);
        },
        current: function () {
            return getJSON(this.apiUrl + "current");
        },
        today: function () {
            return getJSON(this.apiUrl + "today");
        }
    });

    var TodoListsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl + "lists/";
        },
        all: function () {
            return getJSON(this.apiUrl);
        },
        create: function (todoListData) {
            return postJSON(this.apiUrl + "new", todoListData);
        },
        getById: function (listId) {
            return getJSON(this.apiUrl + listId + "/todos");
        },
        createById: function (listId, todoData) {
            return postJSON(this.apiUrl + listId + "/todos", todoData);
        }
    });

    var TodoPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl + "todos/";
        },
        changeStatus: function (todoId) {
            var headers = {
                "X-accessToken": tokenKeySaved
            };

            return putJSON(this.apiUrl + todoId, {}, headers);
        }
    });

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UsersPersister(apiUrl);
            this.appointments = new AppointmentsPersister(apiUrl);
            this.todoLists = new TodoListsPersister(apiUrl);
            this.todos = new TodoPersister(apiUrl);
        }
    });

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());