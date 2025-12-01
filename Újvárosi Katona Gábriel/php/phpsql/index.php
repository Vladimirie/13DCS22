

<?php 


include_once("config.php");

$stmt = $db->prepare("SELECT * FROM user");
$stmt->execute();
// <table style='border: solid;'>

echo "<table>";

echo"
<tr>
 <th>ID</th>
<th>username</th>
<th>Fullname</th>
<th>Email</th>
<th>Művelet</th>
</tr>";


foreach ($stmt as $row) {
    echo "<form action='' method='post'>";
    echo "<tr>";

    echo "<td><input type='hidden' name='id' value='"  .$row['id']. "'></td>" ;
    echo "<td><input type='text' name='username' value='"  .$row["username"] ."'></td>" ;
    echo "<td><input type='text' name='fullname' value='".$row["fullname"] . "'></td>" ;
    echo "<td><input type='email' name='email' value='".$row["email"] ."'></td>";
    echo "<td><input type='submit' value='Módosit' name='update'> </td>";
    
    echo "</tr>";
    echo "</form>";
 
}
echo "</table>";


//CRUD

if (isset($_POST['create'])) {
    $sql = "INSERT INTO user (username, password ,fullname, email)
    VALUES (:username, :password, :fullname, :email)";

    $stmt1 = $db->prepare($sql);
    $stmt1->execute([
        ':username' => $_POST['username'],
        ':password' => $_POST['password'],
        ':fullname' => $_POST['fullname'],
        ':email' => $_POST['email']
    ]);

    echo "<h1>Sikeres hozzáadás</h1>";
}


if (isset($_POST['update'])) {
    $sql1 = "UPDATE user SET username = :username, fullname = :fullname, email = :email WHERE id = :id";
    $stm2 = $db->prepare($sql1);

    $stm2->execute([
        ':username' => $_POST['username'],
        ':fullname' => $_POST['fullname'],
        ':email' => $_POST['email'],
        ':id' => $_POST['id']
    ]);

    echo $_POST['username'];
}

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>CRUD</title>
</head>
<body>
<h2>ú j felhasználó hozzáadása </h2> 
<form action="" method="post">
        <input type="text" name="username" placeholder="LehasználóNév">
        <input type="password" name="password" placeholder="Haladó szó">
        <input type="text" name="fullname" placeholder="Betelt Name">
        <input type="email" name="email" placeholder="E Levél">

        <input type="submit" name="create" value="Felvétel">



</form>
</body>
</html>