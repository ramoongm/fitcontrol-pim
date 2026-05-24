

const openMenu = document.getElementById("openMenu");
const closeMenu = document.getElementById("closeMenu");
const sidebar = document.getElementById("sidebar");
const nomeUsuario = document.getElementById("nomeUsuario");
const tabelaPresencaAluno = document.getElementById("tabelaPresencaAluno");
const totalPresencas = document.getElementById("totalPresencas");
const percentualFrequencia = document.getElementById("percentualFrequencia");
const ultimaPresenca = document.getElementById("ultimaPresenca");
const statusFrequencia = document.getElementById("statusFrequencia");

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

const nomeLogado = localStorage.getItem("usuarioLogado");

if (nomeLogado && nomeUsuario) {
  nomeUsuario.textContent = nomeLogado;
}

function carregarPresencasAluno() {
  const presencas = JSON.parse(localStorage.getItem("presencas")) || [];
  const minhasPresencas = presencas.filter(item => item.aluno === nomeLogado);

  if (!tabelaPresencaAluno) return;

  if (minhasPresencas.length === 0) {
    tabelaPresencaAluno.innerHTML = `
      <tr>
        <td colspan="2">Nenhum registro encontrado.</td>
      </tr>
    `;
    totalPresencas.textContent = "0";
    percentualFrequencia.textContent = "0%";
    ultimaPresenca.textContent = "-";
    statusFrequencia.textContent = "Sem dados";
    return;
  }

  tabelaPresencaAluno.innerHTML = minhasPresencas.map(item => `
    <tr>
      <td>${item.data}</td>
      <td>${item.status}</td>
    </tr>
  `).join("");

  const presencasConfirmadas = minhasPresencas.filter(
    item => item.status === "Presente"
  ).length;

  const total = minhasPresencas.length;
  const percentual = Math.round((presencasConfirmadas / total) * 100);

  totalPresencas.textContent = presencasConfirmadas;
  percentualFrequencia.textContent = `${percentual}%`;
  ultimaPresenca.textContent = minhasPresencas[0].data;

  if (percentual >= 75) {
    statusFrequencia.textContent = "Boa";
  } else if (percentual >= 50) {
    statusFrequencia.textContent = "Regular";
  } else {
    statusFrequencia.textContent = "Baixa";
  }
}

carregarPresencasAluno();



