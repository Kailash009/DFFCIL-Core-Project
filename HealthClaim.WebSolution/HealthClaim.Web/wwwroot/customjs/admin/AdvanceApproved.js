//Global Declartion

var spanMemberNotification = document.getElementById("spanMemberNotification");
var spanMemberAdvancePay = document.getElementById("spanMemberAdvancePay");
var spanMemberOther = document.getElementById("spanMemberOther");
var inputAdvanceApprovedHospitalName = document.getElementById("inputAdvanceApprovedHospitalName");
var inputAdavnceApprovedHospitalReg = document.getElementById("inputAdavnceApprovedHospitalReg");
var inputAdvanceApprovedDocterName = document.getElementById("inputAdvanceApprovedDocterName");
var inputAdvancedApprovedLikelyDateOfAdmission = document.getElementById("inputAdvancedApprovedLikelyDateOfAdmission");
var inputAdvancedApprovedEstimateAmout = document.getElementById("inputAdvancedApprovedEstimateAmout");
var inputAdvancedApprovedAdvancedRequested = document.getElementById("inputAdvancedApprovedAdvancedRequested");
var inputAdvancedApprovedApprovedAmount = document.getElementById("inputAdvancedApprovedApprovedAmount");
var inputTopDetailsEstimateAmount = document.getElementById("inputTopDetailsEstimateAmount");
var inputTopUpDetailsAmoutRequired = document.getElementById("inputTopUpDetailsAmoutRequired");
var inputTopUpDetailsApprovedAmount = document.getElementById("inputTopUpDetailsApprovedAmount");
var headingModelName = document.getElementById("heading6ModelName");
var headingModelAccountNo = document.getElementById("heading6ModelAccountNo");
var headingModelBankName = document.getElementById("heading6ModelBankName");
var headingModelUtrNo = document.getElementById("heading6ModelUtrNo");
var headingAdvancedApprovedPatientName = document.getElementById("headingAdvancedApprovedPatientName");
var headingAdvancedApprovedRelationName = document.getElementById("headingAdvancedApprovedRelationName");
var headingAdvancedApprovedDob = document.getElementById("headingAdvancedApprovedDob");
var headingAdvancedApprovedFemale = document.getElementById("headingAdvancedApprovedFemale");
var headingAdvancedApprovedAdvancedDate = document.getElementById("headingAdvancedApprovedAdvancedDate");
var headingAdvancedApprovedRequesteAmount = document.getElementById("headingAdvancedApprovedRequesteAmount");
var headingAdvancedApprovedPendingApproval = document.getElementById("headingAdvancedApprovedPendingApproval");
var headingAdvancedApprovedApprovelDate = document.getElementById("headingAdvancedApprovedApprovelDate");


//Events
$(document).ready(function () {

    setAdvanceApprovedDefaultValue();
});
//Functions
function setAdvanceApprovedDefaultValue() {

    spanMemberNotification.innerHTML = '34';
    spanMemberAdvancePay.innerHTML = "10";
    spanMemberOther.innerHTML = "10";
    inputAdvanceApprovedHospitalName.value = "";
    inputAdavnceApprovedHospitalReg.value = "";
    inputAdvanceApprovedDocterName.value = "";
    inputAdvancedApprovedLikelyDateOfAdmission.value = "";
    inputAdvancedApprovedEstimateAmout.value = "";
    inputAdvancedApprovedAdvancedRequested.value = "";
    inputAdvancedApprovedApprovedAmount.value = "";
    inputTopDetailsEstimateAmount.value = "";
    inputTopUpDetailsAmoutRequired.value = ""
    inputTopUpDetailsApprovedAmount.value = "";
    headingModelName.innerHTML = "";
    headingModelAccountNo.innerHTML = "";
    headingModelBankName.innerHTML = "";
    headingModelUtrNo.innerHTML = "";
    headingAdvancedApprovedRelationName.innerHTML = "";
    headingAdvancedApprovedDob.innerHTML = "";
    headingAdvancedApprovedFemale.innerHTML = "";
    headingAdvancedApprovedAdvancedDate.innerHTML = "";
    headingAdvancedApprovedRequesteAmount.innerHTML = "";
    headingAdvancedApprovedPendingApproval.innerHTML = "";
    headingAdvancedApprovedApprovelDate.innerHTML - "";
}

// ApiCallFunctions



