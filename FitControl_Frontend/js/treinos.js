

const openMenu = document.getElementById("openMenu");
const closeMenu = document.getElementById("closeMenu");
const sidebar = document.getElementById("sidebar");
const formTreino = document.getElementById("formTreino");
const listaTreinos = document.getElementById("listaTreinos");
const alunoTreino = document.getElementById("alunoTreino");
const professorTreino = document.getElementById("professorTreino");

if (openMenu) openMenu.addEventListener("click", () => sidebar.classList.add("show"));
if (closeMenu) closeMenu.addEventListener("click", () => sidebar.classList.remove("show"));

function carregarSelectsTreino() {
  const alunos = JSON.parse(localStorage.getItem("alunos")) || [];
  const professores = JSON.parse(localStorage.getItem("professores")) || [];

  alunoTreino.innerHTML = `<option value="">Selecione o aluno</option>`;
  alunos.forEach(aluno => alunoTreino.innerHTML += `<option value="${aluno.idAluno}">${aluno.nome}</option>`);

  professorTreino.innerHTML = `<option value="">Selecione o professor</option>`;
  professores.forEach(prof => professorTreino.innerHTML += `<option value="${prof.idProfessor}">${prof.nome}</option>`);
}

function carregarTreinos() {
  const treinos = JSON.parse(localStorage.getItem("treinos")) || [];
  if (treinos.length === 0) {
    listaTreinos.innerHTML = `<tr><td colspan="5">Nenhum treino cadastrado.</td></tr>`;
    return;
  }

  listaTreinos.innerHTML = treinos.map(treino => `
    <tr>
      <td>${nomeAlunoPorId(treino.idAluno)}</td>
      <td>${nomeProfessorPorId(treino.idProfessor)}</td>
      <td>${treino.nomeTreino}</td>
      <td>${formatarDataBR(treino.dataInicio)}</td>
      <td>${treino.exercicios}</td>
    </tr>
  `).join("");
}

if (formTreino) {
  formTreino.addEventListener("submit", function(event) {
    event.preventDefault();

    const idAluno = alunoTreino.value;
    const idProfessor = professorTreino.value;
    const nomeTreino = document.getElementById("nomeTreino").value.trim();
    const dataInicio = document.getElementById("dataInicioTreino").value;
    const exercicios = document.getElementById("exerciciosTreino").value.trim();
    const observacoes = document.getElementById("observacoesTreino").value.trim();

    const treinos = JSON.parse(localStorage.getItem("treinos")) || [];
    treinos.push({ idTreino: Date.now(), idAluno, idProfessor, nomeTreino, dataInicio, exercicios, observacoes });
    localStorage.setItem("treinos", JSON.stringify(treinos));

    alert("Treino cadastrado com sucesso!");
    formTreino.reset();
    carregarTreinos();
  });
}

carregarSelectsTreino();
carregarTreinos();




