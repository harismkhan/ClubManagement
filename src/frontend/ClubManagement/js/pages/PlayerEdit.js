function onInit() {
    let playersJson = localStorage.getItem("clubmanagement.players") ?? "[]";
    let players = PlayerParser.multipleFromJson(playersJson);
    let paramsString = window.location.search.substring(1);
    let searchParams = new URLSearchParams(paramsString);
    let id;
    let player;
    if (searchParams.has("id")) {
        id = searchParams.get("id");
        player = players.find(c => c.id == id);
        if (player) {
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
        else {
            alert("player not found")
        }
    }
}
function onSave() {
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
    let playersJson = localStorage.getItem("clubmanagement.players") ?? "[]";
    let players = PlayerParser.multipleFromJson(playersJson);
    let paramsString = window.location.search.substring(1);
    let searchParams = new URLSearchParams(paramsString);
    let id = searchParams.get("id");
    let index = -1;
    if (id) {
        index = players.findIndex(c => c.id == id);
    }
    if (index !== -1) {
        players[index].firstName = firstName;
        players[index].lastName = lastName;
        players[index].birthDate = birthDate;
        players[index].street = street;
        players[index].city = city;
        players[index].zip = zip;
        players[index].height = height;
        players[index].weight = weight;
        players[index].playerNumber = playerNumber;
        players[index].clubId = clubId;
        players[index].teamId = teamId;
    }
    else {
        let player = new Player(getNewId(players), firstName, lastName, birthDate, street, city, zip, height, weight, playerNumber, clubId, teamId);
        players.push(player);
    }
    localStorage.setItem("clubmanagement.players", JSON.stringify(players))
    window.location.href = "./players.html";

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
    console.log("Hallo");
    let playersJson = localStorage.getItem("clubmanagement.players") ?? "[]";
    let players = PlayerParser.multipleFromJson(playersJson);

    let paramsString = window.location.search.substring(1);
    let searchParams = new URLSearchParams(paramsString);
    if (!searchParams.has("id")) {
        return;
    }

    let id = searchParams.get("id");
    let index = players.findIndex(p => p.id == id);
    if (index === -1){
        return;
    }
        players.splice(index, 1);
    localStorage.setItem("clubmanagement.players", JSON.stringify(players));

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