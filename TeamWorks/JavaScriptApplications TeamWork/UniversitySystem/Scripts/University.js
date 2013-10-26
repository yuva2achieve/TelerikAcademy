var universitySystem = (function () {

    //class CityName
    var CityName = kendo.Class.extend({
        cityID: '',
        name: '',
        init: function (cityID, name) {
            if (cityID) {
                this._Id = cityID;
            }
            if (name) {
                this.name = name;
            }
        }
    });
    
    //class CityName
    var ContactData = kendo.Class.extend({
        _id: '',
        firstName: '',
        lastName: '',
        email: '',
        address: '',
        city: '',
        phoneNumber: '',
        age: '',

        init: function (_id, firstName, lastName, email, address, city,phoneNumber, age) {

            if (_id) {
                this._id = _id;
            }
            if (firstName){
                this.firstName = firstName;
            }
            if (lastName) {
                this.lastName = lastName;
            }
            if (email) {
                this.email = email;
            }
            if (address) {
                this.address = address;
            }
            if (city) {
                this.city = city;
            }
            if (phoneNumber) {
                this.phoneNumber = phoneNumber;
            }
            if (age) {
                this.age = age;
            }

        }
    });

    //class UniversityPerson
    var UniversityPerson = ContactData.extend({
        hours: 20,
        fullname: function () {
            return this.firstName + " " + this.lastName;
        }
    });

    //this is tha maximmum working hours per week
    var requestHoursPerWeek = 40;

    //class Student
    var Student = UniversityPerson.extend({
        facultyNumber: '',
        speciality: '',
        workLoad: function() {
            return (requestHoursPerWeek - this.hours > 0 ? requestHoursPerWeek - this.hours : 0);
        }
    });

    //class Assistant
    var Assistant = UniversityPerson.extend({
        workLoad: function () {
            return this.hours;
        }
    });
    
    //class Teacher
    var Teacher = UniversityPerson.extend({
        workLoad: function() {
            return (requestHoursPerWeek - this.hours > 0 ? this.hours : this.hours + ((this.hours - requestHoursPerWeek) * 2));
        }
    });
    
    //class GeoLocation
    var GeoLocation = kendo.Class.extend({
        latitude: '',
        longitude: '',

        init: function (latitude, longitude) {
            if (latitude) {
                this.latitude = latitude;
            }
            if (longitude) {
                this.longitude = longitude;
            }
        }
    });
    
    //class University
    var University = GeoLocation.extend({
        name: '',
        init: function(name, latitude, longtitude)
        {
            if (name) {
                this.name = name;
            }
            GeoLocation.fn.init.call(this, latitude, longtitude);
        }
    });
    
    //class UserProfile 
    var UserProfile = ContactData.extend({
        password: '',
        userName: ''
    });
    


    return {
       ContactData: ContactData,
       Student: Student,
       Assistant: Assistant,
       Teacher: Teacher,
       UserProfile: UserProfile,
       University: University,
       GeoLocation: GeoLocation
    };
}());