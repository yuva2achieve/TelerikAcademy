/// <reference path="../Scripts/jasmine.js"/>
/// <reference path="../Scripts/jasmine.async.js"/>
/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"/>
/// <reference path="../Scripts/kendo.custom.min.js"/>
/// <reference path="../Scripts/MongoLab.js"/>
/// <reference path="../Scripts/University.js"/>
/// <reference path="../Scripts/Functionalities.js"/>

describe("Functionalities tests", function () {

    describe("should add one student", function () {
        var async = new AsyncSpec(this);

        var mongoDB = new MongoLab('KR-YVgnAgQztphU54zK9Qu-20PzjdLj5');
        var students = [];
        var newStudents = [];
        var addedStudentsCount = 0;
        var studentsCountBeforeAdd = 0;
        var studentsCountAfterAdd = 0;
        var expectedStudentNames =
            [
                { Name: "Петър Петров Петров" },
                { Name: "Иван Иванов Иванов" }
            ];
        var expectedCityNames =
            [
                { Name: "София" },
                { Name: "Пловдив" }
            ];
        var studentsToAdd = 1;

        async.it("and list students in the database before add", function (done) {

            mongoDB.listDocuments('universitysystem', 'Student', function (data) {
                for (var i = 0; i < data.length; i++) {
                    var studs = new universitySystem.Student(data[i]._id, data[i].firstName, data[i].lastName, data[i].email, data[i].address, data[i].city, data[i].phoneNumber, data[i].age);
                    studentsCountBeforeAdd++;
                }

                done();
            });
        })

        async.it("and add one student to the database", function (done) {

            functionalities.addStudents(studentsToAdd, expectedStudentNames, expectedCityNames, mongoDB, function (data) {
                var stud = new universitySystem.Student(data._id, data.firstName, data.lastName, data.email, data.address, data.city, data.phoneNumber, data.age);
                newStudents.push(stud);
                addedStudentsCount++;
                done();

                expect(addedStudentsCount).toBe(1);
                expect(newStudents.length).toBe(addedStudentsCount);
            });
        })

        async.it("and list students in the database after add", function (done) {

            mongoDB.listDocuments('universitysystem', 'Student', function (data) {
                for (var i = 0; i < data.length; i++) {
                    var studs = new universitySystem.Student(data[i]._id, data[i].firstName, data[i].lastName, data[i].email, data[i].address, data[i].city, data[i].phoneNumber, data[i].age);
                    students.push(studs);
                    studentsCountAfterAdd++;
                }

                done();

                expect(studentsCountBeforeAdd).toBe(studentsCountAfterAdd - addedStudentsCount);
                expect(students.length).toBe(studentsCountAfterAdd);
            });
        })
    })

    describe("should add five students", function () {
        var async = new AsyncSpec(this);

        var mongoDB = new MongoLab('KR-YVgnAgQztphU54zK9Qu-20PzjdLj5');
        var students = [];
        var newStudents = [];
        var addedStudentsCount = 0;
        var studentsCountBeforeAdd = 0;
        var studentsCountAfterAdd = 0;
        var expectedStudentNames =
            [
                { Name: "Петър Петров Петров" },
                { Name: "Иван Иванов Иванов", },
                { Name: "Йордан Георгиев Стоянов" }
            ];
        var expectedCityNames =
            [
                { Name: "София" },
                { Name: "Пловдив" },
                { Name: "Варна" }
            ];
        var studentsToAdd = 5;

        async.it("and list students in the database before add", function (done) {

            mongoDB.listDocuments('universitysystem', 'Student', function (data) {
                for (var i = 0; i < data.length; i++) {
                    var studs = new universitySystem.Student(data[i]._id, data[i].firstName, data[i].lastName, data[i].email, data[i].address, data[i].city, data[i].phoneNumber, data[i].age);
                    studentsCountBeforeAdd++;
                }

                done();
            });
        })

        async.it("and add one student to the database", function (done) {
            var expected = 0;
            functionalities.addStudents(studentsToAdd, expectedStudentNames, expectedCityNames, mongoDB, function (data) {
                var stud = new universitySystem.Student(data._id, data.firstName, data.lastName, data.email, data.address, data.city, data.phoneNumber, data.age);
                newStudents.push(stud);
                addedStudentsCount++;
                expected++;
                done();

                expect(addedStudentsCount).toBe(expected);
                expect(newStudents.length).toBe(addedStudentsCount);
            });
        })

        async.it("and list students in the database after add", function (done) {

            mongoDB.listDocuments('universitysystem', 'Student', function (data) {
                for (var i = 0; i < data.length; i++) {
                    var studs = new universitySystem.Student(data[i]._id, data[i].firstName, data[i].lastName, data[i].email, data[i].address, data[i].city, data[i].phoneNumber, data[i].age);
                    students.push(studs);
                    studentsCountAfterAdd++;
                }

                done();

                expect(studentsCountBeforeAdd).toBe(studentsCountAfterAdd - addedStudentsCount);
                expect(students.length).toBe(studentsCountAfterAdd);
            });
        })
    })

    describe("should add one university", function () {
        var async = new AsyncSpec(this);
        
        var mongoDB = new MongoLab('KR-YVgnAgQztphU54zK9Qu-20PzjdLj5');
        var newUniversities = [];
        var universities = [];
        var expectedUniName = "SofiaUniversity";
        var addedUniCount = 0;
        var uniCountBeforeAdd = 0;
        var uniCountAfterAdd = 0;
        var universityNames = [];

        async.it("and list all universities in the database before add", function (done) {

            mongoDB.listDocuments('universitysystem', 'University', function (data) {
                for (var i = 0; i < data.length; i++) {
                    uniCountBeforeAdd++;
                }
                done();
            });
        })

        async.it("and add one university to the database", function (done) {

            functionalities.addUniversity(expectedUniName, mongoDB, function (data) {

                newUniversities.push(data);
                addedUniCount++;
                done();

                expect(newUniversities.length).toBe(addedUniCount);
                expect(addedUniCount).toBe(1);
            });
        })

        async.it("and list all universities in the database after add", function (done) {

            mongoDB.listDocuments('universitysystem', 'University', function (data) {
                for (var i = 0; i < data.length; i++) {
                    universities.push(data[i]);
                    uniCountAfterAdd++;
                    universityNames.push(universities[i].name);
                }

                done();

                expect(uniCountBeforeAdd).toBe(uniCountAfterAdd - addedUniCount);
            });
        })

        async.it("and check that university names are correct", function (done) {
            var nameFound = false;

            for (var i = 0; i < universityNames.length; i++) {

                if (universityNames[i] === expectedUniName) {
                    nameFound = true;
                    break;
                }
            }

            done();
            expect(nameFound).toBeTruthy();
        })
    })

    describe("should add five universities", function () {
        var async = new AsyncSpec(this);
        
        var mongoDB = new MongoLab('KR-YVgnAgQztphU54zK9Qu-20PzjdLj5');
        var newUniversities = [];
        var universities = [];
        var expectedUniNames = ["SofiaUniversity", "TU-Sofia", "Stanford", "Berkley", "NBU"];
        var universitiesToAddCount = 5;
        var addedUniCount = 0;
        var uniCountBeforeAdd = 0;
        var uniCountAfterAdd = 0;
        var universityNames = [];

        async.it("and list all universities in the database before add", function (done) {

            mongoDB.listDocuments('universitysystem', 'University', function (data) {
                for (var i = 0; i < data.length; i++) {
                    uniCountBeforeAdd++;
                }
                done();
            });
        })

        async.it("and add five universities to the database", function (done) {

            var expected = 0;

            functionalities.addUniversity(expectedUniNames[0], mongoDB, function (data) {

                newUniversities.push(data);
                addedUniCount++;
                expected++;
                done();

                expect(newUniversities.length).toBe(addedUniCount);
                expect(addedUniCount).toBe(expected);

            });


            functionalities.addUniversity(expectedUniNames[1], mongoDB, function (data) {

                newUniversities.push(data);
                addedUniCount++;
                expected++;
                done();

                expect(newUniversities.length).toBe(addedUniCount);
                expect(addedUniCount).toBe(expected);

            });


            functionalities.addUniversity(expectedUniNames[2], mongoDB, function (data) {

                newUniversities.push(data);
                addedUniCount++;
                expected++;
                done();

                expect(newUniversities.length).toBe(addedUniCount);
                expect(addedUniCount).toBe(expected);

            });

            functionalities.addUniversity(expectedUniNames[3], mongoDB, function (data) {

                newUniversities.push(data);
                addedUniCount++;
                expected++;
                done();

                expect(newUniversities.length).toBe(addedUniCount);
                expect(addedUniCount).toBe(expected);

            });
            
            functionalities.addUniversity(expectedUniNames[4], mongoDB, function (data) {

                newUniversities.push(data);
                addedUniCount++;
                expected++;
                done();

                expect(newUniversities.length).toBe(addedUniCount);
                expect(addedUniCount).toBe(expected);

            });
        })

        async.it("and list all universities in the database after add", function (done) {

            mongoDB.listDocuments('universitysystem', 'University', function (data) {
                for (var i = 0; i < data.length; i++) {
                    universities.push(data[i]);
                    universityNames.push(universities[i].name);
                    uniCountAfterAdd++;
                }

                done();

                expect(uniCountBeforeAdd).toBe(uniCountAfterAdd - addedUniCount);
                expect(addedUniCount).toBe(universitiesToAddCount);
            });
        })

        async.it("and check that university names are correct", function (done) {
            var name1Found = false;
            var name2Found = false;
            var name3Found = false;
            var name4Found = false;
            var name5Found = false;

            for (var i = 0; i < universityNames.length; i++) {
                if (universityNames[i] === expectedUniNames[0]) {
                    name1Found = true;
                }
                else if (universityNames[i] === expectedUniNames[1]) {
                    name2Found = true;
                }
                else if (universityNames[i] === expectedUniNames[2]) {
                    name3Found = true;
                }
                else if (universityNames[i] === expectedUniNames[3]) {
                    name4Found = true;
                }
                else if (universityNames[i] === expectedUniNames[4]) {
                    name5Found = true;
                }
            }

            done();
            expect(name1Found).toBeTruthy();
            expect(name2Found).toBeTruthy();
            expect(name3Found).toBeTruthy();
            expect(name4Found).toBeTruthy();
            expect(name5Found).toBeTruthy();
        })
    })
})