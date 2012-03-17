$(document).ready(function () {
	$('.index-hero').hide();

	setTimeout(function() {
		$('.index-hero').fadeIn('slow');
	}, 1000);
});	

function redirdctToGitHub() {
	document.location.href = "https://github.com/maximilian-krauss/updateSystem.NET";
}
function addToolTips() {
	$('#btn-download-binaries').tipsy({
		gravity: 's',
		fade: true
	});
	$('#btn-download-sourcecode').tipsy({
		gravity: 's',
		fade: true
	});
}