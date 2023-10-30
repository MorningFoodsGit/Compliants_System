document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("query");
    const searchResultsDiv = document.getElementById("searchResults6");
    const selectedInput = document.getElementById("prdct_cde_mf");
    const selectedInput2 = document.getElementById("prdct_desc");

    searchInput.addEventListener("input", function () {
        const searchString = searchInput.value.trim();

        if (searchString !== "") {
            // Make an AJAX request to the server API for both prdct_cde_mf and prdct_desc
            const searchRequest1 = fetch(`/api/ProductApi?query=${encodeURIComponent(searchString)}`);
            const searchRequest2 = fetch(`/api/SearchExternalDatabase?query=${encodeURIComponent(searchString)}`);

            // Use Promise.all to wait for both requests to complete
            Promise.all([searchRequest1, searchRequest2])
                .then(responses => Promise.all(responses.map(response => response.json())))
                .then(dataArray => {
                    const results1 = dataArray[0];
                    const results2 = dataArray[1];
                    displaySearchResults(results1, selectedInput, results2, selectedInput2);
                })
                .catch(error => console.error("Error fetching search results:", error));
        } else {
            // Clear the search results if the search input is empty
            searchResultsDiv.innerHTML = "";
        }
    });

    function displaySearchResults(results1, selectedInput1, results2, selectedInput2) {
        // Clear previous search results
        searchResultsDiv.innerHTML = "";

        if (results1 && results1.length > 0 && results2 && results2.length > 0) {
            // Loop through the search results and display them
            for (let i = 0; i < Math.min(results1.length, results2.length); i++) {
                const resultItem = document.createElement("div");
                resultItem.textContent = results1[i] + " - " + results2[i]; // Combine results
                resultItem.classList.add("searchResultItem");
                resultItem.addEventListener("click", function () {
                    selectedInput1.value = results1[i]; // Populate the first selected input
                    selectedInput2.value = results2[i]; // Populate the second selected input
                    searchResultsDiv.innerHTML = ""; // Clear the search results after selecting
                });
                searchResultsDiv.appendChild(resultItem);
            }
        } else {
            // Display a message if no results were found
            const noResultsMsg = document.createElement("div");
            noResultsMsg.textContent = "No results found.";
            searchResultsDiv.appendChild(noResultsMsg);
        }
    }
});