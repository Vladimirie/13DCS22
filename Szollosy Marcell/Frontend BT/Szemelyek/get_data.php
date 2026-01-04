<?php
header('Content-Type: application/json; charset=utf-8');
$servername = "37.221.209.228:40180";
$username = "ajax";
$password = "Password123";
$dbname = "ajaxteszt";

$id = isset($_GET['id']) ? intval($_GET['id']) : 0;

$conn = new mysqli($servername, $username, $password, $dbname);
if ($conn->connect_error) {
    die("Kapcsolódási hiba: " . $conn->connect_error);
}
$conn->set_charset("utf8mb4");

$sql = "SELECT email, telefon, anyja_neve, igazolvany_szam FROM Szemelyek WHERE id = ?";
// SQL lekérdezés logolása a konzolra
error_log("SQL query: " . $sql . " with ID: " . $id);
$stmt = $conn->prepare($sql);
$stmt->bind_param("i", $id);
$stmt->execute();
$result = $stmt->get_result();

$data = $result->fetch_assoc();
$response = [
    'status' => 'success',
    'message' => 'sikeres adatátvitel',
    'data' => $data
];

echo json_encode($response);

$conn->close();
?>
