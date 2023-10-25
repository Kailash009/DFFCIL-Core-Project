//Global Variable
var spanFinanceStep1TotalNotification = document.getElementById("spanFinanceStep1TotalNotification");
var spanFinanceStep1AdvancedPay = document.getElementById("spanFinanceStep1AdvancedPay");
var spanFinanceStep1other = document.getElementById("spanFinanceStep1other");
var headingFinanceStep1PatentName = document.getElementById("headingFinanceStep1PatentName");
var headingFinanceStep1PatentRelation = document.getElementById("headingFinanceStep1PatentRelation");
var headingFinanceStep1PatentDob = document.getElementById("headingFinanceStep1PatentDob");
var headingFinanceStep1Gender = document.getElementById("headingFinanceStep1Gender");
var headingFinanceStep1AdvancedReqAmount = document.getElementById("headingFinanceStep1AdvancedReqAmount");
var headingFinanceStep1ApprovedReqAmount = document.getElementById("headingFinanceStep1ApprovedReqAmount");
var headingFinanceStep1PatentStatus = document.getElementById("headingFinanceStep1PatentStatus");
var headingFinanceStep1ApprovalDate = document.getElementById("headingFinanceStep1ApprovalDate");
var inputFinanceStep1HospitalName = document.getElementById("inputFinanceStep1HospitalName");
var inputFinanceStep1HospitalRegNo = document.getElementById("inputFinanceStep1HospitalRegNo");
var inputFinanceStep1DoctorName = document.getElementById("inputFinanceStep1DoctorName");
var inputFinanceStep1LikelyDateAdmission = document.getElementById("inputFinanceStep1LikelyDateAdmission");
var inputFinanceStep1EstimatedAmount = document.getElementById("inputFinanceStep1EstimatedAmount");
var inputFinanceStep1AdvancedRequested = document.getElementById("inputFinanceStep1AdvancedRequested");
var inputFinanceStep1ApprovedAmount = document.getElementById("inputFinanceStep1ApprovedAmount");
var textareaFinanceStep1PaymentMode = document.getElementById("textareaFinanceStep1PaymentMode");
var textareaFinanceStep1Date = document.getElementById("textareaFinanceStep1Date");
var textareaFinanceStep1UtrNo = document.getElementById("textareaFinanceStep1UtrNo");

//Events
$(document).ready(function () {

    financeStep1DefaultValue();
});
//Functions

function financeStep1DefaultValue() {
    spanFinanceStep1TotalNotification.innerHTML = "";
    spanFinanceStep1AdvancedPay.innerHTML = "";
    spanFinanceStep1other.innerHTML = "";
    headingFinanceStep1PatentName.innerHTML = "";
    headingFinanceStep1PatentRelation.innerHTML = "";
    headingFinanceStep1PatentDob.innerHTML = "";
    headingFinanceStep1Gender.innerHTML = "";
    headingFinanceStep1AdvancedReqAmount.innerHTML = "";
    headingFinanceStep1ApprovedReqAmount.innerHTML = "";
    headingFinanceStep1PatentStatus.innerHTML = "";
    headingFinanceStep1ApprovalDate.innerHTML = "";
    inputFinanceStep1HospitalName.value = "";
    inputFinanceStep1HospitalRegNo.value = "";
    inputFinanceStep1DoctorName.value = "";
    inputFinanceStep1LikelyDateAdmission.value = "";
    inputFinanceStep1EstimatedAmount.value = "";
    inputFinanceStep1AdvancedRequested.value = "";
    inputFinanceStep1ApprovedAmount.value = "";
    textareaFinanceStep1PaymentMode.innerHTML = "";
    textareaFinanceStep1Date.innerHTML = "";
    textareaFinanceStep1UtrNo.innerHTML = "";
}