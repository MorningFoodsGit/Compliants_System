document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("searchInput");
    const searchResultsDiv = document.getElementById("searchResults");

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