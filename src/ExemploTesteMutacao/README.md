# Stryker .NET - Buscando e eliminando mutantes

## Execução

Esse exemplo tem como objetivo mostrar o que o Striker .NET faz, qual a técnica utilizada. Para isso, foi utilizado a biblioteca Mono.Cecil para realizar um reflection do nosso assembly e realizar modificação a com a finalizada de incluir pequenos bugs e fazer com que nossos testes unitários quebrem em sua execução.

Para o teste, basta na raiz desse exemplo, executar o comando abaixo no prompt do powershell:

```
> .\run.ps1
```

Como resultado, teremos alguns testes que previsivelmente irão quebrar e um deles será executado com sucesso, ou seja, não passou no teste de mutação.

O script irá executar os seguintes passos:

- Criar diretorio de log
- Criar diretorio do NuGet e efetuar o download caso já não tenha sido feito anteriormente
- Restaurar pacotes da solução
- Compilar solução
- Executar os testes unitários. Nesse ponto, todos devem ser executados com sucesso
- Criar os mutantes, ou seja, irá alterar nosso assembler
- Executa novamente os testes unitários com o objetivo de testar os mutantes, nessa execução, todos os testes devem falhar. 


## Autor

[Raphael A. F. Cardoso](https://raphaelcardoso.com.br)

