/// <reference path="libs/_references.js" />


(function () {
    var data = persisters.get("api/");
    vmFactory.setPersister(data);

    var appLayout = new kendo.Layout('<div id="main-content"></div>');
    var navLayout = new kendo.Layout('<div id="navigation"></div>');
    var userLayout = new kendo.Layout('<div id="actions"></div>');
    var navRendered = false;
    var actionsRendered = false;

    var initNav = function () {
        viewFactory.getNavView().then(function (nav) {
            var view = new kendo.View(nav);
            navLayout.showIn("#navigation", view);
        });

        navRendered = true;
    };

    var initUserActions = function () {
        viewFactory.getUserActionsView().then(function (actions) {
            var vm = vmFactory.getUserActionsVm(function () {
                router.navigate("/login");
            });
            var view = new kendo.View(actions, { model: vm });
            userLayout.showIn("#actions", view);
        });

        actionsRendered = true;
    };

    var showNavAndActions = function () {
        $("#main-navigation").show();
        $("#user-actions").show();

        if (!navRendered) {
            initNav();
        }

        if (!actionsRendered) {
            initUserActions();
        }
    }

    var hideNavAndActions = function () {
        $("#main-navigation").hide();
        $("#user-actions").hide();
    }

    var username = localStorage.displayName;
    if (username === undefined) {
        username = "No Name";
    }
    var username = function () {
        var username = localStorage.displayName;
        if (username === undefined) {
            username = "No Name";
        }
        return username;
    };
    var router = new kendo.Router();
    router.route("/", function () {
        if (data.users.isLogged()) {
            //$("#main-content").html("<p>" + data.users.currentUser() + "</p>")
            router.navigate("/home");
        } 
        else {
            router.navigate("/login");
        }
    });

    router.route("/login", function () {
        hideNavAndActions();

        viewFactory.getLoginView().then(function (loginViewHtml) {
            var loginVm = vmFactory.getLoginVM(
                function () {
                    router.navigate("/home");
                });
            var view = new kendo.View(loginViewHtml,
                { model: loginVm });
            appLayout.showIn("#main-content", view)
        });

        if (data.users.isLogged()) {
            router.navigate("/home");
        }
    });

    router.route("/home", function () {


        var logoutVm = vmFactory.getLogoutVm(
               function () {
                   router.navigate("/login");
               });
        viewFactory.getHome().then(function (home) {
            var logoutVm = vmFactory.getLogoutVm(
               function () {
                   router.navigate("/login");
               });
            var view = new kendo.View(home,
                { model: logoutVm });
            appLayout.showIn("#main-content", view)
        });

        if (!data.users.isLogged()) {
            router.navigate("/login");
        }
        else {
            router.navigate("/morgues");
        }
    });

    router.route("/morgues", function () {
        showNavAndActions();

        viewFactory.getDonchoMorgue()
            .then(function (morguesHtml) {
                vmFactory.getDonchoMorguesVM()
                .then(function (vmMorgues) {
                    var view = 
                        new kendo.View(morguesHtml,
                    { model: vmMorgues })
                    appLayout.showIn("#main-content", view);
                    $("#user").html("user:" + "<strong>" + username() + "</strong>");
                });
            });

        if (!data.users.isLogged()) {
            router.navigate("/login");
        }
    });

    router.route("/morgues/:id", function (id) {
        showNavAndActions();

        viewFactory.getParticularMorgueView()
        .then(function (particularMorgueHtml) {
            vmFactory.getParticularMorgueVM(id)
            .then(function (vmParticularMorgue) {
                console.log(vmParticularMorgue);
                var view =
                    new kendo.View(particularMorgueHtml,
                    { model: vmParticularMorgue });
                appLayout.showIn("#main-content", view);
                $("#user").html("user:" + "<strong>" + username() + "</strong>");
            })
        });

        if (!data.users.isLogged()) {
            router.navigate("/login");
        }
    });

    router.route("/auto-parts", function () {
        showNavAndActions();


        viewFactory.getPartsView()
            .then(function (partsHTML) {
                vmFactory.getPartsVM()
                    .then(function (partsVM) {
                        var view =
                 new kendo.View(partsHTML,
                 { model: partsVM });

                        appLayout.showIn("#main-content", view);
                    });
            });

        if (!data.users.isLogged()) {
            router.navigate("/login");
        }
    });

    router.route("/auto-parts/:id", function (id) {
        showNavAndActions();

        viewFactory.getParticularPartView()
        .then(function (particularPartHtml) {
            vmFactory.getParticularPartVM(id)
            .then(function (vmParticularPart) {
                console.log(vmParticularPart);
                var view =
                    new kendo.View(particularPartHtml,
                    { model: vmParticularPart });
                appLayout.showIn("#main-content", view);
                $("#user").html("user:" + "<strong>" + username() + "</strong>");
            })
        });

        if (!data.users.isLogged()) {
            router.navigate("/login");
        }
    });

    router.route("/locations", function () {
        showNavAndActions();

        viewFactory.getLocationsView()
            .then(function (locationsHtml) {
                vmFactory.getLocationsVm()
                .then(function (locationsVm) {
                    var view =
                        new kendo.View(locationsHtml,
                    { model: locationsVm })
                    appLayout.showIn("#main-content", view);
                });
            });

        if (!data.users.isLogged()) {
            router.navigate("/login");
        }
    });

    router.route("/location/:city", function (city) {
        showNavAndActions();

        viewFactory.getMorguesByLocationView()
            .then(function (morguesHtml) {
                vmFactory.getMorgueByLocationVm(city)
                .then(function (vmMorgues) {
                    var view =
                        new kendo.View(morguesHtml,
                    { model: vmMorgues });

                    appLayout.showIn("#main-content", view);
                });
            });

        if (!data.users.isLogged()) {
            router.navigate("/login");
        }
    });

    //    });
    $(function () {
        appLayout.render("#app");
        navLayout.render("#main-navigation");
        userLayout.render("#user-actions");
        router.start(); 
    });
}());