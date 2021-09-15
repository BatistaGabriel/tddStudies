# Estudos de TDD

## Contexto

Este repositório foi criado para concentrar os códigos que forem gerados durante o andamento do curso "TDD com xUnit para C# .NET Core"


## Troubleshoot

Caso quanto tente rodar um ```dotnet restore``` e tenha o seguinte output
```
PS C:\Workspace\tddStudies> dotnet restore
  Determinando os projetos a serem restaurados...
C:\Workspace\tddStudies\test\OnlineCourses.Domain.Test\OnlineCourses.Domain.Test.csproj : error NU1100: Não foi possível resolver 'Bogus (>= 33.1.1)' para 'net5.0'. [C:\Workspace\tddStudies\OnlineCourses.sln]
C:\Workspace\tddStudies\test\OnlineCourses.Domain.Test\OnlineCourses.Domain.Test.csproj : error NU1100: Não foi possível resolver 'ExpectedObjects (>= 3.5.4)' 
para 'net5.0'. [C:\Workspace\tddStudies\OnlineCourses.sln]
C:\Workspace\tddStudies\test\OnlineCourses.Domain.Test\OnlineCourses.Domain.Test.csproj : error NU1100: Não foi possível resolver 'Microsoft.NET.Test.Sdk (>= 16.7.1)' para 'net5.0'. [C:\Workspace\tddStudies\OnlineCourses.sln]
C:\Workspace\tddStudies\test\OnlineCourses.Domain.Test\OnlineCourses.Domain.Test.csproj : error NU1100: Não foi possível resolver 'xunit (>= 2.4.1)' para 'net5.0'. [C:\Workspace\tddStudies\OnlineCourses.sln]
C:\Workspace\tddStudies\test\OnlineCourses.Domain.Test\OnlineCourses.Domain.Test.csproj : error NU1100: Não foi possível resolver 'xunit.runner.visualstudio (>= 2.4.3)' para 'net5.0'. [C:\Workspace\tddStudies\OnlineCourses.sln]
```

Tente executar os comando:

```
 dotnet nuget locals --clear all
```
^ Limpa suas referencias locais do nuget

```
dotnet nuget add source https://api.nuget.org/v3/index.json -n DefaultNuget
```
^ Registra um novo apontamento para o source https://api.nuget.org/v3/index.json