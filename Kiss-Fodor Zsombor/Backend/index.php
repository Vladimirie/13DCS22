<?php
/*
echo "<h1> Hello Bello </h1>";

$dollarbaloldal = "<h3>zesty</h3>";

echo $dollarbaloldal;

$a = 10;
$b = 10;

echo $a + $b;

echo "<br>";

if ($a > $b) {
    echo "Az A nagyobb mint a B";
}
else if ($a < $b) {
    echo "A B nagyobb mint az A";
}
else {
    echo "A két szám egyenlő";
}

echo "<br>";

for ($i=0; $i < 11; $i++) {
    echo $i;
}

echo "<br>";

$c = 10;
while ($c >= 0) {
    echo $c;
    $c--;
}

for ($j=1; $j < 101; $j++) {
    if ($j % 3 == 0) {
        echo $j;
    }
}

echo "<br>";

$szam = 1;
echo "<table>";
for ($j=0; $j < 10; $j++) {
    echo "<tr>";
    for ($i=0; $i < 10; $i++) {
        if ($szam % 5 == 0) {
            echo "<td><b>" . $szam . "</b></td>";
        }
        else {
            echo "<td>" . $szam . "</td>";
        }
        $szam++;
    }
    echo "</tr>";
}
echo "</table>";

*/

//$tomb = [2, 5, 10, 12, 64, 23, 73, 4, 19, 47];
/*
foreach ($tomb as $tombtag) {
    if ($tombtag % 2 == 0) {
        echo $tombtag . " ";
    }
}*/

/*
echo "<h1>Programozási tételek</h1>";

echo "<h2>1. Maximum kiválasztás</h2>";

$max = $tomb[0];

foreach ($tomb as $maxkereses) {
    if ($maxkereses > $max) {
        $max = $maxkereses;
    }
}

echo "A legnagyobb szám: " . $max . ".";

echo "<h2>2. Lináris keresés</h2>";
//benne van-e a 23 és hol

$index = 0;
$megvan = false;
$keresendoszam = 23;

while (!$megvan && $index != count($tomb)) {
    if ($tomb[$index] == $keresendoszam) {
        $megvan = true;
    }
    $index++;
}

if ($megvan) {
    echo "a " . $keresendoszam . " benne van és a " . $index . ". helyen van.";
}
else {
    echo "nincs benne a " . $keresendoszam .".";
}

echo "<h2>3. Kiválasztás</h2>";
//a keresendő szám (23) indexe
$megvan = false;
$index = 0;
while (!$megvan && $index != count($tomb)) {
    if ($tomb[$index] == $keresendoszam) {
        $megvan = true;
    }
    $index++;
}

if ($megvan) {
    echo  "a szám " . $index . ". helyen van.";
}

echo "<h2>4. Eldöntés</h2>";
//benne van a 23-e
$megvan = false;
$index = 0;

while (!$megvan && $index != count($tomb)) {
    if ($tomb[$index] == $keresendoszam) {
        $megvan = true;
    }
    $index++;
}

if ($megvan) {
    echo "Van benne a keresendő szám.";
}
else {
    echo "Nincs benne a keresendő szám.";
}

echo "<h2>5. Sorozatszámítás</h2>";
//összeadni a tömbökben lévő pártalan számokat
$osszeg = 0;
for ($i = 0;$i < count($tomb);$i++) {
    if ($tomb[$i] % 2 == 1) {
        $osszeg = $osszeg + $tomb[$i];
    }
}

echo "A tömben lévő páratatlan számok összege: " . $osszeg . ".";


echo "<h2>6. megszámlálás</h2>";
//mennyi darab párs szám van a tömben

$parosok = 0;
for ($i = 0; $i < count($tomb);$i++) {
    if($tomb[$i] % 2 == 0) {
        $parosok++;
    }
}

echo "A tömben " . $parosok . " páros szám található.";

*/

echo "<h1>Mátrixok</h1>";

$ember = [
    ["János", "Budapest", 17, "tanuló"],
    ["Elemér", "Kecskemét", 28, "orvos"],
    ["Károly", "Budapest", 33, "rendőr"],
    ["Ferenc", "Miskolc", 58, "üzletvezető"],
    ["Gábor", "Budapest",31, "rendőr"],
    ["István", "Szeged", 47, "pék"]
];

//1. feladat
//Mennyi emberről van adatunk
echo "<h1>1. feladat</h1>";
echo count($ember)." darab emberről van adatunk.";

//2. feladat
//mennyi a pesti lakosok átlag életkora
echo "<h1>2. feladat</h1>";
$budapestiek = 0;
$budapestikor = 0;
foreach($ember as $krapek) {
    if ($krapek[1] == "Budapest") {
        $budapestiek++;
        $budapestikor = $budapestikor +  $krapek[2];
    }
}
$budapestikor = $budapestikor / $budapestiek;
echo $budapestikor . " az átlag életkor a Budapestieknél.";

//3.
//legfiatalabbik rendőr
echo "<h1>3. feladat</h1>";

$rendorkor = [];

foreach ($ember as $emberek) {
    if($emberek[3] == "rendőr") {
        $rendorkor[] = $emberek[2];
    }
}

$legfiatalabb = $rendorkor[0];
foreach($rendorkor as $rendor) {
    if($rendor <= $rendorkor) {
        $rendorkor = $rendor;
    }
}
echo "A legfiatalabb rendőr az ".$rendorkor." éves.";

//4.
//van-e pék, milyen idős és hol lakik?
echo "<h1>4. feladat</h1>";

$foundpek = false;
$index = 0;
foreach($ember as $emberek) {
    if($emberek[3] == "pék") {
        echo "Van pék és ".$emberek[2]." éves és ".$emberek[1]."-ben/ban lakik.";
        $foundpek = true;
    }
    $index++;
}

if(!$foundpek) {
    echo "Sajnos nincs pék.";
}
?>