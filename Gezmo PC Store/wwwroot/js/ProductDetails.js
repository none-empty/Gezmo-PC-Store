document.addEventListener('DOMContentLoaded', function () {
    // Attach click event listener to all add-to-cart buttons
    document.querySelectorAll('.add-to-cart-button').forEach(function (button) {
        button.addEventListener('click', function () {
            // Get the item ID
            const itemId = this.getAttribute('data-item-id');

            // Get the ID of the associated quantity input
            const quantityInputId = this.getAttribute('data-quantity-input-id');

            // Get the value of the quantity input
            const quantity = document.getElementById(quantityInputId).value;

            // Validate quantity (optional)
            if (quantity <= 0) {
                alert('Please enter a valid quantity.');
                return;
            }

            // Send the request to add the item to the cart
            addItemToCart(itemId, quantity);
            showSuccessMessage('Item added to cart!');
        });
    });

    // Function to display success message
    function showSuccessMessage(message) {
        alert(message); // Replace with a toast or other UI feedback
    }

    // Function to send the item and quantity to the server
    function addItemToCart(itemId, quantity) {
        fetch('/ProductDetailsPage/AddToCart', { // Replace with your controller name
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Requested-With': 'XMLHttpRequest',
            },
            body: JSON.stringify({ itemId: itemId, quantity: parseInt(quantity, 10) })
        })
            .then(response => response.json())
            .then(data => {
                if (!data.success) {
                    alert('Failed to add the item to the cart.');
                }
            })
            .catch(() => {
                alert('An error occurred while adding the item to the cart.');
            });
    }
});