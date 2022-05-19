const playersKey = ("clubmanagement.players")

async function onInit() {
    let playersJson = await PlayerService.getItems() ?? "[]";
    let players = PlayerParser.multipleFromJson(playersJson);

    fillTable(players)

}

function fillTable(players) {
    let tableBody = document.getElementById("playerTableBody");
tableBody.innerHTML =``;

    for (var i = 0; i < players.length; i++) {
        tableBody.innerHTML += `
        <tr class="row" >
            <td class="FirstName" onClick="onRowClick(${players[i].id})">${players[i].firstName}</td>
            <td class="LastName" onClick="onRowClick(${players[i].id})">${players[i].lastName}</td>
            <td class="BirthDate" onClick="onRowClick(${players[i].id})">${players[i].birthDate}</td>
            <td class="Street" onClick="onRowClick(${players[i].id})">${players[i].street}</td>
            <td class="City" onClick="onRowClick(${players[i].id})">${players[i].city}</td>
            <td class="Zip" onClick="onRowClick(${players[i].id})">${players[i].zip}</td>
            <td class="Height" onClick="onRowClick(${players[i].id})">${players[i].height}</td>
            <td class="Weight" onClick="onRowClick(${players[i].id})">${players[i].weight}</td>
            <td class="PlayerNumber" onClick="onRowClick(${players[i].id})">${players[i].playerNumber}</td>
            <td class="deleteItem" onClick="onDelete(${players[i].id})"><i class="fa-solid fa-user-xmark"></i></i></td>
          </a>
        </tr>`
            ;
    }
}


function onRowClick(id) {
    window.location.href = `./playerEdit.html?id=${id}`;
}
function onDelete(id) {
    let playersJson = localStorage.getItem(playersKey) ?? "[]";
    let players = PlayerParser.multipleFromJson(playersJson);
    let index = players.findIndex(p => p.id == id);

    if (index === -1) {
        return;
    }

    players.splice(index, 1);

    localStorage.setItem(playersKey, JSON.stringify(players));

    window.location.href = "./players.html";
}

setTimeout(async() => {
    await onInit();
}, 1);

document.addEventListener('keydown', function (event) {
    if (event.key === "Escape") {
        window.location.href = "../index.html";
    }
});

