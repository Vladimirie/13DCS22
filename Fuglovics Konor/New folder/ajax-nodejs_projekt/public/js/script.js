const butt = document.getElementById("refresh_table");
butt.addEventListener("click", UploadCombobox);
const combobox = document.getElementById("cars");
combobox.addEventListener("onchange", LoadData(this.value));
const _id = document.getElementById('edit_id').value;
const carplate = document.getElementById('f_licenseplate').value;
const carbrand = document.getElementById('f_brand').value;
const carmodel = document.getElementById('f_model').value;
const tabl = document.getElementById('datatable');
tabl.addEventListener("onload", LoadTable);

async function UploadCombobox()
{
	try
	{
		let allpeople = [];
		const res = await fetch('/api/cars');
		allpeople = await res.json();
		const select = document.getElementById("cars");
		select.innerHTML = (
			"<option value=\"\">Choose a Car</option>"
		);
		allpeople.forEach(p =>
		{
			const option = document.createElement('option');
			option.value = p.CarID;
			option.textContent = p.Brand;
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
	const res = await fetch('/api/cars');
	const datae = await res.json();
	document.getElementById('datatable').innerHTML = datae.map(tbl => `
		<tr>
			<td>${tbl.licenseplate}</td>
			<td>${tbl.brand}</td>
			<td>${tbl.model}</td>
			<td>
				<button class="modify" onclick="edit(${JSON.stringify(tbl)})">Modify</button>
				<button class="delete" onclick="delete(${tbl.id})"></button>
			</td>
		`
	).join();
}
function edit(car)
{
	_id = car.carid;
	carplate = car.licenseplate;
	carbrand = car.brand;
	carmodel = car.model;
}
function LoadData(id)
{
	if(!id)
	{
		ClearData();
		return;
	}
	const selected = allpeople.find(c => c.CarID == id);
	if (selected)
	{
		carplate = selected.LicensePlate;
		carbrand = selected.Brand;
		carmodel = selected.Model;
	}
}
function ClearData()
{
	document.getElementById('f_licenseplate').value = "";
	document.getElementById('f_brand').value = "";
	document.getElementById('f_model').value = "";
}