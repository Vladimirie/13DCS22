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
          <a class="nav-link active" href="#">Itemek</a>
        </li>
        <!-- GABI -->
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="monsters.php">Szörnyek</a>
        </li>
        <!-- ZSOMBOR -->
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="quests.php">Questek</a>
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

$items = $data['targyak'];

//mindegyik item a shopban
foreach ($items as $item) {
  echo"
  <div class='col'>
  <div class='card' style='background-color: grey'>";

  //item képe
  echo"<img src='images/" . $item['icon'] ."' class='card-img-top' style='border: black 0.3pc solid;'>
  <div class='card-body'";
  
  //ritkaság alapján való szín
  if ($item['ritkasag'] == 'közönséges') {
    echo "style='color: lightblue'";
  }
  else if ($item['ritkasag'] == 'ritka')
  {
    echo "style='color: lightgreen'";
  }
  else if ($item['ritkasag'] == 'epikus')
  {
    echo "style='color: purple'";
  }
  else {
    echo "style='color: orange'";
  }
  echo".> <h1 class='card-title'";

  //név és kategória
  echo">" . $item['tipus'] .": ". $item['nev'] ."</h1>";

  //adatok
  //ár
  echo"<h3 class='card-text'>Költség: ". $item['ertek']."</h3>";

  //szint
  echo"<h3 class='card-text'>Szint követelmény: ". $item['szint_kovetelmeny']."</h3>";

  //eladható-e
  echo"<h3 class='card-text'>Értékesíthető? ";
  if ($item['ertekesitheto']) {
    echo "Igen";
  }
  else {
    echo "Nem";
  }
  echo "</h3>";

  //felvehető-e
  echo"<h3 class='card-text'>Felvehető? ";
  if ($item['equipelheto']) {
    echo "Igen";
  }
  else {
    echo "Nem";
  }
  echo "</h3>";

  //bónuszok
  if (count($item["bonuszok"]) > 0) {
    echo "<h1>Bónuszok:</h1>";
    echo "<ul>";
    foreach($item["bonuszok"] as $key => $value) {
      echo"<li style='font-size: 3ch;";

      if ($key == "sebzes") {
        echo "color: red; '> Sebzés";
      }
      else if ($key == "tuz") {
        if ($item['tipus'] != "páncél") {
          echo "color: orange; '> Tűz sebzés";
        }
        else {
          echo "color: orange; '> Tűz védelem";
        }
      }
      else if ($key == "vedelem") {
        echo "color: blue; '> Védelem";
      }
      else if ($key == "hp_heal") {
        echo "color: salmon; '> Életpont";
      }
      else if ($key == "mp_heal") {
        echo "color: aquamarine; '> Mana";
      }
      else if ($key == "kritikus") {
        echo "color: darkred; '> Kritikus%";
      }
      else if ($key == "mana") {
        echo "color: aqua; '> Max Mana";
      }
      else if ($key == "jeg") {
        if ($item['tipus'] != "páncél") {
          echo "color: cyan; '> Jég sebzés";
        }
        else {
          echo "color: cyan; '> Jég védelem";
        }
      }
      else if ($key == "lassitas") {
        echo "color: black; '> Lassítás";
      }
      else if ($key == "arny") {    
        if ($item['tipus'] != "páncél") {
          echo "color: purple; '> Árny sebzés";
        }
        else {
          echo "color: purple; '> Árny védelem";
        }
      }
      else if ($key ==  "hp_max") {
        echo "color: red; '> Max Életpont";
      }
      else if ($key ==  "időtartam_mp") {
        echo "color: white; '> Időtartam";
      }
      else if ($key == "eletero_regen") {
        echo "color: pink; '> Regeneráció";
      }
      else {
        if ($item['tipus'] != "páncél") {
          echo "color: yellow; '> Fény sebzés";
        }
        else {
          echo "color: yellow; '> Fény védelem";
        }
      }

      if ($key != "időtartam_mp") {
        echo ": +" . $value ."</li>";
      }
      else {
        echo ": " . $value ."sec</li>";
      }
      
    }
    echo "</ul>";
  }
  
  echo"  </div>
  </div>
  </div>";
}
    //<p class='card-text'>This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>";

?>

</div>

</body>
</html>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>