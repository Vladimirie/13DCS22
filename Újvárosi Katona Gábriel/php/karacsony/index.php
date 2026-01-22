<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    

<?php
include_once "./config.php";





$incDir = "." . DIRECTORY_SEPARATOR . "pages" . DIRECTORY_SEPARATOR;
$incDef = $incDir . "home.php";

if (isset($_GET['s']) && !empty($_GET['s'])) {
$_GET['s'] = str_replace("\0", '', $_GET['s']);
    $incFile = basename(realpath($incDir.$_GET['s'].".php"));
    $incPath = $incDir.$incFile;

    if (!empty($incFile) && file_exists($incPath)) {
        include($incPath);
    }else{
        include('pages/404.php');
    }





} else {
    include($incDef);
}


?>








</body>
</html>