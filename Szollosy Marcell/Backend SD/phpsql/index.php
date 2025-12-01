

<?php 


include_once("config.php"); //megkapjuk a configban lefutott kód adatokat könnyeb munkáért, pl a db változót

$stmt = $db->prepare("SELECT * FROM user"); //csinálunk egy SQL parancsot a databaseben való végrehajtásra, pl itt megakarjuk majd kapni a user táblázat minden tagját
$stmt->execute(); //végrehajtuk duh
//elkezdünk csinálni egy táblázatot
echo "<table style='border: solid;'>";

echo"
<tr>
 <th>ID</th>
<th>username</th>
<th>Fullname</th>
<th>Email</th>
</tr>";

//felbontjuk a lefutatott SQL parancsból megkapot infomációkat és kiírjuk őket a táblázatba!
foreach ($stmt as $row) {
    echo "<tr>";

    echo "<td>" .$row['id']. "</td>"  ;
    echo "<td>".$row["username"] . " </td>" ;
    echo "<td>".$row["fullname"] . "</td>" ;
    echo "<td>".$row["email"] . "</td>";
    echo "</tr>";
}
echo "</table>";


//CRUD


//Create
if (isset($_POST['create'])) {
    $sql = "INSERT INTO user (username, password, fullname, email)
            VALUES (:username, :password, :fullname, :email";

    $stmt1 = $db->prepare($sql);
    $stmt1->execute([
        ':username' => $_POST['username'],
        ':password' => $_POST['password'],
        ':fullname' => $_POST['fullname'],
        ':email' => $_POST['email']
    ]);

    echo "<h1>Sikeres hozzáadás</h1>";
}


//Update
if (isset($_POST['update'])) {
    $sql1 = "UPDATE user SET username = :usernam, fullname = :fullname, email = :email WHERE id = :id";
    $stmt2 = $db->prepare($sql);
    $stmt2->execute([
        ':username' => $_POST['username'],
        ':fullname' => $_POST['fullname'],
        ':email' => $_POST['email']
    ]);

    echo "<h1>Sikeres módosítás</h1>";
}
?>

<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>CRUD</title>
</head>
<body>
    <h2>Új felhasználó hozzáadás</h2>
    <form action="" method="post">
        <input type="text" name="username" placeholder="Felhasználónév">
        <input type="password" name="password" placeholder="Jelszó">
        <input type="text" name="fullname" placeholder="Teljes Név">
        <input type="email" name="email" placeholder="E-mail">

        <input type="submit" value="Felvétel" name="create">
    </form>


    
</body>
</html>