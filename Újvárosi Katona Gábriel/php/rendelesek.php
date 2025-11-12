<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>fantasy piactér és kaland</title>
    <style>
        td{
            border: solid;
        }

  
      
    </style>
</head>
<body>


<h1 style="text-align: center;">Bolti adatok</h1>
<?php

$file_path = 'data.json';

$json = file_get_contents($file_path);

$data = json_decode( $json, true);

$termekek = $data['termekek'];
$rendelesek = $data['rendelesek'];

echo "<h2>Raktáron</h2>";


echo "<table>" ;
echo "<tr>";
foreach($termekek as $termek){

    if ($termek['raktaron']) {
        echo "<tr>";
        echo "<td> ".$termek['nev']." </td>";
        echo "</tr>";
    }

}
echo "</tr>";
echo "</table>";


echo "<h2> Rendelések </h2>";

echo "<table>" ;
echo "<tr>"; 
echo "<th>"."Név"."</th>";
echo "<th>"."Árú"."</th>";
echo "<th>"."Ár"."</th>";
foreach($rendelesek as $rendeles){
echo "<tr>";
echo "<td>".$rendeles['vevo'] ."</td>";
$found = false;
$index = 0;
while (!$found) {
    if ($termekek[$index]['id'] == $rendeles['termek_id']) {
        $found = true;
        echo "<td>".$termekek[$index]['nev'] ."</td>";
        echo "<td>".$termekek[$index]['ar'] ."FT"."</td>";

    } 
    $index++;

}
echo "</tr>";



}
echo " </table>";

?>

<h2>Termékek</h2>
<form action="" method="post">

<Select onchange="this.form.submit()" name="termekvalasztas">
    <option value="">Válaszon egy kategóriát</option>
    <option value="gyumolcs">gyümolcs</option>
    <option value="pekaru">Pékárú</option>
    <option value="tej">Tej</option>
</Select>
</form>

<?php
if (isset($_POST["termekvalasztas"])) {

   
    
    foreach ($termekek as $termek){

            if ($termek["kategoria"] == $_POST['termekvalasztas']) {
                

                echo $termek["nev"]." ";
                if ($termek["raktaron"]) {

                    echo "Raktáron";
                } else {
                    echo "Elfogyott";
                }
                
                echo "<br>";
            }        
    }

}


 ?>

</body>
</html>