var tbody = document.querySelector('table tbody');
var aluno = {};
function Cadastrar(){        
    aluno.nome = document.querySelector('#nome').value;
    aluno.sobrenome = document.querySelector('#sobrenome').value;
    aluno.telefone = document.querySelector('#telefone').value;
    aluno.ra = document.querySelector('#ra').value;
    aluno.descricao = document.querySelector('#descricao').value;
    
    console.log(aluno)
    if(aluno.id === undefined || aluno.id === 0){
        salvarEstudantes(`POST`, 0, aluno);
    }else{
        salvarEstudantes(`PUT`, aluno.id, aluno);
    }
    carregaEstudantes();
    $('#myModal').modal('hide')
}
function NovoAluno(){
    var btnSalvar = document.querySelector('#btnSalvar');
    var lblTitulo = document.querySelector('#titulo');

    document.querySelector('#nome').value = "";
    document.querySelector('#sobrenome').value = "";
    document.querySelector('#telefone').value = "";
    document.querySelector('#ra').value = "";
    document.querySelector('#descricao').value = "";

    aluno = {};
    
    btnSalvar.textContent = 'Cadastrar';
   
    lblTitulo.textContent = 'Cadastrar Aluno';

    $('#myModal').modal('show')
}
function Cancelar(){
    var btnSalvar = document.querySelector('#btnSalvar');
    var lblTitulo = document.querySelector('#titulo');

    document.querySelector('#nome').value = "";
    document.querySelector('#sobrenome').value = "";
    document.querySelector('#telefone').value = "";
    document.querySelector('#ra').value = "";
    document.querySelector('#descricao').value = "";

    aluno = {};
    
    btnSalvar.textContent = 'Cadastrar';
    
    lblTitulo.textContent = 'Cadastrar Aluno';

    $('#myModal').modal('hide')
}

function carregaEstudantes(){
    tbody.innerHTML = '';
    var xhr = new XMLHttpRequest();
    
    xhr.open(`GET`, `http://localhost:26949/api/Aluno/Recuperar`, true);
    xhr.onload = function (){
        var estudantes = JSON.parse(this.responseText);
        for(var i in estudantes){
            adicionaLinha(estudantes[i])
        }
    }
    console.log("teste")
    xhr.send();
}

function salvarEstudantes(metodo, id, corpo){
    var xhr = new XMLHttpRequest();

    if(id === undefined || id === 0){
        id = '';
    }
    xhr.open(`POST`, `http://localhost:52702/api/Aluno/${id}`, false);
    
    
    xhr.setRequestHeader('content-type', 'application/json');
    xhr.send(JSON.stringify(corpo));
    
    
}

function excluirEstudante(id){
    var xhr = new XMLHttpRequest();

    if(id === undefined || id === 0){
        id = '';
    }
    xhr.open(`Delete`, `http://localhost:52702/api/Aluno/${id}`, false);
    xhr.send();
}

function excluir(id){
    bootbox.confirm({
        message: "Sabe voar estudante?",
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-success'
            },
            cancel: {
                label: 'No',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if(result){
                excluirEstudante(id);
                carregaEstudantes();
            }
            
        }
    });
    
    
}

function editarEstudante(estudante){
    var btnSalvar = document.querySelector('#btnSalvar')
    
    var lblTitulo = document.querySelector('#titulo');

    document.querySelector('#nome').value = estudante.nome;
    document.querySelector('#sobrenome').value = estudante.sobrenome;
    document.querySelector('#telefone').value = estudante.telefone;
    document.querySelector('#ra').value = estudante.ra;
    document.querySelector('#descricao').value = estudante.descricao;

    btnSalvar.textContent = 'Salvar';
    
    lblTitulo.textContent = `Editar Aluno ${estudante.nome} ${estudante.sobrenome}`;
    
    aluno = estudante;
}
carregaEstudantes();

function adicionaLinha(estudante){
    var trow = `<tr>
                    <td>${estudante.nome}</td>
                    <td>${estudante.sobrenome}</td>
                    <td>${estudante.telefone}</td>
                    <td>${estudante.ra}</td>
                    <td>${estudante.descricao}</td>
                    <td><button onclick='editarEstudante(${JSON.stringify(estudante)})' 
                    class="btn btn-info" data-toggle="modal" data-target="#myModal">Editar</button>
                        <button onclick='excluir(${estudante.id})' class="btn btn-danger">Deletar</button>
                    </td>
                <tr>`;
    tbody.innerHTML += trow;                 
}