# Desafio técnico

Apresentação

A solução contém quatro projetos:

1. Core: Projeto que abriga o domínio contendo regras de negócios (cálculo de juros)
2. Core.Tests: Testes unitários das regras de negócio definidas no projeto Core
3. WebApi1: API responsável por fornecer a taxa de juros (/taxaJuros)
4. WebApi2: API que permite o cálculo dos juros (/calculaJuros) e retorna o endereço do repositório Github onde o código-fonte está localizado.


Como rodar a solução?

1. Baixe o código-fonte
2. Abra o código-fonte no Visual Studio 2019
3. Habilite para iniciar 2 projetos: WebApi1 e WebApi2
    - Dentro do Visual Studio, clique com o botão direito na solução
    - Selecione a opção "Propertiess"
    - Na janela que se abrirá, selecione a opção "Multiple startup projects"
    - Selecione a "Action": "Start" para os projetos WebApi1 (Taxa de Juros) e WebApi2 (Cálculo do juros - valor final)
    - Clique Ok e feche a janela
4. Execute a aplicação
5. Duas aplicações Web API serão exibidas. Anote a URL da WebApi1 (Exemplo: https://localhost:{PORT}/taxajuros)
6. Pare de executar as aplicações
7. No projeto WebApi, abra o arquivo appsettings.json e altere o valor do atributo ApplicationConfig.UrlTaxaJuros para o endereço obtido no passo 5
8. Execute novamente a aplicação, agora a WebApi2 pode ser utilizada porque sabe onde está rodando a WebApi1.
