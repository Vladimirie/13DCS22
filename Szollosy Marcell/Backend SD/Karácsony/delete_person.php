<?php
include 'db.php';
$id = $_GET['id'] ?? 0;
$pdo->prepare("DELETE FROM persons WHERE id = ?")->execute([$id]);
header("Location: index.php");
?>