

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
?>