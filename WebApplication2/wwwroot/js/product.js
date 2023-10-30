document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("prdct_cde_mf");
    const searchResultsDiv = document.getElementById("searchResults");
    const selectedInput = document.getElementById("prdct_desc");

    searchInput.addEventListener("input", function () {
        const searchString = searchInput.value.trim();

        if (searchString !== "") {
            // Make an AJAX request to the server API
            fetch(`/api/SearchExternalDatabase?query=${encodeURIComponent(searchString)}`)
                .then(response => response.json())
                .then(data => displaySearchResults(data))
                .catch(error => console.error("Error fetching search results:", error));
        } else {
            // Clear the search results if the search input is empty
            searchResultsDiv.innerHTML = "";
        }
    });

    function displaySearchResults(results) {
        // Clear previous search results
        searchResultsDiv.innerHTML = "";

        if (results && results.length > 0) {
            // Loop through the search results and display them
            results.forEach(result => {
                const resultItem = document.createElement("div");
                resultItem.textContent = result;
                resultItem.classList.add("searchResultItem");
                resultItem.addEventListener("click", function () {
                    selectedInput.value = result; // Populate the selected input with the clicked search result
                    searchResultsDiv.innerHTML = ""; // Clear the search results after selecting
                });
                searchResultsDiv.appendChild(resultItem);
            });
        } else {
            // Display a message if no results were found
            const noResultsMsg = document.createElement("div");
            noResultsMsg.textContent = "No results found.";
            searchResultsDiv.appendChild(noResultsMsg);
        }
    }
});