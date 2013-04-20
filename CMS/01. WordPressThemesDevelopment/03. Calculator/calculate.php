<?php
function isValidNumber($number) {
	return is_numeric($number) && (floor($number) == $number);
}

$leftNumber = $_POST['leftNumber'];
$sign = $_POST['sign'];
$rightNumber = $_POST['rightNumber'];

$errorMessages = array();

//Numbers check
if(!isValidNumber($leftNumber)) {
	$errorMessages[] = "The left number is invalid.";
}

if(!isValidNumber($rightNumber)) {
	$errorMessages[] = "The right number is invalid.";
}

//Sign check
$possibleSigns = array("+", "-", "*", "/");
if(!in_array($sign, $possibleSigns)) {
	$errorMessages[] = "The sign must be '+, -, *' or '/'.";
}

//check for error(s)
if(count($errorMessages) > 0) {
	foreach($errorMessages AS $error) {
		echo $error . "<br />";
	}
} else {
	switch($sign) {
		case "+": {
			echo $leftNumber + $rightNumber;
			break;
		}
		
		case "-": {
			echo $leftNumber - $rightNumber;
			break;
		}
		
		case "*": {
			echo $leftNumber * $rightNumber;
			break;
		}
		
		case "/": {
			if($rightNumber == 0) {
				echo "Divide by zero";
			} else {
				echo $leftNumber / $rightNumber;
			}
			break;
		}
	}
}
?>