const addStudentButton = document.getElementById('add-student-btn');
const modal = document.getElementById('myModal');
const closeModalBtn = document.getElementById('closeModalBtn');
const modalCancelButton = document.getElementById('cancelStudentBtn');
const modalSaveButton = document.getElementById('saveStudentBtn');
const deleteModal = document.getElementById('deleteModal');
const confirmDeleteBtn = document.getElementById('confirmDeleteBtn');
const cancelDeleteBtn = document.getElementById('cancelDeleteBtn');

const indexedDB = window.indexedDB || window.mozIndexedDB || window.webkitIndexedDB || window.msIndexedDB || window.shimIndexedDB;
if (!indexedDB)
{
    console.log("IndexedDB could not be found in this browser.");
}

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
    const request = openDatabase();

    request.onsuccess = function () {
        const db = request.result;
        const transaction = db.transaction("students", "readwrite");
        const store = transaction.objectStore("students");
        const id = generateUniqueId();

        store.put({ id, ...student });

        transaction.oncomplete = function () {
            db.close();
            console.log( "Student added to the database :" + id);
        };
    };
    fetchStudentsFromDB();
}

function generateUniqueId() 
{
    return Date.now();
}

function renderStudentsTable(students) 
{
    const tableBody = document.getElementById('studentTableBody');
    tableBody.innerHTML = ''; 

    students.forEach((student) => {
        const row = document.createElement('tr');

        const nameCell = document.createElement('td');
        nameCell.textContent = student.name;

        const ageCell = document.createElement('td');
        ageCell.textContent = student.age;

        const classCell = document.createElement('td');
        classCell.textContent = student.class;

        const addressCell = document.createElement('td');
        addressCell.textContent = student.address;

        const deleteCell = document.createElement('td');
        const deleteButton = document.createElement('button');
        deleteButton.style.background = '#d9534f';
        deleteButton.style.color = '#fff';
        deleteButton.style.borderRadius = '5px';

        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', () => 
        {
            showDeleteModal(student.id);
        });

        deleteCell.appendChild(deleteButton);

        row.appendChild(nameCell);
        row.appendChild(ageCell);
        row.appendChild(classCell);
        row.appendChild(addressCell);
        row.appendChild(deleteCell);

        tableBody.appendChild(row);
    });
}

function showDeleteModal(studentId) 
{
    deleteModal.style.display = 'block';
    confirmDeleteBtn.onclick = function () 
    {
        deleteStudent(studentId);
        deleteModal.style.display = 'none';
    };

    cancelDeleteBtn.onclick = function () 
    {
        deleteModal.style.display = 'none';
    };
}

function deleteStudent(studentId) 
{
    const request = openDatabase();

    request.onsuccess = function () {
        const db = request.result;
        const transaction = db.transaction("students", "readwrite");
        const store = transaction.objectStore("students");

        const deleteRequest = store.delete(studentId);

        deleteRequest.onsuccess = function () {
            console.log(`Student with ID ${studentId} deleted from the database`);
            fetchStudentsFromDB(); 
        };

        deleteRequest.onerror = function (event) {
            console.error(`Error deleting student with ID ${studentId}:`, event.target.error);
        };

        transaction.oncomplete = function () {
            db.close();
        };
    };
}

function openDatabase() 
{
    if (!indexedDB) {
        console.log("IndexedDB not available.");
        return;
    }
    const request = indexedDB.open("studentDb", 1);

    request.onerror = function (event) {
        console.error("An error occurred with IndexedDB");
        console.error(event);
    };

    request.onupgradeneeded = function (event) {
        const db = event.target.result;

        if (!db.objectStoreNames.contains("students")) {
            db.createObjectStore("students", { keyPath: "id" });
        }
    };
    return request;
}

function fetchStudentsFromDB() 
{
    const request = openDatabase();

    request.onsuccess = function () {
        const db = request.result;
        const transaction = db.transaction("students", "readonly");
        const store = transaction.objectStore("students");

        const students = [];

        store.openCursor().onsuccess = function (event) {
            const cursor = event.target.result;
            if (cursor) 
            {
                students.push(cursor.value);
                cursor.continue();
            } 
            else 
            {
                renderStudentsTable(students);
                db.close();
            }
        };
    };
}

fetchStudentsFromDB();