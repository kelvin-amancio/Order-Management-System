# Questionário de Conhecimento

### Seção 1: C# e Desenvolvimento de API Restful

1. **Qual é a diferença entre uma classe abstrata e uma interface em C#?**
   - a) Classes abstratas não podem ter métodos abstratos.
   - b) Interfaces podem ter implementações de métodos.
   - **c) Classes abstratas podem ter construtores, enquanto interfaces não podem.**
   - d) Interfaces podem ter campos, enquanto classes abstratas não podem.

2. **Qual das seguintes opções descreve melhor uma API RESTful?**
   - a) Uma API que usa o protocolo FTP para transferir dados.
   - b) Uma API que segue o protocolo SOAP para troca de mensagens.
   - **c) Uma API que usa HTTP para realizar operações de CRUD em recursos.**
   - d) Uma API que é exclusivamente usada para comunicação entre servidores.

3. **Qual das seguintes opções é uma característica dos métodos assíncronos em C#?**
   - a) Eles sempre retornam `void`.
   - **b) Eles usam a palavra-chave `await` para pausar a execução até que uma tarefa seja concluída.**
   - c) Eles não podem lançar exceções.
   - d) Eles são mais rápidos que os métodos síncronos em todos os casos.

4. **O que é o Entity Framework no contexto do desenvolvimento de aplicações .NET?**
   - a) Uma biblioteca para manipulação de imagens.
   - **b) Um ORM (Object-Relational Mapping) para trabalhar com bancos de dados.**
   - c) Um framework para criação de interfaces de usuário.
   - d) Um sistema de controle de versão.

5. **Qual é a finalidade do atributo `[HttpGet]` em um método de controlador ASP.NET?**
   - a) Especificar que o método deve ser chamado em resposta a uma solicitação POST.
   - **b) Especificar que o método deve ser chamado em resposta a uma solicitação GET.**
   - c) Especificar que o método deve retornar dados em formato JSON.
   - d) Especificar que o método é protegido por autenticação.

6. **O que é o ASP.NET Core?**
   - a) Um framework para desenvolvimento de jogos.
   - **b) Um framework multiplataforma para desenvolvimento de aplicações web e APIs.**
   - c) Um sistema de gerenciamento de banco de dados.
   - d) Um sistema de controle de versão.

7. **Como se define uma rota personalizada em um controlador ASP.NET?**
   - **a) Usando a anotação `[Route]`.**
   - b) Usando a anotação `[Path]`.
   - c) Definindo o caminho no arquivo de configuração.
   - d) Não é possível definir rotas personalizadas em ASP.NET.

8. **Qual é a função do middleware no ASP.NET Core?**
   - a) Gerenciar o acesso ao banco de dados.
   - **b) Interceptar e manipular solicitações HTTP.**
   - c) Criar interfaces de usuário dinâmicas.
   - d) Gerenciar serviços de autenticação de terceiros.

9. **O que é um DTO (Data Transfer Object)?**
   - a) Um objeto de banco de dados usado para armazenar dados temporários.
   - **b) Um objeto usado para encapsular dados que são transferidos entre diferentes camadas de uma aplicação.**
   - c) Um tipo de arquivo usado para armazenar dados de configuração.
   - d) Um padrão de design usado para manipulação de exceções.

10. **Qual dos seguintes é um exemplo de status de resposta HTTP usado em APIs RESTful?**
    - a) 500 - Internal Server Error
    - b) 302 - Found
    - c) 200 - OK
    - **d) Todas as opções acima**

11. **Como se pode limitar o número de resultados retornados por uma API RESTful?**
    - a) Usando o método `Reduce`.
    - **b) Usando parâmetros de consulta como `limit` e `offset`.**
    - c) Configurando o limite no servidor web.
    - d) Não é possível limitar o número de resultados.

12. **O que é CORS (Cross-Origin Resource Sharing) e por que é importante em APIs?**
    - a) Um padrão para compartilhamento de recursos como arquivos CSS e JS entre servidores.
    - **b) Uma política de segurança que define como recursos de diferentes origens podem interagir.**
    - c) Um sistema de gerenciamento de banco de dados.
    - d) Uma biblioteca para renderização gráfica.

#### Parte 2: Banco de Dados Microsoft SQL Server 

1. **Qual das seguintes consultas SQL é usada para atualizar dados em uma tabela?**
   - a) SELECT
   - **b) UPDATE**
   - c) DELETE
   - d) INSERT

2. **Qual comando SQL é usado para remover uma tabela completamente do banco de dados?**
   - **a) DROP TABLE**
   - b) DELETE TABLE
   - c) REMOVE TABLE
   - d) TRUNCATE TABLE

3. **O que é uma chave primária em um banco de dados relacional?**
   - a) Uma coluna que pode ter valores duplicados.
   - **b) Uma coluna ou conjunto de colunas que identifica unicamente cada linha em uma tabela.**
   - c) Uma tabela especial usada para armazenar chaves estrangeiras.
   - d) Um comando SQL usado para criar tabelas.

4. **Como se define uma relação entre duas tabelas em um banco de dados relacional?**
   - a) Usando uma chave primária em ambas as tabelas.
   - **b) Usando uma chave estrangeira que referencia a chave primária de outra tabela.**
   - c) Definindo ambas as tabelas com o mesmo nome.
   - d) Não é possível definir relações entre tabelas em SQL.

5. **O que é uma instrução JOIN em SQL?**
   - **a) Uma operação que combina registros de duas ou mais tabelas com base em uma condição relacionada.**
   - b) Um comando para inserir dados em várias tabelas ao mesmo tempo.
   - c) Uma função de agregação para calcular somas ou médias.
   - d) Um tipo de índice usado para melhorar o desempenho das consultas.

6. **Qual dos seguintes tipos de dados é usado para armazenar texto em SQL Server?**
   - a) INT
   - **b) NVARCHAR**
   - c) DECIMAL
   - d) FLOAT

7. **Como se cria um índice em uma tabela do SQL Server?**
   - **a) Usando o comando CREATE INDEX.**
   - b) Usando o comando ADD INDEX.
   - c) Usando o comando INSERT INDEX.
   - d) Usando o comando DEFINE INDEX.

8. **O que é um 'stored procedure' no SQL Server?**
   - **a) Um conjunto de comandos SQL que podem ser armazenados e executados no banco de dados.**
   - b) Um tipo de banco de dados temporário.
   - c) Uma chave estrangeira usada para relacionar tabelas.
   - d) Uma tabela especial usada para armazenar metadados.

9. **Qual comando SQL é usado para recuperar dados de uma tabela?**
   - a) RETRIEVE
   - b) GET
   - **c) SELECT**
   - d) FETCH

10. **Qual das seguintes opções é uma prática recomendada ao trabalhar com transações no SQL Server?**
    - a) Usar transações para cada operação de consulta.
    - b) Evitar o uso de transações para operações de escrita.
    - **c) Comitar a transação somente após verificar que todas as operações foram bem-sucedidas.**
    - d) Usar transações apenas para operações de leitura.

11. **O que é uma 'view' no SQL Server?**
    - a) Um backup de uma tabela.
    - b) Uma tabela temporária que armazena dados intermediários.
    - **c) Uma consulta armazenada que fornece uma visão específica dos dados.**
    - d) Uma configuração de segurança que restringe o acesso a dados.

12. **O que é o comando `TRUNCATE TABLE` e como ele difere do comando `DELETE`?**
    - **a) `TRUNCATE TABLE` remove todos os registros de uma tabela, enquanto `DELETE` remove registros específicos.**
    - b) `TRUNCATE TABLE` e `DELETE` são sinônimos.
    - c) `TRUNCATE TABLE` é usado para excluir uma tabela inteira, enquanto `DELETE` remove apenas as linhas.
    - d) `TRUNCATE TABLE` remove registros e estrutura da tabela, enquanto `DELETE` apenas os registros.

#### Parte 3: Padrão Swagger

1. **O que é Swagger?**
   - a) Uma linguagem de programação.
   - **b) Um conjunto de ferramentas para a documentação de APIs.**
   - c) Um framework para desenvolvimento frontend.
   - d) Um banco de dados NoSQL.

2. **Qual das seguintes opções descreve a finalidade do arquivo `swagger.json`?**
   - a) Armazenar os logs de uma aplicação.
   - **b) Definir a estrutura e os endpoints de uma API.**
   - c) Configurar o banco de dados da aplicação.
   - d) Definir as políticas de segurança da aplicação.

3. **O que é o OpenAPI Specification?**
   - **a) Uma especificação para descrever, produzir, consumir e visualizar serviços web RESTful.**
   - b) Um padrão para autenticação de APIs.
   - c) Um formato de arquivo para armazenamento de logs.
   - d) Uma ferramenta de integração contínua.

4. **Como o Swagger facilita a interação dos desenvolvedores com APIs?**
   - **a) Automatizando a criação de documentação de APIs e fornecendo uma interface interativa para testar endpoints.**
   - b) Gerando automaticamente código frontend a partir de especificações de APIs.
   - c) Monitorando o desempenho das APIs em tempo real.
   - d) Configurando automaticamente as permissões de acesso para diferentes usuários.

