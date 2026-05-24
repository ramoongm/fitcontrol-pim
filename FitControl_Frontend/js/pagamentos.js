

const openMenu = document.getElementById("openMenu");
const closeMenu = document.getElementById("closeMenu");
const sidebar = document.getElementById("sidebar");
const formPagamento = document.getElementById("formPagamento");
const listaPagamentos = document.getElementById("listaPagamentos");
const matriculaSelect = document.getElementById("matriculaPagamento");

if (openMenu) openMenu.addEventListener("click", () => sidebar.classList.add("show"));
if (closeMenu) closeMenu.addEventListener("click", () => sidebar.classList.remove("show"));

function carregarSelectMatriculas() {
  const matriculas = JSON.parse(localStorage.getItem("matriculas")) || [];
  matriculaSelect.innerHTML = `<option value="">Selecione a matrÃ­cula</option>`;

  matriculas.forEach(matricula => {
    const plano = planoPorId(matricula.idPlano);
    matriculaSelect.innerHTML += `<option value="${matricula.idMatricula}">${nomeAlunoPorId(matricula.idAluno)} - ${plano?.nome || "Plano"}</option>`;
  });
}

function obterMatricula(idMatricula) {
  const matriculas = JSON.parse(localStorage.getItem("matriculas")) || [];
  return matriculas.find(m => String(m.idMatricula) === String(idMatricula));
}

function carregarPagamentos() {
  const pagamentos = JSON.parse(localStorage.getItem("pagamentos")) || [];
  if (pagamentos.length === 0) {
    listaPagamentos.innerHTML = `<tr><td colspan="5">Nenhum pagamento registrado.</td></tr>`;
    return;
  }

  listaPagamentos.innerHTML = pagamentos.map(pagamento => {
    const matricula = obterMatricula(pagamento.idMatricula);
    const plano = matricula ? planoPorId(matricula.idPlano) : null;
    return `
      <tr>
        <td>${matricula ? nomeAlunoPorId(matricula.idAluno) : "-"}</td>
        <td>${plano?.nome || "-"}</td>
        <td>${formatarMoeda(pagamento.valor)}</td>
        <td>${formatarDataBR(pagamento.dataPagamento)}</td>
        <td class="${pagamento.status === "Pago" ? "active" : "inactive"}">${pagamento.status}</td>
      </tr>
    `;
  }).join("");
}

if (formPagamento) {
  formPagamento.addEventListener("submit", function(event) {
    event.preventDefault();

    const idMatricula = matriculaSelect.value;
    const valor = document.getElementById("valorPagamento").value;
    const dataPagamento = document.getElementById("dataPagamento").value;
    const status = document.getElementById("statusPagamento").value;

    const pagamentos = JSON.parse(localStorage.getItem("pagamentos")) || [];
    pagamentos.push({ idPagamento: Date.now(), idMatricula, valor, dataPagamento, status });
    localStorage.setItem("pagamentos", JSON.stringify(pagamentos));

    alert("Pagamento registrado com sucesso!");
    formPagamento.reset();
    carregarPagamentos();
  });
}

carregarSelectMatriculas();
carregarPagamentos();




