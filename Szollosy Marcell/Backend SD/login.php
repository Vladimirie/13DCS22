<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
</head>
<body>
    
    <form action="" method="post">
        <label for="name">Username: </label>
        <input type="text" name="name" id="name">
        <br><br>
        <label for="pw">Password: </label>
        <input type="password" name="pw" id="pw">
        <br><br>
        <input type="submit" name="login" value="login">
    </form>

</body>
</html>

<?php



$username = "Admin";
$password = "Amin123";
if (isset($_POST['login'])){
    $felhasznalonev = $_POST['name'];
    $jelszo = $_POST['pw'];

    if ($felhasznalonev == $username && $jelszo) {
        echo "Sikeres belépés";
    }else{
        echo "Rossz felhasználónév vagy jelszó.";
    }
}




?>