document.addEventListener("DOMContentLoaded", function () {
  const userMenu = document.getElementById("userMenu");
  const dropdown = document.getElementById("dropdownMenu");
  const logoutBtn = document.getElementById("logout");
  const trocarBtn = document.getElementById("trocarUsuario");
  const nomeUsuario = document.getElementById("nomeUsuario");

  console.log("user.js carregado");

  if (localStorage.getItem("usuarioLogado") && nomeUsuario) {
    nomeUsuario.textContent = localStorage.getItem("usuarioLogado");
  }

  if (userMenu && dropdown) {
    userMenu.addEventListener("click", function (e) {
      e.stopPropagation();
      dropdown.classList.toggle("show");
      console.log("clicou no menu");
    });
  }

  document.addEventListener("click", function () {
    if (dropdown) {
      dropdown.classList.remove("show");
    }
  });

  if (logoutBtn) {
    logoutBtn.addEventListener("click", function (e) {
      e.stopPropagation();
      localStorage.removeItem("usuarioLogado");
      window.location.href = "index.html";
    });
  }

  if (trocarBtn) {
    trocarBtn.addEventListener("click", function (e) {
      e.stopPropagation();
      localStorage.removeItem("usuarioLogado");
      window.location.href = "index.html";
    });
  }
});


CSS

