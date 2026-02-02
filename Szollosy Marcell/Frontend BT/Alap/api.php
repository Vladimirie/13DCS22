<?php
header('Content-Type: application/json; charset=utf-8');

$servername = "mysql.nethely.hu";
$username = "ajaxteszt";
$password = "Kikanho20040304";
$dbname = "ajaxteszt";

$conn = new mysqli($servername, $username, $password, $dbname);
if ($conn->connect_error) {
    http_response_code(500);
    echo json_encode(['error' => 'Adatbázis hiba: '.$conn->connect_error]);
    exit;
}
$conn->set_charset("utf8mb4");

$method = $_SERVER['REQUEST_METHOD'];

// Felhasználónév ellenőrzés
if ($method === 'GET' && isset($_GET['check_username'])) {
    $username = strtolower($conn->real_escape_string(trim($_GET['check_username'])));
    $sql = "SELECT COUNT(*) as cnt FROM Szemelyek WHERE LOWER(nev) = '$username'";
    $result = $conn->query($sql);
    $taken = false;
    if ($result) {
        $row = $result->fetch_assoc();
        $taken = ($row['cnt'] > 0);
    }
    echo json_encode(['taken' => $taken]);
    exit;
}

// Feladatok lekérése
if ($method === 'GET' && isset($_GET['action']) && $_GET['action'] === 'tasks') {
    $tasks = [];
    $result = $conn->query("SELECT id, title, description FROM Feladatok ORDER BY id");
    if ($result) {
        while ($row = $result->fetch_assoc()) {
            $tasks[] = $row;
        }
    }
    echo json_encode($tasks);
    exit;
}

// Új feladat hozzáadása
if ($method === 'POST' && isset($_POST['title'], $_POST['description'])) {
    $title = $conn->real_escape_string(trim($_POST['title']));
    $description = $conn->real_escape_string(trim($_POST['description']));
    if ($title === '') {
        http_response_code(400);
        echo json_encode(['error' => 'A cím megadása kötelező']);
        exit;
    }
    $sql = "INSERT INTO Feladatok (title, description) VALUES ('$title', '$description')";
    if ($conn->query($sql)) {
        $id = $conn->insert_id;
        echo json_encode(['id' => $id, 'title' => $title, 'description' => $description]);
    } else {
        http_response_code(500);
        echo json_encode(['error' => 'Hiba az adatbázisban']);
    }
    exit;
}

// Feladat módosítása PUT kéréssel
if ($method === 'PUT') {
    parse_str(file_get_contents('php://input'), $put_vars);
    if (isset($put_vars['id'], $put_vars['title'], $put_vars['description'])) {
        $id = (int)$put_vars['id'];
        $title = $conn->real_escape_string(trim($put_vars['title']));
        $description = $conn->real_escape_string(trim($put_vars['description']));
        if ($title === '') {
            http_response_code(400);
            echo json_encode(['error' => 'A cím megadása kötelező']);
            exit;
        }
        $sql = "UPDATE Feladatok SET title = '$title', description = '$description' WHERE id = $id";
        if ($conn->query($sql)) {
            echo json_encode(['success' => true, 'id' => $id, 'title' => $title, 'description' => $description]);
        } else {
            http_response_code(500);
            echo json_encode(['error' => 'Hiba az adatbázisban']);
        }
        exit;
    }
    http_response_code(400);
    echo json_encode(['error' => 'Hiányzó paraméterek']);
    exit;
}

// Feladat törlése DELETE kéréssel
if ($method === 'DELETE' && isset($_GET['id'])) {
    $id = (int)$_GET['id'];
    if ($conn->query("DELETE FROM Feladatok WHERE id = $id")) {
        echo json_encode(['success' => true]);
    } else {
        http_response_code(500);
        echo json_encode(['error' => 'Törlési hiba']);
    }
    exit;
}

http_response_code(400);
echo json_encode(['error' => 'Ismeretlen kérés']);
exit;
