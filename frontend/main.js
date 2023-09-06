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

    function createTask() {
        pageModal.style.display = 'block';
        savePageBtn.textContent = 'Save';
        cancelEditBtn.style.display = 'none';
        selectedIndex = null;
        pageTitleInput.value = '';
        pageTextInput.value = '';
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


