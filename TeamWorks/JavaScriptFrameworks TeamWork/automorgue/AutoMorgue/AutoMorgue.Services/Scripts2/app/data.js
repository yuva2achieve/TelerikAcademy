/// <reference path="../libs/_references.js" />

window.persisters = (function () {

    if (localStorage.getItem("sessionKey") != null || localStorage.getItem("displayName") != null) {
        var sessionKey = localStorage.getItem("sessionKey");
        var displayName = localStorage.getItem("displayName");
    } else {
        var sessionKey = "";
        var displayName = "";
    }

    function getJSON(requestUrl, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "GET",
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function postJSON(requestUrl, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify(data),
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function putJSON(requestUrl, headers, data) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "PUT",
                contentType: "application/json",
                dataType: "json",
                headers: headers,
                data: JSON.stringify(data),
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    var UserPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        login: function (username, password) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };
            return postJSON(this.apiUrl + "login", user).
                then(function (data) {
                    sessionKey = data.sessionKey;
                    displayName = data.displayName;
                    localStorage.setItem("displayName", displayName);
                    localStorage.setItem("sessionKey", sessionKey);
                    return data.displayName;
                });
        },
        register: function (username, password, displayName) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString(),
                displayName: displayName
            };

            return postJSON(this.apiUrl + "register", user).
              then(function (data) {
                  sessionKey = data.sessionKey;
                  displayName = data.displayName;
                  localStorage.setItem("displayName", displayName);
                  localStorage.setItem("sessionKey", sessionKey);
                  return data.displayName;
              });
        },
        logout: function () {

            if (!sessionKey) {
                alert("NO SESSION KEY")
            } else {

                var headers = {
                    "X-sessionKey": sessionKey
                }
                return putJSON(this.apiUrl + "logout", headers).
                    then(function (data) {
                        sessionKey = null;
                        displayName = null;
                        localStorage.removeItem("sessionKey");
                        localStorage.removeItem("displayName");
                        return sessionKey;
                    }, function () {
                        alert("error")
                    });
            }
        },
        isLogged: function () {
            if (localStorage.getItem("sessionKey") == null) {
                return false;
            }
            return true;
        },
        currentUser: function () {
            return displayName;
        }
    });
    
    var MorguesPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        all: function () {
            //console.log(this.apiUrl);
            return getJSON(this.apiUrl + "/All");
        },

        particular: function (id) {
            return getJSON(this.apiUrl + "?morgueId=" + id);
        },

        getByLocation: function (location) {
            return getJSON(this.apiUrl + "/GetByLocation?location=" + location);
        },

        getLocations: function () {
            return getJSON(this.apiUrl + "/locations");
        }
    });

    var PartsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        all: function () {
            return getJSON(this.apiUrl + "All");
        },

        particular: function (id) {
            return getJSON(this.apiUrl + "GetById?autoPartId=" + id);
        },

        sale: function (part) {
            var headers = {
                "X-sessionKey": sessionKey
            }

            var data = {
                Id: part.Id,
                Quantity: part.Quantity - 1
            };

            return putJSON(this.apiUrl + "sale", headers, data);
        }
    });

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UserPersister(apiUrl + "users/");
            this.morgues = new MorguesPersister(apiUrl + "morgues");
            this.parts = new PartsPersister(apiUrl + "autoparts/");
        }

    });

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());