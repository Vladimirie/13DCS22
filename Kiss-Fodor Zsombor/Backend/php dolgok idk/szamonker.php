<?php

$gyumi = [
    ['Alma', 'piros', 359],
    ['Körte', 'sárga', 489],
    ['Cirton', 'sárga', 519],
    ['Eper','piros', 259],
    ['Banán', 'sárga', 679],
    ['Egres','piros', 689]
];


//mennyi sárga és piros
$sarga = 0;
$piros = 0;

foreach ($gyumi as $gyumocs) {
    if($gyumocs[1] == 'piros') {
        $piros++;
    }
    else {
        $sarga++;
    }
}
echo ('<p>ennyi sárga gyümi van: '. $sarga .'<br> és ennyi piros van: '. $piros.'</p>');
//legolcsóbb
$legolcsobb = $gyumi[0][2];
$legolcsobbnev = $gyumi[0][0];
foreach ($gyumi as $gyumocs) {
    if($gyumocs[2] < $legolcsobb) {
        $legolcsobb = $gyumocs[2];
        $legolcsobbnev = $gyumocs[0];
    }
}
echo ('<p>a legolcsóbb gyümölcs az a(z): '. $legolcsobbnev . '</p>');
//szín drága
$pirosar = $gyumi[0][2];
$sargaar = $gyumi[0][2];


foreach ($gyumi as $gyumocs) {
    if($gyumocs[1] == 'piros') {
        if($pirosar < $gyumocs[2]) {
            $pirosar += $gyumocs[2];
        }
    }
    else {
        if($sargaar < $gyumocs[2]) {
            $sargaar += $gyumocs[2];
        }
    }
}

$arkulombseg = 0;
if ($sargaar > $pirosar) {
    $arkulombseg = $sargaar - $pirosar;
    echo ('<p> a sárgák a drágábbak ' . $arkulombseg .  ' forintal </p>');

} else {
    $arkulombseg = $pirosar - $sargaar;
    echo ('<p> a pirosak a drágábbak ' . $arkulombseg .  ' forintal </p>');
}
//650-él drággább

$i = 0;
$foundexpensive = false;
while ($i < count($gyumi) && !$foundexpensive) {
    if ($gyumi[$i][2] > 650) {
        $foundexpensive = true;
    }
    $i++;
}

if ($foundexpensive) {
    echo ('<p> van 650 forintnál drágább gyümölcs </p>');
} else {
    echo ('<p> nincs 650 forintnál drágább gyümölcs </p>');
}

//átlag árak szín és olcsóbb

$pirosatlag = $pirosar / $piros;
$sargaatlag = $sargaar / $sarga;
if ($sargaatlag > $pirosatlag) {
    $arkulombseg = $sargaatlag - $pirosatlag;
    echo ('<p> a pirosak átlagosan az olcsóbbak ' . round($arkulombseg) .  ' forintal </p>');
} else {
    $arkulombseg = $pirosatlag - $sargaatlag;
    echo ('<p> a sárgák átlagosan az olcsóbbak ' . round($arkulombseg) .  ' forintal </p>');
}
?>