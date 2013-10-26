(function($) {
  var map;
  var capitals;
  var markers = [];
  var counter;

  function initialize() {
      var mapOptions = {
          zoom: 6,
          center: new google.maps.LatLng(42.69959515809203, 23.337364196777344),
          mapTypeId: google.maps.MapTypeId.TERRAIN
      };

      map = new google.maps.Map(document.getElementById('map-canvas'),
          mapOptions);

      capitals = capitalsData.getData();
      counter = 0;
      for (var i = 0; i < capitals.length; i++) {
      	var newMarker = new MapMarker(capitals[i].lat, capitals[i].long, capitals[i].info, capitals[i].title, capitals[i].color);
         markers.push(newMarker);
      };
      var navContainer = $('<div id="nav"></div>');
      var nav = $("<ul/>");
      for (var i = 0; i < markers.length; i++) {
        var item = $('<li></li>');
        item.append(markers[i].title);
        item.bind('click', {marker: markers[i], current: i}, function(event) {
          var data = event.data;
          counter = data.current;
          map.panTo((data.marker).getPosition());
      });
        nav.append(item);
      };

      $('body').append(navContainer.append(nav));

      var prevbtn = $("<button/>").text("Previous capital");
      var nextbtn = $("<button/>").text("Next capital");
      prevbtn.attr('id', 'btn-prev');
      nextbtn.attr('id', 'btn-next');
      prevbtn.on('click', previous);
      nextbtn.on('click', next);

      $('#nav').append(nextbtn);
      $('#nav').append(prevbtn);
  }

  function next() {
    if(counter < markers.length - 1) {
        counter += 1;
    } else {
        counter = 0;
    }
    map.panTo(markers[counter].getPosition());
  }

  function previous() {
    if(counter > 0) {
        counter -= 1;
    } else {
        counter = markers.length - 1;
    }
    map.panTo(markers[counter].getPosition());
  }

   var MapMarker = Class.create({
      init: function(latitude, longitude, info, title, color) {
        this.latitude = latitude;
        this.longitude = longitude;
        this.info = info;
        this.title = title;
        this.color = color;
        this.marker = this.createMarker();
      },
      createMarker: function () {
        var marker = new google.maps.Marker({
          position: new google.maps.LatLng(this.latitude, this.longitude),
          map: map,
          title: this.title
        }); 
        iconFile = 'http://maps.google.com/mapfiles/ms/icons/' + this.color + '-dot.png';
        marker.setIcon(iconFile);

        var infowindow = new google.maps.InfoWindow({
            content: this.info
        });

        google.maps.event.addListener(marker, 'click', function () {
            infowindow.open(map,marker);
            map.panTo(marker.getPosition());
        });

        return marker;
      },
      getPosition: function() {
        return this.marker.getPosition();
      }

  });

  google.maps.event.addDomListener(window, 'load', initialize());
})(jQuery);