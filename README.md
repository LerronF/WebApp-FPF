# WebApp-FPF
## Este repositório contém o projeto de um CRUD em ASPNET.

### Para rodar a aplicação, siga so passos abaixo:

* Copie o link abaixo para clonar o repositório em sua máquina. 
  * Link: [GitHub](https://github.com/LerronF/WebApp-FPF.git)
* Instale em sua máquina o Banco de dados Oracle seguindo os links abaixo(se ja possui instalação ignore essa etapa).
  * Crie sua conta Oracle para fazer download dos conteudos.
  * [Oracle Database Express Edition (XE) Release 18.4.0.0.0 (18c)](https://www.oracle.com/database/technologies/xe-downloads.html)
  * [Downloads do SQL Developer 20.4.1](https://www.oracle.com/tools/downloads/sqldev-downloads.html)
* Abra o diretório [main/sql](https://github.com/LerronF/WebApp-FPF/tree/main/sql), copie o conteudo do arquivo **ExportaçãoOracleDesafio** e cole no navegador do SGBD e execute. Ele irá criar as tabelas necessárias para a execução da aplicação.
* Configurar a ConnectionStrings do projeto:
  * Abra este diretorio [ConnectionString](https://github.com/LerronF/WebApp-FPF/blob/main/src/DesafioFPF/DesafioFPF.WebApp/appsettings.json), e faça as alterações necessárias.
  * Se tiver dificuldades para configurar siga os passos abaixo: 
    *  Localize na sua maquina o arquivo **tnsnames.ora**, abra e copie o conteudo da config XE, e cole na ConnectionStrings que fica dentro do [appsettings.json](https://github.com/LerronF/WebApp-FPF/blob/main/src/DesafioFPF/DesafioFPF.WebApp/appsettings.json) conforme exemplo ao lado: "ConnectionStrings": { "OracleDBConnection": "Data Source=(DESCRIPTION =**COLE AQUI O CONTEUDO DA XE**;User ID=**SEU USUARIO**;Password=**SUA SENHA**"

#### Pronto ! Sua maquina está configurada para rodar a aplicação !

#### As operações do cadastro são bem intuitivas e simples.


Até logo.
