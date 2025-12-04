
 


 <h1 style="text-align: center;"> Termékek </h1>
<table class="table" style="text-align: center; ">
    <tr>
        <th></th>
        <th>Név</th>
        <th>Ár</th>
        <th>Menyiség</th>
        <th>Leírás</th>
        <th>Műveletek</th>

    </tr>


<?php 


$stmt = $database->prepare("SELECT * FROM products");
$stmt->execute();

foreach ($stmt as $row) {
    // itt valamiért csak ' kall szerete és nem " al
    echo '<form action="" method="post">';
    echo "<tr>";
    echo "<td> <input type='hidden' name='id' value='". $row['id']. "'></td>";
    echo "<td> <input type='text' name='name' value='". $row['name']. "'></td>";
    echo "<td> <input type='number' name='price' value='". $row['price']. "'>FT/KG</td>";
    echo "<td> <input type='number' name='quantity' value='". $row['quantity']. "'>KG</td>";
    echo "<td> <input type='text' name='description' value='". $row['description']. "'></td>";
    echo "<td> 
    <input type='submit'  name='update' class='btn btn-warning' value='Módosít'> 
    <input type='submit'  name='delete' class='btn btn-danger' value='Törlés'>";
    echo "</td>";
    echo "</tr>";
    echo "</form>";

}
echo "</table>";


if (isset($_POST['update'])) {

    $sql = "UPDATE products SET name = :name, price = :price, quantity = :quantity, description = :description   WHERE id = :id";


    $stmt1 = $database->prepare($sql);
    $stmt1->execute([
        ':name' => $_POST['name'],
        ':price' => $_POST['price'],
        ':quantity' => $_POST['quantity'],
        ':description' => $_POST['description'],
        ':id' => $_POST['id'],

    ]);

    echo "<h1>".$_POST['name']."Sikeresen Módosítva</h1>";
}

if (isset($_POST['delete'])) {
    
    $sql2 = "DELETE FROM products WHERE id = :id";
    $stm3 = $database->prepare($sql2) ;
    $stm3->execute([
        ':id' => $_POST['id']
    ]);
    echo "<h1>".$_POST['name']."Sikeresen Kitötölve</h1>";
    
}

?>