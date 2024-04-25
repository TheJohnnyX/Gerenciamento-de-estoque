
# API de Gerenciamento de Estoque

##Propósito do sistema
Gerenciamento de estoque, permitindo a adição, edição, exclusão e listagem de produtos, fornecedores e validações.

##Usuários
Funcionários da empresa responsáveis pelo gerenciamento de estoque.

##N-Layer

# Camada de Apresentação (Presentation Layer)
Responsáveis por receber requisições HTTP, chamar os serviços da camada de lógica de negócios e retornar as respostas adequadas.
# Camada de Lógica de Negócios (Business Logic Layer)
Contêm a lógica de negócios da aplicação.
Realizam validações, chamam métodos da camada de acesso a dados e coordenam as operações.
# Camada de Acesso a Dados (Data Access Layer)
Responsáveis por abstrair o acesso ao banco de dados.

# Entidades

Produto
Fornecedor
Associar
Vender

# Requisitos Funcionais

### Cadastro de produtos.
Permite cadastrar produtos, informando Nome, descrição e valor.
### Edição de produtos.
Permite a edição de produtos, informando Nome, descrição e valor.
### Exclusão de produtos.
Permite a exclusão de produtos informando o ID
### Listar um produto específico
Fornece os dados de um produto específico
### Listagem de todos os produtos.
Fornece uma lista com todos os produtos

### Cadastro de fornecedores.
Permite cadastrar fornecedores, informando Nome, descrição e valor.
### Edição de fornecedores.
Permite a edição de fornecedores, informando Nome, descrição e valor.
### Exclusão de fornecedores.
Permite a exclusão de fornecedores informando o ID
### Listar um fornecedor específico
Fornece os dados de um fornecedor específico
### Listagem de todos os fornecedores.
Fornece uma lista com todos os fornecedores

### Associar produtos a fornecedores.
Permite associar ao informar o ID do produto e o ID do fornecedor
Ao associar, validar se o produto e o fornecedor existem
### Vender produtos
Permite vender ao informar o ID do produto, ID do fornecedor, e quantidade.
Ao vender, verificar se o produto existe e se está asociado, buscando o valor de venda na entidade de produtos





















