<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <h1>Űrlap kezelése</h1>
    <form action="" method="post">
        <label for="name">Név:</label>
        <input type="text" name="name" id="name">
        <br><br>
        <label for="location">Lakhely:</label>
        <input type="text" name="location" id="location">
        <br><br>
        <label for="age">Kor:</label>
        <input type="number" name="age" id="age">
        <br><br>
        <input type="radio" name="gender" id="male">
        <label for="male">Férfi</label>
        <br>
        <input type="radio" name="gender" id="female">
        <label for="female">Nő</label>
        <br><br>
        <input type="submit" name="submit" value="Submit">
    </form>
</body>
</html>
<?php
IF(ISSET($_POST['submit']))
{
    $NAME=$_POST['name'];
    $AGE=$_POST['age'];
    $LOCATION=$_POST['location'];
    ECHO$NAME;
    ECHO"<BR>";
    ECHO$AGE;
    ECHO"<BR>";
    ECHO$LOCATION;
}
?>