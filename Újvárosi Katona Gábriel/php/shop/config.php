<?php

$dbconnection = "localhost";
$dbusername = "root";
$dbpassword = "";
$dbname = "shop";

try {

    $database = new PDO("mysql:host=$dbconnection;dbname=$dbname",$dbusername,$dbpassword);
    $database -> setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    

} catch (\Throwable $e) {
    echo $e->getMessage();
}





?>

