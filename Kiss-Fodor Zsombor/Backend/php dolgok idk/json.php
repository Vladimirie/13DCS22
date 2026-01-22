<?php

$file_path = 'adatok.json';

$json = file_get_contents(filename: $file_path);

$data = json_decode(json: $json, associative: true);

$people = $data['people'];

//var_dump($people);

/*

foreach ($people as $man) {
    echo $man['name'];
}
*/





/*
foreach ($people as $lakosok['city']){
    if ($lakosok['city'] == "Budapest"){
        $pestiszam++;
    }
}

echo "<p>A budapesti emberek széma: ".$pestiszam;

$osszeletkor = 0;
$atlageletkor = 0;

foreach ($people as $kor){
    $osszeletkor +=['age'];
    $atlageletkor++;
}

echo "<p>Átlag életkor: ".($osszeletkor / $atlageletkor);

$maxEletkor = 0;
$legidosebbNev = "";

foreach ($people as $szemely) {
    if ($szemely['age']) > $maxEletkor {
        $maxEletkor = $szemely['age'];
        $legidosebbNev = $szemel['name'];
    }

}

echo "<p>A legidősebb: ".$legidosebbNev ."</p>";
*/

//



echo "<table style='border: 2px solid black;'>";


foreach ($data['people'] as $row) {
    echo "<tr >";
    echo "<td>". $row['name']."</td>";
    echo "<td>". $row['age']."</td>";
    echo "<td>". $row['city']."</td>";
    echo "</tr>";
}

echo "</table>";