<?php

//localhost változók
$server = "localhost";
$username = "root";
$password = "";


try {
        $db = new PDO("mysql:host=$server;dbname=13d2cs",$username, $password); //csatlakozuk a databasehez
        $db -> setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);


} catch (\Throwable $e) {
    echo $e->getMessage(); //ha nem tudunk csatlakozni akkor megkapunk egy hibakódott
}


?>