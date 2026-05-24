

const openMenu = document.getElementById("openMenu");
const closeMenu = document.getElementById("closeMenu");
const sidebar = document.getElementById("sidebar");
const formProfessor = document.getElementById("formProfessor");
const listaProfessores = document.getElementById("listaProfessores");

if (openMenu) openMenu.addEventListener("click", () => sidebar.classList.add("show"));
if (closeMenu) closeMenu.addEventListener("click", () => sidebar.classList.remove("show"));

function carregarProfessores() {
  const professores = JSON.parse(localStorage.getItem("professores")) || [];
  if (professores.length === 0) {
    listaProfessores.innerHTML = `<tr><td colspan="4">Nenhum professor cadastrado.</td></tr>`;
    return;
  }

  listaProfessores.innerHTML = professores.map(professor => `
    <tr>
      <td>${professor.nome}</td>
      <td>${professor.email}</td>
      <td>${professor.telefone}</td>
      <td>${professor.especialidade}</td>
    </tr>
  `).join("");
}

if (formProfessor) {
  formProfessor.addEventListener("submit", function(event) {
    event.preventDefault();

    const nome = document.getElementById("nomeProfessor").value.trim();
    const email = document.getElementById("emailProfessor").value.trim();
    const telefone = document.getElementById("telefoneProfessor").value.trim();
    const especialidade = document.getElementById("especialidadeProfessor").value.trim();

    const professores = JSON.parse(localStorage.getItem("professores")) || [];
    if (professores.some(prof => prof.email === email)) {
      alert("Professor jÃ¡ cadastrado com este e-mail.");
      return;
    }

    professores.push({ idProfessor: Date.now(), nome, email, telefone, especialidade });
    localStorage.setItem("professores", JSON.stringify(professores));

    alert("Professor cadastrado com sucesso!");
    formProfessor.reset();
    carregarProfessores();
  });
}

carregarProfessores();




