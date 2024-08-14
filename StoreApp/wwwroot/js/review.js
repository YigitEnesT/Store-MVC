
document.getElementById("addReviewButton").addEventListener("click", function () {
    var form = document.getElementById("reviewForm");
    var btnText = document.getElementById("addReviewButton");
    form.style.display = form.style.display === "none" ? "block" : "none";
    btnText.innerHTML = form.style.display === "none" ? "Add Review" : "Close";
});