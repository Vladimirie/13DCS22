function Mentes() 
{
    let nev = document.getElementById("nevInput").value;
    let ido = document.getElementById("idoPont").value;
    let sport = document.getElementById("sport").value;
    let berlet = document.getElementById("berletInput").value;
    if (!isNaN(berlet) && berlet != '' && nev != '') //megnézzük hogy a bérlet tényleg csak számokat tartalmaz és nem üresek a mezők
    {
        let adat = {nev, ido, sport, berlet}; //beolvassuk az mezőkben lévő infót és egy objektumot csináunk belőle
        let storage = JSON.parse(localStorage.getItem("programok") || "[]"); //megszerezzük a local storageben a "programok" nevű tömböt, ha nincs akkor csináunk egyet! (ez a || "[]")

        storage.push(adat); //bedobjuk neki az új adatot
        localStorage.setItem("programok", JSON.stringify(storage)); //eltároljuk az új verzióját a tömbnek
    
        Reset();
        alert("Adatok tárolva!");  
    }
    else {
        alert("Probléma adódott a mezőben! Lehet az: nincs adat a név vagy/és a bérlet mezőben! Vagy nem csak számokat írt be a bérlet mezőbe!")
    }
}

function Megjelenit() 
{
    let storage = JSON.parse(localStorage.getItem("programok") || "[]"); //megkapjuk a "programok" tömböt, ha nincs, csinálunk

    //itt egy full új táblázatot írunk meg ami tartalmazza a "programok" tömb elemeit!
    let html = "<table> <tr> <th>Név</th> <th>Időpont</th> <th>Sport</th> <th>Bérlet</th></tr>";
    storage.forEach(element => {
        html += "<tr> <td>"+ element.nev +"</td> <td>" + element.ido +"</td> <td>" + element.sport +"</td> <td>"+ + element.berlet +"</td></tr>";
    });
    html += "</table>";

    //kiírjuk a táblázatot
    document.getElementById("adatok").innerHTML = html;
}

function Reset() 
{
    document.getElementById("nevInput").value = '';
    document.getElementById("idoPont").value = '9:00-10:00';
    document.getElementById("sport").value = 'Aerobik';
    document.getElementById("berletInput").value = '';
}

//ne foglalkozz ezzel
function AlreadyInCheck(adat, adatArray) 
{
    let returnValue = true;
    let strikes = 0;

    adatArray.forEach(element => 
    { 
        if (element.nev == adat.nev) 
        {
            strikes++;
            console.log(strikes); 
        }
        else if(element.ido == adat.ido)
        {
            strikes++;
            console.log(strikes);    
        }
        else if(element.sport == adat.sport)
        {
            strikes++;
            console.log(strikes);
        }
        else if(element.berlet == adat.berlet)
        {
            strikes++;
            console.log(strikes);
        }
    }); 

    if (strikes == 4) {
        returnValue = false;
    }

    return returnValue;
}