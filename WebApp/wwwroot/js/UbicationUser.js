 function initMap() {
    var mapOptions = {
    center: { lat: 9.94078478557062, lng: - 84.09686643773655 }, 
    zoom: 10,
    mapTypeId: google.maps.MapTypeId.ROADMAP
};
    var map = new google.maps.Map(document.getElementById('map'), mapOptions);

    var marker = new google.maps.Marker({
        position: mapOptions.center,
    map: map,
    draggable: true,
    title: 'Ubicación seleccionada'
            });

     geocoder = new google.maps.Geocoder();
     google.maps.event.addListener(marker, 'dragend', function () {
         var latitude = marker.getPosition().lat();
         var longitude = marker.getPosition().lng();

         geocoder.geocode({ 'location': { lat: latitude, lng: longitude } }, function (results, status) {
             if (status === 'OK') {
                 if (results[0]) {
                     var address = results[0].formatted_address;
                     document.getElementById('address').value = address;
                     document.getElementById('address').placeholder = 'Dirección: ' + address;
                     document.getElementById('address').innerHTML = 'Dirección: ' + address;
                 }
             } else {
                 console.log('Error en la geocodificación inversa: ' + status);
             }
         });
     });

}

