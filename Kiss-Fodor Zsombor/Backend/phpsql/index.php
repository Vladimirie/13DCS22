

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
    echo "<form action='' method='post'";
    echo "<tr>";
    echo "<td><input type='hidden' name='id' value='".$row['id']. "'</td>"  ;
    echo "<td> <input name='username' type='text' value='".$row["username"] . "' </td>" ;
    echo "<td> <input name='fullname' type='text' value='".$row["fullname"] . "' </td>" ;
    echo "<td> <input name='email' type='text' value='".$row["email"] . "' </td>";
    echo "<td> <input type='submit' name='update'></td>";
    echo "</tr>";
    echo "</form>";
}

if (isset($_POST["update"])) {
    $sqlcom = "UPDATE user SET username = :username, fullname = :fullname, email = :email WHERE id = :id ";
    $updtcmd = $db->prepare($sqlcom);
    $updtcmd->execute([
        ':username' => $_POST['username'],
        ':fullname' => $_POST['fullname'],
        ':email' => $_POST['email'],
        ':id' => $_POST['id'],
    ]);
}

echo "</table>";
?>