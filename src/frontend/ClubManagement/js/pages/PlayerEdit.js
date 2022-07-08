async function onInit() {
    let id = getIdFromParameters();
    if (id) {
        let player = await PlayerService.getById(id);
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
    let id = getIdFromParameters();

    let player = readPlayerFromForm(id); 
    
    if (id != null && id !== ""){
        PlayerService.updateItem(player);
    }
    else {
        PlayerService.addItem(player);
    }
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

async function onDelete() {
    let id = getIdFromParameters();

    await PlayerService.deleteItem(id);
}

setTimeout(async() => {
    await onInit();
}, 1);

document.addEventListener('keydown', function(event){
    if(event.key === "Escape"){
        window.location.href = "./Players.html";
    }
});
