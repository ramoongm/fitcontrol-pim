

const formAluno = document.getElementById("formAluno");
const listaAlunos = document.getElementById("listaAlunos");
const openMenuAluno = document.getElementById("openMenu");
const closeMenuAluno = document.getElementById("closeMenu");
const sidebarAluno = document.getElementById("sidebar");

if (openMenuAluno) openMenuAluno.addEventListener("click", () => sidebarAluno.classList.add("show"));
if (closeMenuAluno) closeMenuAluno.addEventListener("click", () => sidebarAluno.classList.remove("show"));

async function carregarAlunos() {
  if (!listaAlunos) return;

  try {
    const response = await fetch("http://localhost:5220/api/Alunos");
    if (!response.ok) throw new Error("Erro na rede");
    const alunos = await response.json();

    if (alunos.length === 0) {
      listaAlunos.innerHTML = `<tr><td colspan="4">Nenhum aluno cadastrado.</td></tr>`;
      return;
    }

    listaAlunos.innerHTML = alunos.map(aluno => `
      <tr>
        <td>${aluno.nome}</td>
        <td>${aluno.email}</td>
        <td>${aluno.telefone}</td>
        <td>${aluno.cpf}</td>
      </tr>
    `).join("");
  } catch (error) {
    console.error("Erro ao carregar alunos:", error);
    listaAlunos.innerHTML = `<tr><td colspan="4">Erro ao carregar os dados da API. Verifique se o backend estÃ¡ rodando.</td></tr>`;
  }
}

if (formAluno) {
  formAluno.addEventListener("submit", async function(event) {
    event.preventDefault();

    const nome = document.getElementById("nome").value.trim();
    const cpf = document.getElementById("cpf").value.trim();
    const email = document.getElementById("email").value.trim();
    const telefone = document.getElementById("telefone").value.trim();
    const dataNascimento = document.getElementById("dataNascimento").value;

    if (!nome || !cpf || !email || !telefone || !dataNascimento) {
      alert("Preencha todos os campos obrigatÃ³rios.");
      return;
    }

    const novoAluno = {
      usuarioId: 1, // Mockando ID do usuÃ¡rio para o exemplo
      nome,
      cpf,
      telefone,
      dataNascimento
    };

    try {
      const response = await fetch("http://localhost:5220/api/Alunos", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(novoAluno)
      });

      if (!response.ok) throw new Error("Erro ao salvar aluno");

      alert("Aluno cadastrado com sucesso! Agora faÃ§a a matrÃ­cula do aluno na tela MatrÃ­culas.");
      formAluno.reset();
      carregarAlunos();
    } catch (error) {
      console.error("Erro:", error);
      alert("Erro ao conectar com a API.");
    }
  });
}

carregarAlunos();




