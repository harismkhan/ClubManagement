const playersKey = "clubmanagement.players"


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
    document.getElementById("firstName").value = player.firstName;
    document.getElementById("lastName").value = player.lastName;
    document.getElementById("birthDate").value = player.birthDate;
    document.getElementById("street").value = player.street;
    document.getElementById("city").value = player.city;
    document.getElementById("zip").value = player.zip;
    document.getElementById("height").value = player.height;
    document.getElementById("weight").value = player.weight;
    document.getElementById("playerNumber").value = player.playerNumber;
    document.getElementById("clubId").value = player.clubId;
    document.getElementById("teamId").value = player.teamId;
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
    let firstName = document.getElementById("firstName").value;
    let lastName = document.getElementById("lastName").value;
    let birthDate = document.getElementById("birthDate").value;
    let street = document.getElementById("street").value;
    let city = document.getElementById("city").value;
    let zip = document.getElementById("zip").value;
    let height = document.getElementById("height").value;
    let weight = document.getElementById("weight").value;
    let playerNumber = document.getElementById("playerNumber").value;
    let clubId = document.getElementById("clubId").value;
    let teamId = document.getElementById("teamId").value;

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