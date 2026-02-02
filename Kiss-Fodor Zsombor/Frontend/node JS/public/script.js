async function loadOwners() {
    try {
      const response = await fetch("/api/owners");
      const owners = await response.json();
  
      const tbody = document.getElementById("ownerTableBody");
      tbody.innerHTML = "";
  
      owners.forEach(owner => {
        tbody.innerHTML += `
          <tr>
            <td>${owner.ID}</td>
            <td>${owner.Name}</td>
            <td>${owner.Address}</td>
            <td>${owner.Phone}</td>
          </tr>
        `;
      });
  
    } catch (error) {
      console.error("Hiba az adatok betöltésekor:", error);
    }
  }
  
  // Automatikus betöltés oldalinduláskor
  loadOwners();
  