// global declaration

var spanClaimAfterReviewFinalPatientAndTotalLimit = document.getElementById("spanClaimAfterReviewFinalPatientAndTotalLimit");
var spanClaimAfterReviewFinalPatientAndUsedLimit = document.getElementById("spanClaimAfterReviewFinalPatientAndUsedLimit");
var spanClaimAfterReviewFinalPatientAndBalanceLimit = document.getElementById("spanClaimAfterReviewFinalPatientAndBalanceLimit");
var inputClaimAfterReviewFinalHospitalName = document.getElementById("inputClaimAfterReviewFinalHospitalName");
var inputClaimAfterReviewFinalHospitalRegNo = document.getElementById("inputClaimAfterReviewFinalHospitalRegNo");
var inputClaimAfterReviewFinalDoctorName = document.getElementById("inputClaimAfterReviewFinalDoctorName");
var inputClaimAfterReviewFinalDateOfAdmission = document.getElementById("inputClaimAfterReviewFinalDateOfAdmission");
var inputClaimAfterReviewFinalAdmissionAdvice = document.getElementById("inputClaimAfterReviewFinalAdmissionAdvice");
var inputClaimAfterReviewFinalEstimatedAmount = document.getElementById("inputClaimAfterReviewFinalEstimatedAmount");
var inputClaimAfterReviewFinalRequestedAmount = document.getElementById("inputClaimAfterReviewFinalRequestedAmount");
var inputClaimAfterReviewFinalApprovedAmount = document.getElementById("inputClaimAfterReviewFinalApprovedAmount");
var inputClaimAfterReviewFinalPaidTo = document.getElementById("inputClaimAfterReviewFinalPaidTo");
var inputReviewFinalDateOfDischarge = document.getElementById("inputReviewFinalDateOfDischarge");
var inputReviewFinalDischargeDishchaRgeSummary = document.getElementById("inputReviewFinalDischargeDishchaRgeSummary");
var inputReviewFinalInvestigationReport = document.getElementById("inputReviewFinalInvestigationReport");
var inputReviewFinalTotalHospitalBill = document.getElementById("inputReviewFinalTotalHospitalBill");
var tdClaimReviewDoctorFinalTotalBillAmount = document.getElementById("tdClaimReviewDoctorFinalTotalBillAmount");
var tdClaimReviewDoctorFinalTotalApprovedAmount = document.getElementById("tdClaimReviewDoctorFinalTotalApprovedAmount");
var tdClaimReviewDoctorFinalDeduction = document.getElementById("tdClaimReviewDoctorFinalDeduction");
var tdClaimReviewDoctorFinalAdvancedPaid = document.getElementById("tdClaimReviewDoctorFinalAdvancedPaid");
var tdClaimReviewDoctorFinalNetDueAmount = document.getElementById("tdClaimReviewDoctorFinalNetDueAmount");
var tdClaimReviewDocterFinalEmpName = document.getElementById("tdClaimReviewDocterFinalEmpName");
var tdClaimReviewDocterFinalPatientName = document.getElementById("tdClaimReviewDocterFinalPatientName");
var tdClaimReviewDocterFinalEmpRelation = document.getElementById("tdClaimReviewDocterFinalEmpRelation");
var tdClaimReviewDocterFinalEmpDob = document.getElementById("tdClaimReviewDocterFinalEmpDob");
var tdClaimReviewDocterFinalEmpGender = document.getElementById("tdClaimReviewDocterFinalEmpGender");



//event
$(document).ready(function () {

    claimAfterDocterReviewFinalDefaultValue();
});


//function
function claimAfterDocterReviewFinalDefaultValue() {
    spanClaimAfterReviewFinalPatientAndTotalLimit.innerHTML = "100000.00";
    spanClaimAfterReviewFinalPatientAndUsedLimit.innerHTML = "700000.00";
    spanClaimAfterReviewFinalPatientAndBalanceLimit.innerHTML = "800000.00";
    inputClaimAfterReviewFinalHospitalName.value = "";
    inputClaimAfterReviewFinalHospitalRegNo.value = "";
    inputClaimAfterReviewFinalDoctorName.value = "";
    inputClaimAfterReviewFinalDateOfAdmission.value = "";
    inputClaimAfterReviewFinalAdmissionAdvice.value = "";
    inputClaimAfterReviewFinalEstimatedAmount.value = "";
    inputClaimAfterReviewFinalRequestedAmount.value = "";
    inputClaimAfterReviewFinalApprovedAmount.value = "";
    inputClaimAfterReviewFinalPaidTo.value = "";
    inputReviewFinalDateOfDischarge.value = "";
    inputReviewFinalDischargeDishchaRgeSummary.value = "";
    inputReviewFinalInvestigationReport.value = "";
    inputReviewFinalTotalHospitalBill.value = "";
    tdClaimReviewDoctorFinalTotalBillAmount.innerHTML = "";
    tdClaimReviewDoctorFinalTotalApprovedAmount.innerHTML = "";
    tdClaimReviewDoctorFinalDeduction.innerHTML = "";
    tdClaimReviewDoctorFinalAdvancedPaid.innerHTML = "";
    tdClaimReviewDoctorFinalNetDueAmount.innerHTML = "";
    tdClaimReviewDocterFinalEmpName.innerHTML = "";
    tdClaimReviewDocterFinalPatientName.innerHTML = "";
    tdClaimReviewDocterFinalEmpRelation.innerHTML = "";
    tdClaimReviewDocterFinalEmpDob.innerHTML = "";
    tdClaimReviewDocterFinalEmpGender.innerHTML = "";
}