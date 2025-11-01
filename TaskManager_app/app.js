const API_URL = "http://localhost:5142/api/Task"; 

const taskList = document.getElementById("taskList");
const addTaskBtn = document.getElementById("addTaskBtn");
const taskTitleInput = document.getElementById("taskTitle");

async function loadTasks() {
  taskList.innerHTML = "<li>Loading...</li>";

  const res = await fetch(API_URL);
  const tasks = await res.json();

  if (tasks.length === 0) {
    taskList.innerHTML = "<li>No tasks yet.</li>";
    return;
  }

  taskList.innerHTML = "";
  tasks.forEach(t => {
    const li = document.createElement("li");
    li.innerHTML = `
      <span style="text-decoration: ${t.isCompleted ? 'line-through' : 'none'};">
        ${t.title}
      </span>
      <div class="buttons">
        <button class="complete" onclick="completeTask('${t.id}')">✅</button>
        <button class="delete" onclick="deleteTask('${t.id}')">🗑️</button>
      </div>
    `;
    taskList.appendChild(li);
  });
}

addTaskBtn.addEventListener("click", async () => {
  const title = taskTitleInput.value.trim();
  if (!title) return;

  await fetch(API_URL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(title)
  });

  taskTitleInput.value = "";
  loadTasks();
});

async function completeTask(id) {
  await fetch(`${API_URL}/${id}/complete`, { method: "PUT" });
  loadTasks();
}

async function deleteTask(id) {
  await fetch(`${API_URL}/${id}/delete`, { method: "DELETE" });
  loadTasks();
}

loadTasks();
