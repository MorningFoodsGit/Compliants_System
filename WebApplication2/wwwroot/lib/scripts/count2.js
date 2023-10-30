
document.addEventListener("DOMContentLoaded", function () {
    const retailerCountElement = document.getElementById("retailerCount");

    // Make an AJAX request to the server API to get the retailer count
    fetch("/cmplnt_base/GetRetailerCount")
        .then(response => response.json())
        .then(count => {
            retailerCountElement.textContent = `Number of Retailers: ${count}`;
        })
        .catch(error => console.error("Error fetching retailer count:", error));
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

updateComplaintCount();

setInterval(updateComplaintCount, 10000); // 10 seconds interval