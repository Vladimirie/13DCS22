
function Save(){

    let nev = document.getElementById("Name").value;
    let idopont = document.getElementById("time").value;
    let sportag = document.getElementById("sportag").value;
    let berlet = document.getElementById("berlet").value;



    let rekord = {nev, idopont, sportag, berlet};

    let lista = JSON.parse(localStorage.getItem("foglalasok") || "[]");
    lista.push(rekord);
    localStorage.setItem("foglalasok", JSON.stringify(lista))
   // document.getElementById("foglalas-form").reset();



}

function Read(){
   
    let lista = JSON.parse(localStorage.getItem("foglalasok") || "[]");

  


    let html = "<table> <tr> <th>Név</th> <th> Időpont </th> <th> Sportág</th> <th> Bérlet </th> </tr>";
    for (let elem of lista) {
        html += '<tr> <td> ${elem.nev}</td> <td> ${elem.indopont}</td> <td> ${elem.sportag}</td> <td> ${elem.berlet}</td> </tr>';
    }
html += "</table>";
document.getElementById("tabla").innerHTML = html;
}

function Clear() {
    localStorage.clear();
}