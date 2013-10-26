(function ($) {
	"use strict";

	$.fn.getTreeView = function () {
		var $self = $(this);
		$self.find("ul").hide();
		$self.on("click.treeview", "span", function (ev) {
			ev.stopPropagation();
			var $span = $(this);
			$span.siblings("ul").toggle();
			$span.toggleClass("expanded");
		})

		return $self;
	}

}(jQuery));