<?php
include 'db.php';

$person_id = $_GET['person_id'] ?? 0;
if (!$person_id || !is_numeric($person_id)) {
    die("Hibás Személy!");
}

if ($_POST['title'] ?? false) {
    $title = trim($_POST['title']);
    $image = null;

    if (!empty($_FILES['image']['name'])) {
        $file = $_FILES['image'];
        $allowed = ['jpg', 'png', 'jpeg'];
        $ext = strtolower(pathinfo($file['name'], PATHINFO_BASENAME));

        if (in_array($ext, $allowed) && $file['error'] == 0) {
            $image = uniqid() . '.' . $ext;
            move_uploaded_file($file['tmp_name'], 'uploads/' . $image);
        }
    }

    if ($title !== '') {
        $pdo->prepare("INSERT INTO gifts (person_id, title, image) VALUES (?, ?, ?)")
            ->execute([$person_id, $title, $image]);
        header("Location: index.php");
        exit;
    }
}
?>

<h2>Új ajándék hozzáadása</h2>
<form method="post" enctype="multipart/form-data">
    Ajándék neve: <input type="text" name="title" required><br><br>
    Kép (jpg/png): <input type="file" name="image"><br><br>
    <button type="submit">Mentés</button>
</form>
<a href="index.php">Vissza</a>