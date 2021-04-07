function CheckLength() {
    var vrednost = document.querySelector('textarea');
    var kopce = document.getElementById('btn_comment');
    var total = vrednost.value;
    if (total.length > 2) {
        kopce.style.display = "block";
    } else {
        kopce.style.display = "none";
    }
}