const playersKey = ("clubmanagement.players")


function onInit() {
    let playersJson = localStorage.getItem(playersKey) ?? "[]";
    let players = PlayerParser.multipleFromJson(playersJson);

    let id = getIdFromParameters();
    let player;
    if (id) {
        player = players.find(c => c.id == id);
        if (player) {
            fillFormFromPlayer(player);
        }
        else {
            alert("player not found")
        }
    }
}

function fillFormFromPlayer(player) {
    document.getElementById("FirstName").value = player.firstName;
    document.getElementById("LastName").value = player.lastName;
    document.getElementById("BirthDate").value = player.birthDate;
    document.getElementById("Street").value = player.street;
    document.getElementById("City").value = player.city;
    document.getElementById("Zip").value = player.zip;
    document.getElementById("Height").value = player.height;
    document.getElementById("Weight").value = player.weight;
    document.getElementById("PlayerNumber").value = player.playerNumber;
    document.getElementById("ClubId").value = player.clubId;
    document.getElementById("TeamId").value = player.teamId;
}

function onSave() {
    let playersJson = localStorage.getItem(playersKey) ?? "[]";
    let players = PlayerParser.multipleFromJson(playersJson);

    let id = getIdFromParameters();

    let index = -1;
    if (id) {
        index = players.findIndex(c => c.id == id);
    }

    if (index !== -1) {
        let player = readPlayerFromForm(id);
        players[index] = player;
    }
    else {
        let player = readPlayerFromForm(getNewId(players));
        players.push(player);
    }

    localStorage.setItem(playersKey, JSON.stringify(players));
    window.location.href = "./players.html";
}

function getIdFromParameters() {
    let paramsString = window.location.search.substring(1);
    let searchParams = new URLSearchParams(paramsString);
    let id = searchParams.get("id");
    return id;
}

function readPlayerFromForm(id){
    let firstName = document.getElementById("FirstName").value;
    let lastName = document.getElementById("LastName").value;
    let birthDate = document.getElementById("BirthDate").value;
    let street = document.getElementById("Street").value;
    let city = document.getElementById("City").value;
    let zip = document.getElementById("Zip").value;
    let height = document.getElementById("Height").value;
    let weight = document.getElementById("Weight").value;
    let playerNumber = document.getElementById("PlayerNumber").value;
    let clubId = document.getElementById("ClubId").value;
    let teamId = document.getElementById("TeamId").value;

    return new Player(id, firstName, lastName, birthDate, street, city, zip, height, weight, playerNumber, clubId, teamId);
}

function getNewId(players) {
    let highestId = 0;
    for (var i = 0; i < players.length; i++) {
        if (players[i].id > highestId) {
            highestId = players[i].id;
        }
    }
    return highestId + 1;
}

function onDelete() {
    let playersJson = localStorage.getItem(playersKey) ?? "[]";
    let players = PlayerParser.multipleFromJson(playersJson);

    let id = getIdFromParameters();
    if (!!!id) {
        return;
    }

    let index = players.findIndex(p => p.id == id);
    if (index === -1){
        return;
    }
    players.splice(index, 1);
    localStorage.setItem(playersKey, JSON.stringify(players));

    window.location.href = "./Players.html";
}

setTimeout(() => {
    onInit();
}, 1);

document.addEventListener('keydown', function(event){
    if(event.key === "Escape"){
        window.location.href = "./Players.html";
    }
});

document.addEventListener('keydown', function (event) {
    if (event.key === "Enter") {
        onSave();
    }
});