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

$(document).ready(watchPosition);

	function getPosition() {
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
				var msg;
				switch (error.code) {
					case 0: 
						msg = 'Der opstod en fejl';
						break;
					case 1: 
						msg = 'Adgang til position nægtet';
						break;
					case 2: 
						msg = 'Position ikke tilgængelig';
						break;
					case 3: 
						msg = 'Timeout';
						break;
				}
            
			$('#error').text(msg + ' ' + error.code);
            },
			{
				maximumAge: 1000,
				enableHighAccuracy: true,
			}
			
		);
	}
	function watchPosition() {
		var startPos;
		var callCount = 0;
		console.log(callCount);
		navigator.geolocation.watchPosition(
			function (position) {
				console.log('watchPosition called ' + callCount + ' times');
				$('#error').text('');
				callCount += 1;
				startPos = position;
				console.log(startPos.coords);
				$('#xcoord').text(startPos.coords.latitude);
				$('#ycoord').text(startPos.coords.longitude);
				$('#accuracy').text(startPos.coords.accuracy);
				$('#callcount').text(callCount);
				
					
			}, 
			function(error) {
				var msg;
				console.log('error.code ' + error.code);
				switch (error.code) {
					case 0: 
						msg = 'Der opstod en fejl';
						break;
					case 1: 
						msg = 'Adgang til position nægtet';
						break;
					case 2: 
						msg = 'Position ikke tilgængelig';
						break;
					case 3: 
						msg = 'Timeout';
						break;
				}
            
				$('#error').text(msg + ' ' + error.code);
            },
			{
				maximumAge: 1000,
				enableHighAccuracy: true,
			}
			
		);
		
	}

