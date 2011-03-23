if (navigator.geolocation) {
    console.log('Geolocation is supported!');
}
else {
    console.log('Geolocation is not supported for this Browser/OS version yet.');
}

$(document).ready(function () {
	$('#xcoord').text('0');
	$('#ycoord').text('0');
	$('#accuracy').text('0');

	
	});


$(document).ready(
	function () {
		var startPos;
		navigator.geolocation.getCurrentPosition(
			function (position) {
				startPos = position;
				console.log(startPos.coords);
				$('#xcoord').text(startPos.coords.latitude);
				$('#ycoord').text(startPos.coords.longitude);
				$('#accuracy').text(startPos.coords.accuracy);
			}, 
			function(error) {
			alert('Error occurred. Error code: ' + error.code);
			// error.code can be:
			//   0: unknown error
			//   1: permission denied
			//   2: position unavailable (error response from locaton provider)
			//   3: timed out
			}
		);
	}
);
