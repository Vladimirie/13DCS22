function CreateRow() {
    let tabla = document.getElementById("table");

    let ujSor = tabla.insertRow();

    let cella1 = ujSor.insertCell(0);
    let cella2 = ujSor.insertCell(1);

    cella1.innerText = "Adat";
    cella2.innerText = "Adat";
}

function AddToList() {
    let lista = document.getElementById("listy");

    let ujAdat = document.createElement("li");
    ujAdat.innerText= "Adat";
    lista.appendChild(ujAdat);

}

function DataBaseRead() {
    const apiUrl = 'api.php';

    const infoTable = document.getElementById('result_table');
    
    fetch(`${apiUrl}?action=tasks`)
        .then(res => res.json())
        .then(data => {
            let html = ""

            data.forEach(element => {
                html += "<p> <h1>"+ element.title +
                "</h1> <h1>" + element.description +
                "</h1> <h1>"+ element.id +
                "</h1> </p> <br>";
            })

            document.getElementById("result_table").innerHTML = html;
        })
}