<?php
include 'db.php';

if ($_POST['name'] ?? false) {
    $name = trim($_POST['name']);
    if ($name !== '') {
        $pdo->prepare("INSERT INTO persons (name) VALUES (?)")
            ->execute([$name]);
        header("Location: index.php"); // visszairányítás
        exit;
    }
}
?>

<h2>Új személy hozzáadása</h2>
<form method="post">
    Név: <input type="text" name="name" required>
    <button type="submit">Mentés</button>
</form>
<a href="index.php">Vissza</a>