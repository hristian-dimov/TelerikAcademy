/// <reference path="../libs/class.js" />
/// <reference path="../libs/http-requester.js" />

define(["httpRequester"], function (httpRequester) {
    function getStudents() {
        return httpRequester.getJSON("http://localhost:19248/api/students");
    }
    function getStudentMarks(id) {
        return httpRequester.getJSON("http://localhost:19248/api/students/" + id + "/marks");
    }
    return {
        students: getStudents,
        getStudentMarks: getStudentMarks
    }
});