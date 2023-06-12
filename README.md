# API Padrão Repositório POO

Controle de um sistema de cobranças onde cada cobranca deve estar vinculada a um cliente, e cada cliente pode ter várias cobranças. Utilização de conhecimentos sobre listas genéricas.

 
1- Camada de domínios(Domain) - Onde ficam os Objetos.

2- Camada DATA ou Repository - Camada de conexão com banco de dados.

3- Camada de serviços - Regra de negócios da Aplicação - Conecta o repositorio com a camada de apresentação dos dados. 

4- Camada de Apresentação - Presentation - Interação com o Usuário.

# Resumo

Camada de Apresentação depende da Camada de Serviço. 

Camada Serviços depende da Camada de Repositóris(Data) e da Camada de Domain. 

Camada de Repositorios depende da Camada de Domain. 

Cada Repositório só pode ter um ponto de Acesso para não gerar inconsistência nos Dados, ou seja, cada Repositório só deve ser instanciado no serviço correspondente.
