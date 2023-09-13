import Database from './database'; 
import Student from './student';
import './main.css';

const addStudentButton: HTMLButtonElement | null = document.getElementById('add-student-btn') as HTMLButtonElement;
const modal: HTMLElement | null = document.getElementById('myModal');
const closeModalBtn: HTMLButtonElement | null = document.getElementById('closeModalBtn') as HTMLButtonElement;
const modalCancelButton: HTMLButtonElement | null = document.getElementById('cancelStudentBtn') as HTMLButtonElement;
const modalSaveButton: HTMLButtonElement | null = document.getElementById('saveStudentBtn') as HTMLButtonElement;
const deleteModal: HTMLElement | null = document.getElementById('deleteModal');
const confirmDeleteBtn: HTMLButtonElement | null = document.getElementById('confirmDeleteBtn') as HTMLButtonElement;
const cancelDeleteBtn: HTMLButtonElement | null = document.getElementById('cancelDeleteBtn') as HTMLButtonElement;

const database = new Database('studentDb');

addStudentButton?.addEventListener('click', () => 
{
    if (modal) 
    modal.style.display = 'flex';
}); 

closeModalBtn?.addEventListener('click', () => 
{
    if(modal)
    modal.style.display = 'none';
});

modalCancelButton?.addEventListener('click', () => 
{
    if(modal)
    modal.style.display = 'none';
});

modalSaveButton?.addEventListener('click', () => 
{
    const name: string = (document.getElementById('name') as HTMLInputElement).value;
    const age: number = parseInt((document.getElementById('age') as HTMLInputElement).value);
    const studentClass: string = (document.getElementById('class') as HTMLInputElement).value;
    const address: string = (document.getElementById('address') as HTMLInputElement).value;
  
    const student = new Student(name, age, studentClass, address);
  
    addStudentToDB(student);
    fetchStudentsFromDB();
  
    (document.getElementById('studentForm') as HTMLFormElement).reset();
    if (modal)
    modal.style.display = 'none';
});

function addStudentToDB(student: Student) {
    const request = database.openDatabase();
  
    request?.addEventListener('success', function () {
      const db = request?.result;
      if (db) {
        const transaction = db.transaction('students', 'readwrite');
        const store = transaction.objectStore('students');
        const id = generateUniqueId();
  
        student.id = id; 
  
        store.put(student);
  
        transaction.oncomplete = function () {
          db.close();
          console.log('Student added to the database: ' + id);
        };
      } else {
        console.error('Failed to open the database.');
      }
    });
  
    request?.addEventListener('error', function (event) {
      console.error('An error occurred while opening the database:', event);
    });
  }
  
  
function generateUniqueId(): number 
{
    return Date.now();
}

function renderStudentsTable(students: Student[]) 
{
    const tableBody = document.getElementById('studentTableBody');
    if (tableBody) {
      tableBody.innerHTML = '';
  
      students.forEach((student) => {
        const row = document.createElement('tr');
  
        const nameCell = document.createElement('td');
        nameCell.textContent = student.name;
  
        const ageCell = document.createElement('td');
        ageCell.textContent = student.age.toString();
  
        const classCell = document.createElement('td');
        classCell.textContent = student.studentClass;
  
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
  
        if (tableBody) {
          tableBody.appendChild(row);
        }
      });
    }
}

function showDeleteModal(studentId: number) 
{
    if (deleteModal) 
    {
      deleteModal.style.display = 'block';
      confirmDeleteBtn?.addEventListener('click', () => {
        deleteStudent(studentId);
        if (deleteModal) {
          deleteModal.style.display = 'none';
        }
      });
  
      cancelDeleteBtn?.addEventListener('click', () => {
        if (deleteModal) {
          deleteModal.style.display = 'none';
        }
      });
    }
  }

  function deleteStudent(studentId: number) 
  {
    const request = database.openDatabase();
  
    request?.addEventListener('success', function () 
    {
      const db = request?.result;
      if (db) 
      {
        const transaction = db.transaction('students', 'readwrite');
        const store = transaction.objectStore('students');
  
        const deleteRequest = store.delete(studentId);
  
        deleteRequest.onsuccess = function () {
          console.log(`Student with ID ${studentId} deleted from the database`);
          fetchStudentsFromDB();
        };
  
        deleteRequest.onerror = function (event) {
          console.error(
            `Error deleting student with ID ${studentId}:`,
            (event.target as IDBRequest).error
          );
        };
  
        transaction.oncomplete = function () {
          db.close();
        };
      } else {
        console.error('Failed to open the database.');
      }
    });
  
    request?.addEventListener('error', function (event) {
      console.error('An error occurred while opening the database:', event);
    });
  }
  

  function fetchStudentsFromDB() {
    const request = database.openDatabase();
  
    request?.addEventListener('success', function () {
      const db = request?.result;
      if (db) {
        const transaction = db.transaction('students', 'readonly');
        const store = transaction.objectStore('students');
  
        const students: Student[] = [];
  
        store.openCursor().onsuccess = function (event) {
          const cursor = (event.target as IDBRequest<IDBCursorWithValue>)
            .result;
          if (cursor) {
            students.push(cursor.value);
            cursor.continue();
          } else {
            renderStudentsTable(students);
            db.close();
          }
        };
      } else {
        console.error('Failed to open the database.');
      }
    });
  
    request?.addEventListener('error', function (event) {
      console.error('An error occurred while opening the database:', event);
    });
  }

  fetchStudentsFromDB();