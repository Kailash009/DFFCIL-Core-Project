//Global Declartion
var radioEmployeeSpecialDiseaseYes = document.getElementById('radioEmployeeSpecialDiseaseYes');
var radioEmployeeSpecialDiseaseNo = document.getElementById('radioEmployeeSpecialDiseaseNo');
var radioEmployeeTaxableYes = document.getElementById('radioEmployeeTaxableYes');
var radioEmployeeTaxableNo = document.getElementById('radioEmployeeTaxableNo');
var radioDoctorSpecialDiseaseYes = document.getElementById('radioDoctorSpecialDiseaseYes');
var radioDoctorSpecialDiseaseNo = document.getElementById('radioDoctorSpecialDiseaseNo');
var radioDoctorTaxableYes = document.getElementById('radioDoctorTaxableYes');
var radioDoctorTaxableNo = document.getElementById('radioDoctorTaxableNo');
var checkboxConfirmation = document.getElementById('checkboxConfirmation');


//Events
$(document).ready(function () {

    setClaimAdvanceDefaultValue();
});
//Functions
function setClaimAdvanceDefaultValue() {
    radioEmployeeSpecialDiseaseYes.value = '';
    radioEmployeeSpecialDiseaseNo.value = '';
    radioEmployeeTaxableYes.value = '';
    radioEmployeeTaxableNo.value = '';
    radioDoctorSpecialDiseaseYes.value = '';
    radioDoctorSpecialDiseaseNo.value = '';
    radioDoctorTaxableYes.value = '';
    radioDoctorTaxableNo.value = '';
    checkboxConfirmation.value = '';

}

// ApiCallFunctions
