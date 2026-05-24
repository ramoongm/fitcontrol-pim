// ðŸ”’ trava de acesso (ADMIN)


const openMenu = document.getElementById("openMenu");
const closeMenu = document.getElementById("closeMenu");
const sidebar = document.getElementById("sidebar");

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

const matriculasCtx = document.getElementById("matriculasChart");
if (matriculasCtx) {
  new Chart(matriculasCtx, {
    type: "line",

    data: {
      labels: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun"],

      datasets: [{
        label: "MatrÃ­culas",
        data: [180, 195, 210, 225, 248, 265],

        borderWidth: 3,
        fill: true,
        tension: 0.3,

        borderColor: "#a855f7",
        backgroundColor: "rgba(168, 85, 247, 0.25)",

        pointBackgroundColor: "#c084fc",
        pointBorderColor: "#ffffff",
        pointRadius: 5
      }]
    },

    options: {
      responsive: true,

      plugins: {
        legend: {
          display: true,

          labels: {
            color: "#7c3aed"
          }
        }
      },

      scales: {
        x: {
          ticks: {
            color: "#7c3aed"
          },

          grid: {
            color: "rgba(168,85,247,0.1)"
          }
        },

        y: {
          ticks: {
            color: "#7c3aed"
          },

          grid: {
            color: "rgba(168,85,247,0.1)"
          }
        }
      }
    }
  });
}

const planosCtx = document.getElementById("planosChart");

if (planosCtx) {
  new Chart(planosCtx, {
    type: "bar",

    data: {
      labels: ["Mensal", "Semestral", "Anual"],

      datasets: [{
        label: "Planos vendidos",
        data: [45, 30, 15],

        borderWidth: 1,

        backgroundColor: [
          "#7c3aed",
          "#a855f7",
          "#c084fc"
        ],

        borderColor: [
          "#7c3aed",
          "#a855f7",
          "#c084fc"
        ]
      }]
    },

    options: {
      responsive: true,

      plugins: {
        legend: {
          display: true,

          labels: {
            color: "#7c3aed"
          }
        }
      },

      scales: {
        x: {
          ticks: {
            color: "#7c3aed"
          },

          grid: {
            color: "rgba(168,85,247,0.1)"
          }
        },

        y: {
          ticks: {
            color: "#7c3aed"
          },

          grid: {
            color: "rgba(168,85,247,0.1)"
          }
        }
      }
    }
  });
}



