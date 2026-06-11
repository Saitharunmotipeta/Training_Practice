// ===================================================
// Hospital Bed Availability Dashboard
// Demonstrates:
// - Arrays
// - Objects
// - Loops
// - Conditions
// - DOM manipulation
// ===================================================


// -----------------------------
// BED DATA (Mock backend data)
// -----------------------------
let beds = [
    { bedNumber: 1, isOccupied: false },
    { bedNumber: 2, isOccupied: true },
    { bedNumber: 3, isOccupied: false },
    { bedNumber: 4, isOccupied: true },
    { bedNumber: 5, isOccupied: false },
    { bedNumber: 6, isOccupied: false },
    { bedNumber: 7, isOccupied: true },
    { bedNumber: 8, isOccupied: false },
    { bedNumber: 9, isOccupied: true },
    { bedNumber: 10, isOccupied: false },
    { bedNumber: 11, isOccupied: true },
    { bedNumber: 12, isOccupied: true }
];


// -----------------------------
// FUNCTION: Render beds on screen
// -----------------------------
function renderBeds() {

    let container = document.getElementById("bedContainer");

    let occupiedCount = 0;
    let availableCount = 0;
    let totalCount = beds.length;

    
    container.innerHTML = "";

    // Loop through all beds
    for (let i = 0; i < beds.length; i++) {

        let bed = beds[i];

     
        let bedDiv = document.createElement("div");

        
        bedDiv.classList.add("bed");

       
        if (bed.isOccupied) {

            occupiedCount++;

            bedDiv.classList.add("occupied");
            bedDiv.innerText =
                "Bed " + bed.bedNumber + "\nOccupied";

            

        } else {

            availableCount++;

            bedDiv.classList.add("available");
            bedDiv.innerText =
                "Bed " + bed.bedNumber + "\nAvailable";

            // Allow click only on available beds
            bedDiv.onclick = function () {
                bed.isOccupied = true;
                renderBeds();
            };
        }

        // Add bed to container
        container.appendChild(bedDiv);
    }

    // Display counts
    document.getElementById("totalBeds").innerText =
        "Total Beds: " + totalCount;

    document.getElementById("occupiedBeds").innerText =
        "Occupied Beds: " + occupiedCount;

    document.getElementById("availableBeds").innerText =
        "Available Beds: " + availableCount;
}


// -----------------------------
// INITIAL LOAD
// -----------------------------
renderBeds();