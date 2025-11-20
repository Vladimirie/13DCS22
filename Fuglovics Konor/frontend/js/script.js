const hover = document.getElementById('hoverme');
function hoverOn()
{
	hover.textContent = "wawa :3";
}

function hoverOff()
{
	hover.textContent = "text";
}
hover.addEventListener('mouseover', hoverOn);
hover.addEventListener('mouseout', hoverOff);