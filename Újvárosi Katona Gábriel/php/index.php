

<?php 

$includeDir = ".". DIRECTORY_SEPARATOR."pages". DIRECTORY_SEPARATOR;
$includeDefault = $includeDir."home.php";
                 
if (isset($_GET['s']) && !empty($_GET['s']) ) {
    $_GET['s'] = str_replace("\0", ' ', $_GET['s']);
    $includeFile = basename(realpath($includeDir.$_GET['s'].".php"));
    $includePath = $includeDir.$includeFile;


    if (!empty($includeFile) && file_exists($includePath)) {
        include($includePath);
    } else {
        include('pages/404.php');
    }
} else { 
    include($includeDefault);
}

?>


    


