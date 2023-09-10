var quill = new Quill("#page-text", {theme:"snow"});

const addTaskButton = document.getElementById('add-task-btn');
const pageModal = document.getElementById('page-modal');
const saveButton = document.getElementById('save-page-btn');
const pageTitleInput = document.getElementById('page-title');
const pageText= document.getElementById('page-text');
const taskList = document.getElementById('task-list');

/*----------------------------------------------------------------------------------*/

addTaskButton.addEventListener('click', ()=>
{
    pageModal.style.display = 'block';
});

saveButton.addEventListener('click', (e)=>
{   
    e.preventDefault();
    const title = pageTitleInput.value;
    const text = pageText.value;
 
    const task = 
    {
        title : title,
        text : text
    };

    let existingTasks = JSON.parse(localStorage.getItem('tasks')) || [];
    existingTasks.push(task);   
    localStorage.setItem('tasks', JSON.stringify(existingTasks));

    pageModal.style.display = 'none';
    pageTitleInput.value = '';
    quill.root.innerHTML = '';

    renderStoredTasks();
});

function renderStoredTasks() 
{
    const taskList = document.getElementById('task-list');
    taskList.innerHTML = '';

    const existingTasks = JSON.parse(localStorage.getItem('tasks')) || [];
    existingTasks.forEach((task, index) => 
    {
        const listItem = document.createElement('li');
        listItem.classList.add('new-task');
        listItem.textContent = task.title;

        listItem.addEventListener('click', () => 
        {
            renderTaskDetails(task);
        });

        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.style.background = '#eb7b7b';
        
        listItem.appendChild(deleteButton);
        taskList.appendChild(listItem);
    });
}

function renderTaskDetails(task)
{
    const taskDetails = document.getElementById('task-details');
    taskDetails.innerHTML = '';

    const title = document.createElement('h1');
    title.textContent = task.title;

    const textBody = document.createElement('p');
    textBody.textContent = task.text;
    textBody.style.marginTop = '30px'
    textBody.style.marginBottom = '20px';

    const editButton = document.createElement('button');
    editButton.textContent = 'Edit';

    const subPageButton = document.createElement('button');
    subPageButton.textContent = 'Add Subtask';
    subPageButton.style.width = '40px'

    
    taskDetails.appendChild(title);
    taskDetails.appendChild(textBody);
    taskDetails.appendChild(editButton);
    taskDetails.appendChild(deleteButton);
    taskDetails.appendChild(subPageButton);

}

window.addEventListener('load', () => 
{
    renderStoredTasks();
});









 
























/*
    function createTask() {
        pageModal.style.display = 'block';
        savePageBtn.textContent = 'Save';
        cancelEditBtn.style.display = 'none';
        selectedIndex = null;
        pageTitleInput.value = '';
        pageTextInput.value = '';
    }

document.addEventListener('DOMContentLoaded', () => {
    const pageList = document.getElementById('page-list');
    const pageContent = document.getElementById('page-content');
    const createPageBtn = document.getElementById('create-page-btn');
    const pageModal = document.getElementById('page-modal');
    const pageTitleInput = document.getElementById('page-title');
    const pageTextInput = document.getElementById('page-text');
    const savePageBtn = document.getElementById('save-page-btn');
    const editPageBtn = document.getElementById('edit-page-btn');
    const cancelEditBtn = document.getElementById('cancel-edit-btn');

    let tasks = JSON.parse(localStorage.getItem('tasks')) || [];
    let selectedIndex = null;

    function saveTasksToLocalStorage() {
        localStorage.setItem('tasks', JSON.stringify(tasks));
    }

    function renderTasks() {
        pageList.innerHTML = '';
        tasks.forEach((task, index) => {
            const listItem = document.createElement('li');
            listItem.textContent = task.title;


            listItem.addEventListener('click', () => {
                renderTaskContent(index);
                selectedIndex = index;
                editPageBtn.style.display = 'block';
            });


            const deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            deleteBtn.classList.add('delete-button'); 
            deleteBtn.addEventListener('click', (event) => {
                deleteTask(index);
            });

            const editBtn = document.createElement('button');
            editBtn.textContent = 'Edit';
            editBtn.addEventListener('click', () => {
                editTask(index);
            });

            listItem.appendChild(deleteBtn);
            listItem.appendChild(editBtn); 
            pageList.appendChild(listItem);
        });
    }

    function renderTaskContent(index) {
        pageContent.innerHTML = '';
        const task = tasks[index];

        const titleElement = document.createElement('h2');
        titleElement.textContent = task.title;

        const textElement = document.createElement('p');
        textElement.textContent = task.text;

        pageContent.appendChild(titleElement);
        pageContent.appendChild(textElement);
    }

    

    function saveTask() {
        const title = pageTitleInput.value;
        const text = pageTextInput.value;

        if (selectedIndex !== null) {
            tasks[selectedIndex].title = title;
            tasks[selectedIndex].text = text;
            savePageBtn.textContent = 'Save';
            cancelEditBtn.style.display = 'none';
            selectedIndex = null;
        } else {
            tasks.push({ title, text });
        }

        saveTasksToLocalStorage();
        renderTasks();
        renderTaskContent(tasks.length - 1);
        pageModal.style.display = 'none';
    }

    function deleteTask(index) {
        tasks.splice(index, 1);
        saveTasksToLocalStorage();
        renderTasks();
        pageContent.innerHTML = '';
    }

    function editTask(index) {
        pageModal.style.display = 'block';
        const task = tasks[index];
        pageTitleInput.value = task.title;
        pageTextInput.value = task.text;
        savePageBtn.textContent = 'Update';
        cancelEditBtn.style.display = 'block';
    }

    cancelEditBtn.addEventListener('click', () => {
        pageModal.style.display = 'none';
        selectedIndex = null;
        pageTitleInput.value = '';
        pageTextInput.value = '';
        savePageBtn.textContent = 'Save';
        cancelEditBtn.style.display = 'none';
    });

    createPageBtn.addEventListener('click', createTask);
    savePageBtn.addEventListener('click', saveTask);
    editPageBtn.addEventListener('click', () => {
        if (selectedIndex !== null) {
            pageModal.style.display = 'block';
            pageTitleInput.value = tasks[selectedIndex].title;
            pageTextInput.value = tasks[selectedIndex].text;
            savePageBtn.textContent = 'Update';
            cancelEditBtn.style.display = 'block';
        }
    });     
    renderTasks();
});

*/