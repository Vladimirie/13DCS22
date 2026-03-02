<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <form action="" method="post">
        <label for="name">Név: </label>
        <input type="text" name="name" id="name">
        <br>
        <label for="pw">Jelszó: </label>
        <input type="password" name="pw" id="pw">
        <br>
        <input type="submit" name="login" value="Belépés">
    </form>
</body>
</html>
<?php
$USERNAME="Admin";
$PASSWORD="1234";
IF(ISSET($_POST['login']))
{
    $FELHNEV=$_POST['name'];
    $JELSZO=$_POST['pw'];
    IF($FELHNEV==$USERNAME&&$JELSZO==$PASSWORD)
    {
        ECHO"Sikeres bejelentkezés!";
    }
    ELSE
    {
        ECHO"Helyetlen felhasználónév vagy jelszó";
    }
}
?>