/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/http-requester.js" />
/// <reference path="../libs/rsvp.js" />

define(["httpRequester"], function (httpRequester) {

    var studentsApiUrl = "http://localhost:21109/api/students";

	function getStudents() {		
	    return httpRequester.getJSON(studentsApiUrl);
	}

	function getMarks(studentId) {
	    return httpRequester.getJSON(studentsApiUrl + "/" + studentId + "/marks");
	}

	return {
	    students: getStudents,
        marks: getMarks
	}
});