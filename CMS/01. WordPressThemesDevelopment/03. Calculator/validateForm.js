function validateForm() {
	var leftNumber = document.getElementById('leftNumber').value;
	var rightNumber = document.getElementById('rightNumber').value;
	var sign = document.getElementById('sign').value;
	
	var errorMessages = [];
	
	//Sign check
	var possibleSigns = ["+", "-", "*", "/"];
	if(!inArray(sign, possibleSigns)) {
		errorMessages.push("The sign must be '+, -, *' or '/'.");
	}
	
	//Numbers check
	if(!isValidNumber(leftNumber)) {
		errorMessages.push("The left number is invalid.");
	}

	if(!isValidNumber(rightNumber)) {
		errorMessages.push("The right number is invalid.");
	}
	
	if(errorMessages.length > 0) {
		alert(errorMessages.join("\n"));
		return false;
	}
}

function inArray(needle, haystack) {
    var length = haystack.length;
    for(var i = 0; i < length; i++) {
        if(haystack[i] == needle) return true;
    }
    return false;
}

function isValidNumber(number) {
	return !isNaN(parseInt(number)) && (Math.floor(number) == number);
}