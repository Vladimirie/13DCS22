<?php
header('Content-Type: application/json; charset=utf-8');
$servername = "37.221.209.228:40180";
$username = "ajax";
$password = "Password123";
$dbname = "ajaxteszt";

// Ellenőrzi, hogy GET kérés-e
if ($_SERVER['REQUEST_METHOD'] !== 'GET') {
    http_response_code(405);
    echo json_encode(['error' => 'Csak GET kérés engedélyezett']);
    exit;
}

$conn = new mysqli($servername, $username, $password, $dbname);
if ($conn->connect_error) {
    die("Kapcsolódási hiba: " . $conn->connect_error);
}
$conn->set_charset("utf8mb4");

$sql = "SELECT id, nev FROM Szemelyek ORDER BY nev";
// SQL lekérdezés logolása a konzolra
error_log("SQL query: " . $sql);
$result = $conn->query($sql);

$names = [];
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $names[] = $row;
        
    }
}
echo json_encode($names);

$conn->close();
?>
