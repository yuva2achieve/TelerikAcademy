/// <reference path="underscore.min.js" />
/// <reference path="class.js" />

var Homework = (function () {
    'use strict';

    var numberOfLegs = 0;

    function task1(students) {
        var result = _.filter(students, isFirstNameBeforeLastName);
        _.each(result, printObject)
    }

    function task2(students) {
        var result = _.filter(students, isStudentBetweenAge);
        _.each(result, printObject);
    }

    function task3(students) {
        var result = _.sortBy(students, 'mark');
        printObject(result[result.length - 1]);
    }

    function task4(animals) {
        var groupedBySpecies = _.groupBy(animals, 'species');
        
        for (var arr in groupedBySpecies) {
            groupedBySpecies[arr] = _.sortBy(groupedBySpecies[arr], 'numberOfLegs');
        }

        for (var arr in groupedBySpecies) {
            _.each(groupedBySpecies[arr], printObject);
        }
    }
    
    function task5(animals) {
        numberOfLegs = 0;
        _.each(animals, countLegs);
        console.log("Total number of legs is: " + numberOfLegs);
    }

    function task6(books) {
        var groupedByAuthor = _.groupBy(books, 'author');
        
        var sortedByAuthor = _.sortBy(groupedByAuthor, function (arr) {
            return arr.length;
        })

        var mostPopularAuthor = (_.last(sortedByAuthor))[0].author;
        console.log(mostPopularAuthor);
    }

    function task7(students) {
        var groupedByFirstName = _.groupBy(students, 'firstName');

        var sortedByFirstName = _.sortBy(groupedByFirstName, function (arr) {
            return arr.length;
        })

        var mostPopularFirstName = (_.last(sortedByFirstName))[0].firstName;
        console.log("Most popular first name: " + mostPopularFirstName);

        var groupedByLastName = _.groupBy(students, 'lastName');

        var sortedByLastName = _.sortBy(groupedByLastName, function (arr) {
            return arr.length;
        })

        var mostPopularFirstName = (_.last(sortedByLastName))[0].lastName;
        console.log("Most popular last name: " + mostPopularFirstName);
    }
    function isFirstNameBeforeLastName(student) {
        var isTrue = false;

        if (student.firstName.localeCompare(student.lastName) == 1) {
            isTrue = true;
        }

        return isTrue;
    }
    
    function isStudentBetweenAge(student) {
        var isTrue = false;
        var minAge = 23;
        var maxAge = 24;


        if (student.age >= minAge && student.age <= maxAge) {
            isTrue = true;
        }

        return isTrue;
    }

    function countLegs(animal) {
        numberOfLegs += animal.numberOfLegs;
    }

    function printObject (obj) {
        console.log(obj.toString());
    }

    return {
        task1: task1,
        task2: task2,
        task3: task3,
        task4: task4,
        task5: task5,
        task6: task6,
        task7: task7
    };
}());