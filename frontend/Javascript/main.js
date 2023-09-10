var quill = new Quill("#page-text", { theme: "snow" });

const addTaskButton = document.getElementById('add-task-btn');
const pageModal = document.getElementById('page-modal');
const saveButton = document.getElementById('save-page-btn');
const pageTitleInput = document.getElementById('page-title');
const pageText = document.getElementById('page-text');
const taskList = document.getElementById('task-list');
const rightPane = document.getElementById('right-pane');
const taskDetails = document.getElementById('task-details');
const subtaskList = document.getElementById('subtask-list');
let selectedTask = null;

addTaskButton.addEventListener('click', () => {
    taskDetails.innerHTML = '';
    pageModal.style.display = 'block';
    const taskDetailsTitle = document.getElementById('task-details-title');
    taskDetailsTitle.textContent = "Add New Task";
});

saveButton.addEventListener('click', (e) => {
    e.preventDefault();
    const title = pageTitleInput.value;
    const text = pageText.value;

    const task = {
        title: title,
        text: text,
        subTask: [],
        favorite: false,
    };

    let existingTasks = JSON.parse(localStorage.getItem('tasks')) || [];
    existingTasks.push(task);
    localStorage.setItem('tasks', JSON.stringify(existingTasks));

    pageModal.style.display = 'none';
    pageTitleInput.value = '';
    quill.root.innerHTML = '';
    renderStoredTasks();
});

function renderStoredTasks() {
    const existingTasks = JSON.parse(localStorage.getItem('tasks')) || [];

    existingTasks.sort((a, b) => (b.favorite - a.favorite));

    taskList.innerHTML = '';

    existingTasks.forEach((task, index) => {
        const listItem = document.createElement('li');
        listItem.classList.add('new-task');
        listItem.textContent = task.title;

        listItem.addEventListener('click', () => {
            renderTaskDetails(task);
        });

        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.classList.add('delete-button');


        deleteButton.addEventListener('click', () => {
            deleteTask(task);
        });

        const favoriteButton = document.createElement('button');
        favoriteButton.textContent = task.favorite ? 'Unfavorite' : 'Favorite';
        favoriteButton.classList.add('favorite-button');

        favoriteButton.addEventListener('click', () => {
            toggleFavorite(task);
        });

        listItem.appendChild(favoriteButton);
        listItem.appendChild(deleteButton);

        taskList.appendChild(listItem);
    });
}

function toggleFavorite(task) {
    task.favorite = !task.favorite; 

    let existingTasks = JSON.parse(localStorage.getItem('tasks')) || [];
    const taskIndex = existingTasks.findIndex(t => t.title === task.title);
    existingTasks[taskIndex] = task;
    localStorage.setItem('tasks', JSON.stringify(existingTasks));

    renderStoredTasks();
}

function renderTaskDetails(task) {
    const taskDetails = document.getElementById('task-details');
    taskDetails.innerHTML = '';

    const title = document.createElement('h1');
    title.textContent = task.title;

    const textBody = document.createElement('p');
    textBody.textContent = task.text;
    textBody.style.marginTop = '30px';
    textBody.style.marginBottom = '20px';

    const editButton = document.createElement('button');
    editButton.textContent = 'Edit';

    const addSubTaskButton = document.createElement('button');
    addSubTaskButton.textContent = 'Add Subtask';

    addSubTaskButton.addEventListener('click', () => {
        selectedTask = task;
        addSubTask();
    });

    if (quill) {
        pageModal.style.display = 'none';
    }

    const subtaskList = document.getElementById('subtask-list');
    subtaskList.innerHTML = '';

    if (task.subTask && task.subTask.length > 0) {
        task.subTask.forEach((subtask) => {
            const subtaskItem = document.createElement('li');
            subtaskItem.textContent = subtask.title;

            const deleteButton = document.createElement('button');
            deleteButton.textContent = 'Delete';
            deleteButton.classList.add('delete-button');

            deleteButton.addEventListener('click', () => {
                deleteSubTask(task, subtask);
            });

            subtaskItem.appendChild(deleteButton);
            subtaskList.appendChild(subtaskItem);
        });
    }

    taskDetails.appendChild(title);
    taskDetails.appendChild(textBody);
    taskDetails.appendChild(editButton);
    taskDetails.appendChild(addSubTaskButton);
}

function addSubTask() {
    if (selectedTask == null)
        return;

    const subTaskForm = document.getElementById('subtask-form');
    subTaskForm.style.display = 'block';

    taskDetails.innerHTML = '';

    const subtaskTitle = document.getElementById('subtask-title');
    const subtaskText = document.getElementById('subtask-text');
    const saveSubtaskButton = document.getElementById('save-subtask-btn');

    saveSubtaskButton.addEventListener('click', () => {
        const title = subtaskTitle.value;
        const text = subtaskText.value;

        const subTask = {
            title: title,
            text: text,
        }

        if (!selectedTask.subTask)
            selectedTask.subTask = [];

        selectedTask.subTask.push(subTask);

        let existingTasks = JSON.parse(localStorage.getItem('tasks')) || [];
        const taskIndex = existingTasks.findIndex(t => t.title === selectedTask.title);
        existingTasks[taskIndex] = selectedTask;
        localStorage.setItem('tasks', JSON.stringify(existingTasks));

        pageTitleInput.value = '';
        pageText.value = '';
        subTaskForm.style.display = 'none';
        renderTaskDetails(selectedTask);
    });
}

function deleteTask(task) {
    let existingTasks = JSON.parse(localStorage.getItem('tasks')) || [];
    existingTasks = existingTasks.filter(t => t.title !== task.title);
    localStorage.setItem('tasks', JSON.stringify(existingTasks));
    renderStoredTasks();
}

function deleteSubTask(task, subTask) {
    if (!task.subTask)
        return;

    const subTaskIndex = task.subTask.indexOf(subTask);
    if (subTaskIndex !== -1) {
        task.subTask.splice(subTaskIndex, 1);

        let existingTasks = JSON.parse(localStorage.getItem('tasks')) || [];
        const taskIndex = existingTasks.findIndex(t => t.title === task.title);
        existingTasks[taskIndex] = task;
        localStorage.setItem('tasks', JSON.stringify(existingTasks));

        renderTaskDetails(task);
    }
}

window.addEventListener('load', () => {
    renderStoredTasks();
});
