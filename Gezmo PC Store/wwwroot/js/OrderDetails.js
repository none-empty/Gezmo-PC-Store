function decreaseQuantity(button) {
    const valueBox = button.nextElementSibling;
    let value = parseInt(valueBox.textContent, 10);
    if (value > 1) {
        valueBox.textContent = value - 1;
    }
}

function increaseQuantity(button) {
    const valueBox = button.previousElementSibling;
    let value = parseInt(valueBox.textContent, 10);
    valueBox.textContent = value + 1;
}