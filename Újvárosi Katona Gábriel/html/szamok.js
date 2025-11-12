numberarray = [];

dszamcount = document.getElementById("szamcont");

function generatearray() {

for (i = 0;  i < document.getElementById("arraylength").value; i++){
    numberarray[i] = Math.floor(Math.random() * 10) 

    dszamcount.innerText += numberarray[i] + ", "
    

}


}


function Sort(){
    dszamcount.innerText = ""
    sorted = false
while(!sorted)  {
sorted = true

for (i = 1; i < numberarray.length; i++) {
    if (numberarray[i] < numberarray[i - 1]) {
        temb = numberarray[i]
        numberarray[i] = numberarray[i - 1]
        numberarray[i - 1] = temb;
        sorted = false
    }


}

}

for (i = 1; i < numberarray.length; i++) {
    dszamcount.innerText += numberarray[i] + ", "
}


}