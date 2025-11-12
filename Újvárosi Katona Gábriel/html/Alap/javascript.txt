const apiUrl = 'api.php';

    const usernameInput = document.getElementById('username');
    const usernameStatus = document.getElementById('username-status');
    let usernameTimeout = null;

    usernameInput.addEventListener('input', () => {
      clearTimeout(usernameTimeout);
      const val = usernameInput.value.trim();
      if (!val) {
        usernameStatus.textContent = '';
        usernameStatus.style.color = '';
        return;
      }
      usernameStatus.textContent = 'Ellenőrzés...';
      usernameStatus.style.color = 'black';
      usernameTimeout = setTimeout(() => {
        fetch(`${apiUrl}?check_username=${encodeURIComponent(val)}`)
          .then(res => res.json())
          .then(data => {
            if (data.taken) {
              usernameStatus.textContent = 'Foglalt';
              usernameStatus.style.color = 'red';
            } else {
              usernameStatus.textContent = 'Szabad';
              usernameStatus.style.color = 'green';
            }
          }).catch(() => {
            usernameStatus.textContent = 'Hiba az ellenőrzés során';
            usernameStatus.style.color = 'orange';
          });
      }, 500);
    });
