

const openMenu = document.getElementById("openMenu");
const closeMenu = document.getElementById("closeMenu");
const sidebar = document.getElementById("sidebar");
const tabelaAlunos = document.getElementById("tabelaAlunos");

if (openMenu) openMenu.addEventListener("click", () => sidebar.classList.add("show"));
if (closeMenu) closeMenu.addEventListener("click", () => sidebar.classList.remove("show"));

const alunos = JSON.parse(localStorage.getItem("alunos")) || [];
const matriculas = JSON.parse(localStorage.getItem("matriculas")) || [];
const pagamentos = JSON.parse(localStorage.getItem("pagamentos")) || [];
const treinos = JSON.parse(localStorage.getItem("treinos")) || [];

const totalAlunosCard = document.getElementById("totalAlunosCard");
const totalMatriculas = document.getElementById("totalMatriculas");
const totalPendentes = document.getElementById("totalPendentes");
const totalTreinos = document.getElementById("totalTreinos");

if (totalAlunosCard) totalAlunosCard.textContent = alunos.length;
if (totalMatriculas) totalMatriculas.textContent = matriculas.filter(m => m.status === "Ativa").length;
if (totalPendentes) totalPendentes.textContent = pagamentos.filter(p => p.status !== "Pago").length;
if (totalTreinos) totalTreinos.textContent = treinos.length;

if (tabelaAlunos) {
  if (alunos.length === 0) {
    tabelaAlunos.innerHTML = `<tr><td colspan="4">Nenhum aluno cadastrado ainda.</td></tr>`;
  } else {
    tabelaAlunos.innerHTML = alunos.slice(-5).reverse().map(aluno => `
      <tr>
        <td>${aluno.nome}</td>
        <td>${aluno.email}</td>
        <td>${aluno.telefone}</td>
        <td>${aluno.cpf || "-"}</td>
      </tr>
    `).join("");
  }
}

const matriculasCtx = document.getElementById("matriculasChart");

if (matriculasCtx) {
  new Chart(matriculasCtx, {
    type: "line",
    data: {
      labels: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun"],
      datasets: [{
        label: "MatrÃ­culas",
        data: [180, 195, 210, 225, 248, 265],

        borderWidth: 3,
        fill: true,
        tension: 0.3,

        borderColor: "#a855f7",
        backgroundColor: "rgba(168, 85, 247, 0.2)",

        pointBackgroundColor: "#c084fc",
        pointBorderColor: "#ffffff",
        pointRadius: 5
      }]
    }
  });
}

const planosCtx = document.getElementById("planosChart");

if (planosCtx) {
  new Chart(planosCtx, {
    type: "bar",
    data: {
      labels: ["Mensal", "Semestral", "Anual"],
      datasets: [{
        label: "Planos vendidos",
        data: [45, 15, 10],

        borderWidth: 1,

        backgroundColor: [
          "#7c3aed",
          "#a855f7",
          "#c084fc"
        ],

        borderColor: [
          "#7c3aed",
          "#a855f7",
          "#c084fc"
        ]
      }]
    }
  });
}




