/// <reference path="../Scripts/jasmine.js"/>
/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"/>
/// <reference path="../Scripts/kendo.custom.min.js"/>
/// <reference path="../Scripts/University.js"/>

describe("University tests", function () {
    var university;

    afterEach(function () {
        university = null;
    })

    it("Should initialize University properly", function () {
        var expectedLatitude = 30;
        var expectedLongtitude = 15;
        var expectedName = "Harvard";
        university = new universitySystem.University(expectedName, expectedLatitude, expectedLongtitude);
        expect(university.name).toBe(expectedName);
        expect(university.latitude).toBe(expectedLatitude);
        expect(university.longitude).toBe(expectedLongtitude);
    })

    it("Should be able to change university name properly", function () {
        university = new universitySystem.University();
        var expectedName = "Harvard";
        university.name = expectedName;
        expect(university.name).toBe(expectedName);
        expectedName = "Berkley";
        university.name = expectedName;
        expect(university.name).toBe(expectedName);
    })
})