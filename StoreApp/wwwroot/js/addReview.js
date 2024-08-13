document.getElementById("addReviewButton").addEventListener("click", function () {
    var btnText = document.getElementById("addReviewButton");
    
    btnText.innerHTML = btnText.innerHTML === "Close" ? "Add Review" : "Close";
});