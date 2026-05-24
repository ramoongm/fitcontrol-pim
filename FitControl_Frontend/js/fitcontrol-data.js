function garantirPlanosPadrao() {
  const planos = JSON.parse(localStorage.getItem("planos")) || [];
  if (planos.length > 0) return planos;

  const planosPadrao = [
    { idPlano: 1, nome: "Plano Mensal", valor: 99.90, duracao: "30 dias", status: "Ativo" },
    { idPlano: 2, nome: "Plano Trimestral", valor: 269.90, duracao: "90 dias", status: "Ativo" },
    { idPlano: 3, nome: "Plano Semestral", valor: 499.90, duracao: "180 dias", status: "Ativo" },
    { idPlano: 4, nome: "Plano Anual", valor: 899.90, duracao: "365 dias", status: "Ativo" }
  ];

  localStorage.setItem("planos", JSON.stringify(planosPadrao));
  return planosPadrao;
}

function formatarMoeda(valor) {
  return Number(valor).toLocaleString("pt-BR", { style: "currency", currency: "BRL" });
}

function formatarDataBR(dataISO) {
  if (!dataISO) return "-";
  const [ano, mes, dia] = dataISO.split("-");
  return `${dia}/${mes}/${ano}`;
}

function nomeAlunoPorId(idAluno) {
  const alunos = JSON.parse(localStorage.getItem("alunos")) || [];
  return alunos.find(aluno => String(aluno.idAluno) === String(idAluno))?.nome || "Aluno nÃ£o encontrado";
}

function nomeProfessorPorId(idProfessor) {
  const professores = JSON.parse(localStorage.getItem("professores")) || [];
  return professores.find(prof => String(prof.idProfessor) === String(idProfessor))?.nome || "Professor nÃ£o encontrado";
}

function planoPorId(idPlano) {
  return garantirPlanosPadrao().find(plano => String(plano.idPlano) === String(idPlano));
}




