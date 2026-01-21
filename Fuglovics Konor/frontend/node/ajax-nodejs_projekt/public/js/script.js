const butt = document.getElementById("refresh_table");
butt.addEventListener("click", UploadCombobox);
const combobox = document.getElementById("people");
combobox.addEventListener("onchange", LoadData(this.value));
const name = document.getElementById('f_name').value;
const email = document.getElementById('f_email').value;
const phone = document.getElementById('f_phone').value;
const mother = document.getElementById('f_mother').value;
const id = document.getElementById('f_id').value;

function Silly()
{
	alert(":3");
}

async function UploadCombobox()
{
	try
	{
		const res = await fetch('/api/szemelyek');
		allpeople = await res.json();
		const select = document.getElementById("people");
		select.innerHTML = (
			"<option value=\"\">Choose a person</option>"
		);
		allpeople.forEach(p =>
		{
			const option = document.createElement('option');
			option.value = p.id;
			option.textContent = p.nev;
			select.appendChild(option);
		});
		alert("Updated list :3");
	}
	catch(err)
	{
		console.error(err);
	}
}
let allpeople = [];
function ClearData()
{
	name = "";
	email = "";
	phone = "";
	mother = "";
	id = "";
}
function LoadData(id)
{
	if(!id)
	{
		ClearData();
		return;
	}
	const selected = allpeople.find(p => p.id == id);
	if (selected)
	{
		name = selected.nev;
		email = selected.email;
		phone = selected.telefon || 'Not assigned';
		mother = selected.anyja_neve || 'Not assigned';
		id = selected.igazolvany_szam || 'Not assigned';
	}
}