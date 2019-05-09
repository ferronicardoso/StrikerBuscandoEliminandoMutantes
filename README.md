# Stryker .NET - Buscando e eliminando mutantes

**Professor X:** _Para alguém que odeia mutantes ... você certamente mantém uma companhia estranha._  
**William Stryker:** _Oh, eles servem ao seu propósito ... desde que possam ser controlados._  

_**Nota:** O nome "Stryker" faz referência ao Sargento William Stryker, famoso personagem dos quadrinhos da Marvel inimigo dos X-Men._

## Introdução

**[Stryker .NET](https://github.com/stryker-mutator/stryker-net)** é uma ferramenta para testar os testes unitários de nossos projetos inserindo nele códigos mutados, ou seja, ele altera nosso projeto para inserir _bugs_ com o objetivo de _quebrar_ os testes unitários. Quanto maior a porcentagem de mutantes mortos, mais eficazes serão seus testes.

*Cobertura de código não é sinonimo de eficácia dos seus testes.*

## Mutadores Suportados

As seguintes mutações são suportada pela versão atual do Stryker .NET:
- Arithmetic Operators
- Equality Operators
- Boolean Literals
- Assignment statements
- Unary Operators
- Update Operators
- Checked Statements
- Linq Methods
- String Literals

## Instalando o Stryker .NET

Para utilizar o Stryker é necessário instala-lo globalmente executando o comando abaixo:

```
> dotnet tool install -g dotnet-stryker
```

## Executando o Stryker

A execução do Stryker pode ser realizada em projeto .NET Core 1.1+ ou .NET Full Framework 4.5+.

Para os projetos .NET Core, basta abrir o console dentro do diretorio do projeto de teste unitário e executar o comando abaixo:

```
> dotnet stryker
```

Já para os projetos .NET Full Framework, é necessário informar no da Solution do projeto

```
> dotnet stryker --solution-path "..\\SolutionName.sln" 
```

Caso o projeto tenha mais de um projeto, é preciso especificar qual o projeto

```
> dotnet stryker --solution-path "..\\SolutionName.sln" --project-file "ProjectName.csproj"
```

Para customizar os reports e definir percentual de pontuação mínima e máxima
```
dotnet stryker -tl 20 -th 25 -r "['ConsoleProgressBar', 'ConsoleReport', 'Html']"
```

Para saber mais sobre as opções disponíveis, basta executar o comando help:

```
> dotnet stryker -h
```

## Autor

[Raphael A. F. Cardoso](https://raphaelcardoso.com.br)

