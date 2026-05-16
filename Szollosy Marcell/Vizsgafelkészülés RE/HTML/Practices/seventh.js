const list = JSON.parse(localStorage.getItem('Items')) || [
  { Brand: 'Axe', Type: 'Bodyspray', Expiration_Date: '2026.11.30' },
  { Brand: 'HoneyApple', Type: 'Food', Expiration_Date: '2026.10.30' }
];

function addItem() {
  const Brand = document.getElementById('Brand').value;
  const Type = document.getElementById('Type').value;
  const Expiration_Date = document.getElementById('Expiration_Date').value;
  if (!Brand || !Expiration_Date) {
    alert('Please fill the space');
    return;
  }
  list.push({ Brand, Type, Expiration_Date })
  SaveItems();
  window.location.href='list.html';
}

function SaveItems() {
  localStorage.setItem('Items', JSON.stringify(list));
}

function RenderItems() {
  const lists = document.getElementById('ItemList');
  if (!list) return;

  list.innerHTML = '';
  item.forEach(a =>{
    const div = document.createElement('div');
    div.className = 'card';
    div.innerHTML = '<strong>${a.Brand}</strong><br>Type: ${a.Type}<br>Expiration_Date: ${a.Expiration_Date}';
    list.appendChild(div);
  });
}

RenderItems();