const tableBody = document.getElementById("autoTabla");
const form = document.getElementById("carForm");

const carIdInput = document.getElementById("carId");
const licenseInput = document.getElementById("licensePlate");
const brandInput = document.getElementById("brand");
const modelInput = document.getElementById("model");


// ======================
// Adatok betöltése
// ======================
async function loadCars() {
    const response = await fetch("/api/cars");
    const cars = await response.json();

    tableBody.innerHTML = "";

    cars.forEach(car => {
        const row = document.createElement("tr");

        row.innerHTML = `
            <td>${car.LicensePlate}</td>
            <td>${car.Brand}</td>
            <td>${car.Model}</td>
            <td>
                <button onclick="editCar(${car.CarID}, '${car.LicensePlate}', '${car.Brand}', '${car.Model}')">
                    Módosít
                </button>
            </td>
        `;

        tableBody.appendChild(row);
    });
}


// ======================
// Módosítás gomb
// ======================
function editCar(id, license, brand, model) {
    form.style.display = "block";

    carIdInput.value = id;
    licenseInput.value = license;
    brandInput.value = brand;
    modelInput.value = model;
}


// ======================
// Mentés
// ======================
form.addEventListener("submit", async (e) => {
    e.preventDefault();

    const id = carIdInput.value;

    const updatedCar = {
        LicensePlate: licenseInput.value,
        Brand: brandInput.value,
        Model: modelInput.value
    };

    const response = await fetch(`/api/cars/${id}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(updatedCar)
    });

    const result = await response.json();
    alert(result.message);

    // Táblázat frissítése
    loadCars();

    // BONUS: űrlap kiürítése és elrejtése
    form.reset();
    form.style.display = "none";
});


// Oldal betöltésekor
loadCars();
