
document.getElementById("table-bt").addEventListener("click", addtablecell); 
document.getElementById("list-bt").addEventListener("click", createlistelement); 
document.getElementById("div-bt").addEventListener("click", addtext); 
function addtablecell (){
/*
let tabla = document.querySelector("table");

let usSor = tabla.insertRow();

let cella1 = usSor.insertCell(0);
let cella2 = usSor.insertCell(1);

cella1.innerText = "Első oszlop";
cella2.innerText = "Második oszlop"
*/
let tbody = document.getElementById("tabla");

let ujSor = tbody.insertRow()
let cella1 = ujSor.insertCell(0)
let cella2 = ujSor.insertCell(1)

cella1.innerText = "01"
cella2.innerText = "Kovács Jávos";

}

function createlistelement () {
    let lista = document.getElementById("sorszamozott-lista");
let li = document.createElement("li");
li.innerText = "Új elem a listában";
lista.appendChild(li)
}

function addtext() {

    let kontener = document.getElementById("mezo-kontener");
    let input = document.createElement("input");
    input.type = "text";
    input.placeholder = "Írj ide...";
    kontener.appendChild(input);
}




const appData = {
    "kocsik":[
        {"id": 1, "m": "Lada", "t" : "2107"},
        {"id": 2, "m": "Trabant", "t" : "601"},
        {"id": 3, "m": "Wartburg", "t" : "353"}
    ]
}

document.getElementById("table-bt2").addEventListener("click", filltable); 

function filltable() {
    let tbody = document.getElementById("tabla2");

    

    for ( i = 0; i < appData.kocsik.length; i++) {
            console.log(i)
          

            let ujSor = tbody.insertRow()
            let cella1 = ujSor.insertCell(0)
            let cella2 = ujSor.insertCell(1)
            let cella3 = ujSor.insertCell(2)

            cella1.innerText = appData.kocsik[i].id
            cella2.innerText = appData.kocsik[i].m
            cella3.innerText = appData.kocsik[i].t

    }
  

}
