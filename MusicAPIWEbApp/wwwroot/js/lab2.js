const uri = 'api/Performers';
let performers = [];

function getPerformers() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayPerformers(data))
        .catch(error => console.error("Виконавці не знайдені", error));
}

function addPerformer() {
    const addNameTextbox = document.getElementById('add-name');

    const performer = {
        name: addNameTextbox.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(performer)
    })
        .then(response => response.json())
        .then(() => {
            getPerformers();
            addNameTextBox.value = '';
        })
        .catch(error => console.error('Не вдалося додати виконавця', error));
    document.getElementById('add-name').value = '';
}

function deletePerformer(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getPerformers())
        .catch(error => console.error('Не вдалося видалити виконавця'), error);
}

function displayEditForm(id) {
    const performer = performers.find(performer => performer.id === id);

    document.getElementById('edit-id').value = performer.id;
    document.getElementById('edit-name').value = performer.name;
    document.getElementById('editForm').style.display = 'block';
}

function updatePerformer() {
    const performerId = document.getElementById('edit-id').value;
    const performer = {
        id: parseInt(performerId, 10),
        name: document.getElementById('edit-name').value.trim()
    }

    fetch(`${uri}/${performerId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(performer)
    })
        .then(() => getPerformers())
        .catch(error => console.error('Не вдалось оновити виконавця', error));

    closeInput();
    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = none;
}

function _displayPerformers(data) {
    const tBody = document.getElementById('performers');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(performer => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Редагувати';
        editButton.setAttribute('onclick', `displayEditForm(${performer.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Видалити';
        deleteButton.setAttribute('onclick', `deletePerformer(${performer.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(performer.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        td2.appendChild(editButton);

        let td3 = tr.insertCell(2);
        td3.appendChild(deleteButton);
    });

    performers = data;
}