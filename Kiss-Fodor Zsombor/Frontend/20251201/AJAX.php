<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>AJAX</title>
    <link rel="stylesheet" href="AJAX.css">
</head>
<body>
    <div class="maindiv">
        <h1>Felhasználónév ellenörzés</h1>
        <input type="text" id="username">
        <p id="username-status"></p>
    </div>

    <div class="maindiv">
        <h1>Feladatok</h1>
        <button onclick=readToDos()>Feladatok Kiírása</button>

        <div id="result_table">

        </div>
    </div>
        
    <div class="maindiv">
        <h1>Új feladat hozzáadása</h1>
    </div>
</body>

<script>
    const apiUrl = 'api.php';

    const usernameInput = document.getElementById('username');
    const usernameStatus = document.getElementById('username-status');
    let usernameTimeout = null;

    usernameInput.addEventListener('input', () => {
    clearTimeout(usernameTimeout);
    const val = usernameInput.value.trim();
    if (!val) {
        usernameStatus.textContent = '';
        usernameStatus.style.color = '';
        return;
    }
    usernameStatus.textContent = 'Ellenőrzés...';
    usernameStatus.style.color = 'black';
    usernameTimeout = setTimeout(() => {
        fetch(`${apiUrl}?check_username=${encodeURIComponent(val)}`)
        .then(res => res.json())
        .then(data => {
            if (data.taken) {
            usernameStatus.textContent = 'Foglalt';
            usernameStatus.style.color = 'red';
            } else {
            usernameStatus.textContent = 'Szabad';
            usernameStatus.style.color = 'green';
            }
        }).catch(() => {
            usernameStatus.textContent = 'Hiba az ellenőrzés során';
            usernameStatus.style.color = 'orange';
        });
    }, 500);
    });

    const infoTable = document.getElementById('result_table');

    function readToDos() {
        fetch(`${apiUrl}?action=tasks`)
        .then(res => res.json())
        .then(data => {
            let html = ""

            data.forEach(element => {
                html += "<p> <input type='text' name='title' value='"+ element.title +
                "'> <input type='text' name='description' value='" + element.description +
                "'> <input type=button name='"+ element.id +
                " value='töröl' id ='deleteButton'> </p> <br>";
            })

            document.getElementById("result_table").innerHTML = html;
        })
    }
    
</script>
</html>