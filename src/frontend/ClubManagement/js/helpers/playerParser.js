class PlayerParser {
    static singleFromJson(json) {
        var obj = JSON.parse(json);
        return new Player(obj.id, obj.firstName, obj.lastName, obj.birthDate, obj.street, obj.city, obj.zip, obj.height, obj.weight, obj.playerNumber, obj.clubId, obj.teamId);
    }
    static multipleFromJson(json) {
        var objs = JSON.parse(json);
        var players = [];
        for (var i = 0; i < objs.length; i++) {
            players.push(new Player(objs[i].id, objs[i].firstName, objs[i].lastName, objs[i].birthDate, objs[i].street, objs[i].city, objs[i].zip, objs[i].height,  objs[i].weight,  objs[i].playerNumber, objs[i].clubId, objs[i].teamId));
        }
        return players;
    }
}
