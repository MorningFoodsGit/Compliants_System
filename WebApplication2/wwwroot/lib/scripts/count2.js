
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


updateComplaintCount();

setInterval(updateComplaintCount, 10000); // 10 seconds interval