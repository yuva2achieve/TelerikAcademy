/// <reference path="../Scripts/jasmine.js"/>
/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"/>
/// <reference path="../Scripts/kendo.custom.min.js"/>
/// <reference path="../Scripts/University.js"/>

describe("Geolocation tests", function () {
    var geolocation;

    afterEach(function () {
        geolocation = null;
    })

    it("Should initialize Geolocation properly", function () {
        var expectedLatitude = 30;
        var expectedLongtitude = 15;
        geolocation = new universitySystem.GeoLocation(expectedLatitude, expectedLongtitude);
        expect(geolocation.latitude).toBe(expectedLatitude);
        expect(geolocation.longitude).toBe(expectedLongtitude);
    })
})