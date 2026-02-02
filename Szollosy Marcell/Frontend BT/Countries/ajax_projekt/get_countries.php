<?php
require 'config.php';
header('Content-Type: application/json');
$stmt = $pdo->query("SELECT id, name FROM countries LIMIT 5");
$countries = $stmt->fetchAll();
echo json_encode($countries);
?>