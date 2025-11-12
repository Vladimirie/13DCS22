<?php

$json = file_get_contents('termekek.json');
$data = json_decode($json, true);

echo "<h1>Bolti Adatok</h1>";

echo "<h2>Raktáron</h2>";
echo "<ul>";

foreach ($data['termekek'] as $termek) {
    if ($termek['raktaron']) {
        echo "<li>" . htmlspecialchars($termek['nev']) . " - " . (int)$termek['ar'] . " Ft (" . htmlspecialchars($termek['kategoria']) . ")</li>";
    }
}

echo "</ul>";

echo "<h2>Rendelések</h2>";
echo "<ul>";

foreach ($data['rendelesek'] as $rendeles) {
    $termek = null;
    foreach ($data['termekek'] as $t) {
        if ($t['id'] == $rendeles['termek_id']) {
            $termek = $t;
            break;
        }
    }

    if ($termek) {
        $vevo = htmlspecialchars($rendeles['vevo']);
        $termek_nev = htmlspecialchars($termek['nev']);
        $db = (int)$rendeles['db'];
        $fizetve = $rendeles['fizetve'] ? 'igen' : 'nem';
        $arfolyam = (int)$termek['ar'];
        $fizetendo = $db * $arfolyam;

        echo "<li>";
        echo "$vevo - $termek_nev - $db db - Fizetve: $fizetve - Fizetendő: $fizetendo Ft";
        echo "</li>";
    }
}

echo "</ul>";

?>