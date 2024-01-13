/*var locations = [
    ['Bondi Beach', -33.890542, 151.274856, 4],
    ['Coogee Beach', -33.923036, 151.259052, 5],
    ['Cronulla Beach', -34.028249, 151.157507, 3],
    ['Manly Beach', -33.80010128657071, 151.28747820854187, 2],
    ['Maroubra Beach', -33.950198, 151.259302, 1]
  ];

  var map = new google.maps.Map(document.getElementById('map'), {
    zoom: 10,
    center: new google.maps.LatLng(-33.92, 151.25),
    mapTypeId: google.maps.MapTypeId.ROADMAP
  });

  var infowindow = new google.maps.InfoWindow();

  var marker, i;

  for (i = 0; i < locations.length; i++) {
    marker = new google.maps.Marker({
      position: new google.maps.LatLng(locations[i][1], locations[i][2]),
      map: map
    });

    google.maps.event.addListener(marker, 'click', (function(marker, i) {
      return function() {
        infowindow.setContent(locations[i][0]);
        infowindow.open(map, marker);
      }
    })(marker, i));
  }*/

  var map;
function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: {lat: 41.713, lng: -85.003},
        zoom: 16
    });

    var flightPlanCoordinates = [
        { lat: 41.7171899900261, lng: -85.002969973285587 },
        { lat: 41.716339720601695, lng: -85.00356011920411 },
        { lat: 41.715420123340095, lng: -85.003969783778473 },
        { lat: 41.713850219112373, lng: -85.0043800221203 },
        { lat: 41.709869880890324, lng: -85.004809740676933 },
        { lat: 41.709570224086633, lng: -85.004860160268152 },

    ];

    var flightPlanCoordinates2 = [
        { lat: 42, lng: -86 },
        { lat: 42, lng: -87},
        { lat: 42, lng: -88 },
        { lat: 43, lng: -88 },
        { lat: 44, lng: -89 },
        { lat: 49, lng: -89 },

    ];

    var arrayOfFlightPlans = [flightPlanCoordinates, flightPlanCoordinates2];

    //Loops through all polyline paths and draws each on the map.
    for (let i = 0; i < 2; i++) {
        var flightPath = new google.maps.Polyline({
        path: arrayOfFlightPlans[i],
        geodesic: true,
        strokeColor: '#FF0000',
        strokeOpacity: 1.0,
        strokeWeight: 4,
        });

        flightPath.setMap(map);
    }
}