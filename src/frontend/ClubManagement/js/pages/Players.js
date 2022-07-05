const playersKey = ("clubmanagement.players")

async function onInit() {
    let playersJson = await PlayerService.getAll() ?? "[]";
    let players = PlayerParser.multipleFromJson(playersJson);

    fillTable(players)

}

function fillTable(players) {
    let tableBody = document.getElementById("playerTableBody");
    tableBody.innerHTML = '';

    for (var i = 0; i < players.length; i++) {
        tableBody.innerHTML += `
        <tr class="row" onClick="onRowClick('${players[i].id}');">
            <td class="firstName">${players[i].firstName}</td>
            <td class="lastName">${players[i].lastName}</td>
            <td class="birthDate">${players[i].birthDate}</td>
            <td class="street">${players[i].street}</td>
            <td class="city">${players[i].city}</td>
            <td class="zip">${players[i].zip}</td>
            <td class="height">${players[i].height}</td>
            <td class="weight">${players[i].weight}</td>
            <td class="playerNumber">${players[i].playerNumber}</td>
            <td class="deleteItem">
                <i class="fa-solid fa-user-xmark" title ="Delete player"></i>
            </td>
          </a>
        </tr>`;
    }
}

function onRowClick(id) {
    window.location.href = `./PlayerEdit.html?id=${id}`;
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

