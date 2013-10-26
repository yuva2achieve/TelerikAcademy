/// <reference path="controllers.js" />
/// <reference path="../libs/angular.js" />

angular.module("autoMorgue", [])
    .config(["$routeProvider", function ($routeProvider) {
        $routeProvider.
            when('/home', { templateUrl: 'Scripts/models/homeTemplate.html', controller: Controllers.HomeController }).
            when('/login', { templateUrl: 'Scripts/models/loginTemplate.html', controller: Controllers.LoginController }).
            when('/register', { templateUrl: 'Scripts/models/registerTemplate.html', controller: Controllers.RegisterController }).
            when('/users/all', { templateUrl: 'Scripts/models/allUsersTemplate.html', controller: Controllers.ListUsersController }).
            when('/users/:nickname', { templateUrl: 'Scripts/models/loggedInTemplate.html', controller: Controllers.LoggedInController }).
            when('/users/delete/:userId', { templateUrl: 'Scripts/models/deleteUserTemplate.html', controller: Controllers.DeleteUserController }).
            when('/locations/all', { templateUrl: 'Scripts/models/allLocationsTemplate.html', controller: Controllers.ListMorgueLocations }).
            when('/morgues/create', { templateUrl: 'Scripts/models/createMorgueTemplate.html', controller: Controllers.CreateMorgueController }).
            when('/morgues/all', { templateUrl: 'Scripts/models/allMorguesTemplate.html', controller: Controllers.ViewMorguesController }).
            when('/morgues/location/:locationName', { templateUrl: 'Scripts/models/allMorguesTemplate.html', controller: Controllers.ViewMorguesByLocation }).
            when('/autoparts/add', { templateUrl: 'Scripts/models/createAutoPartTemplate.html', controller: Controllers.AddAutoPart }).
            when('/autoparts/all', { templateUrl: 'Scripts/models/autoPartsTemplate.html', controller: Controllers.ViewAutoPartsController }).
            when('/autoparts/categories/:categoryName', { templateUrl: 'Scripts/models/autoPartsTemplate.html', controller: Controllers.ListAutoPartsCategory }).
            when('/autoparts/:morgueId', { templateUrl: 'Scripts/models/autoPartsTemplate.html', controller: Controllers.ListAutoPartsByMorgueId }).
            when('/autoparts/edit/:partId', { templateUrl: 'Scripts/models/editAutoPartTemplate.html', controller: Controllers.EditAutoPart }).
            otherwise({ redirectTo: '/home' });
    }]);