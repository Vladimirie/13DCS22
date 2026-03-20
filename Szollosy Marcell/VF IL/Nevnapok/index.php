<?php
header("Content-Type: application/json; charset=utf-8");

$conn = new mysqli("localhost", "root", "", "nevnapok");

if ($conn->connect_error) {
    die(json_encode(["hiba" => "adatbázis hiba"]));
}

if (isset($_GET['nap'])) {
    $nap = explode("-", $_GET['nap']);
    $ho = $nap[0];
    $n = $nap[1];

    $sql = "SELECT * FROM nevnap WHERE ho=$ho AND nap=$n LIMIT 1";
}
elseif (isset($_GET['nev'])) {
    $nev = $conn->real_escape_string($_GET['nev']);

    $sql = "SELECT * FROM nevnap 
            WHERE nev1='$nev' OR nev2='$nev' 
            LIMIT 1";
}
else {
    echo json_encode([
        "minta1" => "/?nap=12-31",
        "minta2" => "/?nev=Szilveszter"
    ]);
    exit;
}

$result = $conn->query($sql);

if ($result->num_rows > 0) {
    $row = $result->fetch_assoc();

    echo json_encode([
        "datum" => $row['ho'] . "." . $row['nap'] . ".",
        "nevnap1" => $row['nev1'],
        "nevnap2" => $row['nev2']
    ]);
} else {
    echo json_encode(["hiba" => "nincs találat"]);
}
?>