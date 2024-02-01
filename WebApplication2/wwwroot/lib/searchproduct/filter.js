document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("query");
    const searchInput3 = document.getElementById("query3");
    const searchInput4 = document.getElementById("query4");
    const searchResultsDiv = document.getElementById("searchResults");
    const searchResultsDiv3 = document.getElementById("searchResults3");
    const searchResultsDiv4 = document.getElementById("searchResults4");

    searchInput.addEventListener("input", function () {
        const searchString = searchInput.value.trim();

        if (searchString !== "") {
            // Make an AJAX request to the server API
            fetch(`/api/Filter/GetComplainantName?query=${encodeURIComponent(searchString)}`)
                .then(response => response.json())
                .then(data => displaySearchResults(data, searchResultsDiv))
                .catch(error => console.error("Error fetching search results:", error));
        } else {
            // Clear the search results if the search input is empty
            searchResultsDiv.innerHTML = "";
        }
    });

    searchInput3.addEventListener("input", function () {
        const searchString3 = searchInput3.value.trim();

        if (searchString3 !== "") {
            // Make an AJAX request to the server API
            fetch(`/api/Filter/GetCompliantDescription?query3=${encodeURIComponent(searchString3)}`)
                .then(response => response.json())
                .then(data => displaySearchResults(data, searchResultsDiv3))
                .catch(error => console.error("Error fetching search results:", error));
        } else {
            // Clear the search results if the search input is empty
            searchResultsDiv3.innerHTML = "";
        }
    });

    searchInput4.addEventListener("input", function () {
        const searchString4 = searchInput4.value.trim();

        if (searchString4 !== "") {
            // Make an AJAX request to the server API
            fetch(`/api/Filter/GetProductDescription?query4=${encodeURIComponent(searchString4)}`)
                .then(response => response.json())
                .then(data => displaySearchResults(data, searchResultsDiv4))
                .catch(error => console.error("Error fetching search results:", error));
        } else {
            // Clear the search results if the search input is empty
            searchResultsDiv4.innerHTML = "";
        }
    });

    function displaySearchResults(results, searchResultsDiv) {
        // Clear previous search results
        searchResultsDiv.innerHTML = "";

        if (results && results.length > 0) {
            // Loop through the search results and display them
            results.forEach(result => {
                const resultItem = document.createElement("div");
                resultItem.textContent = result;
                resultItem.classList.add("searchResultItem");
                resultItem.addEventListener("click", function () {
                    searchResultsDiv.closest(".modal-body").querySelector("input[type='text']").value = result; // Populate the search input with the clicked search result
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
