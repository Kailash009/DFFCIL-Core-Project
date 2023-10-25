var empId = 18;

//Global Declartion
//var spanTotalLimit = document.getElementById('spanTotalLimit');
var tdPatientName = document.getElementById('tdPatientName');
var tdRelation = document.getElementById('tdRelation');
var tdDateOfBirth = document.getElementById('tdDateOfBirth');
var tdMale = document.getElementById('tdMale');
var inputHospitalName = document.getElementById('inputHospitalName');
var inputHospitalRegNo = document.getElementById('inputHospitalRegNo');
var inputDoctorName = document.getElementById('inputDoctorName');
var inputActualDateOfAdmission = document.getElementById('inputActualDateOfAdmission');
var inputEstimatedAmount = document.getElementById('inputEstimatedAmount');
var inputApprovedAmount = document.getElementById('inputApprovedAmount');
var inputReviseEstimateAmount = document.getElementById('inputReviseEstimateAmount');
var inputTopUpAmountRequired = document.getElementById('inputTopUpAmountRequired');
var spanNumber = document.getElementById('spanNumber');
var inputBankName = document.getElementById('inputBankName');
var inputIFSC = document.getElementById('inputIFSC');
var inputBeneficiaryName = document.getElementById('inputBeneficiaryName');
var inputBeneficiaryAccountNo = document.getElementById('inputBeneficiaryAccountNo');
var inputConfirmAccountNo = document.getElementById('inputConfirmAccountNo');
var inputDateOfDischarge = document.getElementById('inputDateOfDischarge');
var inputFinalHospitalBill = document.getElementById('inputFinalHospitalBill');
var spanFinalBills = document.getElementById('spanFinalBills');




//Events
$(document).ready(function () {

    //setAdvanceClaimDefaultValue();
    bindTableAdvanceClaim();
});


function bindTableAdvanceClaim() {
    var tblAdvanceClaim = $('#tblbodycontent');

    $.ajax({
        type: "GET",
        url: apiBaseUrl + "/api/Claim/GetAdvance/" + empId.toString(),
        //data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSeend: function () {
            $('.page-loader').show();
        },
        success: function (response) {
            /*console.log(response)
            console.log(response.statusCode)*/
            tblAdvanceClaim.append('');
            var count = 1;
            $.each(response.data, function () {
                var htmlContent = `'<tr>
                 <td>`+ count + `</td>
					<td>`+ this['employeeName'] + `</td>
                        <td>`+ this['patientName'] + `</td>
                        <td>`+ this['relation'] + `</td>
                        <td>`+ this['requestDate'] + `</td>
                        <td>`+ this['advanceAmount'] + `</td>
                        <td>`+ this['approvedDate'] + `</td>
                        <td>`+ this['approvedAmount'] + `</td>
                        <td><button onclick="settle_click('emp_id','Jacob','John','Father')" type="button" class="btn btn-success-details">Settle</button></td>
                    </tr>'`;

                tblAdvanceClaim.append(htmlContent);
                count++;
            });
            $('.page-loader').hide();

        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
//Functions
function setAdvanceClaimDefaultValue() {
    //spanTotalLimit.innerHTML = rupee.format(5000000.00);// rupee define in commonformat.js
    tdPatientName.innerHTML = 'Mainawati';// text define in commonformat.js
    tdRelation.innerHTML = 'Mother';// text define in commonformat.js
    tdDateOfBirth.innerHTML = '01/07/1983';// text define in commonformat.js
    tdMale.innerHTML = 'Female';// text define in commonformat.js
    inputHospitalName.value = 'Max';// text define in commonformat.js
    inputHospitalRegNo.value = '252525';// text define in commonformat.js
    inputDoctorName.value = 'Dr. Ajay';// text define in commonformat.js
    inputActualDateOfAdmission.value = '25/3/2023';// text define in commonformat.js
    inputEstimatedAmount.value = '5,000';// text define in commonformat.js
    inputApprovedAmount.value = '4,000';// text define in commonformat.js
    inputReviseEstimateAmount.value = '20,000';// text define in commonformat.js
    inputTopUpAmountRequired.value = '30,000';// text define in commonformat.js
    spanNumber.innerHTML = rupee.format(50000.00); // text define in commonformat.js
    inputBankName.value = 'SBI Bank';// text define in commonformat.js
    inputIFSC.value = 'CNRB00245';// text define in commonformat.js
    inputBeneficiaryName.value = 'Avdhesh';// text define in commonformat.js
    inputBeneficiaryAccountNo.value = '2706101014038';// text define in commonformat.js
    inputConfirmAccountNo.value = '2706101014038';// text define in commonformat.js
    inputDateOfDischarge.value = '25/3/2023';// text define in commonformat.js
    inputFinalHospitalBill.value = '5000';// text define in commonformat.js
    spanFinalBills.value = '5000';// text define in commonformat.js


}

// ApiCallFunctions
