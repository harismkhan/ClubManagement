const url = 'https://localhost:7011/api/Player';
class PlayerService {
    static async getAll() {
        return await fetch(url)
            .then(response => response.json())
            .catch(error => console.error('Unable to get Players.', error));
    }

    static async getById(id) {
        return await fetch(`${url}/${id}`)
            .then(response => response.json())
            .catch(error => console.error('Unable to get Player.', error));
    }

    static async addItem(player) {
        await fetch(url, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(player)
        })
        .catch(error => console.error('Unable to add Player.', error));
    }

    static async deleteItem(id) {
        await fetch(`${url}/${id}`, {
            method: 'DELETE',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(id)
        })
            .then(() => getAll())
            .catch(error => console.error('Unable to delete Player.', error));
    }

    static async updateItem(player) {
        await fetch(url, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(player)
        })
            .catch(error => console.error('Unable to update Player.', error));
    }
}

