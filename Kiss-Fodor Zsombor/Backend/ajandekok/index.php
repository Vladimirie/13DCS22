<?php
include_once("config.php"); //megkapjuk a configban lefutott kód adatokat könnyeb munkáért, pl a db változót

$stmt = $db->prepare("SELECT * FROM persons"); //csinálunk egy SQL parancsot a databaseben való végrehajtásra, pl itt megakarjuk majd kapni a user táblázat minden tagját
$stmt->execute(); //végrehajtuk duh
//elkezdünk csinálni egy táblázatot

echo "<form action='' method='post'>";
echo "<input name='insertName' type='text' placeholder='Név'>" ;
echo "<input name='insertRelation' type='text' placeholder='Kapcsolat'>" ;
echo "<input name='insertNote' type='text' placeholder='Megjegyzés'>";
echo "<input type='submit' name='create' value='Új személy hozzáadása'>";
echo "</form>";

if (isset($_POST["create"])) {
    if ($_POST['insertName'] != "" && strlen($_POST['insertRelation']) >= 3) {
        $sqlcom = "INSERT INTO `persons`(`name`, `relation`, `note`) VALUES (:insertName,:insertRelation,:insertNote)";
        $updtcmd = $db->prepare($sqlcom);
        $updtcmd->execute([
            ':insertName' => $_POST['insertName'],
            ':insertRelation' => $_POST['insertRelation'],
            ':insertNote' => $_POST['insertNote']
        ]);
    }
    else {
        echo "<p>A név és kapcsolat mező kitöltése kötelező!</p>";  
    }
}


echo "<table style='border: solid;'>";

echo"
<tr>
<th>Név</th>
<th>Kapcsolat</th>
<th>Megjegyzés</th>
</tr>";

//felbontjuk a lefutatott SQL parancsból megkapot infomációkat és kiírjuk őket a táblázatba!
foreach ($stmt as $row) {
    echo "<form action='' method='post'";
    echo "<tr>";
    echo "<td> <input name='name' type='text' value='".$row["name"] . "' </td>" ;
    echo "<td> <input name='relations' type='text' value='".$row["relation"] . "' </td>" ;
    echo "<td> <input name='note' type='text' value='".$row["note"] . "' </td>";
    echo '<td> 
    <input type="hidden" name="id" value="'. $row["id"] . '">
    <a href="gifts.php?id='. $row['id'].'" style="border: solid 0.1ch black; background-color: lightgrey; border-radius: %; padding:0.4ch;" >Ajándékok megtekintése</a>
    <input type="submit" name="update" value="Szerkesztés">
    <input type="submit" name="delete" value="Törlés">
    </td> ';
    echo "</tr>";
    echo "</form>";
}

if (isset($_POST["delete"])) {
    $sqlcom = "DELETE FROM persons WHERE `persons`.`id` = :id";
        $updtcmd = $db->prepare($sqlcom);
        $updtcmd->execute([
            ':id' => $_POST['id']
        ]);
}

if (isset($_POST["update"])) {
    $sqlcom = "UPDATE persons SET name = :name, relation = :relations, note = :note WHERE id = :id ";
    $updtcmd = $db->prepare($sqlcom);
    $updtcmd->execute([
        ':name' => $_POST['name'],
        ':relations' => $_POST['relations'],
        ':note' => $_POST['note'],
        ':id' => $_POST['id'],
    ]);
}
?>