


const Login = async () => {
    console.log("Login function")
    const postData = {
        email: document.getElementById("emailLogin").value,
        password: document.getElementById("passwordLogin").value
    }
    console.log("postData", postData)
    const responsePost = await fetch('api/Users/login', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(postData)
    });
    const dataPost = await responsePost.json();
    console.log("dataPost", dataPost)
    if (responsePost.ok) {
        sessionStorage.setItem("user", JSON.stringify(dataPost));
        window.location.href = "Products.html";
    }
    
}


const Register = async () => {
    const postData = {
        email: document.getElementById("emailRegister").value,
        password: document.getElementById("passwordRegister").value,
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value
    }
    const responsePost = await fetch('api/users/register', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(postData)
    });
    //try {
    //    const dataPost = await responsePost.json();
        
    //}
    //catch {
    //    alert("catch..............")
    //}

    if (responsePost.status==200) {
        //const dataPost = await responsePost.json();
        window.location.href = "Login.html";
    }
}


const UpdateUserDetails = async () => {
    
    const postData = {
        email: document.getElementById("email").value,
        password: document.getElementById("passwordRegister").value,
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value
    }

    const responsePost = await fetch(`api/users/${JSON.parse(sessionStorage.getItem("user")).userId}`, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(postData)
    });
    const dataPost = await responsePost.json();

    if (responsePost.ok) {
        /*console.log(dataPost);*/
        sessionStorage.removeItem("user");
        sessionStorage.setItem("user", JSON.stringify(postData))
        alert("user updated successfully");
        window.location.href = "Products.html";
  
       
    }
    console.log("responsePost.status: ",responsePost.status)
    if (responsePost.status==400)
        alert("fields are invalid")
}


const CheckPassword = async () => {
    let password = document.getElementById("passwordRegister").value;
    let progrees = document.getElementById("passwordStrengh")//.value;
    const responsePost = await fetch('api/users/checkPassword', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(password)
    });
    const dataPost = await responsePost.json();
    progrees.value = dataPost
    console.log("dataPost111111", dataPost);

    document.getElementById("passwordStrengh").value = dataPost;
}
