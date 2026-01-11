document.addEventListener("DOMContentLoaded", function () {
    loadMembers();
    loadBooks();

    document.getElementById("findMember").addEventListener("submit", function (e) {
        e.preventDefault();
        const query = this.search.value;
        searchMembers(query);
    });

    document.getElementById("findBook").addEventListener("submit", function (e) {
        e.preventDefault();
        const query = this.search.value;
        searchBooks(query);
    });
});

let members = [];
let books = [];

function loadMembers() {
    fetch('/Checkouts/GetMembers')
        .then(res => res.json())
        .then(data => {
            members = data;
            renderTable();
        });
}

function loadBooks() {
    fetch('/Checkouts/GetBooks')
        .then(res => res.json())
        .then(data => {
            books = data;
            renderTable();
        });
}

function searchMembers(query) {
    fetch(`/Checkouts/SearchMembers?search=${encodeURIComponent(query)}`)
        .then(res => res.json())
        .then(data => {
            members = data;
            renderTable();
        });
}

function searchBooks(query) {
    fetch(`/Checkouts/SearchBooks?search=${encodeURIComponent(query)}`)
        .then(res => res.json())
        .then(data => {
            books = data;
            renderTable();
        });
}

function renderTable() {
    const tbody = document.getElementById("checkoutTableBody");
    tbody.innerHTML = "";

    const maxLength = Math.max(members.length, books.length);

    for (let i = 0; i < maxLength; i++) {
        const memberName = members[i] ? members[i].name : "";
        const bookName = books[i] ? books[i].name : "";

        const row = `
            <tr>
                <td>${memberName}</td>
                <td>${bookName}</td>
            </tr>
        `;

        tbody.innerHTML += row;
    }
}
