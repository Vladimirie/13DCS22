<?php 
$id = $_GET['id'];
include_once("config.php");

$stmt = $db->prepare("SELECT * FROM gifts WHERE person_id = ". $id); //csinálunk egy SQL parancsot a databaseben való végrehajtásra, pl itt megakarjuk majd kapni a user táblázat minden tagját
$stmt->execute(); //végrehajtuk duh
//elkezdünk csinálni egy táblázatot

echo "<form action='' method='post'>";
echo "<input name='insertName' type='text' placeholder='Név'>" ;
echo "<input name='insertRelation' type='text' placeholder='Kapcsolat'>" ;
echo "<input name='insertNote' type='text' placeholder='Megjegyzés'>";
echo "<input type='submit' name='create' value='Új személy hozzáadása'>";
echo "</form>";

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
    echo "<td> <input name='title' type='text' value='".$row["title"] . "' </td>" ;
    echo "<td> <input name='price' type='number' value='".$row["price"] . "' </td>" ;
    echo " <label for='status'>Choose a car:</label>

    <select name="cars" id="cars">
      <option value="volvo">Volvo</option>
      <option value="saab">Saab</option>
      <option value="mercedes">Mercedes</option>
      <option value="audi">Audi</option>
    </select> ";
    echo "<td> <input name='note' type='hidden' value='".$row["image"] . "' </td>";
    echo "<td> <input name='creation' type='datetime-local' value='".$row["created_at"] . "' </td>";
    echo '<td> 
    <input type="hidden" name="id" value="'. $row["id"] . '">
    <input type="hidden" name="id" value="'. $row["person_id"] . '">
    <input type="submit" name="update" value="Szerkesztés">
    <input type="submit" name="delete" value="Törlés">
    </td> ';
    echo "</tr>";
    echo "</form>";
}






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
?>