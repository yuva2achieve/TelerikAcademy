/// <reference path="../Scripts/jasmine.js"/>
/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"/>
/// <reference path="../Scripts/kendo.custom.min.js"/>
/// <reference path="../Scripts/University.js"/>

describe("Student tests", function () {
    var student;

    afterEach(function () {
        student = null;
    })

    it("Should initialize Student properly", function () {
        var expectedId = "9204148040";
        var expectedFirstName = "Petar";
        var expectedLastName = "Petrov";
        var expectedEMail = "petar@gmail.com";
        var expectedAddress = "Mladost";
        var expectedCity = "Sofia";
        var expectedPhoneNumber = "0895234123";
        var expectedAge = 20;
        var expectedFullName = expectedFirstName + " " + expectedLastName;
        student = new universitySystem.Student(
            expectedId,
            expectedFirstName,
            expectedLastName,
            expectedEMail,
            expectedAddress,
            expectedCity,
            expectedPhoneNumber,
            expectedAge);
        expect(student.firstName).toBe(expectedFirstName);
        expect(student.lastName).toBe(expectedLastName);
        expect(student.email).toBe(expectedEMail);
        expect(student.address).toBe(expectedAddress);
        expect(student.city).toBe(expectedCity);
        expect(student.phoneNumber).toBe(expectedPhoneNumber);
        expect(student.age).toBe(expectedAge);
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
        student = new universitySystem.Student(
            expectedId,
            expectedFirstName,
            expectedLastName,
            expectedEMail,
            expectedAddress,
            expectedCity,
            expectedPhoneNumber,
            expectedAge);
        expect(student.fullname()).toBe(expectedFullName);
    })

    it("Should return proper workload in first case", function () {
        student = new universitySystem.Student();
        expect(student.hours).toBe(20);
        expect(student.workLoad()).toBe(20);
    });

    it("Should return proper workload in second case", function () {
        student = new universitySystem.Student();
        student.hours = 50;
        expect(student.hours).toBe(50);
        expect(student.workLoad()).toBe(0);
    });

    it("Should be able to change faculty number properly", function () {
        student = new universitySystem.Student();
        var expectedFacultyNumber = "921445111";
        student.facultyNumber = expectedFacultyNumber
        expect(student.facultyNumber).toBe(expectedFacultyNumber);
        expectedFacultyNumber = "536143114";
        student.facultyNumber = expectedFacultyNumber;
        expect(student.facultyNumber).toBe(expectedFacultyNumber);
    });

    it("Should be able to change specialty properly", function () {
        student = new universitySystem.Student();
        var expectedSpecialty = "Math";
        student.speciality = expectedSpecialty
        expect(student.speciality).toBe(expectedSpecialty);
        expectedSpecialty = "Biology";
        student.speciality = expectedSpecialty;
        expect(student.speciality).toBe(expectedSpecialty);
    });
})