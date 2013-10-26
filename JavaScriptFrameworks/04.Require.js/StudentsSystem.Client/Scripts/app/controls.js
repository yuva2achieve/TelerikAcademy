/// <reference path="../libs/class.js" />

define(["libs/class"], function (Class) {
    var controls = controls || {};

    var ComboBox = Class.create({
		init: function (itemsSource) {
			if (!(itemsSource instanceof Array)) {
				throw "The itemsSource of a ComboBox must be an array!";
			}
			this.itemsSource = itemsSource;
		},
		render: function (template) {
		    var div = document.createElement("div");
		},
		renderMarks: function (template) {

		}
	});
	controls.listView = function (itemsSource) {
	    return new ComboBox(itemsSource);
	}

	return controls;
});