/// <reference path="libs/require.js" />
require.config({
    paths: {
		jquery: "Scripts/libs/jquery-2.0.3",
		rsvp: "Scripts/libs/rsvp",
		httpRequester: "Scripts/libs/http-requester",
		dataPersister: "Scripts/app/data-persister",
		mustache: "Scripts/libs/mustache"
	}
});

require(["dataPersister"], function (data) {
    var students = data.marks(3);
    students.then(function (data) {
        console.log(data);
    },
    function (err) {
        console.log(err);
    });
})

