document.addEventListener("DOMContentLoaded", function () {
    // Define an array of action details for each type
    const actions = [
        { name: "Sent to Boyndie", resultId: "actionCountResult", progressId: "actionCountProgress" },
        { name: "Reply Sent", resultId: "actionCountResult2", progressId: "actionCountProgress2" },
        { name: "Sent to Buckley", resultId: "actionCountResult3", progressId: "actionCountProgress3" },
        { name: "Sent to QA", resultId: "actionCountResult4", progressId: "actionCountProgress4" }
    ];

    // Loop through each action and make an AJAX request
    actions.forEach(action => {
        const actionCountResult = document.getElementById(action.resultId);
        const actionCountProgress = document.getElementById(action.progressId);

        fetch(`/cmplnt_base/GetActionCount?actionName=${action.name}`)
            .then(response => response.json())
            .then(data => displayActionCount(data))
            .catch(error => console.error("Error fetching action count:", error));

        function displayActionCount(count) {
            actionCountResult.textContent = count.toLocaleString();
            actionCountProgress.value = count;
        }
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const categoryCountElement = document.getElementById("categoryCountDiv");

    // Make an AJAX request to the server API to get the product category count
    fetch("/cmplnt_base/GetProductCatCount")
        .then(response => response.json())
        .then(count => {
            categoryCountElement.textContent = `Number of Product Categories: ${count}`;
        })
        .catch(error => console.error("Error fetching product category count:", error));
});

function updateComplaintCount() {
    $.ajax({
        url: '/cmplnt_base/GetTotalComplaintCount',
        type: 'GET',
        dataType: 'json',
        success: function (count) {
            displayComplaintCount(count);
        },
        error: function (error) {
            console.log('Error:', error);
        }
    });
}

function displayComplaintCount(count) {
    const countDiv = document.getElementById('complaintCountDiv');
    if (countDiv) {
        countDiv.textContent = `Total Complaints in the System: ${count}`;
    }
}

