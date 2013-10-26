/// <reference path="../Scripts/jasmine.js"/>
/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"/>
/// <reference path="../Scripts/kendo.custom.min.js"/>
/// <reference path="../Scripts/University.js"/>

describe("Teacher tests", function () {
    var teacher;

    afterEach(function () {
        teacher = null;
    })

    it("Should initialize Teacher properly", function () {
        var expectedId = "9204148040";
        var expectedFirstName = "Petar";
        var expectedLastName = "Petrov";
        var expectedEMail = "petar@gmail.com";
        var expectedAddress = "Mladost";
        var expectedCity = "Sofia";
        var expectedPhoneNumber = "0895234123";
        var expectedAge = 20;
        var expectedFullName = expectedFirstName + " " + expectedLastName;
        teacher = new universitySystem.Teacher(
            expectedId,
            expectedFirstName,
            expectedLastName,
            expectedEMail,
            expectedAddress,
            expectedCity,
            expectedPhoneNumber,
            expectedAge);
        expect(teacher.firstName).toBe(expectedFirstName);
        expect(teacher.lastName).toBe(expectedLastName);
        expect(teacher.email).toBe(expectedEMail);
        expect(teacher.address).toBe(expectedAddress);
        expect(teacher.city).toBe(expectedCity);
        expect(teacher.phoneNumber).toBe(expectedPhoneNumber);
        expect(teacher.age).toBe(expectedAge);
    });

    it("Should return proper full name", function () {
        var expectedId = "9204148040";
        var expectedFirstName = "Petar";
        var expectedLastName = "Petrov";
        var expectedEMail = "petar@gmail.com";
        var expectedAddress = "Mladost";
        var expectedCity = "Sofia";
        var expectedPhoneNumber = "0895234123";
        var expectedAge = 20;
        var expectedFullName = expectedFirstName + " " + expectedLastName;
        teacher = new universitySystem.Teacher(
            expectedId,
            expectedFirstName,
            expectedLastName,
            expectedEMail,
            expectedAddress,
            expectedCity,
            expectedPhoneNumber,
            expectedAge);
        expect(teacher.fullname()).toBe(expectedFullName);
    })

    it("Should return proper workload in first case", function () {
        teacher = new universitySystem.Teacher();
        expect(teacher.hours).toBe(20);
        expect(teacher.workLoad()).toBe(20);
    });

    it("Should return proper workload in second case", function () {
        teacher = new universitySystem.Teacher();
        teacher.hours = 50;
        expect(teacher.hours).toBe(50);
        expect(teacher.workLoad()).toBe(70);
    });

    it("Should be able to change faculty number properly", function () {
        teacher = new universitySystem.Teacher();
        var expectedFacultyNumber = "921445111";
        teacher.facultyNumber = expectedFacultyNumber
        expect(teacher.facultyNumber).toBe(expectedFacultyNumber);
        expectedFacultyNumber = "536143114";
        teacher.facultyNumber = expectedFacultyNumber;
        expect(teacher.facultyNumber).toBe(expectedFacultyNumber);
    });

    it("Should be able to change specialty properly", function () {
        teacher = new universitySystem.Teacher();
        var expectedSpecialty = "Math";
        teacher.speciality = expectedSpecialty
        expect(teacher.speciality).toBe(expectedSpecialty);
        expectedSpecialty = "Biology";
        teacher.speciality = expectedSpecialty;
        expect(teacher.speciality).toBe(expectedSpecialty);
    });
})