<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>QUIZ</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">

</head>
<body>

<h1 class="text-center">Quiz</h1>

<form action="" method="post">
    <div class="container">
        <div class="row">
            <div class="col-sm-12 text-center">
                <h3>1. Kérdés</h3>
                <label for="">Mennyi hónapig tart egy terhesség?</label>
                <br>
                <input type="radio" name="terhes" id="7" value="7">
                <label for="7">7 hónap</label>
                <input type="radio" name="terhes" id="8" value="8">
                <label for="8">8 hónap</label>
                <br>
                <input type="radio" name="terhes" id="9" value="9">
                <label for="9">9 hónap</label>
                <input type="radio" name="terhes" id="6" value="6">
                <label for="6">6 hónap</label>

            </div>
        </div>

        <div class="row">
            <div class="col-sm-12 text-center">
            <h3>2. Kérdés</h3>
                <label for="">Az allábiak közöl melyik nem francia?</label>
                <br>
                <input type="radio" name="auto" id="Cirtoen" value="Cirtoen">
                <label for="Cirtoen">Cirtoen</label>
                <input type="radio" name="auto" id="Peugeot" value="Peugeot">
                <label for="Peugeot">Peugeot</label>
                <br>
                <input type="radio" name="auto" id="Mercedes" value="Mercedes">
                <label for="Mercedes">Mercedes</label>
                <input type="radio" name="auto" id="Renault" value="Renault">
                <label for="Renault">Renault</label>

            </div>
        </div>

        <div class="row mt-3">
            <div class="col-sm-12 text-center">
            <h3>3. Kérdés</h3>
                <label for="">Írja be a hiányzó szót a mondatból:</label>
                <br>
                <label for="">Why are you ____ ?</label>
                <br>
                <input type="text" name="Running" id="Running">
            </div>
        </div>

        <div class="row mt-3">
            <div class="col-sm-12 text-center">
            <h3>4. Kérdés</h3>
                <label for="">Az alábbiak közül, melyik órák után van 20 perces szünet?</label>
                <br>
                <input type="checkbox" name="3ora" id="3ora">
                <label for="3ora">3. után</label>
                <input type="checkbox" name="4ora" id="4ora">
                <label for="4ora">4. után</label>
                <br>
                <input type="checkbox" name="5ora" id="5ora">
                <label for="5ora">5. után</label>
                <input type="checkbox" name="6ora" id="6ora">
                <label for="6ora">6. után</label>
            </div>
        </div>

        <div class ="row">
            <div class="col-sm-12 text-center">
                <input type="submit" name="submit" class="btn btn-success" value="Beküldés">
            </div>
        </div>
    </div>
</form>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>    
</body>
</html>

<?php

if (isset($_POST['submit'])) {

    if (!isset($_POST['terhes']) && !isset($_POST['auto']) && !isset($_POST['Running'])){
        echo "<script>alert('Töltse ki a mezőket!')</script'";
    }else{

        $elertPont = 0;
        $maxPont = 4;

        $elso = 9;
        $elsoValasz = $_POST['terhes'];
        $masodik ="Mercedes";
        $masodikValasz = $_POST['auto'];
        $harmadik = "Running";
        $harmadikValasz = $_POST['Running'];
        

        if ($elsoValasz == $elso) {
            $elertPont++;
        }
        if ($masodikValasz == $masodik) {
            $elertPont++;
        }
        if ($harmadikValasz == $harmadik){
            $elertPont++;
        }
        if (isset($_POST['4ora']) && isset($_POST['5ora']) && !isset($_POST['3ora']) && !isset($_POST['6ora']) ){
            $elertPont++;
        }

        echo "<b>Elért pont: ". $elertPont ."</b>";

    
}

}

?>