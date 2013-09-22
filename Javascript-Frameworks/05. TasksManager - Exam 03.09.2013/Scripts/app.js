/// <reference path="libs/_references.js" />


(function () {
    var appLayout = new kendo.Layout('<div id="main-content"></div>');
    var data = persisters.get("api/");
    vmFactory.setPersister(data);

    var router = new kendo.Router();

    router.route("/", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
    });

    router.route("/login", function () {
        viewsFactory.getLoginView()
        .then(function (loginViewHtml) {
            var loginVm = vmFactory.getLoginVM(function (address) {
                router.navigate(address);
                location.reload();
            });

            var view = new kendo.View(loginViewHtml, { model: loginVm });
            appLayout.showIn("#main-content", view);
        });
    });

    router.route("/logout", function () {
        if (data.users.currentUser()) {
            data.users.logout()
            .then(function () {
                router.navigate("/");
                location.reload();
            });
        }
        else {
            alert("You're not logged in");
        }
    });
    
    router.route("/appointments", function () {
        viewsFactory.getAppointmentsView()
        .then(function (appointmentsViewHtml) {
            vmFactory.getAppointmentsVM()
            .then(function (appointmentsVM) {
                var view = new kendo.View(appointmentsViewHtml, { model: appointmentsVM });
                appLayout.showIn("#main-content", view);
            });
        });
    });

    router.route("/appointments/create", function () {
        viewsFactory.getCreateNewAppointmentView()
        .then(function (appointmentsViewHtml) {
            var appointmentsVM = vmFactory.getCreateNewAppointmentVM(function (address) {
                router.navigate(address);
            });

            var view = new kendo.View(appointmentsViewHtml, { model: appointmentsVM });
            appLayout.showIn("#main-content", view);
        });
    });

    router.route("/appointments/comming", function () {
        viewsFactory.getAppointmentsView()
        .then(function (appointmentsViewHtml) {
            vmFactory.getCommingAppointmentsVM()
            .then(function (appointmentsVM) {
                var view = new kendo.View(appointmentsViewHtml, { model: appointmentsVM });
                appLayout.showIn("#main-content", view);
            });
        });
    });

    router.route("/appointments/:dd/:mm/:yyyy", function (dd, mm, yyyy) {
        viewsFactory.getAppointmentsView()
        .then(function (appointmentsViewHtml) {
            vmFactory.getAppointmentsByDateVM(dd, mm, yyyy)
            .then(function (appointmentsVM) {
                var view = new kendo.View(appointmentsViewHtml, { model: appointmentsVM });
                appLayout.showIn("#main-content", view);
            });
        });
    });

    router.route("/appointments/today", function () {
        viewsFactory.getAppointmentsView()
        .then(function (appointmentsViewHtml) {
            vmFactory.getTodayAppointmentsVM()
            .then(function (appointmentsVM) {
                var view = new kendo.View(appointmentsViewHtml, { model: appointmentsVM });
                appLayout.showIn("#main-content", view);
            });
        });
    });

    router.route("/appointments/current", function () {
        viewsFactory.getAppointmentsView()
        .then(function (appointmentsViewHtml) {
            vmFactory.getCurrentAppointmentsVM()
            .then(function (appointmentsVM) {
                var view = new kendo.View(appointmentsViewHtml, { model: appointmentsVM });
                appLayout.showIn("#main-content", view);
            });
        });
    });

    router.route("/lists", function () {
        viewsFactory.getListsView()
        .then(function (listsViewHtml) {
            vmFactory.getListsVM(function (address) {
                router.navigate(address);
            })
            .then(function (listsVM) {
                var view = new kendo.View(listsViewHtml, { model: listsVM });
                appLayout.showIn("#main-content", view);
                kendo.bind($("input[type=checkbox]"), listsVM);
            });
        });
    });

    router.route("/lists/create", function () {
        viewsFactory.getCreateNewListView()
        .then(function (listsViewHtml) {
            var listsVM = vmFactory.getCreateNewListVM(function (address) {
                router.navigate(address);
            });

            var view = new kendo.View(listsViewHtml, { model: listsVM });
            appLayout.showIn("#main-content", view);
        });
    });

    router.route("/lists/:listId/todos", function (listId) {
        viewsFactory.getListsView()
        .then(function (listsViewHtml) {
            vmFactory.getSingleListVM(listId)
            .then(function (listsVM) {
                var view = new kendo.View(listsViewHtml, { model: listsVM });
                appLayout.showIn("#main-content", view);
            });
        });
    });

    router.route("/lists/:listId/create", function (listId) {
        viewsFactory.getCreateNewTodoView()
        .then(function (listsViewHtml) {
            var listsVM = vmFactory.getCreateNewTodoVM(listId, function (address) {
                router.navigate(address);
            });

            var view = new kendo.View(listsViewHtml, { model: listsVM });
            appLayout.showIn("#main-content", view);
        });
    });

    router.route("/todos/:todoId", function (todoId) {
        data.todos.changeStatus(todoId).then(function () {
            router.navigate("/");
        });
    });

    $(function () {
        appLayout.render("#app");

        router.start("/");

        if (data.users.currentUser() != 'undefined' && data.users.currentUser()) {
            $('#main-menu').css('display', 'block');
        }
    });
}());