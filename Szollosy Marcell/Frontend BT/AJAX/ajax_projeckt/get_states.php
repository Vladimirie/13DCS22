<?php 
require 'config.php'; 
header('Content-Type: application/json'); 
 
$country_id = $_GET['country_id'] ?? 0; 
 
if (!is_numeric($country_id) || $country_id == 0) { 
    echo json_encode(['error' => 'Érvénytelen ország azonosító.']);     exit; 
} 
 
$stmt = $pdo->prepare("SELECT id, name FROM states WHERE country_id = ? ORDER BY name"); 
$stmt->execute([$country_id]); 
$states = $stmt->fetchAll(); 
 
echo json_encode($states); 
?> 
