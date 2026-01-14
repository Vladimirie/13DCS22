const gsmdata = 
[{
	id: 1,
	márka: "Samsung",
	név: "Galaxy S3",
	modell: "GT-I9300",
	megjelent: "2012.09.",
	sim: "Micro-SIM",
	hálózat: "3G",
	rendszer: "Android 4.4.4",
	kártyafüggő: false
},
{
	id: 2,
	márka: "Samsung",
	név: "Star",
	modell: "GT-S5230",
	megjelent: "2009.05.",
	sim: "Mini-SIM",
	hálózat: "EDGE",
	rendszer: "-",
	kártyafüggő: true	
},
{
	id: 3,
	márka: "Nokia",
	név: "-",
	modell: "3310",
	megjelent: "2000",
	sim: "Mini-SIM",
	hálózat: "GSM",
	rendszer: "-",
	kártyafüggő: false
},
{
	id: 4,
	márka: "Nokia",
	név: "-",
	modell: "E51",
	megjelent: "2007.11.",
	sim: "Mini-SIM",
	hálózat: "3G",
	rendszer: "Symbian OS S60v3",
	kártyafüggő: true,
},
{
	id: 5,
	márka: "HTC",
	név: "Desire",
	modell: "A8181",
	megjelent: "2010.02.",
	sim: "Mini-SIM",
	hálózat: "3G",
	rendszer: "Android 2.1",
	kártyafüggő: false
},
{
	id: 6,
	márka: "Samsung",
	név: "-",
	modell: "SGH-D900i",
	megjelent: "2007",
	sim: "Mini-SIM",
	hálózat: "EDGE",
	rendszer: "-",
	kártyafüggő: false
},
{
	id: 7,
	márka: "Samsung",
	név: "Galaxy J6 (2018)",
	modell: "SM-J600F",
	megjelent: "2018.05.",
	sim: "Nano-SIM",
	hálózat: "4G",
	rendszer: "Android 10",
	kártyafüggő: false,
},
{
	id: 8,
	márka: "Nokia",
	név: "-",
	modell: "C2-01",
	megjelent: "2011.03.",
	sim: "Mini-SIM",
	hálózat: "3G",
	rendszer: "-",
	kártyafüggő: true
}]
const gsmlist = document.getElementById("dropdown");
const tbldata = document.querySelector("#datatable tbody");
gsmlist.addEventListener('change', LoadData);
gsmdata.forEach(phone =>
{
	const list = document.createElement("option");
	list.value = phone.modell;
	if(phone.név == "-")
	{
		list.innerHTML = `${phone.márka} ${phone.modell}`;
	}
	else
	{
		list.innerHTML = `${phone.márka} ${phone.név}`;
	}
	gsmlist.appendChild(list);
});
function LoadData()
{
	gsmdata.forEach(phone =>
	{
		const data = document.createElement("tr");
		data.innerHTML = `
			<td>${phone.márka}</td>
			<td>${phone.név}</td>
			<td>${phone.modell}</td>
			<td>${phone.megjelent}</td>
			<td>${phone.sim}</td>
			<td>${phone.hálózat}</td>
			<td>${phone.rendszer}</td>
			<td>${phone.kártyafüggő}</td>
		`;
		tbldata.appendChild(data);
	});
};