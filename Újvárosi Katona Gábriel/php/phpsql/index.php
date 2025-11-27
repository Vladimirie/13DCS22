

<?php 


include_once("config.php");

$stmt = $db->prepare("SELECT * FROM user");
$stmt->execute();
// <table style='border: solid;'>
echo "<table style='border: solid;'>";

echo"
<tr>
 <th>ID</th>
<th>username</th>
<th>Fullname</th>
<th>Email</th>
</tr>";


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