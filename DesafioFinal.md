# Desafio Final

No desafio final vamos criar um dashboard para visualizar as principais informações de um e-commerce.

O código-fonte base do programa, bem como os arquivos necessários para realizar a tarefa, estão no link https://s3.amazonaws.com/ada.8c8d357b5e872bbacd45197626bd5759/c-sharp/tecnicas-de-programacao/desafio-final/CodigoFonteDesafioFinal.zip

Para exibição do dashboard, foram definidos os seguintes endpoints e retornos esperados:


### Endpoint
    /clientes/resumo

### Rota
    POST

### Dados
    Contador dos países com mais clientes. Caso não tenha país definido no cliente, devolver como "desconhecido"
    Top 5 domínios mais utilizados por clientes, com a quantidade de emails para o domínio

### Retorno esperado
    {
        "paisesComMaisClientes": {
            "pais 1": 100,
            "pais 2": 80,
            "desconhecido": 50
        },
        "dominios": {
            "dominio um": 100,
            "dominio dois": 80
        }
    }

### Endpoint
    /clientes

### Rota
    POST

### Dados
    Lista com os primeiros 100 clientes, ordenados em ordem alfabética. Exibir todos os dados dos clientes, mas o nome dos clientes deve ser unificado em um campo só chamado de "Nome Completo".

### Retorno esperado
    {
        "clientes": [
            {
                "nome_completo": "xxx",
                "email": "xxx@xxx.com",
                ...
            }
        ]
    }

### Endpoint
    /pedidos/resumo

### Rota
    POST

### Dados
    Devolver o valor total (soma) dos pedidos de acordo com o mês e ano que foi realizado em ordem decrescente.
    Devolver o top 10 dos clientes que realizaram pedidos ordenados por ordem descrescente de valor (nome completo e valor)
    Para cada um dos meses que houve compra, devolver a soma dos valores comprados nos primeiros 15 dias do mês e outra soma com os valores comprados nos últimos 15 dias do mês

### Retorno esperado
    {
        "totalPedidos": {
            "2023-11": 1000,00,
            "2023-10": 1000,00
        },
        "topClientes": {
            "nome completo cliente 1": 1000,00,
            "nome completo cliente 2": 999,00
        },
        "totalPedidosPorQuinzena": {
            "2023-11": {
                "primeira": 500,00,
                "segunda": 500,00
            }
        }
    }

### Endpoint
    /pedidos/mais_comprados

### Rota
    POST

### Dados
    Devolver os 30 produtos mais comprados (nome, categoria, quantidade e valor total), ordenados de forma decrescente pelo valor
    Devolver os 30 produtos mais comprados (nome, categoria, quantidade e valor total), ordenados de forma decrescente pela quantidade

### Retorno esperado
    {
        "produtosMaisCompradosPorValor": [
            {
                "nome": "nome do produto",
                "categoria": "nome da categoria",
                "quantidade": 50,
                "valor": 1000
            }
        ],
        "produtosMaisCompradosPorQuantidade": [
            {
                "nome": "nome do produto",
                "categoria": "nome da categoria",
                "quantidade": 50,
                "valor": 1000
            }
        ],
    }

### Endpoint
    /pedidos/mais_comprados_por_categoria

### Rota
    POST

### Dados
    Devolver os 30 produtos mais comprados de cada uma das categorias (nome, quantidade e valor total), ordenados de forma decrescente pelo valor
    Devolver os 30 produtos mais comprados de cada uma das categorias (nome, quantidade e valor total), ordenados de forma decrescente pela quantidade
    
    Obs: O nome da categoria na chave NÃO deve conter acentos, caracteres especiais ou espaços. Ex: "Men's Shoes" deve ser enviado como "mensShoes, "Play Sets Playground Equipment" deve ser enviado como "playSetsPlaygroundEquipment", etc. 

### Retorno esperado
    {
        "nomeDaCategoriaPorValor": [
            {
                "nome": "nome do produto",
                "quantidade": 50,
                "valor": 1000
            }
        ],
        "nomeDaCategoriaPorQuantidade": [
            {
                "nome": "nome do produto",
                "quantidade": 50,
                "valor": 1000
            }
        ]
    }

### Endpoint
    /pedidos/mais_comprados_por_fornecedor

### Rota
    POST

### Dados
    Devolver os 30 produtos mais comprados de cada um dos fornecedores (nome, categoria, quantidade e valor total), ordenados de forma crescente pelo nome do fornecedor

    Obs: O nome do fornecedor na chave NÃO deve conter acentos, caracteres especiais ou espaços. Ex: "José Da Couve" deve ser enviado como "joseDaCouve".

### Retorno esperado
    {
        "nomeDoFornecedor": [
            {
                "nome": "nome do produto",
                "categoria": "nome da categoria",
                "quantidade": 50,
                "valor": 1000
            }
        ],
        "nomeDoFornecedor": [
            {
                "nome": "nome do produto",
                "categoria": "nome da categoria",
                "quantidade": 50,
                "valor": 1000
            }
        ]
    }
   
&nbsp;

## Requisitos

- Seguir o contrato definido para a API acima, ou seja, respeitar as definições de nome dos endpoints, rotas e objetos no dicionário que será devolvido ao frontend. Utilize o formato camelCase para os retornos.

- Resultados corretos.

- Os valores devem ser formatados em R$, ou seja, com vírgula como separador decimal (ex: 1000,00). Não é necessário separar o milhar.

- Os endpoints devem ser separados em arquivos diferentes. Ex: Os endpoints `/clientes` e o `/clientes/resumo` fica no arquivo EndpointsClientes.cs. O endpoint `/produtos` fica no arquivo EndpointsProdutos.cs.

- Utilize métodos assincronos nos métodos

- Utilizar linq para consultar dados no banco de dados

- Utilizar lambda e funções anônimas, quando aplicável, para organizar os retornos da API.

- Utilizar classes e interfaces

- Não abrir o browser ao rodar a API.

- A API deve configurada para responder nas portas 
    - HTTPS: 5000
    - HTTP: 5050

&nbsp;

## Critérios de avaliação

O trabalho como um todo vale 10 pontos. Cada um dos itens definidos nos requisitos básicos será avaliado, e tem o peso de 1 ponto no desafio final.

&nbsp;

## Data de entrega

Dia 18/12/2023, até as 23:59

Extensível até o dia 22/12/23 às 23:59