Realizei uma arquitetura orientadas a Dados bem simples e com cache para otimização

Aplicação de Análise de Gastos Públicos a partir de Dados do TSE
Esta aplicação tem como objetivo processar dados de prestação de contas eleitorais fornecidos pelo Tribunal Superior Eleitoral (TSE), especificamente os disponíveis no seguinte site:

Fonte dos dados:
https://dadosabertos.tse.jus.br/dataset/prestacao-de-contas-eleitorais-2024

Os dados, que são disponibilizados em formato CSV, contêm informações detalhadas sobre os gastos de campanha, incluindo valores gastos por cidade, capitais e a origem dos recursos (públicos ou privados).

Funcionalidades da Aplicação
Extração de Dados:

A aplicação lê os arquivos CSV fornecidos pelo TSE e armazena os dados localmente em uma pasta do projeto (por exemplo, a pasta bin).
Processamento de Gastos:

A aplicação filtra os dados para exibir informações específicas, como:
Os maiores gastos por cidade.
Análise dos gastos de todas as capitais do Brasil.
Cálculo do total de recurso público utilizado nas campanhas.
Relatórios:

A aplicação gera relatórios que exibem as cidades com maiores gastos e o total de recursos públicos, permitindo uma visão geral e comparativa dos gastos eleitorais entre as capitais.
Objetivo
O objetivo principal é permitir que gestores e analistas possam entender melhor a distribuição dos gastos de campanha, com ênfase na utilização de recursos públicos, promovendo maior transparência e controle social sobre os recursos utilizados em eleições.
