function findGender(relation) {

	let gender = "";

	switch (relation) {
		case 'Husband':
		case 'Father':
		case 'Brother':
		case 'Son':
			gender = "Male";
			break;
		case 'Wife':
		case 'Mother':
		case 'Sister':
		case 'Daughter':
			gender = "Female";
			break;
		default:
			gender = "Unknown";
			break;
	}

	return gender;
}
function getTotalYearFromDateOfBirth(dob) {
	var start = new Date(dob);
	var end = new Date();
	var diff = new Date(end - start) / (1000 * 60 * 60 * 24 * 365.25);
	var age = Math.round(diff);
	return age;
}