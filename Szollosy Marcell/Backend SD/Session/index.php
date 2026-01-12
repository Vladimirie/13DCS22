<?php

//PHP SESSIONS

session_start();





var_dump ($_SESSION);
echo "<br>";

$_SESSION['name'] = 'Péter';

var_dump ($_SESSION);
echo "<br>";

echo $_SESSION['name'];

if (isset($_SESSION['name'])) {
    echo "Szia ".$_SESSION['name'];
}else{
    echo "Jelentkezz be!";
}

unset($_SESSIONű['name']);


?>