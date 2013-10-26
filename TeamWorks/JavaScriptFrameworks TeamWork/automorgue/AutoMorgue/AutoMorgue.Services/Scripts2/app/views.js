/// <reference path="../libs/_references.js" />

var viewFactory = (function () {
    var rootUrl = "Scripts2/partials/"
    var templates = {};
    function getTemplate(name) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates[name]) {
                resolve(templates[name])
            }
            else {
                $.ajax({
                    url: rootUrl + name + ".html",
                    type: "GET",
                    success: function (templateHtml) {
                        templates[name] = templateHtml;
                        resolve(templateHtml);
                    },
                    error: function (err) {
                        reject(err)
                    }
                });
            }
        });
        return promise;
    }

    function getLoginView() {
        return getTemplate("login-form");
       
    };
    function getNav() {
        return getTemplate("nav");
    };

    function getUserActions() {
        return getTemplate("user-actions");
    };

    function getHome() {
        return getTemplate("home");
    };

    function getActions() {
        return getTemplate("user-actions");
    };

    function getLogoutView() {
        return getTemplate("home");
    };

    function getLocationsView() {
        return getTemplate("locations");
    };

    //THIS IS WITH WHAT WE WOKING FOR THE MOMENT
    function getDonchoMorguesView() {
         return getTemplate("morgues")
    }

    function getMorguesByLocationView() {
        return getTemplate("morgues-location");
    }

    function getParticularMorgueView() {
        return getTemplate("ParticularMorgue")
    }

    function getParticularPartView() {
        return getTemplate("ParticularPart")
    }

    function getPartsView() {
        return getTemplate("Parts")
    }
    return {
        getMorguesByLocationView: getMorguesByLocationView,
        getLoginView: getLoginView,
        getActionsView: getActions,
        getNavView: getNav,
        getUserActionsView: getUserActions,
        getLogoutView:getLogoutView,
        getHome: getHome,
        getDonchoMorgue: getDonchoMorguesView,
        getParticularMorgueView: getParticularMorgueView,
        getPartsView: getPartsView,
        getLocationsView: getLocationsView,
        getParticularPartView: getParticularPartView
    }
}());