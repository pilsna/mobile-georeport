﻿if (navigator.geolocation) {
    console.log('Geolocation is supported!');
}
else {
    console.log('Geolocation is not supported for this Browser/OS version yet.');
}

$(document).ready(initialize);

$(document).ready(startWatchPosition);

function initialize() {
	$('#xcoord').text('');
	$('#ycoord').text('');
	$('#accuracy').text('');	
	$('#submitbutton').bind('click', submitNotification);
}

function getData() {
    var data = {
		notification: {
			X: $('#xcoord').text(),
			Y: $('#ycoord').text(),
			Accuracy: $('#accuracy').text(),
			Message: $('#description').val(),
			Email: $('#email').val(),
			Error: $('error').text()
		}
	};
	//data.notification.Message = 'test3';
	return data;
}

function submitNotification() {
	$.mobile.pageLoading();
    notify();
	$.mobile.pageLoading('true');
    
	$('#submitbutton').unbind();
}

function notify() {
	$.ajax({
	  contentType: 'application/json; charset=utf-8', 
	  dataType: 'json',
      type: 'POST',
      data: JSON.stringify(getData()),
	  url: 'Notification/Create',
	  success:function(data){
		$('#successmessage').text(data);
	  }
	});
}

function startWatchPosition() {
	watchPosition(20, 5);
}

function getPosition() {
	var startPos;
	navigator.geolocation.getCurrentPosition(
		function (position) {
			startPos = position;
			console.log(startPos.coords);
			$('#locationinfo').show();
			$('#xcoord').text(startPos.coords.latitude.toFixed(2));
			$('#ycoord').text(startPos.coords.longitude.toFixed(2));
			$('#accuracy').text(startPos.coords.accuracy.toFixed(2));
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

function watchPosition(times, maxAccuracy) {
	var startPos;
	var callCount = 0;
	console.log(callCount);
	var watchID = navigator.geolocation.watchPosition(
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
			if (watchID === times || startPos.coords.accuracy < maxAccuracy) {
				navigator.geolocation.clearWatch(watchID);
			}
				
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


