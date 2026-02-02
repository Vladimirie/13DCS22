function kalkulal(){
    //Űrlapadatok
    const szelesseg= document.getElementById("magassag").value;
    const magassag= document.getElementById("szelesseg").value;
    const papir=document.getElementById('papirtipus').value;

    //Számítások
    let terulet=Math.round((szelesseg*magassag)/10000);    
    let koltseg=terulet*papir;

    document.getElementById("terulet").textContent = terulet;
    document.getElementById("papir").textContent = papir;

    //Megjelenítés
    document.getElementById("koltseg").textContent = koltseg;
    document.getElementById('valasz').style.visibility = "visible";

   
}

