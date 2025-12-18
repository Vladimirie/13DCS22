<?php
//localhost változók
$server = "localhost";
$username = "root";
$password = "";
$databaseName = "13d2cs";

try {
        $db = new PDO("mysql:host=$server;dbname=$databaseName",$username, $password); //csatlakozuk a databasehez
        $db -> setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);


} catch (\Throwable $e) {
    echo $e->getMessage(); //ha nem tudunk csatlakozni akkor megkapunk egy hibakódott
}

?>