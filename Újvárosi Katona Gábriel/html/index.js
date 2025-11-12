


function Addnumber(number, id) {


    document.getElementById(id).innerText = number;
   
}


function Format(borderwidth, color, hasborder, id , border_Style){

    if(hasborder) {
    document.getElementById(id).style.borderStyle = border_Style;
    document.getElementById(id).style.backgroundColor = color;
    document.getElementById(id).style.borderWidth = borderwidth + "px";  



    } else {
        document.getElementById(id).style.backgroundColor = color;
    }

}

setTimeout('Addnumber(100, "water")', 1000)
setTimeout('Addnumber(200, "thick")', 2000)
setTimeout('Addnumber(350, "thinaqua")', 3000)
setTimeout('Addnumber(750, "red")', 4000)
setTimeout('Addnumber(1750, "libafoszold")', 5000)
setTimeout('formatcalling()', 6000)
function formatcalling(){
    setTimeout('Format(0.1, "lightcyan", true, "water", "Solid") ', 1000)
    setTimeout('Format(10, "white", true, "thick", "Solid")', 2000)
    setTimeout('Format(0.2, "aqua", true, "thinaqua", "Solid")', 3000)
    setTimeout('Format(0, "red" , false ,"red","");', 4000)
    setTimeout(' Format(2, "ForestGreen ", true, "libafoszold" ,"Dashed") ', 5000)

      
    
    
   


}