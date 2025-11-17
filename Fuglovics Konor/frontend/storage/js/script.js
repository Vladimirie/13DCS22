<<<<<<< HEAD
function Save()
{
	let name = document.getElementById('name').value;
	let time = document.getElementById('time').value;
	let sport = document.getElementById('sports').value;
	let ticket = document.getElementById('ticket').value;
	const btn = document.getElementById('btndel');
	let record = {name, time, sport, ticket};
	let list = JSON.parse(localStorage.getItem("orders") || "[]");
	list.push(record);
	localStorage.setItem("orders", JSON.stringify(list));
	document.getElementById('form').reset();
	alert("Sikeres mentés.");
	if(list !== undefined && list.length != 0)
	{
		btn.removeAttribute('hidden');
	}
}
function Read()
{
	let list = JSON.parse(localStorage.getItem('orders') || "[]");
	let html = "<table><tr><th>Név:</th><th>Időpont:</th><th>Sportág:</th><th>Bérletszám:</th></tr>";
	for(let item of list)
	{
		html += `<tr>
			<td>${item.name}</td>
			<td>${item.time}</td>
			<td>${item.sport}</td>
			<td>${item.ticket}</td>
		</tr>`;
	}
	html+="</table>";
	document.getElementById('datatable').innerHTML = html;
}
function Delete()
{
	localStorage.clear();
=======
function Save()
{
	let name = document.getElementById('name').value;
	let time = document.getElementById('time').value;
	let sport = document.getElementById('sports').value;
	let ticket = document.getElementById('ticket').value;
	const btn = document.getElementById('btndel');
	let record = {name, time, sport, ticket};
	let list = JSON.parse(localStorage.getItem("orders") || "[]");
	list.push(record);
	localStorage.setItem("orders", JSON.stringify(list));
	document.getElementById('form').reset();
	alert("Sikeres mentés.");
	if(list !== undefined && list.length != 0)
	{
		btn.removeAttribute('hidden');
	}
}
function Read()
{
	let list = JSON.parse(localStorage.getItem('orders') || "[]");
	let html = "<table><tr><th>Név:</th><th>Időpont:</th><th>Sportág:</th><th>Bérletszám:</th></tr>";
	for(let item of list)
	{
		html += `<tr>
			<td>${item.name}</td>
			<td>${item.time}</td>
			<td>${item.sport}</td>
			<td>${item.ticket}</td>
		</tr>`;
	}
	html+="</table>";
	document.getElementById('datatable').innerHTML = html;
}
function Delete()
{
	localStorage.clear();
>>>>>>> 508682966dc1c50aeb4017a64c1f9d921eaa4e6d
}