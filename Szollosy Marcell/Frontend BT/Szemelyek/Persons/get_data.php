<?php
header('Content-Type: application/json; charset=utf-8');
$servername = "37.221.209.228:40180";
$username = "ajax";
$password = "Password123";
$dbname = "ajaxteszt";

$id = isset($_GET['id']) ? intval($_GET['id']) : 0;

// Adatbázis kapcsolat létrehozása
$conn = new mysqli($servername, $username, $password, $dbname);

// Kapcsolódási hiba ellenőrzése
if ($conn->connect_error) {
    die("Kapcsolódási hiba: " . $conn->connect_error);
}
$conn->set_charset("utf8mb4");

// SQL lekérdezés: egy rekord lekérése az 'id' alapján
$sql = "SELECT * FROM tabla_nev WHERE id = ?";  // ← Itt cseréld ki 'tabla_nev'-t a valódi táblanevedre!

// SQL lekérdezés logolása a konzolra
error_log("SQL query: " . $sql . " with ID: " . $id);

// Előkészített utasítás létrehozása
$stmt = $conn->prepare($sql);

if (!$stmt) {
    // Ha az előkészítés sikertelen
    echo json_encode([
        'status' => 'error',
        'message' => 'Hiba az SQL előkészítésekor: ' . $conn->error,
        'data' => null
    ]);
    $conn->close();
    exit;
}

// Paraméter kötése (i = integer)
$stmt->bind_param("i", $id);

// Lekérdezés végrehajtása
$stmt->execute();

// Eredmény lekérése
$result = $stmt->get_result();

// Adatok tömbbe gyűjtése
$data = $result->fetch_assoc(); // Csak egy rekord várható, mert 'id' egyedi

// JSON válasz összeállítása
echo json_encode([
    'status' => 'success',
    'message' => 'sikeres adatátvitel',
    'data' => $data ?: null  // Ha nincs találat, null lesz
]);

$conn->close();
?>