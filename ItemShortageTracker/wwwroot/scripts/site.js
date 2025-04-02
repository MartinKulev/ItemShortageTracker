function toggleMessageBox(elementId, duration) {
    const element = document.getElementById(elementId);
    if (element) {
        element.style.display = "block";
        setTimeout(() => {
            element.style.display = "none";
        }, duration);
    }
}