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
  <div class="container-fluid" >
    <a class="navbar-brand" href="#">Navbar</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="#">Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="./monsters.php"> Szörnyek</a>
        </li>
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
            Dropdown
          </a>
          <ul class="dropdown-menu">
            <li><a class="dropdown-item" href="#">Action</a></li>
            <li><a class="dropdown-item" href="#">Another action</a></li>
            <li><hr class="dropdown-divider"></li>
            <li><a class="dropdown-item" href="#">Something else here</a></li>
          </ul>
        </li>
        <li class="nav-item">
          <a class="nav-link disabled" aria-disabled="true">Disabled</a>
        </li>
      </ul>
      <form class="d-flex" role="search">
        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
        <button class="btn btn-outline-success" type="submit">Search</button>
      </form>
    </div>
  </div>
</nav>
<?php 
$file_path = 'game.json';

$json = file_get_contents($file_path);

$data = json_decode( $json, true);
?> 
vers : <?php echo $data['meta']['verzio'] ?>v

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
      Column
    </div>
  </div>
</div>








<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>
</html>