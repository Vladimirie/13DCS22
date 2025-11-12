<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="style.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
</head>
<body>

<?php

$file_path = 'game.json';

$json = file_get_contents( $file_path);

$data = json_decode($json, true);

?>

<nav class="navbar navbar-expand-lg bg-body-tertiary">
  <div class="container-fluid">
  <a class="navbar-brand" href="#">
      <img src="testi.webp" alt="Logo" width="30" height="30" class="d-inline-block align-text-top">
      Epic MMORPG Game
    </a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <!-- GABI -->
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="players.php">Játékosok és Guildek</a>
        </li>
        <!-- ZSOMBOR -->
        <li class="nav-item">
          <a class="nav-link" href="items.php">Itemek</a>
        </li>
        <!-- GABI -->
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="monsters.php">Szörnyek</a>
        </li>
        <!-- ZSOMBOR -->
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="quests.php">Questek</a>
        </li>
        <!-- -->
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="zones.php">Zonák</a>
        </li>
        <!-- -->
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="events.php">Eventek</a>
        </li>
        <!-- -->
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="trades.php">Tranzakciók</a>
        </li>
        <!-- -->
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="log.php">Log</a>
        </li>
      </ul>
    </div>
  </div>
</nav>

<div class="row row-cols-1 row-cols-md-2 g-4" style="padding: 2ch;">
<h1 style="color: white; font-weight: bold;">Tárgyak:</h1> <br>
<?php

$quests = $data['kuldetesek'];
$reqItems = $data['targyak'];
$reqMonsters = $data['szornyek'];

//mindegyik quest
foreach ($quests as $quest) {
    //quest neve
    echo"
    <div class='col'>
    <div class='card-body' style='background-color: grey'>
    <h1 class='card-title'>" . $quest['cim'] ."</h1>";

    //leírása
    echo"<h3 class='card-text'>Leírás: ". $quest['leiras']."</h3>";

    //kovetelmények
    echo"<h3 class='card-text'>Kellő szint: ". $quest['kovetelmenyek']['szint_min']."</h3>";
    if ($quest['kovetelmenyek']['targy_idk'] != null) {

        echo"<h3 class='card-text'>Kellő tárgyak: ";

        for ($i = 0; $i < count($quest['kovetelmenyek']['targy_idk']); $i++)  
        {
            if ($i != count($quest['kovetelmenyek']['targy_idk']) && $i != 0) {
                echo ", ";
            }
            for ($j = 0; $j < count($reqItems); $j++) {
                if ($reqItems[$j]['id'] == $quest['kovetelmenyek']['targy_idk'][$i]) {
                    echo $reqItems[$j]['nev'];            
                }
            }
        }
        echo "</h3>";
    }    
    //if ($quest['kovetelmenyek']['szorny_oles'] != null) {
        //echo"<h3 class='card-text'>Megöllendő szörnyek: ". $quest['kovetelmenyek']['szint_min']."</h3>";
    //}
    //határidő
    if ($quest['hatarido'] != null) {
        echo"<h3 class='card-text'>Határidő: ". $quest['hatarido']."</h3>";
    }
    else {
        echo"<h3 class='card-text'>Határidő: bármikor elvégezhető</h3>";
    }
    //jutalmak
    echo" 
    </div>
    </div>";
}
    //<p class='card-text'>This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>";

?>

</div>

</body>
</html>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>