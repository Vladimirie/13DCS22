const lists = JSON.parse(localStorage.getItem('Items')) || [
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
  addItem.push({ Brand, Type, Expiration_Date })
  SaveItems();
  window.location.href='list.html';
}

function SaveItems() {
  localStorage.setItem('Items', JSON.stringify(list));
}

function RenderItems() {
  const list = document.getElementById('itemList');
  if (!list) return;

  list.innerHTML = '';
<<<<<<< HEAD
  item.forEach(a =>{
=======
  lists.forEach(a =>{
>>>>>>> eb5b9e80266646de374ed7db566ac7ba368a0f4f
    const div = document.createElement('div');
    div.className = 'card';
    div.innerHTML = '<strong>${a.Brand}</strong><br>Type: ${a.Type}<br>Expiration_Date: ${a.Expiration_Date}';
    list.appendChild(div);
  });
}

RenderItems();