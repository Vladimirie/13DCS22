



<div class="f" style="background-image: url(./stan-twt-skeleton-banging-shield.gif); width:50vh; height: 50vh;">


</div>


<?php

//PHP SESSIONS

session_start();

  var_dump($_SESSION);
echo "<br>";
$_SESSION['name'] = "Púzó Védő";

var_dump($_SESSION);
echo "<br>";

if (isset($_SESSION['name'])) {
echo  "Szia ".$_SESSION['name'];
} else {
    echo "Jelentkez be!";
}


//unset($_SESSION['name']);
session_unset();
session_destroy();


?>