const form = document.getElementById("loginForm");
const usuarioInput = document.getElementById("usuario");
const senhaInput = document.getElementById("senha");

form.addEventListener("submit", function(event) {
    event.preventDefault();

    const usuario = usuarioInput.value.trim();
    const senha = senhaInput.value.trim();

    if (!usuario || !senha) {
        alert("Preencha usuÃ¡rio e senha.");
        return;
    }

    if (usuario === "admin" && senha === "1234") {
        localStorage.setItem("usuarioLogado", "Administrador");
        localStorage.setItem("tipoUsuario", "admin");
        alert("Login de administrador realizado com sucesso!");
        window.location.href = "dashboard.html";
        return;
    }

    const usuarios = JSON.parse(localStorage.getItem("usuarios")) || [];

    const usuarioEncontrado = usuarios.find(
        user => (user.usuario === usuario || user.email === usuario) && user.senha === senha
    );

    if (usuarioEncontrado) {
        localStorage.setItem("usuarioLogado", usuarioEncontrado.nome);
        localStorage.setItem("tipoUsuario", usuarioEncontrado.tipo || "aluno");

        alert("Login realizado com sucesso!");

        if (usuarioEncontrado.tipo === "admin") {
            window.location.href = "dashboard.html";
        } else if (usuarioEncontrado.tipo === "professor") {
            window.location.href = "treinos.html";
        } else {
            window.location.href = "aluno-dashboard.html";
        }
    } else {
        alert("UsuÃ¡rio ou senha invÃ¡lidos.");
    }
});

function sair() {
    localStorage.removeItem("usuarioLogado");
    window.location.href = "index.html";
}



