document.addEventListener("DOMContentLoaded", function () {
    const actionCountResult = document.getElementById("actionCountResult");
    const actionCountProgress = document.getElementById("actionCountProgress");

    // Make an AJAX request to the server to get the count of "Sent to Boyndie" actions      
    fetch(`/cmplnt_base/GetActionCount?actionName=Sent to Boyndie`)
        .then(response => response.json())
        .then(data => displayActionCount(data))
        .catch(error => console.error("Error fetching action count:", error));

    function displayActionCount(count) {
        // Update the result div and progress bar with the count
        actionCountResult.textContent = count.toLocaleString(); // Format the count with commas
        actionCountProgress.value = count; // Set the progress value to the count
    }
});

document.addEventListener("DOMContentLoaded", function () {
    const actionCountResult = document.getElementById("actionCountResult2");
    const actionCountProgress = document.getElementById("actionCountProgress2");

    fetch(`/cmplnt_base/GetActionCount?actionName=Reply Sent`)
        .then(response => response.json())
        .then(data => displayActionCount(data))
        .catch(error => console.error("Error fetching action count:", error));

    function displayActionCount(count) {
        actionCountResult.textContent = count.toLocaleString();
        actionCountProgress.value = count;
    }
});

document.addEventListener("DOMContentLoaded", function () {
    const actionCountResult = document.getElementById("actionCountResult3");
    const actionCountProgress = document.getElementById("actionCountProgress3");

    fetch(`/cmplnt_base/GetActionCount?actionName=Sent to Buckley`)
        .then(response => response.json())
        .then(data => displayActionCount(data))
        .catch(error => console.error("Error fetching action count:", error));

    function displayActionCount(count) {
        actionCountResult.textContent = count.toLocaleString();
        actionCountProgress.value = count;
    }
});

document.addEventListener("DOMContentLoaded", function () {
    const actionCountResult = document.getElementById("actionCountResult4");
    const actionCountProgress = document.getElementById("actionCountProgress4");

    fetch(`/cmplnt_base/GetActionCount?actionName=Sent to QA`)
        .then(response => response.json())
        .then(data => displayActionCount(data))
        .catch(error => console.error("Error fetching action count:", error));

    function displayActionCount(count) {
        actionCountResult.textContent = count.toLocaleString();
        actionCountProgress.value = count;
    }
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

