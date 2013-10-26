/// <reference path="view-models.js" />
/// <reference path="../libs/_references.js" />
window.vmFactory = (function () {
    var data = null;
    // var data = persisters.get("api/");
    //debugger;
    function getLoginViewModel(successCallback) {
        var viewModel = {
            username: "durvar",
            password: "durvar",
            displayName: "",
            login: function () {
                data.users.login(this.get("username"), this.get("password")).
                    then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    });
            },
            register: function () {
                data.users.register(this.get("username"), this.get("password"), this.get("displayName")).
                    then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    })
            }
        }

        return kendo.observable(viewModel);
    }

    function homePageViewMdoel(successCallback) {
        //var displayName = this.data.users.currentUser();

        var homeViewModel = {
            logout: function () {
                data.users.logout().
                    then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    },
                    function () {
                        if (successCallback) {
                            successCallback
                        }
                    });
            },
            //displayName: displayName
        }

        return kendo.observable(homeViewModel);
    };

    //THIS IS WITH WHAT WE WOKING FOR THE MOMENT
    function getDonchoMorguesViewModel() {
        return data.morgues.all()
			.then(function (morgues) {
			    var viewModel = {
			        morgues: morgues,
			        location: function (ev) {
			            var target = $(ev.currentTarget);
			            var id = target.context.id;

			            window.location.href = "IndexPage.html#/morgues/" + id;
			        }
			    };
			     
			    return kendo.observable(viewModel);
			});
    }

    function getMorguesLocationViewModel (location) {
        return data.morgues.getByLocation(location)
			.then(function (morgues) {
			    var viewModel = {
                    city: "Morgues in " + location,
			        morgues: morgues,
			        location: function (ev) {
			            var target = $(ev.currentTarget);
			            var id = target.context.id;

			            window.location.href = "IndexPage.html#/morgues/" + id;
			        }
			    };
			    return kendo.observable(viewModel);
			});
    }

    function getLocationsViewModel() {
        return data.morgues.getLocations()
			.then(function (locations) {
			    var viewModel = {
			        locations: locations,
			        goToLocation: function (ev) {
			            var target = $(ev.currentTarget);
			            var id = target.context.id;
			            
			            window.location.replace("#/location/" + id);
			        }
			    };

			    return kendo.observable(viewModel);
			});
    }

    function getPartsViewModel() {
        return data.parts.all()
			.then(function (parts) {
			    var viewModel = {
			       parts: parts,
			        getPerticularPart: function (ev) {
			            var target = $(ev.currentTarget);
			            var id = target.context.id;

			            window.location.href = "IndexPage.html#/auto-parts/" + id;
			        },
			    };
			    return kendo.observable(viewModel);
			});
    }

    function getUserActionsViewModel(successCallback) {
        var displayName = data.users.currentUser();

        var model = {
            displayName: "User: " + displayName,
            logout: function () {
                data.users.logout().then(function () {
                    if (successCallback) {
                        successCallback();
                    }
                });
            }
        }

        return kendo.observable(model);
    }

    function getParticularMorgueViewModel(id) {
        return data.morgues.particular(id)
        .then(function (particularMorgue) {
            var viewModel = {
                particularMorgue: particularMorgue,
            };

            return kendo.observable(viewModel);
        });
    }

    function getParticularPartViewModel(id) {
        return data.parts.particular(id)
        .then(function (particularPart) {
            var viewModel = {
                particularPart: particularPart,
                sale: function () {
                    var self = this;
                    var singlePart = {
                        Id: particularPart["Id"],
                        Quantity: this.get('particularPart.Quantity')
                    }
                    if (singlePart.Quantity > 0) {
                        data.parts.sale(singlePart).then(function (data) {
                            self.set('particularPart.Quantity', data["Quantity"]);
                        });
                    }
                    else {
                        alert("Noooooo!");
                    }
                },
                logout: function () {
                    data.users.logout();
                    window.location.href = "http://localhost:5887/IndexPage.html#/login";
                }
            };

            return kendo.observable(viewModel);
        });
    }

    function geSalePartViewModel(id) {
        return data.parts.particular(id)
        .then(function (particularPart) {
            var self = this;
            var viewModel = {
                particularPart: particularPart,
                sale: function () {
                    var singlePart = {
                        Id: particularPart["Id"],
                        Quantity: particularPart['Quantity']
                    }
                    data.parts.sale(singlePart).then(function (data) {
                        console.log(self.get(particularPart['Quantity'])); 
                    });
                },
                logout: function () {
                    data.users.logout();
                    window.location.href = "http://localhost:5887/IndexPage.html#/login";
                }
            };

            return kendo.observable(viewModel);
        });
    }

    return {
        getMorgueByLocationVm: getMorguesLocationViewModel,
        getLocationsVm: getLocationsViewModel,
        getLoginVM: getLoginViewModel,
        getLogoutVm: homePageViewMdoel,
        getUserActionsVm: getUserActionsViewModel,
        getParticularMorgueVM: getParticularMorgueViewModel,
        getPartsVM:getPartsViewModel,
        getDonchoMorguesVM: getDonchoMorguesViewModel,
        getParticularPartVM: getParticularPartViewModel,
        geSalePartVM: geSalePartViewModel,
        setPersister: function (persister) {
            data = persister;
        }

    }
}());