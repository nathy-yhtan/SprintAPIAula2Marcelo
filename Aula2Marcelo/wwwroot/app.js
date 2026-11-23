const apiUrl = "/api/Livros";

async function carregarLivros() {

    try {
        const resposta = await fetch(apiUrl);
        const livros = await resposta.json();

        const tbody = document.getElementById("tabelaCorpo");
        tbody.innerHTML = "";

        livros.forEach(livro => {
            tbody.innerHTML += `
                <tr>
                    <td>${livro.id}</td>
                    <td>${livro.titulo}</td>
                    <td>${livro.autor}</td>      
                </tr>
            `;
        });
    } catch (erro) {
        alert("Erro ao buscar os dados");
        console.error(erro);
    }
}

async function cadastrarLivro() {

    const token = document.getElementById('inputToken').value;

    if (!token) {
        alert("Acesso negado: cole o token no local indicado");
        return;
    }

    const novoLivro = {
        titulo: "Varity",
        autor: "Collen Hoover",
        anoPublicacao: 2018
    };

    try {
        const resposta = await fetch(apiUrl, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
            },
            body: JSON.stringify(novoLivro)
        });

        if (resposta.ok) {
            alert("novo livro cadastrado");
            carregarLivros();
        } else {
            alert("Erro: token invalido ou expirado")
        }
    } catch (erro) {
        console.erro(error);
    }
}

carregarLivros();