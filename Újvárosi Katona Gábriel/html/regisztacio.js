

goodpassword = false

function Login(){
    Email = document.getElementById("email").value;
    Password = document.getElementById("password").value;
    correctEmail = false;
    noneamptypassword = false
    if (Email == "") {
        alert("Kérjük töltse ki az Email mezőt")
    }


   else if (!Email.includes("@") && !Email.includes(".")) {

            alert("Kérjük valid emailt adjon meg!")



    } else {
            correctEmail = true;
    }

    if(Password == ""){
        alert("Kérem töltse ki a jelszó mezőt!")
    } else {
            noneamptypassword = true;
    }

    if (noneamptypassword && goodpassword && correctEmail) {
        window.open("https://www.youtube.com/watch?v=9vCb_ZopT4A")
    } else if  ((noneamptypassword && !goodpassword && correctEmail)){
            alert("Olvas meg tanulni!!")

    }

}

PasswordField =  document.getElementById("password");

PasswordField.addEventListener("keyup", function(event){

    
            ToggleWarning(event.getModifierState("CapsLock"))
            ActivePasswordCheck();

    


});

warningText = "A Caps Lock Be van kapcsovla!";

function ToggleWarning(State){

    if (State) {

        document.getElementById("warningfield").innerText = warningText;

    } else {
        document.getElementById("warningfield").innerText = "";
    }


}
Passworderrorfield = document.getElementById("passwrderrorfield");


function ActivePasswordCheck(){




        if (PasswordField.value.length < 5) {

       Passworderrorfield.innerText = "A jelszónak hoszabnak kell lenie 4 karakternél!";
    
        } else if (PasswordField.value.length > 25) {
            Passworderrorfield.innerText = "A jelszónak rövidebnek kell lennie 25 karakternél!"
        } else if (!PasswordField.value.includes("&") && !PasswordField.value.includes("#") && !PasswordField.value.includes("\\") && !PasswordField.value.includes("!") ) {
    
            Passworderrorfield.innerText = "A jelszónak tartamaznia kell speciális karaktereket!"


        } else {
            Passworderrorfield.innerText = "";
            goodpassword = true;
        }
    
}