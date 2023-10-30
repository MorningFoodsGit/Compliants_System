document.addEventListener("DOMContentLoaded", function () {
    fetch("/cmplnt_base/GetRetailerProductCategoryCounts")
        .then(response => response.json())
        .then(data => {
            createProductCategoryChart(data);
        })
        .catch(error => console.error("Error fetching data:", error));
});

function createProductCategoryChart(data) {
    const retailers = Object.keys(data);
    const productCategories = Object.keys(data[retailers[0]]);

    const datasets = productCategories.map(category => ({
        label: category,
        data: retailers.map(retailer => data[retailer][category]),
    }));

    const ctx = document.getElementById("productCategoryChart").getContext("2d");
    new Chart(ctx, {
        type: "bar",
        data: {
            labels: retailers,
            datasets: datasets,
        },
        options: {
            scales: {
                x: {
                    stacked: true,
                },
                y: {
                    stacked: true,
                    beginAtZero: true,
                },
            },
        },
    });
}

document.addEventListener("DOMContentLoaded", function () {
    fetch("/cmplnt_base/GetRetailerProductCategory2Counts")
        .then(response => response.json())
        .then(data => {
            const retailerData = data.map(item => ({
                label: item.Retailer,
                data: item.Counts.map(subItem => subItem.Count),
                backgroundColor: getRandomColor(),
                borderColor: getRandomColor(),
                borderWidth: 1
            }));

            const productCategories = data[0].Counts.map(subItem => subItem.ProductCategory);

            createBarChart("retailerProductCategoryChart", productCategories, retailerData);
        })
        .catch(error => console.error("Error fetching retailer product category counts:", error));
});

function getRandomColor() {
    const letters = "0123456789ABCDEF";
    let color = "#";
    for (let i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}

function createBarChart(chartId, labels, datasets) {
    const ctx = document.getElementById(chartId).getContext("2d");
    new Chart(ctx, {
        type: "bar",
        data: {
            labels: labels,
            datasets: datasets
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: "top",
                },
                title: {
                    display: true,
                    text: "Retailer vs. Product Category Counts"
                }
            }
        }
    });
}