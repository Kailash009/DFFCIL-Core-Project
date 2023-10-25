//Sample Code for Api Call
//url = apiBaseUrl + "/api/Employeefamily/GetFamily";
//getApiCall(url, success, failour);
//function success(response)
//{
//	var jsonData = response.data;

//}
//function failour(response) {

//} 

var apiBaseUrl = 'https://uat.dfccil.services.cetpainfotech.com';

function getApiCall(url, successCallBack, failourCallBack, data = {},contentType= "application/json; charset=utf-8", dataType= "json") {	 
	 $.ajax({
		type: "GET",
		url: url,
		data: data,
		contentType: contentType,
		dataType: dataType,
		 success: function (response) {
			 successCallBack(response);
		
		},
		failure: function (failourResponse) {
			failourCallBack(failourResponse)
			
		}
	});
}
