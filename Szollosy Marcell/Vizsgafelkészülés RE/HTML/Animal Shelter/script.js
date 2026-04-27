const animals = JSON.parse(localStorage.getItem('animals')) || [
  { name: 'Milo', type: 'Cat', age: '2' },
  { name: 'Buddy', type: 'Dog', age: '3' }
];

function saveAnimals() {
    /*fetch("url", {
        method: "POST",
        body: JSON.stringify(animals),
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    })
    .then((response) => response.json())
    .then((json) => console.log(json));*/
    localStorage.setItem('animals', JSON.stringify(animals));
}

function renderAnimals() {
  const list = document.getElementById('animalList');
  if (!list) return;

  list.innerHTML = '';
  animals.forEach(a => {
    const div = document.createElement('div');
    div.className = 'card';
    div.innerHTML = `<strong>${a.name}</strong><br>Type: ${a.type}<br>Age: ${a.age}`;
    list.appendChild(div);
  });
}

function addAnimal() {
  const name = document.getElementById('name').value;
  const type = document.getElementById('type').value;
  const age = document.getElementById('age').value;


  if (!name || !age) {
    alert('Please fill all fields');
    return;
  }

  animals.push({ name, type, age });
  saveAnimals();
  window.location.href = 'list.html';
}

// Run on page load
renderAnimals();