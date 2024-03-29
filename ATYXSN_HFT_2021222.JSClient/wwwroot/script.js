﻿let bookmakers = [];
let connection = null;
let noncrudarray = [];

let bookmakerIdToUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:48810/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BookmakerCreated", (user, message) => {
        getdata();
    });

    connection.on("BookmakerDeleted", (user, message) => {
        getdata();
    });

    connection.on("BookmakerUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();

}


async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};


async function getdata() {
    await fetch('http://localhost:48810/bookmaker')
        .then(x => x.json())
        .then(y => {
            bookmakers = y;
            display();
        });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    bookmakers.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.bookmakerId + "</td><td>"
        + t.bookmakerName + "</td><td>" +
        `<button type="button" onclick="remove(${t.bookmakerId})">Delete</button>` + 
        `<button type="button" onclick="showupdate(${t.bookmakerId})">Update</button>`
            + "</td></tr>";
    });
}

function showupdate(id) {
    document.getElementById('bookmakernametoupdate').value = bookmakers.find(t => t['bookmakerId'] == id)['bookmakerName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    bookmakerIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('bookmakernametoupdate').value;
    fetch('http://localhost:48810/bookmaker', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                bookmakerName: name,
                bookmakerId: bookmakerIdToUpdate
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function create() {
    let name = document.getElementById('bookmakername').value;
    fetch('http://localhost:48810/bookmaker', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json',},
        body: JSON.stringify(
            {
                bookmakerName: name
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function remove (id) {
    fetch('http://localhost:48810/bookmaker/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function noncrud() {
    fetch('http://localhost:48810/MatchStat/AverageOddsByBookmaker')
        .then(x => x.json())
        .then(y => {
            noncrudarray = y;
            var table = document.getElementById("table");
            table.innerHTML = "";
            table.style.width = "100%";
            var tr = document.createElement("tr");
            var th1 = document.createElement("th");
            var th2 = document.createElement("th");
            th1.innerHTML = "Name";
            th2.innerHTML = "Odds";
            tr.appendChild(th1);
            tr.appendChild(th2);
            table.appendChild(tr);
            for (var i = 0; i < y.length; i++) {
                var tr = document.createElement("tr");
                var td1 = document.createElement("td");
                var td2 = document.createElement("td");
                td1.innerHTML = y[i].name;
                td2.innerHTML = y[i].odds;
                tr.appendChild(td1);
                tr.appendChild(td2);
                table.appendChild(tr);
            }
        });
}