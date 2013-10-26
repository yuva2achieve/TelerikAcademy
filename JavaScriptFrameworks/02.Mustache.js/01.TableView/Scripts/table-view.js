/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
    var TableView = Class.create({
        init: function (itemsSource, rows, columns) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of a ListView must be an array!";
            }
            this.itemsSource = itemsSource;
            this.rows = rows;
            this.columns = columns;
        },
        render: function (template) {
            var table = document.createElement("table");
            for (var i = 0; i < this.rows; i++) {
                var tableRow = document.createElement("tr");

                for (var j = 0; j < this.columns; j++) {
                    var tableColumn = document.createElement("td");
                    var item = this.itemsSource.shift();
                    tableColumn.innerHTML = template(item);
                    tableRow.appendChild(tableColumn);
                }
                
                table.appendChild(tableRow);
            }
            return table.outerHTML;
        }
    });

    c.getTableView = function (itemsSource, rows, columns) {
        return new TableView(itemsSource, rows, columns);
    }
}(controls || {}));