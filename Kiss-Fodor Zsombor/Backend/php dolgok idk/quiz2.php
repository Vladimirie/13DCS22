<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Quiz Feladat</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
<style>

    body {
        background-image: url("mili.jpg");
        color: white;
        font-weight: bold;
    }

    form {
        background-color: rgba(159, 91, 177, 0.73);
        width: 80ch;
        margin-right: auto;
        margin-left: auto;
    }

</style>
</head>
<body>
<form method="post" action="#" id="form">
    <div class="container">

        <div class="col-sm-12 text-center">
                <h3> 1. Kérdés</h3>
                <label for="">Melyik állat nyerte a futóversenyt?</label>
                <br>
                <input type="radio" name="futni" id ="nyul" value="nyul" class="radio">
                <label for="nyul">Nyúl</label>
                <input type="radio" name="futni" id ="teknos" value="teknos" class="radio">
                <label for="teknos">Teknős</label>
                <br>
                <input type="radio" name="futni" id ="none" value="none" class="radio">
                <label for="none">Egyik se</label>
                <input type="radio" name="futni" id ="both" value="both" class="radio">
                <label for="both">Mindkettő</label>          
        </div>

        <div class="col-sm-12 text-center">
                <h3> 2. Kérdés</h3>
                <label for="">Meyik állat NEM jár 4 lábon?</label>
                <br>
                <input type="radio" name="lab" id ="roka" value="roka" class="radio">
                <label for="roka">Róka</label>
                <input type="radio" name="lab" id ="far" value="far" class="radio">
                <label for="far">Farkas</label>
                <br>
                <input type="radio" name="lab" id ="zebr" value="zebr" class="radio">
                <label for="zebr">Zebra</label>
                <input type="radio" name="lab" id ="foka" value="foka" class="radio">
                <label for="foka">Fóka</label>          
        </div>

        <div class="col-sm-12 text-center">
                <h3> 3. Kérdés</h3>
                <label for="">Mi hiányzik Albert Estein híres tudományos egyenletében: E=(?)c²?</label>
                <br>
                <input type="radio" name="albert" id ="m" value="m" class="radio">
                <label for="m">m</label>
                <input type="radio" name="albert" id ="t" value="t" class="radio">
                <label for="t">t</label>
                <br>
                <input type="radio" name="albert" id ="v" value="v" class="radio">
                <label for="v">v</label>
                <input type="radio" name="albert" id ="c" value="c" class="radio">
                <label for="c">c</label>          
        </div>

        <div class="col-sm-12 text-center">
                <h3> 4. Kérdés</h3>
                <label for="">Melyik szót használja az Audi a kombi stílusú járműveire?</label>
                <br>
                <input type="radio" name="audi" id ="safari" value="safari" class="radio">
                <label for="safari">Safari</label>
                <input type="radio" name="audi" id ="Kombi" value="Kombi" class="radio">
                <label for="Kombi">Kombi</label>
                <br>
                <input type="radio" name="audi" id ="avant" value="avant" class="radio">
                <label for="avant">Avant</label>
                <input type="radio" name="audi" id ="tour" value="tour" class="radio">
                <label for="tour">Touring</label>          
        </div>
        
        <div class="col-sm-12 text-center" id="gomb">
                <input type="submit" name="submit" class="btn btn-success mt-3"></input>
        </div>
    </div>
</form>

<div class="col-sm-12 text-center" id="result" style="display: none;">
    <h1 id="nyeremeny"></h1>

    <div>
        <h1 id="didWeJustLose">VESZTETTÉL!</h1>
    </div>

    <button onclick="Reset()" style="width: 10ch;">Újra!</button>
</div>


<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>
</html>

<script>
    function Reset() {
        history.back()
        
    }
</script>

<?php

    $kerdesSzam = 0;
    $nyeremeny = 0;
    $nyerhetunk = true;

    if (isset($_POST["submit"])) 
    {   
        if (isset($_POST["futni"]) && isset($_POST["lab"])) {

            echo "<script>document.getElementById('form').style.display = 'none';</script>";
            echo "<script>document.getElementById('gomb').style.display = 'none';</script>";

            echo "<script>document.getElementById('checking').style.display = 'block';</script>";
            echo "<script>document.getElementById('nyeremeny').style.display = 'block';</script>";
            echo "<script>document.getElementById('didWeJustLose').style.display = 'block';</script>";
            $valasz = ["teknos", "foka", "m", "avant"];
            $kerdes = [$_POST["futni"], $_POST["lab"], $_POST["albert"], $_POST["audi"]];

            for ($i = 0; $i < count($kerdes); $i++) {
                if ($valasz[$kerdesSzam] == $kerdes[$kerdesSzam]) {
                $kerdesSzam += 1;
                if ($kerdesSzam == 0) {
                    $nyeremeny = 10000;
                }
                elseif ($kerdesSzam == 1) {
                    $nyeremeny = 10000;
                }
                else {
                    $nyeremeny = $nyeremeny * 2;
                }
                echo "<script>document.getElementById('nyeremeny').textContent = 'Nyeremény: ' + '$nyeremeny' + ' forint';</script>";
                echo "<script>document.getElementById('didWeJustLose').textContent = 'helyes válasz!!';</script>"; 
                }
                else {
                    $nyerhetunk = false;
                    $nyeremeny = 0;
                    echo "<script>document.getElementById('didWeJustLose').textContent = 'VESZTETTÉL!';</script>"; 
                    echo "<script>document.getElementById('nyeremeny').textContent = 'Nyeremény: ' + '$nyeremeny' + ' forint';</script>";
                }
            }

            if ($nyerhetunk == true) {
                echo "<script>document.getElementById('didWeJustLose').textContent = 'NYERTÉL!';</script>"; 
            }

            echo "<script>document.getElementById('checking').style.display = 'none';</script>";
            echo "<script>document.getElementById('result').style.display = 'block';</script>";
        } 
    }
?>