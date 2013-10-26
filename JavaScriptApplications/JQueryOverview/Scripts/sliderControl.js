/// <reference path="jquery-2.0.2.js"/>

var sliderControl = (function () {
    "use strict";

    var getSliderControl = {
        rootURL: "http://lorempixel.com/400/200/sports/",
        numberOfPictures: 10,
        currentPictureIndex: '',
        container: '',

        init: function (sliderId) {
            this.container = $(sliderId);
            this.currentPictureIndex = 1;
            var img = document.createElement("img");
            img.src = this.rootURL + this.currentPictureIndex;
            this.container.append(img);
        },

        previous: function () {
            $("img").remove();
            var img = document.createElement("img");
            if (this.currentPictureIndex == 1) {
                this.currentPictureIndex = this.numberOfPictures;
            }
            else {
                this.currentPictureIndex--;
            }

            img.src = this.rootURL + this.currentPictureIndex;
            this.container.append(img);
        },

        next: function () {
            $("img").remove();
            var img = document.createElement("img");
            if (this.currentPictureIndex == this.numberOfPictures) {
                this.currentPictureIndex = 1;
            }
            else {
                this.currentPictureIndex++;
            }

            img.src = this.rootURL + this.currentPictureIndex;
            this.container.append(img);
        },

        slideshow: function () {
            var self = this;
            setInterval(function () {
                self.next();
            }, 3500);
        }
    }

    return {
        Slider: getSliderControl
    }
}());