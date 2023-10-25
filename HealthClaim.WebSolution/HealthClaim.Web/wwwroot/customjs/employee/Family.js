var gender = '';

$(document).ready(function () {
	BindEmployeeMembers();

	BindEmployeeRelation();
	$('#ddlEmployeerelation').change(function () {

		var gender = $("#ddlEmployeerelation option:selected").text();
		gender = findGender(gender);

	});
	$("#btnAddFamilyMember").click(function () {

		debugger;
		var financialYear = $("#ddlFinancialYear option:selected").text();
		var memberName = $('#txtMemberName').val();
		var panNo = $('#txtPanNo').val();
		var annualIncome = $('#txtAnnualIncome').val();
		var employeerelationId = $('#ddlEmployeerelation').val();
		var date = $('#ddlDate').val();
		var month = $('#ddlMonth').val();
		var year = $('#ddlYear').val();
		var totalage = $('#txtTotalAge').val();

		var dob = date + "/" + month + "/" + year;
		var gender = $("#ddlEmployeerelation option:selected").text();
		gender = findGender(gender);

		debugger;

		var itrFile = new FormData();
		var fileITR = $('#itrFile')[0].files[0];
		itrFile.append('file', fileITR);

		var panFile = new FormData();
		var filePAN = $('#panFile')[0].files[0];
		panFile.append('file', filePAN);


		var data =
		{
			"empId": 18,
			"name": memberName,
			"relationId": parseInt(employeerelationId),
			"gender": gender,
			"ITRFile": fileITR,
			"FinancialYear": financialYear,
			"AnnualIncome": parseInt(annualIncome),
			"PANFile": filePAN,
			"PANNo": panNo,
			"dateOfBirth": dob,
			"emailId": "na@na.com",
			"mobileNo": "123456789",
			"bloodGroup": "O+",
			"isActive": true
		};
		var formdata = { employeefamilyModel: data };

		//FormData Object
		const formDataNew = new FormData();
		formDataNew.append('name', data.name)
		formDataNew.append('gender', data.gender)
		formDataNew.append('empId', data.empId)
		formDataNew.append('relationId', data.relationId)
		formDataNew.append('emailId', data.emailId)
		formDataNew.append('mobileNo', data.mobileNo)
		formDataNew.append('bloodGroup', data.bloodGroup)
		formDataNew.append('dateOfBirth', data.dateOfBirth)
		formDataNew.append('isActive', data.isActive)
		formDataNew.append('ITRFile', data.ITRFile)
		formDataNew.append('FinancialYear', data.FinancialYear)
		formDataNew.append('AnnualIncome', data.AnnualIncome)
		formDataNew.append('PANFile', data.PANFile)
		formDataNew.append('PANNo', data.PANNo)

		//console.log(data)
		$.ajax({
			type: "POST",
			url: apiBaseUrl + "/api/Employeefamily/CreateEmpRelation",
			data: formDataNew,
			//contentType: 'multipart/form-data',
			processData: false,
			contentType: false,
			//dataType: "json",
			beforeSend: function () {
				$('.page-loader').show();
				$("#btnAddFamilyMember").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
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
				BindEmployeeMembers();
				$('#myModal').modal('hide');

			},
			complete: function () {

				$('.page-loader').hide();
				$("#btnAddFamilyMember").html('<i class="fa-solid fa-plus"></i> &nbsp;Add')
			},
			error: function (jqXHR, status) {
				// error handler
				//console.log(jqXHR);
				//console.log(jqXHR.responseJSON);
				//console.log();
				swal({
					title: 'Invalid !',
					text: jqXHR.responseJSON.message,
					type: 'error'
				});
				$('.page-loader').hide();
				$("#btnAddFamilyMember").html('<i class="fa-solid fa-plus"></i> &nbsp;Add')
			}
		});
	});

	$("#ddlYear").change(function () {
		var date = $('#ddlDate').val();
		var month = $('#ddlMonth').val();
		var year = $('#ddlYear').val();

		var dob = month + "/" + date + "/" + year;
		var totalAge = getTotalYearFromDateOfBirth(dob);
		$('#txtTotalAge').val(totalAge);
	});
});

function BindEmployeeRelation() {
	var ddlEmployeerelation = $('#ddlEmployeerelation');

	$.ajax({
		type: "GET",
		url: apiBaseUrl + "/api/Employeefamily/GetRelation/0",
		data: '{}',
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: function (response) {
			//console.log(response)
			//console.log(response.statusCode)

			$.each(response.data, function () {
				ddlEmployeerelation.append($("<option></option>").val(this['id']).html(this['name']));
			});
		},
		failure: function (response) {
			alert(response.d);
		}
	});
}
function BindEmployeeMembers() {
	var ddlEmployeerelation = $('#tbodyContent');

	$.ajax({
		type: "GET",
		url: apiBaseUrl + "/api/Employeefamily/GetFamily",
		data: '{}',
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		beforeSeend: function () {
			$('.page-loader').show();

		},
		success: function (response) {
			//console.log(response)
			//console.log(response.statusCode)
			ddlEmployeerelation.append('');
			$.each(response.data, function () {
				var htmlContent = `'<tr>
					<td> `+ this['memberName'] + `</td>
                        <td>`+ this['relation'] + `</td>
                        <td class="text-center">`+ this['dob'] + `</td>
                        <td class="text-center">`+ this['age'] + `</td>
                        <td class="text-center">`+ this['gender'] + `</td>
                        <td class="text-center">NIL</td>
                    </tr>'`;

				ddlEmployeerelation.append(htmlContent);
			});
			$('.page-loader').hide();

		},
		failure: function (response) {
			alert(response.d);
		}
	});
}


