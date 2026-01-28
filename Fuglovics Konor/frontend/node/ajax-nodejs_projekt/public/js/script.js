const butt = document.getElementById("refresh_table");
butt.addEventListener("click", UploadCombobox);
const combobox = document.getElementById("people");
combobox.addEventListener("onchange", LoadData(this.value));
const _id = document.getElementById('edit_id').value;
const name = document.getElementById('f_name').value;
const email = document.getElementById('f_email').value;
const phone = document.getElementById('f_phone').value;
const mother = document.getElementById('f_mother').value;
const id = document.getElementById('f_idnum').value;
const tabl = document.getElementById('datatable');
tabl.addEventListener("onload", LoadTable);

function Silly()	//EZ CSAK A GOMBOK TESZTELÉSEKÉNT VOLT!!
{
	alert(":3");
}
async function Greet()
{
	const name = document.getElementById("name").value;
	const res = await fetch('/api/koszontes', 
	{
		method: "POST",
		headers: 
		{
			'Content-Type': 'application/json'
		},
		body: JSON.stringify({name})
	});
	const data = await res.json();
	document.getElementById("greettext").innerText = data.message || data.error;
}
async function UploadCombobox()
{
	try
	{
		let allpeople = [];
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
async function LoadTable()
{
	const res = await fetch('/api/szemelyek');
	const datae = await res.json();
	document.getElementById('datatable').innerHTML = datae.map(tbl => `
		<tr>
			<td>${tbl.nev}</td>
			<td>${tbl.email}</td>
			<td>${tbl.telefon}</td>
			<td>${tbl.anyja_neve}</td>
			<td>${tbl.igazolvany_szam}</td>
			<td>
				<button class="modify" onclick="edit(${JSON.stringify(tbl)})">Modify</button>
				<button class="delete" onclick="delete(${tbl.id})"></button>
			</td>
		`
	).join();
}
function edit(person)
{
	_id = person.id;
	name = person.nev;
	email = person.email;
	phone = person.telefon || '';
	mother = person.anyja_neve || '';
	id = person.igazolvany_szam || '';
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
function ClearData()
{
	document.getElementById('f_name').value = "";
	document.getElementById('f_email').value = "";
	document.getElementById('f_phone').value = "";
	document.getElementById('f_mother').value = "";
	document.getElementById('f_idnum').value = "";
}