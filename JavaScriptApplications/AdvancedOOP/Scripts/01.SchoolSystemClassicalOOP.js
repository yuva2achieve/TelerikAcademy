if (!Object.create) {
    Object.create = function (obj) {
        function f() { };
        f.prototype = obj;
        return new f();
    }
}

var classicalSchoolSystemNS = (function () {
    "use strict";

    var School = function (name, town) {
        this.name = name;
        this.town = town;
        this.classes = [];
        this.addClass = function (schoolClass) {
            this.classes.push(schoolClass);
        }

        return this;
    }
    
    var SchoolClass = function (name, teacher) {
        this.name = name;
        this.teacher = teacher;
        this.students = [];
        this.addStudent = function (student) {
            this.students.push(student);
        }

        return this;
    }

    var SchoolPerson = function (fname, lname, age) {
        this.firstName = fname;
        this.lastName = lname;
        this.age = age;
        this.introduce = function () {
            return "Name: " + this.firstName + " " + this.lastName + ", Age: " + this.age;
        }

        return this;
    }

    var Student = function (fname, lname, age, grade) {
        SchoolPerson.call(this, fname, lname, age);
        this.grade = grade;
        this.introduce = function () {
            return new SchoolPerson(fname,lname,age).introduce() + ", Grade: " + this.grade;
        }

        return this;
    }

    Student.prototype = Object.create(SchoolPerson.prototype);

    var Teacher = function (fname, lname, age, specialty) {
        SchoolPerson.call(this, fname, lname, age);
        this.specialty = specialty;
        this.introduce = function () {
            return new SchoolPerson(fname, lname, age).introduce() + ", Specialty: " + this.specialty;
        }

        return this;
    }

    Teacher.prototype = Object.create(SchoolPerson.prototype);

    return {
        School: School,
        SchoolClass: SchoolClass,
        Student: Student,
        Teacher: Teacher
    }
}());