if (!Object.create) {
    Object.create = function (obj) {
        function f() { };
        f.prototype = obj;
        return new f();
    }
}

if (!Object.prototype.extend) {
    Object.prototype.extend = function (properties) {
        function f() { };
        f.prototype = Object.create(this);
        for (var prop in properties) {
            f.prototype[prop] = properties[prop];
        }
        f.prototype._super = this;
        return new f();
    }
}

var prototypeSchoolSystemNS = (function () {
    "use strict";

    var School = {
        name: '',
        town: '',
        classes: [],
        init: function (name, town) {
            this.name = name;
            this.town = town;
            this.classes = [];
        },

        addClass: function (studentClass) {
            this.classes.push(studentClass);
        }
    }

    var SchoolClass = {
        name: '',
        teacher: '',
        students: [],
        init: function (name, teacher) {
            this.name = name;
            this.teacher = teacher;
            this.students = [];
        },
        addStudent: function (student) {
            this.students.push(student);
        },
    };

    var SchoolPerson = {
        firstName: '',
        lastName: '',
        age: '',
        init: function (fname, lname, age) {
            this.firstName = fname;
            this.lastName = lname;
            this.age = age;
        },
        introduce: function () {
            return "Name: " + this.firstName + " " + this.lastName + ", Age: " + this.age;
        }
    }

    var Student = SchoolPerson.extend({
        grade: '',
        init: function (fname, lname, age, grade) {
            SchoolPerson.init.call(this, fname, lname, age);
            this.grade = grade;
        },
        introduce: function () {
            return SchoolPerson.introduce.call(this) + ", Grade: " + this.grade;
        }
    })

    var Teacher = SchoolPerson.extend({
        specialty: '',
        init: function (fname, lname, age, specialty) {
            SchoolPerson.init.call(this, fname, lname, age);
            this.specialty = specialty;
        },
        introduce: function () {
            return SchoolPerson.introduce.call(this) + ", Specialty: " + this.specialty;
        }
    })

    return {
        School: School,
        SchoolClass: SchoolClass,
        Student: Student,
        Teacher: Teacher
    }
}());