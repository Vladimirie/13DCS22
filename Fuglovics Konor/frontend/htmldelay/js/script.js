function fill1()
{
	document.getElementById("input1").value = 100;
	setTimeout(fill2, 500);
}
function fill2()
{
	document.getElementById("input2").value = 100;
	setTimeout(fill3, 500);
}
function fill3()
{
	document.getElementById("input3").value = 100;
	setTimeout(fill4, 500);
}
function fill4()
{
	document.getElementById("input4").value = 100;
	setTimeout(fill5, 500);
}
function fill5()
{
	document.getElementById("input5").value = 100;
}
function start()
{
	setTimeout(fill1, 500);
}
{}
function Reset()
{
	document.querySelectorAll("input").forEach((inp)=>
	{
		inp.value = "";
		inp.style = "";
	});
	setTimeout(fill1, 500);
}
/*for (var i=1;i<6;i++)
{
	var input = "input"+i;
	fill(input);
	setTimeout(fill, 500);
}*/
window.onload = start;