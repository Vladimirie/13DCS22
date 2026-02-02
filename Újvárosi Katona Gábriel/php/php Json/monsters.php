<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
    <title>fantasy piactér és kaland</title>
</head>
<body style="background-image: url(./hatter.jpg) ;background-repeat: no-repeat; background-size: cover; Color: White; "> 
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
<?php 
$file_path = 'game.json';

$json = file_get_contents($file_path);

$data = json_decode( $json, true);
?> 








<?php 


echo '<div class="container text-center">';
echo'<div class="row row-cols-2">';

foreach ($data['szornyek'] as $monster){

    echo '<div class="card border-info mb-3" style="width: 18rem;">';
    echo '<img src="./snek.jpg" class="card-img-top"alt="'.$monster['nev'].'">';
    echo  '<h5 class="card-title">'.$monster['nev'].'</h5>';
    echo '<ul>';
    

switch ($monster['kategoria']) {
    case "elementál":
      
        echo '<li style="color: magenta;">Elementál</li>';
      break;
    case "szellem":
        echo '<li style="color: gray;">Szellem</li>';
      break;
    case "vad":
        echo '<li style="color: brown;">Vad</li>';
      break;
      case"őr":
        echo '<li style="color: Blue;">Őr</li>';
        break;
        case"főellenfél":
            echo '<li style="color: gold; background-color: black ">Főellenfél</li>';
            break;
        case"humanoid":
         echo '<li style="color: black;">Humanoid</li>';
       break;
       case"elit":
        echo '<li style="color: red;">Elit</li>';
      break; 
      case"óriás":
        echo '<li style="color: mediumpurple ;">Óriás</li>';
      break;   
    default:
            echo '<li>'.$monster['kategoria'].'</li>';
            break;
  }
  
  
 echo '<li> Xp mennyiség: '.$monster['xp'].'</li>';
 echo '<li> arany Drop: '.$monster['arany'].'</li>';

  echo '</ul>';
    echo '<h4> Dropok: </h4>';
    echo '<div class="container text-center">';
    echo '<div class="row">';
    foreach ($monster['dropok'] as $loot){

      echo' <div class="col">';
        $found = false;
        $index = 0;
        while (!$found && $index < count($data['targyak'])) {
            if ($data['targyak'][$index]['id'] == $loot['item_id']) {

              $found = true;
              echo $data['targyak'][$index]['nev'];

            }
            $index++;


        }
          echo      ' Dropolás esélye: '.$loot['esely_szazalek'];
          echo ' Min drop: '.$loot['min_db'];
          echo ' Max drop: '.$loot['max_db'];

     echo'</div>';


    }

 


echo'</div>';
echo '</div>';


echo '  </div>';



}



echo '  </div>';

echo '  </div>';
?>














<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>
</html>