const addStudentButton = document.getElementById('add-student-btn');
const modal = document.getElementById('myModal');
const closeModalBtn = document.getElementById('closeModalBtn');
const modalCancelButton = document.getElementById('cancelStudentBtn');
const modalSaveButton = document.getElementById('saveStudentBtn');




addStudentButton.addEventListener('click', ()=>
{
    modal.style.display = 'flex';
})

closeModalBtn.addEventListener('click', () => {
    modal.style.display = 'none';
});

modalCancelButton.addEventListener('click', () => {
    modal.style.display = 'none';
});

modalSaveButton.addEventListener('click', ()=>
{
    const name = document.getElementById('name').value;
    const age = parseInt(document.getElementById('age').value);
    const studentClass = document.getElementById('class').value;
    const address = document.getElementById('address').value;

    const student = 
    {
        name,
        age,
        class: studentClass,
        address
    };

    addStudentToDB(student);
    document.getElementById('studentForm').reset();
    document.getElementById('myModal').style.display = 'none';
})

function addStudentToDB(student) 
{
    const indexedDB =
        window.indexedDB ||
        window.mozIndexedDB ||
        window.webkitIndexedDB ||
        window.msIndexedDB ||
        window.shimIndexedDB;

    if (!indexedDB) {
        console.log("IndexedDB could not be found in this browser.");
        return;
    }

    const request = indexedDB.open("studentDb", 1);

    request.onerror = function (event) {
        console.error("An error occurred with IndexedDB");
        console.error(event);
    };

    request.onupgradeneeded = function () {
        const db = request.result;
        db.createObjectStore("students", { keyPath: "id" });
    };

    request.onsuccess = function () {
        const db = request.result;
        const transaction = db.transaction("students", "readwrite");
        const store = transaction.objectStore("students");
        const id = generateUniqueId();

        store.put({ id, ...student });

        transaction.oncomplete = function () {
            db.close();
            console.log("Student added to the database");
        };
    };
}

function generateUniqueId() 
{
    return Date.now();
}