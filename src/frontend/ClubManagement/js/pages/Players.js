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
        <tr class="row" >
            <td onClick="onRowClick('${players[i].id}');" class="firstName">${players[i].firstName}</td>
            <td onClick="onRowClick('${players[i].id}');" class="lastName">${players[i].lastName}</td>
            <td onClick="onRowClick('${players[i].id}');" class="birthDate">${players[i].birthDate}</td>
            <td onClick="onRowClick('${players[i].id}');" class="street">${players[i].street}</td>
            <td onClick="onRowClick('${players[i].id}');" class="city">${players[i].city}</td>
            <td onClick="onRowClick('${players[i].id}');" class="zip">${players[i].zip}</td>
            <td onClick="onRowClick('${players[i].id}');" class="height">${players[i].height}</td>
            <td onClick="onRowClick('${players[i].id}');" class="weight">${players[i].weight}</td>
            <td onClick="onRowClick('${players[i].id}');" class="playerNumber">${players[i].playerNumber}</td>
            <td class="deleteItem">
                <button onClick="onDelete('${players[i].id}')" class="fa-solid fa-xmark deleteButton" title ="Delete player"></button>
            </td>
          </a>
        </tr>`;
    }
}

function onRowClick(id) {
    window.location.href = `./PlayerEdit.html?id=${id}`;
}

async function onDelete(id) {
    await PlayerService.deleteItem(id);
    await onInit();
}

setTimeout(async() => {
    await onInit();
}, 1);

document.addEventListener('keydown', function (event) {
    if (event.key === "Escape") {
        window.location.href = "../index.html";
    }
});