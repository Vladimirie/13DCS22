<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    

    <form action="" method="post">
        <label for="name">Username:  </label>
        <input type="text" name="name" id="name">
        <br><br>

        <label for="pw">Password: </label>
        <input type="password" name="pw" id="pw">
        <input type="submit" name="login" value="Login">
    </form>





</body>
</html>




<?php
$username = "Admin";
$password = "Admin123";

if (isset($_POST['login'])) {
    if ($username == $_POST['name'] && $password == $_POST['pw']){
        echo "Belépés sikeres!";
    } else {
        echo "Felhasználó név vagy jelszó hejtelen";
    }


}


?>