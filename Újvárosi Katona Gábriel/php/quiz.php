<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>QUIZ</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">

</head>
<body >
    

<h1 class="text-center">Quiz</h1>

<form action="" method="post">
    <div class="container">
        <div class="row">
            <div class="col-sm-12 text-center">
                <h3>1. kérdés</h3>
                <label for="">Mennyi hónapig tart egy terhesség?</label> <br>
                <label for="7">7 hónap</label>
                <input type="radio" name="terhes" id="7" value="7">
                <label for="8">8 hónap</label>
                <input type="radio" name="terhes" id="8" value="8"> <br>
                <label for="9">9 hónap</label>
                <input type="radio" name="terhes" id="9" value="9">
                <label for="6">6 hónap</label>
                <input type="radio" name="terhes" id="6" value="6">
                
                <br>




            </div>

        </div>
        <div class="row mt-3">
        <div class="col-sm-12 text-center"> 
        <h3>2. kérdés</h3>
                <label for="">Az alábiak közül melyik atuó márka nem francia</label> <br>
              
                <label for="7">Citroen</label>
                <input type="radio" name="auto" id="7" value="CIT">
                <label for="8">Mercedes</label>
                <input type="radio" name="auto" id="8" value="MERC"> <br>
                <label for="9">Peugeot</label>
                <input type="radio" name="auto" id="9" value="PEG">
                <label for="6">Renault</label>
                <input type="radio" name="auto" id="6" value="REN">
                
                <br>




        </div>
        </div>
        <div class="row mt-3">
        <div class="col-sm-12 text-center"> 
        <h3>3. kérdés</h3>
        <label for="">írja be a hiányzó szót a mondatból:</label> <br>

        Aki korán kell, ... lel <br>
        <input type="text" name="mondat" id="mondat">



        </div>
        </div>
        <div class="row mt-3">
        <div class="col-sm-12 text-center"> 
        <h3>4. kérdés</h3>
        <label for="">Az allábiak közül melyik órák után van 20 perces szünet?</label> <br>
                      <label for="4ora">4</label>
                <input type="checkbox" name="4ora" id="4ora" >
                <label for="1ora">1</label>
                <input type="checkbox" name="1ora" id="1ora" > <br>
                <label for="2ora">2</label>
                <input type="checkbox" name="2ora" id="2ora" >
                <label for="5ora">5</label>
                <input type="checkbox" name="5ora" id="5ora" >
                
                <br>



        </div>
        </div>
        <div class="row">
            <div class="col-ms-12 text-center">
            <input  type="submit" name="submit" value="Beküldés" id="Submit" class="btn btn-success mt-3" >

            </div>
        </div> 

    </div>
</form>



<?php

    

   if (isset($_POST['submit'])){
    if (!isset($_POST['terhes']) || !isset($_POST['auto'])){
        echo "<script> alert('Töltse ki a mezőket!')</script>";
    } else {

    $elso = 9;
    $elsoValasz = $_POST['terhes'];
    $elertPont = 0;
    $maxpont = 4;
    $masodik = "MERC";
    $masodikValasz = $_POST['auto'];
    $harmadik = "aranyat";
    $haradikValasz = $_POST['mondat']; 
    


    if ($elsoValasz == $elso) {
        $elertPont++;

    }
    if ($masodikValasz == $masodik) {
        $elertPont++;
    }
    if ($haradikValasz == $harmadik) {
        $elertPont++;
    }
    if (isset($_POST['4ora']) && isset($_POST['5ora']) && !isset($_POST['1ora']) && !isset($_POST['1ora']) ) {
        $elertPont++;
    }
   echo "<b> Elért pont:  ".$elertPont."</b>";
    


   
}
   }
?>


<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>
</html>
