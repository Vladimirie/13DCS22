<<<<<<< HEAD
const array =
[
	{
		name: "Anti Spook Squad",
		date: "1974.10.26.",
		location: "Badlands",
		participants: ["Jane", "Sanchez", "Dell", "Tavish", "Mikhail"],
		category: "Squad"
	},
	{
		name: "Formula 1 Ferrari Team",
		date: "2016.6.30.",
		location: "Alleyway Circuit",
		participants: ["Alonso", "Massa"],
		category: "Racing"
	},
	{
		name: "Kortárs Művészeti Kiállítás",
		date: "2025.12.1.",
		location: "Műcsarnok",
		participants: ["Anna", "Zsuzsa", "László", "Mariann"],
		category: "Culture"
	},
	{
		name: "IT Szakmai Konferencia 2025",
		date: "2025.9.10.",
		location: "Debrecen Egyetem",
		participants: ["Péter", "Gábor", "Norbert", "Bea", "Dávid"],
		category: "Conference"
	},
	{
		name: "13.D Osztály",
		date: "2020.9.1.",
		location: "BGÉSZC Katona József Technikum",
		participants: ["Konor", "Máté", "Zsombor", "Gábriel", "Marcell", "Ali", "Alex"],
		category: "Education"
	},
]
function PrintList(arrayname, itemID)
{
	const ul = document.getElementById(itemID);
	ul.innerHTML = '';
	for (const event of arrayname)
	{
		const li = document.createElement("li");
		const participantString = event.participants.join(', ');
		li.innerHTML = `
			<strong>${event.name}</strong> (${event.date})
			<br>
			&nbsp;&nbsp;&nbsp;Location: ${event.location}, Category: ${event.category}
			<br>
			&nbsp;&nbsp;&nbsp;Participants (${event.participants.length} people): ${participantString}
		`;
		ul.appendChild(li);
	}
}
PrintList(array, "originallist");
const BigEvents = array.filter(event => event.participants.length>3);
PrintList(BigEvents, "filterresultlist");

const NamesAndCategories = array.map(event => 
{
	return {
		name: event.name,
		category: event.category
	};
});

const mapUL = document.getElementById("mapresultlist");
NamesAndCategories.forEach(item =>
{
	const li = document.createElement('li');
	li.textContent = `Name: ${item.name}, Category: ${item.category}`;
	mapUL.appendChild(li);
})
let totalParticipants = [];
for(const event of array)
{
	totalParticipants = totalParticipants.concat(event.participants);
}
const customParticipants = new Set(totalParticipants);
const setUL = document.getElementById('setresultlist');
setUL.innerHTML = '';
for(const participant of customParticipants)
{
	const li = document.createElement('li');
	li.textContent = participant;
	setUL.appendChild(li);
=======
const array =
[
	{
		name: "Anti Spook Squad",
		date: "1974.10.26.",
		location: "Badlands",
		participants: ["Jane", "Sanchez", "Dell", "Tavish", "Mikhail"],
		category: "Squad"
	},
	{
		name: "Formula 1 Ferrari Team",
		date: "2016.6.30.",
		location: "Alleyway Circuit",
		participants: ["Alonso", "Massa"],
		category: "Racing"
	},
	{
		name: "Kortárs Művészeti Kiállítás",
		date: "2025.12.1.",
		location: "Műcsarnok",
		participants: ["Anna", "Zsuzsa", "László", "Mariann"],
		category: "Culture"
	},
	{
		name: "IT Szakmai Konferencia 2025",
		date: "2025.9.10.",
		location: "Debrecen Egyetem",
		participants: ["Péter", "Gábor", "Norbert", "Bea", "Dávid"],
		category: "Conference"
	},
	{
		name: "13.D Osztály",
		date: "2020.9.1.",
		location: "BGÉSZC Katona József Technikum",
		participants: ["Konor", "Máté", "Zsombor", "Gábriel", "Marcell", "Ali", "Alex"],
		category: "Education"
	},
]
function PrintList(arrayname, itemID)
{
	const ul = document.getElementById(itemID);
	ul.innerHTML = '';
	for (const event of arrayname)
	{
		const li = document.createElement("li");
		const participantString = event.participants.join(', ');
		li.innerHTML = `
			<strong>${event.name}</strong> (${event.date})
			<br>
			&nbsp;&nbsp;&nbsp;Location: ${event.location}, Category: ${event.category}
			<br>
			&nbsp;&nbsp;&nbsp;Participants (${event.participants.length} people): ${participantString}
		`;
		ul.appendChild(li);
	}
}
PrintList(array, "originallist");
const BigEvents = array.filter(event => event.participants.length>3);
PrintList(BigEvents, "filterresultlist");

const NamesAndCategories = array.map(event => 
{
	return {
		name: event.name,
		category: event.category
	};
});

const mapUL = document.getElementById("mapresultlist");
NamesAndCategories.forEach(item =>
{
	const li = document.createElement('li');
	li.textContent = `Name: ${item.name}, Category: ${item.category}`;
	mapUL.appendChild(li);
})
let totalParticipants = [];
for(const event of array)
{
	totalParticipants = totalParticipants.concat(event.participants);
}
const customParticipants = new Set(totalParticipants);
const setUL = document.getElementById('setresultlist');
setUL.innerHTML = '';
for(const participant of customParticipants)
{
	const li = document.createElement('li');
	li.textContent = participant;
	setUL.appendChild(li);
>>>>>>> 508682966dc1c50aeb4017a64c1f9d921eaa4e6d
}