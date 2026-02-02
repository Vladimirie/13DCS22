<?php 
/*
echo "<h1>Hello tesvir</h1>";

$valami = " <h3>teszt</h3>";

echo $valami;

$a = 10;
$b = 10;

echo $a + $b;

echo " <br>";

if ($a > $b) {
    echo "az A nagyobb mint a B";
 } else if ($a < $b) {
    echo "A B nagyobb, mint az A";
 } else {
    echo "Az a és a B egyenlő";
 }
 echo " <br>";


 for ($i=0; $i < 10; $i++) {
    echo $i;
 }
 echo " <br>";
$j = 0;
 while ($j <= 10) {
    echo $j;
    $j++;
 }
 echo " <br>";
for ($p=1; $p <= 100; $p++) {
    if ($p % 3 == 0) {
        echo $p;
        echo " ";
    }

}
/*
echo "<table>";
echo "<tr>";
for ($p=1; $p <= 100; $p++) {
    
    if ($p % 10 == 0) {
   
  echo "<td>"."<b>".$p."</b>"."</tr>" ;
  echo "<tr>";

     } else if ($p % 5 == 0) {

        echo "<td>"."<b>".$p."</b>"."</td>" ;

    } else {
        echo "<td>".$p."</td> ";
    }
}
*/
//echo "<tr>";
//echo "<table>";
/*
echo "<table>";
$szam = 1;
for ($i=0; $i < 10; $i++)  {
    echo "<tr>";
    for ($j = 0; $j < 10; $j++) {
            if ($szam % 5 == 0) {
                echo "<td><b>".$szam."</b></td>";
            } else {
                echo "<td>".$szam."</td>";
            }
            $szam++;
            }
            echo "</tr>";
    }
    echo "</table>";
*/
$tomb = [2,5, 10, 12, 64, 23, 73, 4, 19, 47];
/*

foreach ($tomb as $szam) {
    if ($szam % 2 == 0) {
        echo $szam." ";
    }

}
*/
echo "<h1> Programozási tételek</h1>";

echo "<h2>1. Maximum kiválasztás</h2> ";


$max = $tomb[0];

foreach ($tomb as $szam ){
    if ($szam > $max) {
        $max = $szam;
    }
}
echo "A legnagyobb szám:".$max;

echo "<h2>2. Lineáris keresés</h2> ";

$index = 0;
$found = false;
$keresetElem = 47;
while (!$found && $index < count($tomb)) {
    if ($keresetElem == $tomb[$index]) {
        $found = true;
    } else {
        $index++;
    }

}

if ($found) {
    echo "A kereset szám  megtalálhato a ".($index+1).". helyen.";
} else {
    echo "A kereset szám nincs benne a tömben";
}

echo "<h2>3. Kiválasztás</h2> ";

$masikindex = 0;

$masikfound = false;
while ( $masikindex < count($tomb) && !$masikfound) {
    if ($tomb[$masikindex] == 23) {
            $masikfound = true;
}
$masikindex++;  }

if ($masikfound)
{
    echo "Az elem a:".($masikindex+1)."edik helyen található";
} else {
    echo "LMFO";
}

echo "<h2>4. Eldöntés</h2> ";

$index = 0;
$found = false;
while (!$found && $index < count($tomb)) {
    if ($tomb[$index] == 23) {
        $found = true;
    }
    $index++;
}

if ($found) {
    echo "Van";
} else {
    echo "Nincs";
}

echo "<h2>5. Sorozatszámítás </h2> ";

$sum = 0;
foreach ($tomb as $szam) {
    if ($szam % 2 != 0) {
        $sum += $szam;
    }
}
echo "Az összes páratlan szám összege:".$sum;

echo "<h2>6. Sorozatszámítás </h2> ";

$db = 0;
foreach ($tomb as $szam )
 {
    if ($szam % 2 == 0) {
        $db++;
    }
}
echo $db." Darab páros szám van a tömbben";

//echo "<video controls source src=\"haf.mp4\"> </video>";
$emberek = [
    ["jános", "Budapest", 17, "tanuló"],
    ["Elemér", "Kecskemét", 28, "orvos"],
    ["Károly", "Budapest", 33, "Rendőr"],
    ["ferenc", "Mickolc", 58, "vállalkozó"],
    ["Gábor", "Budapest", 31, "Rendőr"],
    ["István", "Szeged" , 47, "pék"]
];
echo "<br>";
echo  count($emberek)."emberől van adatunk";
//echo "<iframe src=\"https://suno.com/embed/e8be6054-8c56-4568-ad6f-9d98d568676b\" width=\"760\" height=\"240\"><a href=\"https://suno.com/song/e8be6054-8c56-4568-ad6f-9d98d568676b\">Listen on Suno</a></iframe>";

$sum = 0;
$db = 0;
foreach ($emberek as $ember) {
    if ($ember[1] == "Budapest")
            {
                $sum += $ember[2];
                $db++;
            }
}

echo "A Budapestiek átlagos életkora: ".($sum / $db);

$min = 0;
$minvan = false;
$minnev = "";
foreach ($emberek as $ember) {
    if ($ember[3] ==  "Rendőr") {
        if (!$minvan) {
            $min = $ember[2];
            $minvan = true;
            $minnev = $ember[0];
        } else if ($min > $ember[2]) {
            $min = $ember[2];
            $minnev = $ember[0];
        }
    }



}
echo "A legfiatalabb rendőr: ".$minnev;


$vanpek = false;
$index = 0;
$pekindex = 0;
while (!$vanpek && $index < count($emberek)) {

    if ($emberek[$index][3] == "pék") {
        $vanpek = true;
        $pekindex = $index;
    }
    $index++;
}
if ($vanpek) {
    echo "A pék".$emberek[$pekindex][2]."Éves és".$emberek[$pekindex][1]."en lakik";
} else {
    echo "nincs pék";
}

echo "<br>";

echo "<h1>Függvények, metódusok</h1>";

function teszt(){
    echo "Hello";
}
teszt();
echo "<br>";
function teszt2($ertek) {
    echo $ertek;
}
echo "<br>";
teszt2("idk");
function teszt3($ertek){
    return $ertek;

}
echo teszt3(20);
echo "<br>";

$tomb1 = [51, 2 ,67, -12, 52, 33, 92, 44];
$tomb2 = [21, -6, -52, 1, 32, 69, -2, 22];

function tombsum($beadottomb) {
    $sum = 0;
    foreach ($beadottomb as $szam) {
        $sum += $szam;
    }
    return $sum;

}
echo "<h2>1. Feladat</h1>";
echo tombsum($tomb1)."A tömb1 összege";
echo "<br>";

echo tombsum($tomb2)."A tömb2 összege";

echo "<br>";
echo "<h2>2. Feladat</h1>";
function tombuneven($beadottomb) {
    $db = 0;
    foreach ($beadottomb as $szam) {
        if ($szam % 2 != 0) {
            $db++;
        }
       
    }
    return $db;
}
echo tombuneven($tomb1)." páratlan szám van a tömb1 ben";
echo "<br>";
echo tombuneven($tomb2)." páratlan szám van a tömb2 ben";
echo "<br>";
echo "<h2>3. Feladat</h1>";

function tombminnum($beadottomb) {
    $min = $beadottomb[0];

    foreach ($beadottomb as $szam) {
            if ($szam < $min) {
                $min = $szam;
            }
    }
    return $min;
}

echo tombminnum($tomb1)."A legkisebb a tomb1 ben";
echo "<br>";
echo tombminnum($tomb2)."A legkisebb a tomb2 ben";

echo "<h2>4. Feladat</h1>";
echo "<br>";

function _7teloszhatotomb($beadottomb) {
        $oszthato = false;
        $index = 0;
        while (!$oszthato && $index < count($beadottomb)){
            if ($beadottomb[$index] % 7 == 0) {
                $oszthato = true;
            }
            $index++;
        }
        if ($oszthato) return "VAN";
        else return "Nincs";


}
 echo _7teloszhatotomb($tomb1)."  tomb 1";
 echo "<br>";
 echo _7teloszhatotomb($tomb2)."  tomb 2";


 echo "<h2>5. Feladat</h1>";

 

?>