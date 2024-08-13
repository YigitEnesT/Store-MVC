$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

document.addEventListener("DOMContentLoaded", function () {
    var reviews = document.querySelectorAll('.review-text');

    reviews.forEach(function (review) {
        var reviewText = review.querySelector('p');
        var showMore = review.querySelector('.show-more');
        var fullText = reviewText.textContent.trim();
        var maxLength = 120;

        if (fullText.length > maxLength) {
            var truncatedText = fullText.substring(0, maxLength) + "...";
            reviewText.textContent = truncatedText;
            showMore.style.display = "inline";
        }

        showMore.addEventListener("click", function (e) {
            e.preventDefault();

            if (showMore.textContent === "Show more") {
                reviewText.textContent = fullText;
                showMore.textContent = "Show less";
            } else {
                reviewText.textContent = truncatedText;
                showMore.textContent = "Show more";
            }
        });
    });
});