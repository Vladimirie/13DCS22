<?php
$gyumolcsok = [
    ['Alma', 'piros', 359],
    ['Körte', 'sárga', 489],
    ['Citrom', 'sárga', 519],
    ['Eper', 'piros', 259],
    ['Banán', 'sárga', 679],
    ['Egres', 'piros', 689]
];

echo "<!DOCTYPE html>";
echo "<html lang='hu'>";
echo "<head><meta charset='UTF-8'><title>Gyümölcsök elemzése</title></head>";
echo "<body>";
echo "<h2>Gyümölcsök elemzése</h2>";

$pirosDb = 0;
$sargaDb = 0;

foreach ($gyumolcsok as $gyumolcs) {
    if ($gyumolcs[1] === 'piros') $pirosDb++;
    if ($gyumolcs[1] === 'sárga') $sargaDb++;
}

echo "1. Piros gyümölcsök száma: $pirosDb<br>";
echo "      Sárga gyümölcsök száma: $sargaDb<br><br>";

$legolcsobb = $gyumolcsok[0];
foreach ($gyumolcsok as $gyumolcs) {
    if ($gyumolcs[2] < $legolcsobb[2]) {
        $legolcsobb = $gyumolcs;
    }
}

echo "2. Legolcsóbb gyümölcs: {$legolcsobb[0]} ({$legolcsobb[2]} Ft/kg)<br><br>";

$osszPiros = 0;
$osszSarga = 0;
$dbPiros = 0;
$dbSarga = 0;

foreach ($gyumolcsok as $gyumolcs) {
    if ($gyumolcs[1] === 'piros') {
        $osszPiros += $gyumolcs[2];
        $dbPiros++;
    } elseif ($gyumolcs[1] === 'sárga') {
        $osszSarga += $gyumolcs[2];
        $dbSarga++;
    }
}

$atlagPiros = $osszPiros / $dbPiros;
$atlagSarga = $osszSarga / $dbSarga;

$kulonbseg = abs($atlagPiros - $atlagSarga);
if ($atlagPiros > $atlagSarga) {
    echo "3. A piros gyümölcsök drágábbak {$kulonbseg} Ft-tal (átlagban).<br><br>";
} elseif ($atlagSarga > $atlagPiros) {
    echo "3. A sárga gyümölcsök drágábbak {$kulonbseg} Ft-tal (átlagban).<br><br>";
} else {
    echo "3. A piros és sárga gyümölcsök átlagára megegyezik.<br><br>";
}

$vanDragabb = false;
foreach ($gyumolcsok as $gyumolcs) {
    if ($gyumolcs[2] > 650) {
        $vanDragabb = true;
        break;
    }
}

echo "4. Van 650 Ft-nál drágább gyümölcs: " . ($vanDragabb ? "Igen" : "Nem") . "<br><br>";

echo "5. Átlagár (piros): " . round($atlagPiros, 2) . " Ft/kg<br>";
echo "   Átlagár (sárga): " . round($atlagSarga, 2) . " Ft/kg<br>";

if ($atlagPiros < $atlagSarga) {
    echo "   A piros gyümölcsök olcsóbbak átlagosan.<br>";
} elseif ($atlagSarga < $atlagPiros) {
    echo "   A sárga gyümölcsök olcsóbbak átlagosan.<br>";
} else {
    echo "   A piros és sárga gyümölcsök átlagára megegyezik.<br>";
}

echo "</body></html>";
?>