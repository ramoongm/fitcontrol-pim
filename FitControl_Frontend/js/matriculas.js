

const openMenu = document.getElementById("openMenu");
const closeMenu = document.getElementById("closeMenu");
const sidebar = document.getElementById("sidebar");
const formMatricula = document.getElementById("formMatricula");
const listaMatriculas = document.getElementById("listaMatriculas");
const alunoSelect = document.getElementById("alunoMatricula");
const planoSelect = document.getElementById("planoMatricula");

if (openMenu) openMenu.addEventListener("click", () => sidebar.classList.add("show"));
if (closeMenu) closeMenu.addEventListener("click", () => sidebar.classList.remove("show"));

function carregarSelects() {
  const alunos = JSON.parse(localStorage.getItem("alunos")) || [];
  const planos = garantirPlanosPadrao();

  alunoSelect.innerHTML = `<option value="">Selecione o aluno</option>`;
  alunos.forEach(aluno => alunoSelect.innerHTML += `<option value="${aluno.idAluno}">${aluno.nome}</option>`);

  planoSelect.innerHTML = `<option value="">Selecione o plano</option>`;
  planos.forEach(plano => planoSelect.innerHTML += `<option value="${plano.idPlano}">${plano.nome} - ${formatarMoeda(plano.valor)}</option>`);
}

function carregarMatriculas() {
  const matriculas = JSON.parse(localStorage.getItem("matriculas")) || [];
  if (matriculas.length === 0) {
    listaMatriculas.innerHTML = `<tr><td colspan="5">Nenhuma matrÃƒÂ­cula cadastrada.</td></tr>`;
    return;
  }

  listaMatriculas.innerHTML = matriculas.map(matricula => {
    const plano = planoPorId(matricula.idPlano);
    return `
      <tr>
        <td>${nomeAlunoPorId(matricula.idAluno)}</td>
        <td>${plano?.nome || "Plano nÃƒÂ£o encontrado"}</td>
        <td>${formatarDataBR(matricula.dataInicio)}</td>
        <td>${formatarDataBR(matricula.dataFim)}</td>
        <td class="${matricula.status === "Ativa" ? "active" : "inactive"}">${matricula.status}</td>
      </tr>
    `;
  }).join("");
}

if (formMatricula) {
  formMatricula.addEventListener("submit", async function(event) {
    event.preventDefault();

    const alunoId = document.getElementById("alunoMatricula").value;
    const planoId = document.getElementById("plano").value;
    const dataInicio = document.getElementById("dataInicio").value;
    const dataFim = document.getElementById("dataFim").value;
    const status = document.getElementById("statusMatricula").value;

    const novaMatricula = {
      alunoId: parseInt(alunoId),
      planoId: parseInt(planoId) || 1, // Exemplo
      dataInicio,
      dataFim: dataFim ? dataFim : null,
      status
    };

    try {
      const response = await fetch("http://localhost:5220/api/Matriculas", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(novaMatricula)
      });

      if (!response.ok) {
        const errorData = await response.json();
        alert("Erro: " + errorData.mensagem);
        return;
      }

      alert("MatrÃ­cula cadastrada com sucesso!");
      formMatricula.reset();
      carregarMatriculas();
    } catch (error) {
      console.error("Erro:", error);
      alert("Erro ao conectar com a API.");
    }
  });
}

carregarSelects();
carregarMatriculas();




