//Global Declartion
/// Upload Task
var empId = 18;
// Upload Multiple JavaScript start
var uploadType = '';
var uploadKey = '';
var fileData = [];
var uploadDetails = { AdmissionAdvice: [], Diagnosis: [], EstimateAmount: [], ITRIncomeProof: [] };
var imgUpload = document.getElementById('upload-img')
    , imgPreview = document.getElementById('img-preview')
    , imgUploadForm = document.getElementById('form-upload')
    , totalFiles
    , previewTitle
    , previewTitleText
    , img;

imgUpload.addEventListener('change', previewImgs, true);
var trBodyUploadDoc = document.getElementById('trBodyUploadDoc');
function loadUploadedFile(key) {
    var row = '';
    let count = 1;
    if (uploadDetails[key].length == 0) {
        trBodyUploadDoc.innerHTML = '';
        return;
    }
    for (let e of uploadDetails[key]) {
        row += `<tr>
               <td class="py-1">${count}</td>
                <td>
                    ${uploadType}
                                           
                </td>
                <td>
                        ${e.comment}
                </td>

                <td>
					<a href="${e.clientPath}" target='_blank'>
                    <i style="font-size:20px; color:red;" class="fa-solid fa-file-lines" aria-hidden="true"></i>
					</a>
                </td>

                <td>
                    <i onclick="delete_file(${count - 1})" class="fa fa-trash trashFontAwesome" aria-hidden="true"></i>
                </td>
                </tr>`;
        count++;

    }
    trBodyUploadDoc.innerHTML = row;
}
function previewImgs(event) {

    if (imgUpload.files.length == 0) {
        return;
    }
    const original = imgUpload.files[0];
    const clone = new File([original], original.name, {
        type: original.type,
        lastModified: original.lastModified,
    });
    let comment = textareaComment.value;

    uploadDetails[uploadKey].push({ uoloadedFile: clone, comment: comment, clientPath: URL.createObjectURL(clone) });
    imgUpload.value = null;
    loadUploadedFile(uploadKey);
}
function delete_file(index) {
    uploadDetails[uploadKey].splice(index, 1);
    loadUploadedFile(uploadKey);
}
function TrigerModalUploadFile(type, type2) {
    uploadType = type;
    uploadKey = type2;
    $("#myModal").modal('show');
    $('#myModalTitle').html(type);
    $('#spnComment').html(type);
    loadUploadedFile(type2);
}
// Upload Multiple JavaScript End
// Parent

var divParentClaimLimt = document.getElementById('divParentClaimLimt');
var ITRIncomeProof = document.getElementById('ITRIncomeProof');
var textareaComment = document.getElementById('textareaComment');
/// Upload Task end
var spanTotalLimit = document.getElementById('spanTotalLimit');

var spanTotalLimit = document.getElementById('spanTotalLimit');

var spanUsedLimit = document.getElementById('spanUsedLimit');
var spanBalanceLimit = document.getElementById('spanBalanceLimit');
var selectMember = document.getElementById('selectMember');
var inputHospitalName = document.getElementById('inputHospitalName');
var inputHospitalRegdNo = document.getElementById('inputHospitalRegdNo');
var inputDoctorName = document.getElementById('inputDoctorName');
var inputDateOfAdmission = document.getElementById('inputDateOfAdmission');
var inputEstimateAmount = document.getElementById('inputEstimateAmount');
var inputAdvanceRequired = document.getElementById('inputAdvanceRequired');
var radioPaytoSelf = document.getElementById('radioPaytoSelf');
var radioPaytoHospital = document.getElementById('radioPaytoHospital');

var inputBankName = document.getElementById('inputBankName');
var inputIFSC = document.getElementById('inputIFSC');
var inputBeneficiaryName = document.getElementById('inputBeneficiaryName');
var inputAccountNo = document.getElementById('inputAccountNo');
var inputConfirmAccountNo = document.getElementById('inputConfirmAccountNo');
var btnSubmitWithoutBankDetails = document.getElementById('btnSubmitWithoutBankDetails');
var btnSubmitAfterBankDetails = document.getElementById('btnSubmitAfterBankDetails');

var divhospitaldetails = document.getElementById('divhospitaldetails');


//Events


$(document).ready(function () {
    loadFamilyMembers();
    setAdvanceDefaultValue();
});
function rbt_self_onchange(e) {
    if (e.value == 'self') {
        divhospitaldetails.style.display = 'none';
        btnSubmitWithoutBankDetails.style.display = 'block';
    }
    else {
        divhospitaldetails.style.display = 'block';
        btnSubmitWithoutBankDetails.style.display = 'none';

    }
}

function btnSubmit_Click() {
    var date = new Date();
    const formDataNew = new FormData();
    formDataNew.append('EmplId', empId);
    formDataNew.append('PatientId', selectMember.value);
    formDataNew.append('RequestSubmittedById', empId);
    formDataNew.append('RequestName', 'FirstAdvance');
    formDataNew.append('AdvanceRequestDate',date.toJSON());
    formDataNew.append('AdvanceAmount', parseInt(inputAdvanceRequired.value));
    formDataNew.append('Reason', 'NA');
    if (radioPaytoSelf.checked) {
        formDataNew.append('PayTo', 'Self');
    }
    else {
        formDataNew.append('PayTo', 'Hospital');
        formDataNew.append('BankName', inputBankName.value);
        formDataNew.append('BeneficiaryAccountNo', inputAccountNo.value);
        formDataNew.append('IFSCCode', inputIFSC.value);
        formDataNew.append('BeneficiaryName', inputBeneficiaryName.value)
    }
    //formDataNew.append('approvalDate', '1980/01/01');
    //formDataNew.append('ApprovedAmount', 0);
    //formDataNew.append('ApprovedById', 18)
    formDataNew.append('HospitalName', inputHospitalName.value)
    formDataNew.append('HospitalRegNo', inputHospitalRegdNo.value)
    formDataNew.append('DateOfAdmission ', (new Date(inputDateOfAdmission.value)).toJSON());
    formDataNew.append('DoctorName', inputDoctorName.value)

    for (var e of uploadDetails.Diagnosis) {
        formDataNew.append('DiagnosisFile', e.uoloadedFile);
    }
    for (var e of uploadDetails.EstimateAmount) {
        formDataNew.append('EstimateAmountFile', e.uoloadedFile);
    }
    for (var e of uploadDetails.AdmissionAdvice) {
        formDataNew.append('AdmissionAdviceFile', e.uoloadedFile);
    }

    formDataNew.append('ClaimTypeId', 1);
    formDataNew.append('StatusId', 1);
    formDataNew.append('UploadTypeId', 1);
    //var _url = 'https://uat.dfccil.services.cetpainfotech.com/api/Claim/AdvanceRequest​';
    var _url = apiBaseUrl + "​/api/Claim/AdvanceRequest";
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

    $.ajax({
        type: "POST",
        url: _url,
        data: formDataNew,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('.page-loader').show();
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
        },
        success: function (response) {

            if (response.statusCode == 201) {
                swal({
                    title: 'Awesome !',
                    text: response.message,
                    type: 'success'
                });
            }
            else {
                swal({
                    title: 'Invalid !',
                    text: 'Bad request try agin.',
                    type: 'error'
                });
            }

            $('#myModal').modal('hide');

        },
        complete: function () {

            $('.page-loader').hide();
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
        },
        error: function (jqXHR, status) {
            $('.page-loader').hide();
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Add')
            swal({
                title: 'Invalid !',
                text: jqXHR.responseJSON.message,
                type: 'error'
            });

        }
    });

}

function inputIFSC_OnFocusOut() {
    var url = apiBaseUrl + "/api​/Common​/IFSCCodeChecker​/" + inputIFSC.value;
    url = url.replace(/[\u200B-\u200D\uFEFF]/g, '');
    // Start Loader Here
    getApiCall(url = url, success, failour);
    function success(response) {
        var jsonData = response.data;
        if (response.statusCode == 200) {
            inputBankName.value = jsonData.bank;
            inputBankName.value = jsonData.bank;
        }
        

        
        //// Close Loader Here;
    }
    function failour(response) {
        //// Close Loader Here;
    }
}
$("#btSubmitRequest").click(function () {
    //FormData Object
   });

function selectMember_OnChange(e) {
    
    ShowHideParentLimit(e.options[e.selectedIndex].text);
}
//Functions
function setAdvanceDefaultValue() {
    spanTotalLimit.innerHTML = rupee.format(1000000.00);// rupee define in commonformat.js
    spanUsedLimit.innerHTML = rupee.format(250000.00);// rupee define in commonformat.js
    spanBalanceLimit.innerHTML = rupee.format(750000.00);// rupee define in commonformat.js
}

// ApiCallFunctions
function loadFamilyMembers() {
    var url = apiBaseUrl + "/api/Employeefamily/GetFamily/" + empId.toString();
    // Start Loader Here
    getApiCall(url = url, success, failour);
    function success(response) {
        var jsonData = response.data;
        selectMember.append('');

        for (let e of jsonData) {
            let option = new Option(e['memberName'] + "(" + e['relation'] + ")", e['id']);
            selectMember.add(option, undefined);
        }
        ShowHideParentLimit(selectMember.options[0].text);
        
        //// Close Loader Here;
    }
    function failour(response) {
        //// Close Loader Here;
    }
}
function ShowHideParentLimit(relation) {
    if (relation.toUpperCase().includes('FATHER') || relation.toUpperCase().includes('MOTHER')) {
        divParentClaimLimt.style.display = 'block';
        itrParent.style.display = 'block';
    }
    else {
        divParentClaimLimt.style.display = 'none';
        itrParent.style.display = 'none';

    }
}