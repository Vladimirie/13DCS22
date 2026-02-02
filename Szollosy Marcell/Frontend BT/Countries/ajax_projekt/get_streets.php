<?php
require 'config.php';
header('Content-Type: application/json');
$state_id = $_GET['state_id'] ?? 0;
if (!is_numeric($state_id) || $state_id == 0) {
echo json_encode(['error' => 'Érvénytelen megye azonosító.']);
exit;
}
$stmt = $pdo->prepare("SELECT id, name FROM streets WHERE state_id = ? ORDER BY name");
$stmt->execute([$state_id]);
$streets = $stmt->fetchAll();
echo json_encode($streets);
?>