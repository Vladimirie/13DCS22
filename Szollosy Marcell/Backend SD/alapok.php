<?php
/*
echo "<h1>Hello World</h1>";

$valami = "<h3>teszt</h3>";

echo $valami;


$a = 50;
$b = 50;

echo $a + $b;

echo "<br>";

if ($a > $b) {
    echo " Az A nagyobb, mint a B";
}else if($b > $a){
    echo "A B nagyobb, mint az A";
}else{
    echo "A két szám egyenlő";
}

echo "<br>";

for ($i=0; $i < 10; $i++) { 
    echo $i;
}

$j = 0;
while ($j < 10) {
    echo $j;
    $j++;
}

// 1-tőé 100-ig jelenlenek meg
// 3-mal osztható számok

for ($j = 1; $j < 101; $j++) {
    if ($j % 3 == 0){
        echo "<bra>";
        echo $j;
    }
}

echo "<br>";
//1-től 100 -ig legyenek kiírva és
//az 5 többszörösei legyenek félkövérek
echo "<table>";
$szam = 1;
for ($i=0; $i < 10; $i++) {
    echo "<tr>";
    for ($j=0; $j < 10; $j++) {
        if ($szam % 5 == 0) {
            echo "<td><b>".$szam."</b></td>";
        }else{
            echo "<td>".$szam."</td>";
        }
        $szam++;
    }
    echo "</tr>";
}
echo "</table>";
*/

$szamok = [2, 5, 10, 12, 64, 23, 73, 4, 19, 47];
/*
foreach ( $szamok as $szam) {
    if ($szam % 2 == 0) {
        echo $szam." ";
    }
*/
/*
echo "<h1>Programozási tételek</h1>";

echo "<b> Tömb elemei: ";
foreach ($szamok as $szam) {
    echo $szam." ";
}

echo "<h2>1. Maximum Kiválasztás</h2>";

$max = $szamok[0];
foreach ($szamok as $maxkeres) {
    if ($maxkeres > $max) {
        $max = $maxkeres;
    }
}

echo "A legnagyobb szám: ".$max;

echo "<h2>2. Lineáris keresés</h2>";

$index = 0;
$found = false;
while (!$found && $index < count($szamok)) {
    if ($szamok[$index] == 23) {
        $found = true;
    }else{
        $index++;
    }
}

if ($found){
    echo " A keresett szám megtalálható a ".($index + 1 ).". helyen.";
}else{
    echo " A keresett szám nincs benne a tömben.";
}

echo "<h2>3. Kiválasztás</h2>";

$pos = 0;
$found = false;

while (!$found && $pos < count($szamok)) {
    if ($szamok[$pos] == 23){
        $found = true;
    }
    $pos++;
}

if($found) {
    echo "A szám a ".$pos.". helyen van.";
}

echo "<h2>4. Eldöntés</h2>";

$index = 0;
$found = false;

while (!$found && $index < count($szamok)) {
    if ($szamok[$index] == 23){
        $found = true;
    }
    $index++;
}

if ($found) {
    echo "Benne van a tömben a szám";
}else{
    echo "nincs benne a tömbben a szám.";
}

echo "<h2>5. Sorozatszámítás</h2>";

$sum = 0;

foreach ($szamok as $szam) {
    if ($szam % 2 != 0) {
        $sum += $szam;
    }
}
echo "A páratlan számok összege: ".$sum;

echo "<h2>6. Megszámlálás</h2>";

$db = 0;

foreach ($szamok as $szam) {
    if ($szam % 2 == 0) {
        $db++;
    }
}

echo $db. " db paros szám található";
*/
/*

echo "<h1>Mátrixok</h1>";

$emberek = [
    ["János", "Budapest", 17, "tanuló"],
    ["Elemér", "Kecskemét", 28, "orvos"],
    ["Károly", "Budapest", 33, "rendőr"],
    ["Ference", "Miskolc", 58, "üzletvezető"],
    ["Gábor", "Budapest", 31, "rendőr"],
    ["István", "Szeged", 47, "pék"]
];

//1. Feladat
//Mennyi emberről van adatunk?
echo count($emberek), "  darab emberről van adatunk";

//2. Feladat
//Mennyi a budapesti lakosok átlad életkora?

$budapestiek = 0;
$atlagelet = 0;

foreach ($emberek as $budapesti) {
    if ($budapesti[1] == "Budapest") {
        $budapestiek++;
        $atlagelet += $budapesti[2];
    }
}

echo "Budapestiek átlagáletkore: ".($atlagelet / $budapestiek);

//3. Feladat
//Melyik a legfiatalabb rendőr?

echo "<h3>3. feladat"

$min = 0;
$minvan = false;
$minnev = "";

foreach ($emberek as $emberek) {
    if ($ember[3] == "rendör"){
        if (!$minvan) {
            $min = $ember[2];
            $minvan = true;
            $minnev = $ember[0];
        }elseif ($min > $ember[2]) {
            $min = $emner[2];
            $minnev = $ember[0];
        }
    }
}

echo "A legfiatalabb rendör: ".$minnev;

//4. Feladat
//Van-e az emberek között pék? 
//Ha igen, milyen idős és hol lakik?

echo


$vanpek = false;
$index = 0;
$pekindex = 0;
while (!$vanpek && $index < count($emberek)) {
    if($emberek[$index][3] == "pék") {
        $vanpek = true;
        $pekindex = $index;
    }
    $index++;
}

if ($vanpek) {
    echo "A pék". $emberek[$pekindex][20]." éves és ". $emberek[$pekindex][]
}else{
    echo "nincsen pék"
}
*/












echo "<h1>Függvények, metódusok</h1>";

function teszt(){
    echo "Hello World";
}

teszt();
echo "<br>";


function teszt2($ertek){
    echo $ertek;
}

teszt2(50);
echo "<br>";

function teszt3($ertek){
    return $ertek;
}

echo teszt3(20);
echo "<br>";


$tomb1 = [51, 2, 67, -12, 52, 33, 92, 44];
$tomb2 = [21, -6, -52, 1, 32, 69, -2, 22];

//1. Feladata
//Írj egy olyan függvényt, amely mind a két tömbre
//alkalmazható és összeadja a tömb értékeinek összegét

echo "<h2> 1. Feladat</h2>";

function tombOsszeg($tomb) {
    $ossz = 0;
    foreach ($tomb as $elem) {
        $ossz += $elem;
    }
    return $ossz;
}

echo "tomb1 összege: " . tombOsszeg($tomb1)  . "\n";
echo "<br>tomb2 összege: " . tombOsszeg($tomb2)  . "\n";

//2.Feladat
//Írj egy olyan függvényt, amely mind a két tömbre
//alkalmazható és megmondja mennyi páratlan szám található

echo "<h2>2. Feladat</h2>";

function paratlanokSzama($tomb) {
    $darab = 0;
    foreach ($tomb as $elem) {
        if ($elem % 2 != 0) {
            $darab++;
        }
    }
    return $darab;
}

echo "Tomb1 páratlanjai: " . paratlanokSzama($tomb1) . "\n";
echo "<br>Tomb2 páratlanjai: " . paratlanokSzama($tomb2) . "\n";

//3. Feladat
//Írj egy olyan függvényt, amely mind a két tömbre
//alkalmazható és meghatározza, melyik a legkisebb szám

echo "<h2>3. Feladat</h2";
echo "<br>";
function legkisebbSzam($tomb) {
    if (empty($tomb)) {
        return null;
    }
    $legkisebb = $tomb[0];
    for ($i = 1; $i < count($tomb); $i++) {
        if ($tomb[$i] < $legkisebb) {
            $legkisebb = $tomb[$i];
        }
    }
    return $legkisebb;
}

echo "<br>A tomb1 legkisebb eleme: " . legkisebbSzam($tomb1) . "\n";
echo "<br>A tomb2 legkisebb eleme: " . legkisebbSzam($tomb2) . "\n";



//4. Feladat
//Írj egy olyan függvényt, amely mind a két tömbre
//alkalmazható és meghatározza, hogy van-e olyan szám ami osztható-e 7-tel?

echo "<h2>4. Feladat</h2>";

function hetes($tomb) {
    $i = 0;
    $van = false;
    while (!$van && $i < count($tomb)) {
        if ($tomb[$i] % 7 == 0) {
            $van = true;
        }
        $i++;
    }

    return $van;
}

if (hetes($tomb1)) {
    echo "Van benne";
}else{
    echo "Nincs benne";
}

echo "<br>";

if (hetes($tomb2)){
    echo "Van ilyen szám";
}else{
    echo "Nincs ilyen szám.";
}

?>