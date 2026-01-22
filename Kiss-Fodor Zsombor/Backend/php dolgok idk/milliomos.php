<?php

    $kerdes = 1;

    if (isset($_POST["submit"])) 
    { 
        if ($kerdes == 1) {
            if (isset($_POST["futni"])) {
            $elso = "teknos";
            $elsoValasz = $_POST["futni"];
    
            if ($elsoValasz == $elso) {
                $kerdes += 1;
                echo "<p>$kerdes<p>";
                echo "<script>document.getElementById('nyeremeny').textContent = 'Nyeremény: ' + '2000' + ' forint';</script>";
                echo "<script>document.getElementById('1').style.display = 'none';</script>";  
                echo "<script>document.getElementById('2').style.display = 'block';</script>";
            }
            else {
                echo "<script>document.getElementById('1').style.display = 'none';</script>";
                echo "<script>document.getElementById('gomb').style.display = 'none';</script>";
                echo "<script>document.getElementById('lose').style.display = 'block';</script>";
            }
            }    
        }
        else if ($kerdes == 2) {
            if (isset($_POST["lab"])) {
                $ketto = "foka";
                $kettoValasz = $_POST["lab"];
    
                if ($kettoValasz == $ketto) {
                    $kerdes += 1;
                    echo "<script>nyeremenyupdate();</script>";
                    echo "<script>document.getElementById('2').style.display = 'none';</script>";  
                    echo "<script>document.getElementById('3').style.display = 'block';</script>";
                }
                else {
                    echo "<script>document.getElementById('2').style.display = 'none';</script>";
                    echo "<script>document.getElementById('gomb').style.display = 'none';</script>";
                    echo "<script>document.getElementById('lose').style.display = 'block';</script>";
                }
            }
        }
    }

?>