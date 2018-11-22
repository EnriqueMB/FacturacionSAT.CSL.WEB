var map;
var markers = [];

(function ($) {
    $.get = function (key) {
        key = key.replace(/[\[]/, '\\[');
        key = key.replace(/[\]]/, '\\]');
        var pattern = "[\\?&]" + key + "=([^&#]*)";
        var regex = new RegExp(pattern);
        var url = unescape(window.location.href);
        var results = regex.exec(url);
        if (results === null) {
            return null;
        } else {
            return results[1];
        }
    }
})(jQuery);


function initialize() {
    var longitud = $("#longitud").val();
    var latitud = $("#latitud").val();
    if (longitud != "" && latitud != "") {
        var haightAshbury = new google.maps.LatLng(latitud, longitud);
    }
    else var haightAshbury = new google.maps.LatLng(20.68009, -101.35403);


    var mapOptions = {
        zoom: 4,
        center: haightAshbury,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    map = new google.maps.Map(document.getElementById('google_pps_map'), mapOptions);

    google.maps.event.addListener(map, 'click', function (event) {
        addMarker(event.latLng);
    });

        addMarker(haightAshbury);
}

function addMarker(location) {
    var marker = new google.maps.Marker({
        position: location,
        draggable: true,
        map: map
    });
    clearMarkers();
    markers.push(marker);
    document.getElementById("latitud").value = marker.position.lat();
    document.getElementById("longitud").value = marker.position.lng();

    google.maps.event.addListener(marker, 'dragend', function () {
        document.getElementById("latitud").value = marker.position.lat();
        document.getElementById("longitud").value = marker.position.lng();
    });

}

// Sets the map on all markers in the array.
function setAllMap(map) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}

// Removes the markers from the map, but keeps them in the array.
function clearMarkers() {
    setAllMap(null);
}

function geocodeResult(results, status) {
    // Verificamos el estatus
    if (status == 'OK') {
        // Si hay resultados encontrados, centramos y repintamos el mapa
        // esto para eliminar cualquier pin antes puesto
        var mapOptions = {
            center: results[0].geometry.location,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map($("#google_pps_map").get(0), mapOptions);
        // fitBounds acercará el mapa con el zoom adecuado de acuerdo a lo buscado
        map.fitBounds(results[0].geometry.viewport);

        // Dibujamos un marcador con la ubicación del primer resultado obtenido
        var markerOptions = { position: results[0].geometry.location }
        var marker = new google.maps.Marker(markerOptions);

        google.maps.event.addListener(map, 'click', function (event) {
            addMarker(event.latLng);
        });

        addMarker(marker.position);
        //marker.setMap(map);
    } else {
        // En caso de no haber resultados o que haya ocurrido un error
        // lanzamos un mensaje con el error
        alert("Geocoding no tuvo éxito debido a: " + status);
    }
}

//Eventos y métodos de geocode
//$('#gmap_geocoding_btn').live('click', function () {
//    // Obtenemos la dirección y la asignamos a una variable
//    var address = $('#gmap_geocoding_address').val();
//    // Creamos el Objeto Geocoder
//    var geocoder = new google.maps.Geocoder();
//    // Hacemos la petición indicando la dirección e invocamos la función
//    // geocodeResult enviando todo el resultado obtenido
//    geocoder.geocode({ 'address': address }, geocodeResult);
//});

google.maps.event.addDomListener(window, 'load', initialize);

