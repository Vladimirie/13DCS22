const name = document.getElementById('name');
const email = document.getElementById('email');
const age = document.getElementById('age');
const grades = document.getElementById('grades');
const jsonparse = document.getElementById('jsonparse');
const parseback = document.getElementById('parseback');
const p1 = document.getElementById('jsonresult');
const p2 = document.getElementById('jsoutput');

function ParseToJSON()
{
	const obj = {Név: name.textContent, Életkor: age, Email: email, Jegyek: grades};
	const convert = JSON.stringify(obj);
	p1.InnerHTML = convert;
}
function ParseBackToJS()
{
	
}
jsonparse.addEventListener('click', ParseToJSON);