

const categoryIds = [];

const getProductsByFiltering = async () => {//string ? desc, int ? minPrice, int ? maxPrice, int ? [] categoryIds
    console.log(getProductsByFiltering) 
    let stringUrl = 'api/products?';

    const minPrice = document.getElementById('minPrice')?.value;
    const maxPrice = document.getElementById('maxPrice')?.value;
    const desc = document.getElementById('nameSearch')?.value;

    stringUrl += `desc=${desc}&minPrice=${minPrice}&maxPrice=${maxPrice}`
    categoryIds.forEach(id => {
        stringUrl += `&categoryIds=${id}`
    })
    console.log("stringUrl: ", stringUrl)
    const responseGet = await fetch(stringUrl)
    const dataGet = await responseGet.json();
    if (responseGet.ok) {
        console.log(dataGet)
        drawProduct(dataGet)
    }
}

const getAllProducts = async () => {


    //אם לחצו על נקה הכל מספר המוצרים בסל מתאפס. כאן מציגים אותו
    if (JSON.parse(sessionStorage.getItem('cart'))) {
        document.getElementById("ItemsCountText").innerHTML = JSON.parse(sessionStorage.getItem('cart')).length;
    }


    const responseGet = await fetch(`api/Products`)
    const dataGet = await responseGet.json();
    if (responseGet.ok) {
        console.log(dataGet)
        drawProduct(dataGet)
        setPrices(dataGet);
    }
}


const filterProducts = () => {

    var productList = document.getElementById('ProductList');
    productList.innerHTML = '';
    getProductsByFiltering();

}




const getAllCategories = async () => {
    console.log("getAllCategories")
    const responseGet = await fetch('api/Categories')
    const dataGet = await responseGet.json();
    if (responseGet.ok) {
        console.log(dataGet)
        //drawProduct(dataGet)
        drawCategory(dataGet);
    }
}



const drawProduct = async (products) => {
    let temp = document.getElementById('temp-card');

    products.forEach(product => {
        const clone = temp.content.cloneNode(true);
        clone.querySelector('img').src = `Images/${product.imageUrl}`;
        clone.querySelector('h1').textContent = product.productName;
        clone.querySelector('.price').textContent = product.price;
        clone.querySelector('.description').textContent = product.description;

        clone.querySelector('button').addEventListener('click', () => {
            console.log('Product added to cart:', product.description);
            addToBasket(product);
        });

        document.getElementById('ProductList').appendChild(clone);
    })
}



const drawCategory = async (categories) => {
    let temp = document.getElementById('temp-category');

    console.log(categories);

    categories.forEach(category => {
        const clone = temp.content.cloneNode(true);

        clone.querySelector('.opt').id = category.categoryId;
        clone.querySelector('.opt').value = category.categoryName;
        clone.querySelector('label').for = category.categoryName;
        clone.querySelector('.OptionName').textContent = category.categoryName;

        clone.querySelector('input').addEventListener('change', (e) => {
            const categoryId = parseInt(e.target.id, 10);
            if (e.target.checked && !categoryIds.includes(categoryId)) {
                categoryIds.push(categoryId);
            } else {
                const indexToRemove = categoryIds.indexOf(categoryId);
                if (indexToRemove !== -1) {
                    categoryIds.splice(indexToRemove, 1);
                }
            }

            filterProducts();
            console.log(categoryIds); // Check the updated categoryIds
        });

        document.getElementById('categoryList').appendChild(clone);
    });
}



const addToBasket = async (product) => {
    console.log("product: ", product)
    let flag = false
    let cart = JSON.parse(sessionStorage.getItem('cart')) || []
    if (cart.length > 0) {
        cart.forEach((e) => {
            if (e.productId == product.productId) {
                e.qty += 1
                e.price += product.price
                flag = true
            }

        })
        if (!flag) {
            let pro1 = { ...product, qty: 1 }
            console.log("before push: ", cart);
            cart.push(pro1)
            console.log("after push: ", cart);

        }
    }
    else {
        let pro = { ...product, qty: 1 }
        cart.push(pro)
    }

    sessionStorage.setItem("cart", JSON.stringify(cart))
    document.getElementById("ItemsCountText").innerHTML = cart.length;
}




const setPrices = (products) => {
    let min = 1000000;
    let max = -1;

    products.forEach(product => {
        if (product.price < min) {
            min = product.price;
        }
        if (product.price > max) {
            max = product.price;
        }
    });

    document.getElementById('minPrice').value = min;
    document.getElementById('maxPrice').value = max;
};


const clearCart = () => {

    sessionStorage.removeItem("cart");
    
}






getAllCategories();
getAllProducts();
