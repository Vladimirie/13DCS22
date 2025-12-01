
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
      
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
    <link rel="stylesheet" href="./css/style.css">
    <title>Document</title>
</head>
<body>
    
<nav class="navbar navbar-expand-lg bg-body-tertiary">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">Navbar</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="#">Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="./pages/home.php">Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="/pages/test.php">Test</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="/pages/alma.php">Alma</a>
        </li>
        <li class="nav-item">
          <a class="nav-link disabled" aria-disabled="true">Disabled</a>
        </li>
      </ul>
    </div>
  </div>
</nav>


<div class="contntent">
<?php 
//^(.*[^/])$ 
//^([^/]+)
//^([a-zA-Z0-9_-]+)$ 

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
</div>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>
</html>


