
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
let tbody = document.querySelector("table");

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