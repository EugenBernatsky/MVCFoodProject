document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("logoutButton").addEventListener("click", logoutAndRedirect);
});

function logoutAndRedirect() {
    document.cookie = "identity=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    window.location.href = "/FoodPage";
}