//Global Declartion
var spanTotalLimit = document.getElementById('spanTotalLimit');
var spanUsedLimit = document.getElementById('spanUsedLimit');
var spanBalanceLimit = document.getElementById('spanBalanceLimit');
var inputHospitalName = document.getElementById('inputHospitalName');
var inputHospitalRegdNo = document.getElementById('inputHospitalRegdNo');
var inputDoctorName = document.getElementById('inputDoctorName');
var inputDateOfAdmission = document.getElementById('inputDateOfAdmission');
var inputEstimateAmount = document.getElementById('inputEstimateAmount');
var inputAdvancePaid = document.getElementById('inputAdvancePaid');
var inputAdditionalDetails = document.getElementById('inputAdditionalDetails');
var inputTotalHospitalBill = document.getElementById('inputTotalHospitalBill');
var textareaClarification = document.getElementById('textareaClarification');


//Events
$(document).ready(function () {

    setClaimAdvanceDefaultValue();
});
//Functions
function setClaimAdvanceDefaultValue() {
    spanTotalLimit.innerHTML = rupee.format(1000000.00);// rupee define in commonformat.js
    spanUsedLimit.innerHTML = rupee.format(250000.00);// rupee define in commonformat.js
    spanBalanceLimit.innerHTML = rupee.format(750000.00);// rupee define in commonformat.js
    // inputHospitalRegdNo.value = '';
    inputHospitalName.value = '';
    inputHospitalRegdNo.value = '';
    inputDoctorName.value = 'Dr.';
    inputDateOfAdmission.value = ''
    inputEstimateAmount.value = '';
    inputAdvancePaid.value = '';

    inputAdditionalDetails.value = '';
    inputTotalHospitalBill.value = '';
    textareaClarification.value = '';

}

// ApiCallFunctions
