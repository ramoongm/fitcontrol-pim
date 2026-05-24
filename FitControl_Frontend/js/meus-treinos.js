

const openMenu = document.getElementById("openMenu");
const closeMenu = document.getElementById("closeMenu");
const sidebar = document.getElementById("sidebar");
const nomeUsuario = document.getElementById("nomeUsuario");

if (openMenu) {
  openMenu.addEventListener("click", () => sidebar.classList.add("show"));
}

if (closeMenu) {
  closeMenu.addEventListener("click", () => sidebar.classList.remove("show"));
}

const nomeLogado = localStorage.getItem("usuarioLogado");

if (nomeLogado && nomeUsuario) {
  nomeUsuario.textContent = nomeLogado;
}



