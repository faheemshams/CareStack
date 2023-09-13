"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
var database_1 = __importDefault(require("./database"));
var student_1 = __importDefault(require("./student"));
require("./main.css");
var addStudentButton = document.getElementById('add-student-btn');
var modal = document.getElementById('myModal');
var closeModalBtn = document.getElementById('closeModalBtn');
var modalCancelButton = document.getElementById('cancelStudentBtn');
var modalSaveButton = document.getElementById('saveStudentBtn');
var deleteModal = document.getElementById('deleteModal');
var confirmDeleteBtn = document.getElementById('confirmDeleteBtn');
var cancelDeleteBtn = document.getElementById('cancelDeleteBtn');
var database = new database_1.default('studentDb');
addStudentButton === null || addStudentButton === void 0 ? void 0 : addStudentButton.addEventListener('click', function () {
    if (modal)
        modal.style.display = 'flex';
});
closeModalBtn === null || closeModalBtn === void 0 ? void 0 : closeModalBtn.addEventListener('click', function () {
    if (modal)
        modal.style.display = 'none';
});
modalCancelButton === null || modalCancelButton === void 0 ? void 0 : modalCancelButton.addEventListener('click', function () {
    if (modal)
        modal.style.display = 'none';
});
modalSaveButton === null || modalSaveButton === void 0 ? void 0 : modalSaveButton.addEventListener('click', function () {
    var name = document.getElementById('name').value;
    var age = parseInt(document.getElementById('age').value);
    var studentClass = document.getElementById('class').value;
    var address = document.getElementById('address').value;
    var student = new student_1.default(name, age, studentClass, address);
    addStudentToDB(student);
    fetchStudentsFromDB();
    document.getElementById('studentForm').reset();
    if (modal)
        modal.style.display = 'none';
});
function addStudentToDB(student) {
    var request = database.openDatabase();
    request === null || request === void 0 ? void 0 : request.addEventListener('success', function () {
        var db = request === null || request === void 0 ? void 0 : request.result;
        if (db) {
            var transaction = db.transaction('students', 'readwrite');
            var store = transaction.objectStore('students');
            var id_1 = generateUniqueId();
            student.id = id_1;
            store.put(student);
            transaction.oncomplete = function () {
                db.close();
                console.log('Student added to the database: ' + id_1);
            };
        }
        else {
            console.error('Failed to open the database.');
        }
    });
    request === null || request === void 0 ? void 0 : request.addEventListener('error', function (event) {
        console.error('An error occurred while opening the database:', event);
    });
}
function generateUniqueId() {
    return Date.now();
}
function renderStudentsTable(students) {
    var tableBody = document.getElementById('studentTableBody');
    if (tableBody) {
        tableBody.innerHTML = '';
        students.forEach(function (student) {
            var row = document.createElement('tr');
            var nameCell = document.createElement('td');
            nameCell.textContent = student.name;
            var ageCell = document.createElement('td');
            ageCell.textContent = student.age.toString();
            var classCell = document.createElement('td');
            classCell.textContent = student.studentClass;
            var addressCell = document.createElement('td');
            addressCell.textContent = student.address;
            var deleteCell = document.createElement('td');
            var deleteButton = document.createElement('button');
            deleteButton.style.background = '#d9534f';
            deleteButton.style.color = '#fff';
            deleteButton.style.borderRadius = '5px';
            deleteButton.textContent = 'Delete';
            deleteButton.addEventListener('click', function () {
                showDeleteModal(student.id);
            });
            deleteCell.appendChild(deleteButton);
            row.appendChild(nameCell);
            row.appendChild(ageCell);
            row.appendChild(classCell);
            row.appendChild(addressCell);
            row.appendChild(deleteCell);
            if (tableBody) {
                tableBody.appendChild(row);
            }
        });
    }
}
function showDeleteModal(studentId) {
    if (deleteModal) {
        deleteModal.style.display = 'block';
        confirmDeleteBtn === null || confirmDeleteBtn === void 0 ? void 0 : confirmDeleteBtn.addEventListener('click', function () {
            deleteStudent(studentId);
            if (deleteModal) {
                deleteModal.style.display = 'none';
            }
        });
        cancelDeleteBtn === null || cancelDeleteBtn === void 0 ? void 0 : cancelDeleteBtn.addEventListener('click', function () {
            if (deleteModal) {
                deleteModal.style.display = 'none';
            }
        });
    }
}
function deleteStudent(studentId) {
    var request = database.openDatabase();
    request === null || request === void 0 ? void 0 : request.addEventListener('success', function () {
        var db = request === null || request === void 0 ? void 0 : request.result;
        if (db) {
            var transaction = db.transaction('students', 'readwrite');
            var store = transaction.objectStore('students');
            var deleteRequest = store.delete(studentId);
            deleteRequest.onsuccess = function () {
                console.log("Student with ID ".concat(studentId, " deleted from the database"));
                fetchStudentsFromDB();
            };
            deleteRequest.onerror = function (event) {
                console.error("Error deleting student with ID ".concat(studentId, ":"), event.target.error);
            };
            transaction.oncomplete = function () {
                db.close();
            };
        }
        else {
            console.error('Failed to open the database.');
        }
    });
    request === null || request === void 0 ? void 0 : request.addEventListener('error', function (event) {
        console.error('An error occurred while opening the database:', event);
    });
}
function fetchStudentsFromDB() {
    var request = database.openDatabase();
    request === null || request === void 0 ? void 0 : request.addEventListener('success', function () {
        var db = request === null || request === void 0 ? void 0 : request.result;
        if (db) {
            var transaction = db.transaction('students', 'readonly');
            var store = transaction.objectStore('students');
            var students_1 = [];
            store.openCursor().onsuccess = function (event) {
                var cursor = event.target
                    .result;
                if (cursor) {
                    students_1.push(cursor.value);
                    cursor.continue();
                }
                else {
                    renderStudentsTable(students_1);
                    db.close();
                }
            };
        }
        else {
            console.error('Failed to open the database.');
        }
    });
    request === null || request === void 0 ? void 0 : request.addEventListener('error', function (event) {
        console.error('An error occurred while opening the database:', event);
    });
}
fetchStudentsFromDB();
