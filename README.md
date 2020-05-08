#Infnet

## Curso de Arquitetura de Sistemas
#### Turma 2020.1


#### Professor Gustavo de Miranda

API para demonstração da utilização de cache com Redis

## Stack da solução

+ Infraestrutura Redis

  + Container Docker  (Linux)

  `
  docker pull redis
   docker run --name redisExemplo -p 6379:6379 redis
  `

  + Configurar a string de conexao no arquivo application.json
    + Aplicacao: String com o banco de dados SQL Server
    + Redis: String de conexão com o Redis; Caso tenha usado o comando docker acima, exatamente assim --> "127.0.0.1,port:6379"

+ Infraestrutura Data

  + Azure Database

+ Aplicação

  + .net Core 3.1 - DDD
    + Pacotes
      + AutoMapper.Extensions.Microsoft.DependencyInjection
      + MessagePack
      + Microsoft.ApplicationInsights.AspNetCore
      + Microsoft.AspNetCore.Hosting.Abstractions
      + Microsoft.AspNetCore.Mvc.Versioning
      + Microsoft.EntityFrameworkCore
      + Microsoft.EntityFrameworkCore.Desig
      + AutoMapper
      + Microsoft.IdentityModel.Tokens
      + System.IdentityModel.Tokens.Jwt
      + Microsoft.Extensions.Caching.Abstractions
      + Microsoft.AspNetCore.Authentication
      + Microsoft.AspNetCore.Authentication.Core
      + Microsoft.AspNetCore.Authentication.JwtBearer
      + Microsoft.Extensions.DependencyInjection.Abstractions
      + Microsoft.Extensions.Options.ConfigurationExtensions
      + Microsoft.EntityFrameworkCore
      + Microsoft.EntityFrameworkCore.Design
      + Microsoft.EntityFrameworkCore.SqlServer
      + Microsoft.EntityFrameworkCore.Tools
      + Microsoft.Extensions.Configuration.FileExtensions
      + Microsoft.Extensions.Configuration.Json
      + Microsoft.Extensions.Configuration.UserSecrets