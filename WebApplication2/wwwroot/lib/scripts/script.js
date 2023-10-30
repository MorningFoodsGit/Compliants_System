$(document).ready(function () {
    // Handle "Retailer" dropdown
    $("#rtlr").on("change", function () {
        if ($(this).val() === "other") {
            $("#otherName").show();
        } else {
            $("#otherName").hide();
        }
    });

    // Handle "Site" dropdown
    $("#Site").on("change", function () {
        if ($(this).val() === "otherSites") {
            $("#otherSite").show();
        } else {
            $("#otherSite").hide();
        }
    });

    // Handle "Complaint Category" dropdown
    $("#cmplnt_ctgry").on("change", function () {
        if ($(this).val() === "otherCats") {
            $("#otherCat").show();
        } else {
            $("#otherCat").hide();
        }
    });

    // Handle "Complaint Source" dropdown
    $("#cmplnt_src").on("change", function () {
        if ($(this).val() === "Othersrc") {
            $("#otherSrcs").show();
        } else {
            $("#otherSrcs").hide();
        }
    });

    // Submit the form
    function submitForm() {
        // Check if the "Other Retailer" input is visible
        if ($("#otherName").is(":visible")) {
            // Get the value entered in the "otherName" input
            const otherNameValue = $("input[name='otherName']").val();
            // Set the value of the hidden "rtlr" input to the "otherName" value
            $("input[name='rtlr']").val(otherNameValue);
        }

        // Check if the "Other Site" input is visible
        if ($("#otherSite").is(":visible")) {
            // Get the value entered in the "otherSite" input
            const otherSiteValue = $("input[name='otherSite']").val();
            // Set the value of the hidden "Site" input to the "otherSite" value
            $("input[name='Site']").val(otherSiteValue);
        }

        // Check if the "Other Complaint Category" input is visible
        if ($("#otherCat").is(":visible")) {
            // Get the value entered in the "otherCat" input
            const otherCatValue = $("input[name='otherCat']").val();
            // Set the value of the hidden "cmplnt_ctgry" input to the "otherCat" value
            $("input[name='cmplnt_ctgry']").val(otherCatValue);
        }

        // Check if the "Other Complaint Source" input is visible
        if ($("#otherSrcs").is(":visible")) {
            // Get the value entered in the "otherSrcs" input
            const otherSrcValue = $("input[name='otherSrcs']").val();
            // Set the value of the hidden "cmplnt_src" input to the "otherSrc" value
            $("input[name='cmplnt_src']").val(otherSrcValue);
        }

        // Submit the form
        $("form").submit();
    }

    // Attach the submitForm function to the form submission event
    $("form").on("submit", function (e) {
        submitForm(); // Call the custom submitForm function
    });
});