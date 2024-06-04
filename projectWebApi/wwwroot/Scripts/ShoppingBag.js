





const getCart = () => {
    headeValues()
    const products = JSON.parse(sessionStorage.getItem("cart"));
    const template = document.getElementById('temp-row');
    products.forEach(product => {
        const clone = document.importNode(template.content, true);
        clone.querySelector('.imageColumn a').href = 'Images/' + product.imageUrl;
        clone.querySelector('.imageColumn img').src = 'Images/' + product.imageUrl;
        clone.querySelector('.itemName').textContent = product.productName;
        clone.querySelector('.price').textContent = product.price + '$';
        const quantityDiv = clone.querySelector('.quantity-num');
        quantityDiv.dataset.productId = product.productId; // Add data attribute for productId
        quantityDiv.textContent = product.qty;
        clone.querySelector('#remove').addEventListener('click', () => removeProduct(product));
        clone.querySelector('#plus').addEventListener('click', () => plusQty(product));
        clone.querySelector('#minos').addEventListener('click', () => minusQty(product));
        document.getElementById('tbody').appendChild(clone);
    });
}

const plusQty = (product) => {
    let cart = JSON.parse(sessionStorage.getItem('cart')) || [];

    cart.forEach(p => {
        if (p.productId == product.productId) {
            p.qty += 1;
            // Update the quantity in the DOM
            document.querySelector(`.quantity-num[data-product-id="${product.productId}"]`).textContent = p.qty;
        }
    });

    sessionStorage.setItem('cart', JSON.stringify(cart));
}

const minusQty = (product) => {
    let cart = JSON.parse(sessionStorage.getItem('cart')) || [];

    cart.forEach(p => {
        if (p.productId == product.productId) {
            p.qty -= 1;
            if (p.qty == 0) {
                removeProduct(p)
            } else {
                document.querySelector(`.quantity-num[data-product-id="${product.productId}"]`).textContent = p.qty;
            }
        }
    });

    sessionStorage.setItem('cart', JSON.stringify(cart));
}

const removeProduct = (product) => {
    const cart = JSON.parse(sessionStorage.getItem('cart')) || [];
    const updatedCart = cart.filter(p => p.productId !== product.productId);
    sessionStorage.setItem("cart", JSON.stringify(updatedCart));
    document.getElementById('tbody').replaceChildren();
    getCart();
}




const headeValues = () => {
    let cart = JSON.parse(sessionStorage.getItem('cart')) || []
    let totalPrice = 0
    cart?.forEach(p => {
        totalPrice += p.price * p.qty
    })
    document.getElementById("itemCount").innerHTML = cart.length;
    document.getElementById("totalAmount").innerHTML = totalPrice;



}

const placeOrder = async () => {

    const cart = JSON.parse(sessionStorage.getItem('cart'))
    if (!cart) {
        alert("הסל ריק, אתה מועבר להוספת מוצרים")
        window.location = 'Products.html'
        return
    }
    const user = JSON.parse(sessionStorage.getItem('user'))
    if (!user) {
        alert("יש להתחבר/להירשם לפני ביצוע הזמנה");
        return
    }

    let orderItems = []
    cart.forEach(p => {
        orderItems.push({
            "ProductId": p.productId,
            "Quantity": p.qty
        })
    })

    const order = {
        UserId: user.userId,
        Date: new Date(),
        Sum: totalPrice,
        OrderItems: orderItems
    }

    const responsePost = await fetch("api/Order", {
        method: "POST",
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(order)
    })

    const dataPost = await responsePost.json();
    if (dataPost) {
        sessionStorage.removeItem("cart")
        alert("הזמנתך בוצעה בהצלחה!!")
        window.location = 'Products.html'
    } else {
        alert("התרחשה בעיה במהלך סגירת הזמנה...")
    }
}


getCart()




