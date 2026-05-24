const signupForm = document.getElementById("signupForm");

if (signupForm) {
  signupForm.addEventListener("submit", function(event) {
    event.preventDefault();

    const nome = document.getElementById("nome").value.trim();
    const usuario = document.getElementById("novoUsuario").value.trim();
    const email = document.getElementById("email").value.trim();
    const senha = document.getElementById("novaSenha").value.trim();
    const confirmarSenha = document.getElementById("confirmarSenha").value.trim();
    const tipo = document.getElementById("tipoUsuario").value;

    if (!nome || !usuario || !email || !senha || !confirmarSenha || !tipo) {
      alert("Preencha todos os campos.");
      return;
    }

    if (senha !== confirmarSenha) {
      alert("As senhas nÃ£o coincidem.");
      return;
    }

    let usuarios = JSON.parse(localStorage.getItem("usuarios")) || [];
    const usuarioExistente = usuarios.find(user => user.usuario === usuario || user.email === email);

    if (usuarioExistente) {
      alert("Esse usuÃ¡rio/e-mail jÃ¡ estÃ¡ cadastrado.");
      return;
    }

    const novoUsuario = {
      idUsuario: Date.now(),
      nome,
      usuario,
      email,
      senha,
      tipo
    };

    usuarios.push(novoUsuario);
    localStorage.setItem("usuarios", JSON.stringify(usuarios));

    alert("Cadastro realizado com sucesso!");
    window.location.href = "index.html";
  });
}




