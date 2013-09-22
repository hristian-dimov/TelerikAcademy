/// <reference path="../libs/_references.js" />

window.vmFactory = (function () {
    var data = null;

    var changeTodoStatus = function (e) {
        var todoId = $(e.target).attr('data-todoId');
        data.todos.changeStatus(todoId)
        .then(function () {
            successCallback("/lists");
        });
    };

    function getLoginViewModel(successCallback) {		
        var viewModel = new kendo.observable({
            username: "TestUser",
            password: "TestUser",
            email: "TestEmail@email.com",
            login: function () {
                data.users.login(this.get("username"), this.get("password"), this.get("email"))
                .then(function () {
                    if (successCallback) {
                        successCallback("/");
                    }
                });
            },
            register: function () {
                data.users.register(this.get("username"), this.get("password"), this.get("email"))
                .then(function () {
                    if (successCallback) {
                        alert("Register successful. Redirecting to login page.");
                        successCallback("/login");
                    }
                });
            }
        });

        return viewModel;
    };

    function getAppointmentsViewModel() {
        return data.appointments.all()
        .then(function (appointments) {
            var viewModel = {
                appointments: appointments,
                message: ""
            };

            return kendo.observable(viewModel);
        });
    }

    function getCreateNewAppointmentViewModel(successCallback) {
        var viewModel = new kendo.observable({
            subject: "",
            description: "",
            appointmentDate: "13/09/2013",
            duration: "",
            createAppointment: function () {
                var appointmentData = {
                    subject: this.get("subject"),
                    description: this.get("description"),
                    appointmentDate: this.get("appointmentDate"),
                    duration: this.get("duration")
                };

                data.appointments.create(appointmentData)
                .then(function () {
                    if (successCallback) {
                        successCallback("/appointments");
                    }
                });
            }
        });

        return viewModel;
    }

    function getCommingAppointmentsViewModel() {
        return data.appointments.comming()
        .then(function (appointments) {
            var viewModel = {
                appointments: appointments,
                message: ""
            };

            return kendo.observable(viewModel);
        });
    }

    function getAppointmentsByDateViewModel(dd, mm, yyyy) {
        return data.appointments.byDate(dd, mm, yyyy)
        .then(function (appointments) {
            var viewModel = {
                appointments: appointments,
                message: ""
            };

            return kendo.observable(viewModel);
        });
    }

    function getTodayAppointmentsViewModel() {
        return data.appointments.today()
        .then(function (appointments) {
            var viewModel = {
                appointments: appointments,
                message: ""
            };

            return kendo.observable(viewModel);
        });
    }

    function getCurrentAppointmentsViewModel() {
        return data.appointments.current()
        .then(function (appointments) {
            var viewModel = {
                appointments: appointments,
                message: ""
            };

            return kendo.observable(viewModel);
        });
    }
    
    function getListsViewModel() {
        return data.todoLists.all()
        .then(function (lists) {
            var viewModel = {
                lists: lists,
                changeStatus: changeTodoStatus,
                message: ""
            };

            return kendo.observable(viewModel);
        });
    }

    function getCreateNewListViewModel(successCallback) {
        var viewModel = new kendo.observable({
            title: "",
            createTodoList: function () {
                var todoListData = {
                    title: this.get("title"),
                    todos: []
                };

                data.todoLists.create(todoListData)
                .then(function () {
                    if (successCallback) {
                        successCallback("/lists");
                    }
                });
            }
        });

        return viewModel;
    }

    function getSingleListViewModel(listId) {
        return data.todoLists.getById(listId)
        .then(function (lists) {
            var viewModel = {
                lists: lists,
                changeStatus: changeTodoStatus,
                message: ""
            };

            return kendo.observable(viewModel);
        });
    }

    function getCreateNewTodoViewModel(listId, successCallback) {
        var viewModel = new kendo.observable({
            text: "",
            createTodo: function () {
                var todoData = {
                    text: this.get("text")
                };

                data.todoLists.createById(listId, todoData)
                .then(function () {
                    if (successCallback) {
                        successCallback("/lists/" + listId + "/todos");
                    }
                });
            }
        });

        return viewModel;
    }

    return {
        getLoginVM: getLoginViewModel,
        getAppointmentsVM: getAppointmentsViewModel,
        getCreateNewAppointmentVM: getCreateNewAppointmentViewModel,
        getCommingAppointmentsVM: getCommingAppointmentsViewModel,
        getAppointmentsByDateVM: getAppointmentsByDateViewModel,
        getCurrentAppointmentsVM: getCurrentAppointmentsViewModel,
        getTodayAppointmentsVM: getTodayAppointmentsViewModel,
        getListsVM: getListsViewModel,
        getCreateNewListVM: getCreateNewListViewModel,
        getSingleListVM: getSingleListViewModel,
        getCreateNewTodoVM: getCreateNewTodoViewModel,
        setPersister: function (persister) {
            data = persister
        }
    };
}());