

const openMenu = document.getElementById("openMenu");
const closeMenu = document.getElementById("closeMenu");
const sidebar = document.getElementById("sidebar");
const nomeUsuario = document.getElementById("nomeUsuario");
const dadosAluno = document.getElementById("dadosAluno");
const planoAluno = document.getElementById("planoAluno");

if (openMenu) {
  openMenu.addEventListener("click", () => {
    sidebar.classList.add("show");
  });
}

if (closeMenu) {
  closeMenu.addEventListener("click", () => {
    sidebar.classList.remove("show");
  });
}

const usuarios = JSON.parse(localStorage.getItem("usuarios")) || [];
const nomeLogado = localStorage.getItem("usuarioLogado");

const alunoLogado = usuarios.find(user => user.nome === nomeLogado);

if (alunoLogado) {
  nomeUsuario.textContent = alunoLogado.nome;

  dadosAluno.innerHTML = `
    <tr>
      <td>${alunoLogado.nome}</td>
      <td>${alunoLogado.email}</td>
      <td>${alunoLogado.usuario}</td>
      <td>${alunoLogado.tipo}</td>
    </tr>
  `;
} else {
  dadosAluno.innerHTML = `
    <tr>
      <td colspan="4">Nenhum dado encontrado.</td>
    </tr>
  `;
}

const alunos = JSON.parse(localStorage.getItem("alunos")) || [];

if (alunoLogado) {
  const registroAluno = alunos.find(aluno => aluno.email === alunoLogado.email);

  if (registroAluno) {
    planoAluno.textContent = registroAluno.plano;
  }
}



