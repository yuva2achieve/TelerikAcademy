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
        renderStudents: function (masterTemplate, detailsTemplate) {
            var table = document.createElement("table");

            for (var i = 0; i < this.rows; i++) {
                var tableRow = document.createElement("tr");

                for (var j = 0; j < this.columns; j++) {
                    var tableColumn = document.createElement("td");
                    var item = this.itemsSource.shift();
                    tableColumn.innerHTML = masterTemplate(item);
                    this.currentMarks = item.Marks;
                    var details = this.renderMarks(detailsTemplate)
                    if (details) {
                        tableColumn.innerHTML += details;
                    }
                    tableRow.appendChild(tableColumn);
                }

                table.appendChild(tableRow);
            }

            return table.outerHTML;
        },
        renderMarks: function (template) {
            var list = document.createElement("ul");
            list.className = "marks"
            for (var index = 0; index < this.currentMarks.length; index++) {
                var item = this.currentMarks[index];
                var markInHtml = template(item);
                list.innerHTML += markInHtml;
            }

            return list.outerHTML;
        }
    });

    c.getTableView = function (itemsSource, rows, columns) {
        return new TableView(itemsSource, rows, columns);
    }
}(controls || {}));