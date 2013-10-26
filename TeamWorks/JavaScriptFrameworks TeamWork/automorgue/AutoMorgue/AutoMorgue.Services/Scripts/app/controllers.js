/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/sha1.js" />


var Controllers = (function () {

    'use strict';

    var baseAPIUrl = "/api/";
    var currentNickname = localStorage.getItem("displayName");
    var currentSessionKey = localStorage.getItem("sessionKey");

    function setLocalStorageInfo(displayName, sessionKey) {
        localStorage.setItem("displayName", displayName);
        localStorage.setItem("sessionKey", sessionKey);
    };

    function clearLocalStorageInfo() {
        localStorage.removeItem("displayName");
        localStorage.removeItem("sessionKey");
    };

    function hideErrorContainer() {
        $("#error-container").hide();
    };

    function isLoggedIn() {
        currentNickname = localStorage.getItem("displayName");
        currentSessionKey = localStorage.getItem("sessionKey");
        
        var isLogged = currentNickname != null && currentSessionKey != null;
        return isLogged;
    };

    function HomeController() {
    
        if (isLoggedIn()) {

            document.location = "#/users/" + currentNickname;
        }
    }

    function LoginController($scope, $http) {

        hideErrorContainer();

        $scope.loginUser = function () {
            var username = $("#inputUsername").val();
            var password = $("#inputPassword").val();
            var authCode = CryptoJS.SHA1(username + password).toString();

            $scope.userLogin = {
                username: username,
                authCode: authCode
            };

            $http.post(baseAPIUrl + 'users/login', $scope.userLogin).success(function (data) {
                setLocalStorageInfo(data.displayName, data.sessionKey);
                currentNickname = localStorage.getItem("displayName");
                currentSessionKey = localStorage.getItem("sessionKey");
                document.location = "#/users/" + currentNickname;
            }).error(function (err) {
                $("#error-container #error-message").text(err.Message);
                $("#error-container").show();
            });
        }
    }

    function RegisterController($scope, $http) {
        $scope.registerUser = function () {
            var username = $("#inputUsername").val();
            var displayName = $("#inputNickname").val();
            var password = $("#inputPassword").val();
            var authCode = CryptoJS.SHA1(username + password).toString()

            $scope.userRegister = {
                username: username,
                displayName: displayName,
                authCode: authCode
            };

            $http.post(baseAPIUrl + 'admin/register', $scope.userRegister).success(function (data) {
                setLocalStorageInfo(data.displayName, data.sessionKey);
                currentNickname = localStorage.getItem("displayName");
                currentSessionKey = localStorage.getItem("sessionKey");
                document.location = "#/users/" + currentNickname;
            }).error(function (err) {
                $("#error-container #error-message").text(err.Message);
                $("#error-container").show();
            });
        }
    }

    function LoggedInController($scope, $routeParams, $http) {

        hideErrorContainer();

        $scope.nickname = $routeParams.nickname;

        $scope.logoutUser = function () {
            $http({
                url: baseAPIUrl + 'users/logout',
                method: "PUT",
                headers: { 'Content-Type': 'application/json', 'X-sessionKey': currentSessionKey }
            }).success(function (data, status, headers, config) {
                clearLocalStorageInfo();
                currentNickname = localStorage.getItem("nickname");
                currentSessionKey = localStorage.getItem("sessionKey");
                document.location = "#/home";
            }).error(function (data, status, headers, config) {
                console.log("Logout Error!");
            });
        }

        if (!isLoggedIn() || currentNickname != $scope.nickname) {

            document.location = "#/login";
        }
    }


    function CreateMorgueController($scope, $http) {

        hideErrorContainer();

        $scope.createMorgue = function () {
            var morgueName = $("#inputMorgueName").val();
            var morgueLocation = $("#inputLocation").val();
            var morguePhoneNumber = $("#inputPhoneNumber").val();
            var morgueWorkTime = $("#inputWorkTime").val();

            var morgue = {
                Name: morgueName,
                Location: morgueLocation,
                PhoneNumber: morguePhoneNumber,
                WorkTime: morgueWorkTime
            };

            $http({
                url: baseAPIUrl + 'morgues/add',
                method: "POST",
                data: morgue,
                headers: { 'Content-Type': 'application/json', 'X-sessionKey': currentSessionKey }
            }).success(function (data, status, headers, config) {
                document.location = "#/morgues/all";
            }).error(function (data, status, headers, config) {
                $("#error-container #error-message").text(err.Message);
                $("#error-container").show();
            });
        }

        if (!isLoggedIn()) {

            document.location = "#/login";
        }
    }

    function ViewMorguesController($scope, $http) {

        $http.get(baseAPIUrl + 'morgues/All').success(function (data) {
            $scope.morgues = data;
        }).error(function (err) {
            console.log(err);
        });
    }

    function ViewMorguesByLocation($scope, $http, $routeParams) {

        var locationName = $routeParams.locationName;

        $http.get(baseAPIUrl + 'morgues/GetByLocation?location=' + locationName).success(function (data) {
            $scope.morgues = data;
        }).error(function (err) {
            console.log(err);
        });
    }

    function ListAutoPartsByMorgueId($scope, $http, $routeParams) {

        var morgueId = $routeParams.morgueId;

        $http.get(baseAPIUrl + 'autoparts/GetByMorgueId?morgueId=' + morgueId).success(function (data) {
            $scope.autoparts = data;
        }).error(function (err) {
            console.log(err);
        });
    }

    function ListMorgueLocations($scope, $http) {

        $http.get(baseAPIUrl + 'morgues/locations').success(function (data) {
            $scope.locations = data;
        }).error(function (err) {
            console.log(err);
        });
    }

    function ListAutoPartsCategory($scope, $http, $routeParams) {

        var categoryName = $routeParams.categoryName;

        $http.get(baseAPIUrl + 'autoparts/GetByCategory?categoryName=' + categoryName).success(function (data) {
            $scope.autoparts = data;
        }).error(function (err) {
            console.log(err);
        });
    }

    function AddAutoPart($scope, $http) {

        hideErrorContainer();

        $scope.createAutoPart = function () {

            var autoPartMorgueName = $("#inputMorgueName").val();
            var autoPartQuantity = $("#inputQuantity").val();
            var autoPartPrice = $("#inputPrice").val();
            var autoPartCategory = $("#inputCategory").val();
            var autoPartName = $("#inputName").val();

            var autoPart = {
                Morgue: autoPartMorgueName,
                Quantity: autoPartQuantity,
                Price: autoPartPrice,
                Category: autoPartCategory,
                Name: autoPartName
            };
        
            $http({
                url: baseAPIUrl + 'autoparts/add',
                method: "POST",
                data: autoPart,
                headers: { 'Content-Type': 'application/json', 'X-sessionKey': currentSessionKey }
            }).success(function (data, status, headers, config) {
                document.location = "#/autoparts/all";
            }).error(function (data, status, headers, config) {
                $("#error-container #error-message").text(err.Message);
                $("#error-container").show();
            });
        }

        if (!isLoggedIn()) {

            document.location = "#/login";
        }
    }

    function ViewAutoPartsController($scope ,$http) {
        $http.get(baseAPIUrl + 'autoparts/All').success(function (data) {
            $scope.autoparts = data;
        }).error(function (err) {
            console.log(err);
        });
    }

    function EditAutoPart($scope, $http, $routeParams) {

        hideErrorContainer();

        var autoPartId = $routeParams.partId;

        $scope.updateAutoPart = function () {

            var autoPartMorgueName = $("#inputMorgueName").val();
            var autoPartQuantity = $("#inputQuantity").val();
            var autoPartPrice = $("#inputPrice").val();
            var autoPartCategory = $("#inputCategory").val();
            var autoPartName = $("#inputName").val();

            var autoPart = {
                Id: autoPartId,
                Morgue: autoPartMorgueName,
                Quantity: autoPartQuantity,
                Price: autoPartPrice,
                Category: autoPartCategory,
                Name: autoPartName
            };

            $http({
                url: baseAPIUrl + 'autoparts/update',
                method: "PUT",
                data: autoPart,
                headers: { 'Content-Type': 'application/json', 'X-sessionKey': currentSessionKey }
            }).success(function (data, status, headers, config) {
                document.location = "#/autoparts/all";
            }).error(function (data, status, headers, config) {
                $("#error-container #error-message").text(err.Message);
                $("#error-container").show();
            });
        }

        if (!isLoggedIn()) {

            document.location = "#/login";
        }
    }

    function ListUsersController($scope, $http) {

        if (!isLoggedIn()) {

            document.location = "#/login";
        }

        $http.get(baseAPIUrl + 'users/All').success(function (data) {
            $scope.users = data;
        }).error(function (err) {
            console.log(err);
        });
    }

    function DeleteUserController($scope, $http, $routeParams) {
        var userID = $routeParams.userId;
        $scope.deleteUser = function myfunction() {

            $http({
                url: baseAPIUrl + 'admin/deleteUser?userId=' + userID,
                method: "DELETE",
                headers: { 'Content-Type': 'application/json', 'X-sessionKey': currentSessionKey }
            }).success(function (data, status, headers, config) {
                document.location = "#/users/all";
            }).error(function (data, status, headers, config) {
                console.log(err);
            });
        }
    }

    return {
        HomeController: HomeController,
        LoginController: LoginController,
        RegisterController: RegisterController,
        LoggedInController: LoggedInController,
        CreateMorgueController: CreateMorgueController,
        ViewMorguesController: ViewMorguesController,
        ListMorgueLocations: ListMorgueLocations,
        ViewMorguesByLocation: ViewMorguesByLocation,
        ViewAutoPartsController: ViewAutoPartsController,
        ListAutoPartsByMorgueId: ListAutoPartsByMorgueId,
        ListAutoPartsCategory: ListAutoPartsCategory,
        ListUsersController: ListUsersController,
        DeleteUserController: DeleteUserController,
        AddAutoPart: AddAutoPart,
        EditAutoPart: EditAutoPart
    }
}());