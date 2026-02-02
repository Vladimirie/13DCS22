


<h1>

Termék Hozáadása

</h1>


<form action="" method="post">
<div class="mb-3">
    <label for="name"  class="form-label">Név</label>
<input type="text" class="form-control" value="" placeholder="Termék név" name="name">
</div>
<div class="mb-3">
    <label for="price"  class="form-label">Ár</label>
<input type="number" class="form-control" value="" placeholder="Ár FT/KG" name="price">
</div>
<div class="mb-3">
<label for="quantity"  class="form-label">Menyiség</label>
<input type="number" class="form-control" value="" placeholder="Menyiség KG" name="quantity">
</div>

<div class="mb-3">
<label for="description"  class="form-label">Leírás</label>  
<input type="text" class="form-control" value="" placeholder="Leírás" name="description">
</div>
<input type="submit" name="insert" class="btn btn-primary" value="Hozáadás">


</form>


<?php 


if (isset($_POST['insert'])) {
    $sql = "INSERT INTO products (name, price , quantity, description)
    VALUES (:name, :price, :quantity, :description)";

    $stmt1 = $database->prepare($sql);
    $stmt1->execute([
        ':name' => $_POST['name'],
        ':price' => $_POST['price'],
        ':quantity' => $_POST['quantity'],
        ':description' => $_POST['description']
    ]);

    echo "<h1>".$_POST['name']."Sikeresen hozzáadva</h1>";
}




?>


