/// <reference path="../Scripts/jasmine.js"/>
/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"/>
/// <reference path="../Scripts/kendo.custom.min.js"/>
/// <reference path="../Scripts/University.js"/>

describe("Assistant tests", function () {
    var assistant;

    afterEach(function() {
        assistant = null;
    });

    it("Should initialize Assistant properly", function () {
        var expectedId = "9204148040";
        var expectedFirstName = "Petar";
        var expectedLastName = "Petrov";
        var expectedEMail = "petar@gmail.com";
        var expectedAddress = "Mladost";
        var expectedCity = "Sofia";
        var expectedPhoneNumber = "0895234123";
        var expectedAge = 20;
        var expectedFullName = expectedFirstName + " " + expectedLastName;
        assistant = new universitySystem.Assistant(
            expectedId,
            expectedFirstName,
            expectedLastName,
            expectedEMail,
            expectedAddress,
            expectedCity,
            expectedPhoneNumber,
            expectedAge);
        expect(assistant.firstName).toBe(expectedFirstName);
        expect(assistant.lastName).toBe(expectedLastName);
        expect(assistant.email).toBe(expectedEMail);
        expect(assistant.address).toBe(expectedAddress);
        expect(assistant.city).toBe(expectedCity);
        expect(assistant.phoneNumber).toBe(expectedPhoneNumber);
        expect(assistant.age).toBe(expectedAge);
    });

    it("Should return proper full name", function() {
        var expectedId = "9204148040";
        var expectedFirstName = "Petar";
        var expectedLastName = "Petrov";
        var expectedEMail = "petar@gmail.com";
        var expectedAddress = "Mladost";
        var expectedCity = "Sofia";
        var expectedPhoneNumber = "0895234123";
        var expectedAge = 20;
        var expectedFullName = expectedFirstName + " " + expectedLastName;
        assistant = new universitySystem.Assistant(
            expectedId,
            expectedFirstName,
            expectedLastName,
            expectedEMail,
            expectedAddress,
            expectedCity,
            expectedPhoneNumber,
            expectedAge);
        expect(assistant.fullname()).toBe(expectedFullName);
    });

    it("Should return proper workload in first case", function () {
        assistant = new universitySystem.Assistant();
        expect(assistant.hours).toBe(20);
        expect(assistant.workLoad()).toBe(20);
    });

    it("Should return proper workload in second case", function () {
        assistant = new universitySystem.Assistant();
        assistant.hours = 50;
        expect(assistant.hours).toBe(50);
        expect(assistant.workLoad()).toBe(50);
    });

    it("Should be able to change faculty number properly", function () {
        assistant = new universitySystem.Assistant();
        var expectedFacultyNumber = "921445111";
        assistant.facultyNumber = expectedFacultyNumber;
        expect(assistant.facultyNumber).toBe(expectedFacultyNumber);
        expectedFacultyNumber = "536143114";
        assistant.facultyNumber = expectedFacultyNumber;
        expect(assistant.facultyNumber).toBe(expectedFacultyNumber);
    });

    it("Should be able to change specialty properly", function () {
        assistant = new universitySystem.Assistant();
        var expectedSpecialty = "Math";
        assistant.speciality = expectedSpecialty;
        expect(assistant.speciality).toBe(expectedSpecialty);
        expectedSpecialty = "Biology";
        assistant.speciality = expectedSpecialty;
        expect(assistant.speciality).toBe(expectedSpecialty);
    });
})