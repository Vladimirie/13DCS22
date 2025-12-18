

<?php
$servername = "localhost";
$username = "root";
$password = "";
$databasename = "karacsony_crud_vezeteknev";
try {
  $database = new PDO("mysql:host=$servername;dbname=$databasename", $username, $password);
  $database->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
  
} catch(PDOException $e) {
  echo "Hiba: " . $e->getMessage();
}

?>