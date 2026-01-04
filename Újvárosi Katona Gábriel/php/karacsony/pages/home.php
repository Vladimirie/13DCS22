
<form action="" method="$_POST"></form>
<?php

$query = "Select * from persons";
$persons = $database->prepare($query);
$persons->execute();


echo '<form action="" method="post">';

echo "<td> <input type='text' name='name' placeholder='név' > </td> ";
echo "<td> <input type='text' name='relation' placeholder='Kapcsolat' > </td> ";
echo "<td> <input type='text' name='note' placeholder='Jegyzet'> </td> ";
echo" <input type='submit'  name='insert'  value='Új megajándékozott hozzáadása '>";
echo "</form>";
echo "<table>";

echo "<tr>";
echo "<td></td>";
echo "<td><h1>Név</h1></td>";
echo "<td><h1>Kapcsolat</h1></td>";
echo "<td><h1>Note</h1></td>";
echo "<td><h1>Műveletek</h1></td>";
echo "</tr>";


foreach($persons as $person) {
    echo "<tr>";
    echo '<form action="" method="post">';
echo "<td> <input type='hidden' name='id' value='" .$person['id']. "'> </td> ";
echo "<td> <input type='text' name='name'  value='" .$person['name']. "'> </td> ";
echo "<td> <input type='text' name='relation' value='" .$person['relation']. "'> </td> ";
echo "<td> <input type='text' name='note' value='" .$person['note']. "'> </td> ";
echo "<td>
<input type='submit'  name='view'  value='Ajándékok megtekintése'>  
<input type='submit'  name='update'  value='Szerkesztés'> 
<input type='submit'  name='delete'  value='Törlés'>";
echo "</td>";


echo "</form>";
echo "</tr>";



        
}
echo "</table>";
echo "<table>";
echo "<tr>";
echo "<td></td>";
echo "<td><h1>Név</h1></td>";
echo "<td><h1>Ár</h1></td>";
echo "<td><h1>Státusz</h1></td>";
echo "<td><h1>Kép</h1></td>";
echo "<td><h1>Öszzár</h1></td>";
echo "<td><h1>Műveletek</h1></td>";
echo "</tr>";


$query = "Select * from gifts";
$gifts = $database->prepare($query);
$gifts->execute();

foreach($gifts as $gift) {
    echo "<tr>";
    echo '<form action="" method="post">';
echo "<td> <input type='hidden' name='id' value='" .$gift['id']. "'> </td> ";
echo "<td> <input type='text' name='title '  value='" .$gift['title']. "'> </td> ";
echo "<td> <input type='number' name='price' value='" .$gift['price']. "'> </td> ";
echo "<td> <input type='text' name='status' value='" .$gift['status']. "'> </td> ";
echo "<td> <input type='text' name='image' value='" .$gift['image']. "'> </td> ";
echo "<td> Öszár:" . "</td>";
echo "<td>
<input type='submit'  name='viewgift'  value='Ajándékok megtekintése'>  
<input type='submit'  name='updategift'  value='Szerkesztés'> 
<input type='submit'  name='deletegift'  value='Törlés'>";
echo "</td>";


echo "</form>";
echo "</tr>";



        
}
echo "</table>";

/*
if (isset($_GET['update'])) {

    $sql = 

}
*/
if (isset($_POST['update'])) {

    $sql = "UPDATE persons SET name = :name, relation = :relation, note = :note    WHERE id = :id";
               // mi az hogy nem tudod a stringet megszámolni !?
    if ($_POST['name'] != "" /*&& count($_POST['relation']) >=  3*/) {
    $ex = $database->prepare($sql);
    $ex->execute([
        ':id' => $_POST['id'],
        ':name' => $_POST['name'],
        ':relation' => $_POST['relation'],
        ':note' => $_POST['note'],

    
    ]);

    echo $_POST['name']." sikeresen frisítve";
} else {
    echo "Kérem agyon meg nevet és rendes kapcsolatot!";
}
}


if (isset($_POST['delete'])) {

    $sqls = "DELETE FROM `persons` WHERE id = :id" ;


    $ex0 = $database->prepare($sqls);
    $ex0->execute([
        ':id' => $_POST['id'],


    
    ]);

    echo $_POST['name']." sikeresen törölve";
}

if (isset($_POST['insert'])) {

   
 
 $sqfl = "INSERT INTO `persons`( `name`, `relation`, `note`) VALUES (:name, :relation, :note);";
 if ($_POST['name'] != "" /*&& count($_POST['relation']) >=  3*/) {
    $ex1 = $database->prepare($sqfl);
    $ex1->execute([
 
        ':name' => $_POST['name'],
        ':relation' => $_POST['relation'],
        ':note' => $_POST['note'],

    
    ]);

    echo $_POST['name']." sikeresen hozzáadva";
} else {
    echo "Kérem agyon meg nevet és rendes kapcsolatot!";
}
}

if (isset($_POST['updategift'])) {

    $sql = "UPDATE persons SET title = :title, price = :price, status = :status   WHERE id = :id";
               // mi az hogy nem tudod a stringet megszámolni !?
    //if ($_POST['title'] != "" /*&& count($_POST['relation']) >=  3*/) {
    $ex = $database->prepare($sql);
    $ex->execute([
        ':id' => $_POST['id'],
        ':title' => $_POST['title'],
        ':price' => $_POST['price'],
        ':status' => $_POST['status'],

    
    ]);

    echo $_POST['name']." sikeresen frisítve";
//} else {
 //   echo "Kérem agyon meg nevet és rendes kapcsolatot!";
//}
}



?>




