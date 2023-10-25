var rupee = new Intl.NumberFormat('en-IN', {
    style: 'currency',
    currency: 'INR',
});
// Summary Veriables start
var trFHB = document.getElementById('trFHB');
var trAA = document.getElementById('trAA');
var trPHB = document.getElementById('trPHB');
var trTB = document.getElementById('trTB');
var trDP = document.getElementById('trDP');
var trBC = document.getElementById('trBC');

var tdFHB = document.getElementById('tdFHB');
var tdAA = document.getElementById('tdAA');
var tdPHB = document.getElementById('tdPHB');
var tdTB = document.getElementById('tdTB');
var tdDP = document.getElementById('tdDP');
var tdBC = document.getElementById('tdBC');
// Summary Veriables ends
var btnInpatientSubmit = document.getElementById('btnInpatientSubmit');
var checkboxDeclaration = document.getElementById('checkboxDeclaration');
var taxUploadDoc = document.getElementById('taxUploadDoc');
var radioTaxableNo = document.getElementById('radioTaxableNo');
var spanTotalLimit = document.getElementById('spanTotalLimit');
var spanUsedLimit = document.getElementById('spanUsedLimit');
var spanBalanceLimit = document.getElementById('spanBalanceLimit');

var spanAmountIncludedMainBill = document.getElementById('spanAmountIncludedMainBill');
var spanAmountNotIncludedMainBill = document.getElementById('spanAmountNotIncludedMainBill');
var spanFinalBill = document.getElementById('spanFinalBill');
var chkPreHospitlization = document.getElementById('chkPreHospitlization');

var inputMedicine = document.getElementById('inputMedicine');
inputMedicine.value = 0.00;

var inputConsultation = document.getElementById('inputConsultation');
inputConsultation.value = 0.00;

var inputInvestigation = document.getElementById('inputInvestigation');
inputInvestigation.value = 0.00;


var inputRoomRentBill = document.getElementById('inputRoomRentBill');
inputRoomRentBill.value = 0.00;
var inputOther = document.getElementById('inputOther');
inputOther.value = 0.00;


//Global Declartion
var empId = 18;

// Upload Multiple JavaScript start
var IsNotInBill = false;
var IsPreHosPitlization = false;
var Rowindex = 1;
var selectedIndex = 1;
var uploadType = '';
var uploadKey = '';
var uploadTypeNotInBill = '';
var uploadKeyNotInBill = '';
var uploadIndexNotInBill = 0;
var uploadTypePreHosPitlization = '';
var uploadKeyPreHosPitlization = '';
var fileData = [];
var uploadDetails = { AdmissionAdvice: [], Diagnosis: [], EstimateAmount: [], ITRIncomeProof: [], FinalHospitalBill: [], DischargeSummary: [], InvestigationReports: [] };
//{ index:1,row:r, type:Medicine ,uoloadedFile: clone, billAmount: 10000, clientPath: URL.createObjectURL(clone)}
var uploadDetailsNotInBill = { Medicine: [], Consultation: [], Investigation: [], Other: [], RoomRent:[] };
var AmountDetailsNotInBill = { Medicine: { count: 0, amount: 0, rowIndex: -1 }, Consultation: { count: 0, amount: 0, rowIndex: -1 }, Investigation: { count: 0, amount: 0, rowIndex: -1 }, Other: { count: 0, amount: 0, rowIndex: -1 }, RoomRent: { count: 0, amount: 0, rowIndex: -1 } };
var uploadDetailsPreHospitlization = { Medicine: [], Consultation: [], Investigation: [], Other: [] };
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
function loadUploadedFileNotInBill(key,index) {
    var row = '';
    let count = 1;
    if (uploadDetailsNotInBill[key].length == 0) {
        trBodyUploadDoc.innerHTML = '';
        return;
    }
    for (let e of uploadDetailsNotInBill[key]) {
        if (e.index == index) {
            row += `<tr>
               <td class="py-1">${count}</td>
                <td>
                    ${key}
                                           
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
        }

        count++;

    }
    trBodyUploadDoc.innerHTML = row;
}
function loadUploadedFilePreHospitlization(key) {
    var row = '';
    let count = 1;
    if (uploadDetailsPreHospitlization[key].length == 0) {
        trBodyUploadDoc.innerHTML = '';
        return;
    }
    for (let e of uploadDetailsPreHospitlization[key]) {
        row += `<tr>
               <td class="py-1">${count}</td>
                <td>
                    ${uploadTypePreHosPitlization}
                                           
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

function getUploadedElementByKeyAndIndex(key, index) {
    for (var e of uploadDetailsNotInBill[key]) {
        if (e.index == index)
            return e;
    }
}
function previewImgs(event) {
    if (IsNotInBill) {
        previewImgsNotInBill(event)
        return;
    }
    if (IsPreHosPitlization) {
        previewImgsPreHospitlization(event);
        return;
    }
    
    if (imgUpload.files.length == 0) {
        return;
    }
    const original = imgUpload.files[0];
    const clone = new File([original], original.name, {
        type: original.type,
        lastModified: original.lastModified,
    });
    let comment = textareaComment.value;

    uploadDetails[uploadKey].push({ uploadedFile: clone, comment: comment, clientPath: URL.createObjectURL(clone) });
    imgUpload.value = null;
    loadUploadedFile(uploadKey);
}
function previewImgsNotInBill(event) {

    if (imgUpload.files.length == 0) {
        return;
    }
    const original = imgUpload.files[0];
    const clone = new File([original], original.name, {
        type: original.type,
        lastModified: original.lastModified,
    });
    let comment = textareaComment.value;
    uploadDetailsNotInBill[uploadKeyNotInBill].push({ index: selectedIndex, type: uploadKeyNotInBill, uploadedFile: clone, billAmount:0 , clientPath: URL.createObjectURL(clone) });
    imgUpload.value = null;
    loadUploadedFileNotInBill(uploadKeyNotInBill, selectedIndex);
}
function previewImgsPreHospitlization(event) {
    

    if (imgUpload.files.length == 0) {
        return;
    }
    const original = imgUpload.files[0];
    const clone = new File([original], original.name, {
        type: original.type,
        lastModified: original.lastModified,
    });
    let comment = textareaComment.value;

    uploadDetailsPreHospitlization[uploadKeyPreHosPitlization].push({ uploadedFile: clone, comment: comment, clientPath: URL.createObjectURL(clone) });
    imgUpload.value = null;
    loadUploadedFilePreHospitlization(uploadKeyPreHosPitlization);
}
function getAmount(uploadKey, uploadIndexNotInBill) {
    var e = document.getElementById(uploadKey + uploadIndexNotInBill.toString());
    if (e)
        return e.value;
}
function delete_file(index) {
    uploadDetails[uploadKey].splice(index, 1);
    loadUploadedFile(uploadKey);
}
function TrigerModalUploadFile(type, type2) {
    IsNotInBill = false;
    uploadType = type;
    uploadKey = type2;
    $("#myModal").modal('show');
    $('#myModalTitle').html(type);
    $('#spnComment').html(type);
    loadUploadedFile(type2);
}
function TrigerModalUploadFileNotInBill(type, type2, index) {
    IsNotInBill = true;
    IsPreHosPitlization = false;
    uploadTypeNotInBill = type;
    uploadKeyNotInBill = type2;
    uploadIndexNotInBill = index;
    $("#myModal").modal('show');
    $('#myModalTitle').html(type);
    $('#spnComment').html(type);
    selectedIndex = index;
    loadUploadedFileNotInBill(type2, index);
  
}
function TrigerModalUploadFilePreHospitlization(type, type2) {
    IsNotInBill = false;
    IsPreHosPitlization = true
    uploadKeyPreHosPitlization = type2;
    uploadTypePreHosPitlization = type;
    uploadType = type;
    uploadKey = type2;
    $("#myModal").modal('show');
    $('#myModalTitle').html(type);
    $('#spnComment').html(type);
    loadUploadedFilePreHospitlization(type2);
}
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
        calculateAndDisplayPrice('NA');
        //// Close Loader Here;
    }
    function failour(response) {
        //// Close Loader Here;
    }
}
// Upload Multiple JavaScript End
// Global Elements
var amountInBill = 0.0;
var amountNotinBill = 0.0;
var preHospitlizationBill = 0.0;

function calculate_onchange(element, type) {
    //debugger;
    calculateAndDisplayPrice(type)
}

function calculateAndDisplayPrice(type) {
    amountInBill = 0.0;
    amountNotinBill = 0.0;
    preHospitlizationBill = 0.0;
    calculateIncudedPrice();
    calculateNotIncludedAmount();
    if (chkPreHospitlization.checked)
        calculatePreHospitlizationBill();
    spanAmountIncludedMainBill.innerHTML = amountInBill;
    spanAmountNotIncludedMainBill.innerHTML = amountNotinBill;
    // spanFinalBill.innerHTML = amountInBill + amountNotinBill + preHospitlizationBill;

    var varFHB = parseFloat(inputFinalHospitalBill.value);
    if (isNaN(varFHB))
        varFHB = 0.0;
    var varAA = 0.0;
    var varTB = 0.0;
    var varPHB = 0.0;
    var varDP = 0.0;
    var varBC = 0.0;
    
    tdFHB.innerHTML = varFHB;
    varAA = amountNotinBill;
    if (isNaN(varAA))
        varAA=0.0
    tdAA.innerHTML = varAA;
    varPHB = preHospitlizationBill;
    if (isNaN(varPHB))
        varPHB = 0.0;
    if (chkPreHospitlization.checked) {
        
        trPHB.style.display = '';
        tdPHB.innerHTML = varPHB;       
        varTB = varFHB + varAA ;       
        trTB.style.display = '';
        trBC.style.display = '';
        tdTB.innerHTML = varTB;
        tdBC.innerHTML = varTB + varPHB;
    }
    else {
        trPHB.style.display = 'none';
        varTB = varFHB + varAA;
        trTB.style.display = 'None';
        trBC.style.display = '';
        tdTB.innerHTML = varTB;

    }
    

    varDP = ((varFHB + varAA + varPHB) * .20).toFixed(2);
    var relation = selectMember.options[selectMember.selectedIndex].text;
    if (relation.toUpperCase().includes('FATHER') || relation.toUpperCase().includes('MOTHER')) {
        trDP.style.display = '';
        tdDP.innerHTML = varDP;

        varTB = varFHB + varAA + varPHB;
        varBC = (varFHB + varAA + varPHB) - varDP;
        trTB.style.display = '';
        tdTB.innerHTML = varTB.toFixed(2);
        trBC.style.display = '';
        tdBC.innerHTML = varBC.toFixed(2);
        
    }
    else {
        trDP.style.display = 'none';
        trTB.style.display = 'none';
        varBC = (varFHB + varAA + varPHB);
        trBC.style.display = '';
        tdBC.innerHTML = varBC;

    }

 /*   var varBC = varTB-varDP;*/



    
}
function calculateIncudedPrice() {   
    try {
        let p = parseFloat(inputMedicine.value);
        if (p == NaN) {
            p = 0
            inputMedicine.value = 0.00;
        }
        amountInBill+=p
    }
    catch {
        inputMedicine.value=0.00;
    }
    try {
        let p = parseFloat(inputConsultation.value);
        if (p == NaN) {
            p = 0
            inputConsultation.value = rupee.format(0.00);
        }
        amountInBill += p
    }
    catch {
        inputConsultation.value = 0;
    }
    try {
        let p = parseFloat(inputInvestigation.value);
        if (p == NaN) {
            p = 0
            inputInvestigation.value = 0.00;
        }
        amountInBill += p
    }
    catch {
        inputInvestigation.value = 0.00;
    }
    try {
        let p = parseFloat(inputRoomRentBill.value);
        if (p == NaN) {
            p = 0
            inputRoomRentBill.value =0.00;
        }
        amountInBill += p
    }
    catch {
        inputRoomRentBill.value = 0;
    }
    try {
        let p = parseFloat(inputOther.value);
        if (p == NaN) {
            p = 0
            inputOther.value = 0.00;
        }
        amountInBill += p
    }
    catch {
        inputOther.value = 0.00;
    }


 
}
function calculateNotIncludedAmount() {
    debugger;
    for (let e in AmountDetailsNotInBill) {
        if (AmountDetailsNotInBill[e].rowIndex != -1) {
            amountNotinBill += AmountDetailsNotInBill[e].amount;
        }
    }
}
function calculatePreHospitlizationBill() {
    try {
        let p = parseFloat(inputMedicinePre.value);
        if (p == NaN) {
            p = 0
            inputMedicinePre.value = 0.00;
        }
        preHospitlizationBill += p
    }
    catch {
        inputMedicinePre.value = 0.00;
    }
    try {
        let p = parseFloat(inputConsultationPre.value);
        if (p == NaN) {
            p = 0
            inputConsultationPre.value = rupee.format(0.00);
        }
        preHospitlizationBill += p
    }
    catch {
        inputConsultationPre.value = 0;
    }
    try {
        let p = parseFloat(inputInvestigationPre.value);
        if (p == NaN) {
            p = 0
            inputInvestigationPre.value = 0.00;
        }
        preHospitlizationBill += p
    }
    catch {
        inputInvestigationPre.value = 0.00;
    }
    
    try {
        let p = parseFloat(inputOtherPre.value);
        if (p == NaN) {
            p = 0
            inputOtherPre.value = 0.00;
        }
        preHospitlizationBill += p
    }
    catch {
        inputOtherPre.value = 0.00;
    }
}

function other_bill_change(element, type, typeKey, Rowindex) {
    debugger;
    try {
        let p = parseFloat(element.value);
        if (p == NaN) {
            element.value = 0.00;
        }
        else {
            AmountDetailsNotInBill[typeKey].amount = p;
        }

    }
    catch {
        AmountDetailsNotInBill[typeKey].amount = 0;
    }
    calculateAndDisplayPrice(typeKey);
    
}


var selectMember = document.getElementById('selectMember');
var inputHospitalName = document.getElementById('inputHospitalName');
var inputHospitalRegdNo = document.getElementById('inputHospitalRegdNo');
var inputDoctorName = document.getElementById('inputDoctorName');
var inputDateOfAdmission = document.getElementById('inputDateOfAdmission');
var btnAdmissionAdvice = document.getElementById('btnAdmissionAdvice');
var inputDateOfDischarge = document.getElementById('inputDateOfDischarge');
var btnDischargeSummary = document.getElementById('btnDischargeSummary');
var inputFinalHospitalBill = document.getElementById('inputFinalHospitalBill');
var radioSpecialDiseaseYes = document.getElementById('radioSpecialDiseaseYes');
var radioSpecialDiseaseNo = document.getElementById('radioSpecialDiseaseNo');
var checkboxDeclaration = document.getElementById('checkboxDeclaration');
var btnAdmissionAdvice = document.getElementById('btnAdmissionAdvice');


//Events
function selectMember_OnChange(e) {
    
    ShowHideParentLimit(e.options[e.selectedIndex].text);
    calculateAndDisplayPrice('NA');
}
//Functions


function setDirectClaimValue() {
    spanTotalLimit.innerHTML = rupee.format(1000000.00);// rupee define in commonformat.js
    spanUsedLimit.innerHTML = rupee.format(250000);
    spanBalanceLimit.innerHTML = rupee.format(750000);
    selectMember.value = '';
    inputHospitalName.value = '';
    inputHospitalRegdNo.value = '';
    inputDoctorName.value = '';
    inputDateOfAdmission.value = '';
    btnAdmissionAdvice.value = '';
    inputDateOfDischarge.value = '';
    btnDischargeSummary.value = '';
    inputFinalHospitalBill.value = '';
    radioSpecialDiseaseYes.value = '';
    radioSpecialDiseaseNo.value = '';
    checkboxDeclaration.value = '';
    inputHospitalRegdNo.value = '';
    btnAdmissionAdvice.value = '';
}

function NotInBill_cilck(e,type,typeKey,relatedObj) {   
    //var newObject = { index: medicineCount, row: e, type: type, uoloadedFile: clone, billAmount: 10000, clientPath: URL.createObjectURL(clone) }
    if (AmountDetailsNotInBill[type].count == 1) {
        alert('Please add sum of all other ' + type + ' bill amount in a single box and uoload all the bills. ');
        return;
    }
    AmountDetailsNotInBill[type].count++;
    AmountDetailsNotInBill[type].rowIndex = Rowindex;
    var element = `<tr data-key="${typeKey}" data-index="${Rowindex.toString()}" id="trid">
                            <td></td>
                            <td>${type}</td>

                            <td>
                                <input id="${typeKey + Rowindex.toString()}" onfocusout="other_bill_change(this,'${type}','${typeKey}','${Rowindex}')" type="text" class="form-control" value="0">
                            </td>
                            <td>
                                <label class="col-sm-12 col-form-label notinclude"> Not included in Final Bill</label>
                            </td>
                            <td>
                                <button onclick="TrigerModalUploadFileNotInBill('${type}','${typeKey}','${Rowindex}')" type="button" class="btn"><i class="fa fa-upload" aria-hidden="true"></i> Upload File</button>
                            </td>

                            <td>
                                <button class="btn"><i class="fa fa-eye" aria-hidden="true"></i> View File</button>
                            </td>
                            <td>
                                <button onclick="delete_bill(this,'${typeKey}','${Rowindex.toString() }')" type="button" class="btn"><i class="fa fa-trash" aria-hidden="true"></i></i> Delete</button>
                            </td>

                        </tr>`;
    $('#tbody' + typeKey).append(element);
    Rowindex++;
    
}
function delete_element_with_type_index(type, index) {
    var i = 0;
    for (let e of uploadDetailsNotInBill[type]) {
        if (e.index == index) {
            uploadDetailsNotInBill[type].splice(i, 1);
            return true;
        }
        i++;
    }
    return false;
}
function delete_row_from_upload_details_not_in_bill(type, index) {
    while (delete_element_with_type_index(type, index));
    AmountDetailsNotInBill[type].count--;
    AmountDetailsNotInBill[type].amount = 0;
    AmountDetailsNotInBill[type].rowIndex = -1;
    //var i = 0;
    //for (let e of uploadDetailsNotInBill[type]) {
    //    if (e.index == index) {
    //        uploadDetailsNotInBill[type].splice(i, 1);
    //        i--;
    //    }
    //    i++;
    //}
}
function delete_bill(e,type,index) {
    var i = e.parentNode.parentNode.rowIndex;
    document.getElementById('billdetails').deleteRow(i);
    delete_row_from_upload_details_not_in_bill(type, index);
    AmountDetailsNotInBill[type].count--;
    AmountDetailsNotInBill[type].amount = 0;
    AmountDetailsNotInBill[type].rowIndex = -1;
    
    calculateAndDisplayPrice(type);
}
function prehospitlization_click(e) {
    var pre1 = document.getElementById('pre1');
    var pre2 = document.getElementById('pre2');
    var row1 = document.getElementById('row1');
    var row2 = document.getElementById('row2');
    //var r_amount = document.getElementById('r_amount');

    if (e.checked) {
        pre1.style.display = 'block';
        pre2.style.display = 'block';
        row1.style.display = '';
        row2.style.display = '';
       // r_amount.innerHTML = '0';

    }
    else {
        pre1.style.display = 'none';
        pre2.style.display = 'none';
        row1.style.display = 'none';
        row2.style.display = 'none';
       // r_amount.innerHTML = '0';
    }
    calculateAndDisplayPrice('NA');

}
// ApiCallFunctions
//function loadFamilyMembers() {
//    var url = apiBaseUrl + "/api/Employeefamily/GetFamily/" + empId.toString();
//    url = url.replace(/[\u200B-\u200D\uFEFF]/g, '');
//    // Start Loader Here
//    getApiCall(url = url, success, failour);
//    function success(response) {
//        var jsonData = response.data;
//        selectMember.append('');

//        for (let e of jsonData) {
//            let option = new Option(e['memberName'] + "(" + e['relation'] + ")", e['id']);
//            selectMember.add(option, undefined);
//        }
//        ShowHideParentLimit(selectMember.options[0].text);
//        //// Close Loader Here;
//    }
//    function failour(response) {
//        //// Close Loader Here;
//    }
//}
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
function radio_taxable_click(e) {
    if (radioTaxableNo.checked) {
        taxUploadDoc.style.display = '';
    }
    else {
        taxUploadDoc.style.display = 'none';
    }
}
function checkboxDeclaration_cick(e) {

    if (e.checked) {
        btnInpatientSubmit.disabled = false;
    }
}
function btnInpatientSubmit_Click(e) {
    alert('ok');
}


$(document).ready(function () {
    loadFamilyMembers();
    setDirectClaimValue();

});
