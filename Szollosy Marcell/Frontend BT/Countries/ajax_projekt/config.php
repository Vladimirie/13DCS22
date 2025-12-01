<?php
$host = 'localhost';
$db = 'country'; // Ide írd be az adatbázisod nevét!
$user = 'root'; // Ide írd be a felhasználóneved!
$pass = ''; // Ide írd be a jelszavad (XAMPP-ben általában üres)!
$charset = 'utf8mb4';
$dsn = "mysql:host=$host;dbname=$db;charset=$charset";
$options = [
PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,
PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
PDO::ATTR_EMULATE_PREPARES => false,
];
try {
$pdo = new PDO($dsn, $user, $pass, $options);
} catch (\PDOException $e) {
http_response_code(500);
echo json_encode(['error' => 'Adatbázis kapcsolati hiba!', 'details' => $e->getMessage()]);
exit;
}
?>