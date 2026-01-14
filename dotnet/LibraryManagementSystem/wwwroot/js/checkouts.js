console.log("JS FILE LOADED");

let isMemberSearch = false;
let isBookSearch = false;

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

    document.getElementById("checkoutBtn").addEventListener("click", createCheckout);
});

let members = [];
let books = [];

function loadMembers() {
    fetch('/Checkouts/GetMembers')
        .then(res => res.json())
        .then(data => {
            members = data;
            renderTable();
            updateMessages();
        });
}

function loadBooks() {
    fetch('/Checkouts/GetBooks')
        .then(res => res.json())
        .then(data => {
            books = data;
            renderTable();
            updateMessages();
        });
}

function searchMembers(query) {
        isMemberSearch = true;
    fetch(`/Checkouts/SearchMembers?search=${encodeURIComponent(query)}`)
        .then(res => res.json())
        .then(data => {
            members = data;
            renderTable();
            checkEnableCheckout();
        });
}

function searchBooks(query) {
        isBookSearch = true;
    fetch(`/Checkouts/SearchBooks?search=${encodeURIComponent(query)}`)
        .then(res => res.json())
        .then(data => {
            books = data;
            renderTable();
            checkEnableCheckout();
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

function checkEnableCheckout() {
    console.log("Members:", members.length);
    console.log("Books:", books.length);

    const btn = document.getElementById("checkoutBtn");

    if (!btn) {
        console.error("checkoutBtn not found in DOM");
        return;
    }

    if (members.length === 1 && books.length === 1) {
        btn.disabled = false;
        console.log("Checkout ENABLED");
    } else {
        btn.disabled = true;
        console.log("Checkout DISABLED");
    }
}

function createCheckout() {
    if (members.length !== 1 || books.length !== 1) return;

    const memberId = members[0].id;
    const bookId = books[0].id;

    fetch('/Checkouts/CreateCheckout', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        body: `memberId=${memberId}&bookId=${bookId}`
    })
    .then(res => res.json())
    .then(data => {
        if (data.success) {
            alert("Checkout successful!");
            members = [];
            books = [];
            renderTable();
            document.getElementById("checkoutBtn").disabled = true;
        }
    });
}


function updateMessages() {
    const memberMsg = document.getElementById("memberMsg");
    const bookMsg = document.getElementById("bookMsg");

    // Members
    if (members.length === 0) {
        memberMsg.textContent = isMemberSearch
            ? "No member found matching the search criteria"
            : "No members available currently";
    } else {
        memberMsg.textContent = "";
    }

    // Books
    if (books.length === 0) {
        bookMsg.textContent = isBookSearch
            ? "No book found matching the search criteria"
            : "No books available currently";
    } else {
        bookMsg.textContent = "";
    }
}
