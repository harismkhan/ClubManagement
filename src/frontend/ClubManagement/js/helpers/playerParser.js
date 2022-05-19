class PlayerParser {
    static multipleFromJson(objs) {
        var players = [];
        for (var i = 0; i < objs.length; i++) {
            players.push(new Player(objs[i].id, objs[i].firstName, objs[i].lastName, objs[i].birthDate, objs[i].street, objs[i].city, objs[i].zip, objs[i].height,  objs[i].weight,  objs[i].playerNumber, objs[i].clubId, objs[i].teamId));
        }
        return players;
    }
}
