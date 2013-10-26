var functionalities = (function () {

    // for cycle for addStudents
    var addStudents = function (studentsCount, studentNames, cityNames, mongoDB, callbackAddStudents) {

        for (var i = 0; i < studentsCount; i += 1) {

            var randomIndex = getRandomInt(0, studentNames.length);

            var newStudent = new universitySystem.Student();
            var randomName = studentNames[randomIndex].Name.split(" ");

            newStudent.firstName = randomName[0];

            randomIndex = getRandomInt(0, studentNames.length);
            randomName = studentNames[randomIndex].Name.split(" ");
            newStudent.lastName = randomName[2];

            randomIndex = getRandomInt(0, cityNames.length);
            newStudent.city = cityNames[randomIndex].Name;

            newStudent.email = '';
            newStudent.address = '';
            newStudent.facultyNumber = '';
            newStudent.phoneNumber = '';

            newStudent.age = getRandomInt(20, 30);

            mongoDB.insertDocuments('universitysystem', 'Student', newStudent, callbackAddStudents);
        }
    }
    //Randomizer
    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min)) + min;
    }

    // add university         
    var addUniversity = function (nameOfUniversity, mongoDB, callbackAddUniversity) {
        var newUniversity = new universitySystem.University(nameOfUniversity);
        mongoDB.insertDocuments('universitysystem', 'University', newUniversity, callbackAddUniversity);
    };

    return {
        addStudents: addStudents,
        addUniversity: addUniversity
    };
}());