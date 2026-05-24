// ðŸ”’ trava de acesso (ADMIN)


const formPresenca = document.getElementById("formPresenca");
const listaPresencas = document.getElementById("listaPresencas");
const openMenu = document.getElementById("openMenu");
const closeMenu = document.getElementById("closeMenu");
const sidebar = document.getElementById("sidebar");
const selectAluno = document.getElementById("aluno");
const presentesHoje = document.getElementById("presentesHoje");
const ultimoHorario = document.getElementById("ultimoHorario");
const totalRegistros = document.getElementById("totalRegistros");
const totalAlunos = document.getElementById("totalAlunos");

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

function carregarSelectAlunos() {
  const alunos = JSON.parse(localStorage.getItem("alunos")) || [];

  if (!selectAluno) return;

  selectAluno.innerHTML = `<option value="">Selecione o aluno</option>`;

  alunos.forEach((aluno) => {
    selectAluno.innerHTML += `
      <option value="${aluno.idAluno}">${aluno.nome}</option>
    `;
  });

  if (totalAlunos) {
    totalAlunos.textContent = alunos.length;
  }
}

function formatarData(dataISO) {
  const [ano, mes, dia] = dataISO.split("-");
  return `${dia}/${mes}/${ano}`;
}

function carregarPresencas() {
  const presencas = JSON.parse(localStorage.getItem("presencas")) || [];

  if (!listaPresencas) return;

  if (presencas.length === 0) {
    listaPresencas.innerHTML = `
      <tr>
        <td colspan="4">Nenhuma presenÃ§a registrada.</td>
      </tr>
    `;
    if (presentesHoje) presentesHoje.textContent = "0";
    if (ultimoHorario) ultimoHorario.textContent = "-";
    if (totalRegistros) totalRegistros.textContent = "0";
    return;
  }

  listaPresencas.innerHTML = presencas.map((item) => `
    <tr>
      <td>${item.aluno}</td>
      <td>${item.data}</td>
      <td>${item.horario || "-"}</td>
      <td class="${item.status === "Presente" ? "active" : ""}">${item.status}</td>
    </tr>
  `).join("");

  const hoje = new Date();
  const dia = String(hoje.getDate()).padStart(2, "0");
  const mes = String(hoje.getMonth() + 1).padStart(2, "0");
  const ano = hoje.getFullYear();
  const dataHoje = `${dia}/${mes}/${ano}`;

  const presencasHoje = presencas.filter(
    (item) => item.data === dataHoje && item.status === "Presente"
  );

  if (presentesHoje) {
    presentesHoje.textContent = presencasHoje.length;
  }

  if (ultimoHorario) {
    ultimoHorario.textContent = presencas[0].horario || "-";
  }

  if (totalRegistros) {
    totalRegistros.textContent = presencas.length;
  }
}

if (formPresenca) {
  formPresenca.addEventListener("submit", function(event) {
    event.preventDefault();

    const idAluno = document.getElementById("aluno").value;
    const aluno = nomeAlunoPorId(idAluno);
    const data = document.getElementById("dataPresenca").value;
    const horario = document.getElementById("horarioEntrada").value;
    const status = document.getElementById("statusPresenca").value;

    if (!aluno || !data || !horario || !status) {
      alert("Preencha todos os campos.");
      return;
    }

    const novaPresenca = {
      idAluno,
      aluno,
      data: formatarData(data),
      horario,
      status
    };

    const presencas = JSON.parse(localStorage.getItem("presencas")) || [];
    presencas.unshift(novaPresenca);
    localStorage.setItem("presencas", JSON.stringify(presencas));

    alert("PresenÃ§a registrada com sucesso!");
    formPresenca.reset();
    carregarPresencas();
  });
}

carregarSelectAlunos();
carregarPresencas();



