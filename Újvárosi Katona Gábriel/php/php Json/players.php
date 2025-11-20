<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style>
      #jatekosquery{
        margin: auto;
        color: red;
      }


    </style>
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
vers : <?php echo $data['meta']['verzio'] ?>

<div class="container text-center">
  <div class="row">
    <div class="col">
    

    <h1>Guildek</h1>
   <table class="table" style="background-color:beige ; border:solid;">
    <tr>
        <th>Guild Neve </th>
        <th>Guild alapítása</th>
        <th>Guild Pontszáma</th>
        <th>Játékosok</th>
       

    </tr>
    
   
    <?php 
    foreach ($data['gildek'] as $gildek){
        echo "<tr>";
            echo "<td> ".$gildek['nev']. "</td>";
            echo "<td> ".$gildek['alapitas']. "</td>";
            echo "<td> ".$gildek['pont']. "</td>";
            echo "<td>";
            foreach ($gildek['tagok'] as $tag) {
                $found = false;
                $index = 0;
                
                while(!$found && $index < count($data['jatekosok'])){
                        if ($tag == $data['jatekosok'][$index]['id']) {
                            echo $data['jatekosok'][$index]['nev']." ";
                            $found = true;
                        }
                        $index++;
                }    


            }
            echo "</td>";
            echo "</tr>";
    }

    ?>




   
   </table>

    </div>
    <div class="col">
      <h1>Játékosok</h1>
      <table class="table" style="background-color:beige ; border:solid;">
      <tr>
    <th > Név </th >
    <th> Szint </th>
    <th> Faj </th>
    <th> Arany</th>
    <th> Guild</th>
    <th> Status</th>



      </tr>
<?php 
foreach ($data['jatekosok'] as $player){
  echo "<tr>";
  echo "<td>".$player['nev']."</td>";
  echo "<td>".$player['szint']."</td>";
  echo "<td>".$player['faj']."</td>";
  echo "<td>".$player['arany']."</td>";
  $found = false;
  $index = 0;
  while(!$found && $index < count($data['gildek'])) {
    if ($data['gildek'][$index]['id'] == $player['guild_id']){
        echo "<td>".$data['gildek'][$index]['nev']."</td>";
        $found = true;

    }
    $index++;

  }
  
  



if ($player['online']) {
  echo '<td style="color: green;">  Online  </td>';
} else {
  echo '<td style="color: red;">  Offline  </td>';
}


  echo "</tr>";
    

}




?>
      



      </table>


    <table>
    <tr>
        <th></th>
    </tr>




    </table>


    </div>
    <div class="col">
   <h1> Keresés</h1>  

  <form action="" name="search" id="search" method="post">
   <input type="text" name="Player_search" id="pl_search_input" onchange="this.form.submit()">
   </form>

   <?php
  if (isset($_POST["Player_search"])) {
      $found = false;
      $index = 0;
      while (!$found && $index < count($data['jatekosok']))  {
          if ($_POST["Player_search"] == $data['jatekosok'][$index]['nev']) {

              $found = true;
              KiIratas($data['jatekosok'][$index], $data);
          }
          $index++;

      } 

      if (!$found) {
        echo "<h3> A kereset játékos nem létezik(Román)";
      }

  };

  function KiIratas($keresetjatekos, $data){
  echo '<div class="jatekosquery" id="jatekosquery" style="background: white; color:black;">';
    echo '<h3>'.$keresetjatekos['nev'].'</h3>';
    echo '<h4> Szint </h4>';
    echo '<h4>'.$keresetjatekos['szint'].'</h4>';
    echo '<h4> Faj </h4>';
    echo '<h4>'.$keresetjatekos['faj'].'</h4>';
    echo '<h4> Arany </h4>';
    echo '<h4>'.$keresetjatekos['arany'].'</h4>';
    echo '<h4> Guild </h4>';
    $found = false;
    $index = 0;
    while (!$found && $index < count($data['gildek'])){
        if ($keresetjatekos['guild_id'] == $data['gildek'][$index]['id']){
          $found = true;
          echo '<h4>'.$data['gildek'][$index]['nev'].'</h4>';
        }
          $index++;
    } 
    if (!$found) {
      echo '<h4> Nincs Guildben </h4>';
    }
    echo '<h4> Online </h4>';
    if ($keresetjatekos['online']) {
      echo '<h4 style="color: green;"> Online </h4>';
    } else {
      echo '<h4 style="color: red;"> Offline </h4>';
    }
 


    $playerinvertory  = Getinventory($keresetjatekos['id'], $data);
    echo '<h4> Inventory </h4>';
    echo '<table class="table">' ;
    foreach ($playerinvertory as $item){
          echo "<tr>";

        $found = false;
        $index = 0;
   while (!$found && $index < count($data['targyak'])){
            if ($item['item_id'] == $data['targyak'][$index]['id']){
              $found = true;
              echo "<td style='border: solid;'>".$data['targyak'][$index]['nev']."</td>";
            }
            $index++;

    }   // Arelis
          echo "<td style='border: solid;'> Megyiség:".$item['mennyiseg'].'</td>';
          echo "<td style='border: solid;'> Állapot:".$item['allapot'].'</td>';
          if ($item['lejarat'] != null) {
            echo "<td style='border: solid;'> Lejárat:".$item['lejarat'].'</td>';
          } else  {
            echo "<td style='border: solid;'>Lejárat: Nincs </td>";
          }
     
          echo "</tr>";
    }
    echo "</table>";
  


    
    echo '<h5> Létehozva</h5>';
    echo '<h5>'.$keresetjatekos['letrehozva'].'</h5>';
    echo '<h5> Jelenlegi Szerver</h5>';
    echo '<h5>'.$keresetjatekos['szerver'].'</h5>';
 echo' </div>';
     
    

  };



function Getinventory($playerid, $data) {
  $found = false;
  $index = 0;
  while (!$found && $index < count($data['keszletek'])) {
     if ($data['keszletek'][$index]['jatekos_id'] == $playerid) {
          $found = true;
          return $data['keszletek'][$index]['tetelek'];
     }
     $index++;
  }
if (!$found) {
  return "Not_found";
}

};


?>

<div class="jatekosquery" style="background: white; color:black">
</div>

      
    </div>
  </div>
</div>








<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>
</html>