# Implementação da Interface Gráfica e Conexão com Banco de Dados

Neste projeto, nossa equipe se dedicou à criação de uma aplicação que integra uma interface gráfica com um banco de dados SQL Server, utilizando como base o banco de dados Northwind. A seguir, detalhamos as funcionalidades implementadas:

## Identificação

**Equipe**: Robson Lins e Talita Pacheco

**Disciplina**: Banco de Dados II

## Tecnologias Utilizadas

Neste projeto, utilizamos uma combinação de tecnologias modernas e eficazes para garantir a funcionalidade e a performance da aplicação. Abaixo estão as principais tecnologias empregadas:

- Linguagem de Programação: C#
- Framework: ASP.NET
- Banco de Dados: Microsoft SQL Server
- Frontend: HTML, CSS, JavaScript

## Funcionalidades Implementadas

### 1. Visualização / Inserção / Remoção / Atualização de Clientes

Nesta funcionalidade, o sistema permite a visualização detalhada dos clientes cadastrados, bem como a inclusão, remoção e atualização de informações. Cada operação é realizada de forma intuitiva e amigável para o usuário.

### 2. Visualização de Compras

A funcionalidade de visualização de compras proporciona ao usuário uma visão completa do histórico de transações realizadas. Os dados são apresentados de forma organizada e de fácil compreensão.

### 3. Inserção de uma Compra com Vários Produtos

Esta funcionalidade permite a inserção de uma compra contendo múltiplos produtos. O sistema guia o usuário através do processo, garantindo que todas as informações necessárias sejam fornecidas de forma eficiente.

### 4. Procedimento Armazenado para Relatório

Foi criado um procedimento armazenado para gerar um relatório que exibe a relação das vendas por categoria. O relatório apresenta informações como a categoria, a quantidade de produtos vendidos por categoria, o total arrecadado pela categoria, o maior comprador daquela categoria, o país com mais compras daquela categoria e a cidade com mais compras da categoria. Os resultados são ordenados pelo valor arrecadado, proporcionando uma visão clara e estruturada das informações.

### 5. Gatilho para Limitar Compras Diárias

Foi implementado um gatilho que impede um cliente de realizar mais de quatro compras em um único dia contendo mais de 4 categorias de produtos. Essa medida visa manter um controle adequado das transações e evitar abusos no sistema.
