//Global Declartion
var spanTotalLimit = document.getElementById('spanTotalLimit');

//Events

//Functions
function setAdvanceDefaultValue() {
    spanTotalLimit.innerHTML = rupee.format(5000000.00);// rupee define in commonformat.js
    inputHospitalRegdNo.value = '';
    
}

// ApiCallFunctions
