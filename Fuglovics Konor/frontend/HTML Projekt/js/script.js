const nyersAdatok = [
	{
		nev: "Balogh Ádám",
		tantargy: "Szakmai Angol",
		hianyzas: 10,
		igazolt: false,
		tipus: ""
	},
	{
		nev: "Domonkos Lilla",
		tantargy: "Szakmai Angol",
		hianyzas: 1,
		igazolt: false,
		tipus: ""
	},
	{
		nev: "Fuglovics Konor",
		tantargy: "Frontend",
		hianyzas: 0,
		igazolt: false,
		tipus: ""
	},
	{
		nev: "Kiss Anna",
		tantargy: "Programozás",
		hianyzas: 5,
		igazolt: true,
		tipus: "Orvosi"
	},
	{
		nev: "Laczkó András",
		tantargy: "Backend",
		hianyzas: 13,
		igazolt: true,
		tipus: "Szülői"
	},
	{
		nev: "Mészáros Eszter",
		tantargy: "Programozás",
		hianyzas: 3,
		igazolt: true,
		tipus: "Orvosi"
	},
	{
		nev: "Nagy Bence",
		tantargy: "Adatbázis",
		hianyzas: 2,
		igazolt: false,
		tipus: ""
	},
	{
		nev: "Tóth Gábor",
		tantargy: "Frontend",
		hianyzas: 10,
		igazolt: false,
		tipus: ""
	},
	{
		nev: "Varga Dóra",
		tantargy: "Programozás",
		hianyzas: 8,
		igazolt: true,
		tipus: "Szülői"
	},
];
function GetSubjects()
{
	const list = document.getElementById("subjectfilter");
	let subjects = [];
	for(const event of nyersAdatok)
	{
		subjects = subjects.concat(event.tantargy);
	}
	const sortsubject = new Set(subjects);
	list.innerHTML = '';
	for(const item of sortsubject)
	{
		const li = document.createElement('option');
		li.textContent = item;
		list.appendChild(li);
	}
}
GetSubjects();