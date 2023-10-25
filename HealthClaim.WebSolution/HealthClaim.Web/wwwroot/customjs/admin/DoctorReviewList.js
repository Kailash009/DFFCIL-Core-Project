// Global Variable
var tdDoctorReviewListEmpName = document.getElementById("tdDoctorReviewListEmpName");
var tdDoctorReviewListPatientName = document.getElementById("tdDoctorReviewListPatientName");
var tdDoctorReviewListDob = document.getElementById("tdDoctorReviewListDob");
var tdDoctorReviewListDob = document.getElementById("tdDoctorReviewListDob");
var tdDoctorReviewListEmpGender = document.getElementById("tdDoctorReviewListEmpGender");

// event
$(document).ready(function () {

    doctorReviewListDefaultValue();
});


function doctorReviewListDefaultValue() {
    tdDoctorReviewListEmpName.innerHTML = "";
    tdDoctorReviewListPatientName.innerHTML = "";
    tdDoctorReviewListDob.innerHTML = "";
    tdDoctorReviewListEmpGender.innerHTML = "";

}