var empId = 18;
$(document).ready(function () {
    loadDashBoard();
});
function countTo(elementId, start, end, duration) {
    const element = document.getElementById(elementId);
    const range = end - start;
    const increment = range / (duration / 30); // Adjust the number 30 for speed

    let current = start;
    const timer = setInterval(() => {
        current += increment;
        element.textContent = Math.round(current);

        if (current >= end) {
            clearInterval(timer);
            element.textContent = end;
        }
    }, 30);
}

function loadDashBoard() {
    var url = apiBaseUrl + "/api/Employee/GetEmpProfile/" + empId.toString();
    // Start Loader Here
    getApiCall(url = url, success, failour);
    function success(response) {
        var jsonData = response.data;
        //selectMember.append('');
        console.log(jsonData)
        $('#spnTotalLimit').html(jsonData.totalLimit)
        $('#spnTotalRequestAmount').html(jsonData.totalRequestAmount)
        //$('#spnTotalApprovedAmount').html(jsonData.totalApprovedAmount)
        countTo("counter2", 0, jsonData.totalApprovedAmount, 3000);
        countTo("counter1", 0, jsonData.totalNumberofApproved, 3000);
    }
    function failour(response) {
        //// Close Loader Here;
    }
}