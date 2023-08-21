
# Kitchen Routing System

Este é um sistema de pedidos de restaurante aonde os pedidos são realizados em pontos de venda (POS) de possiveis diversos estabelecimentos e são enviados para areas especificas da cozinha de acordo com cada pedido.



## Referência

 - [Fluent Validation](https://docs.fluentvalidation.net)
 - [Moq](https://github.com/moq/moq)
 - [Serilog](https://github.com/serilog/serilog-extensions-logging-file)
 - [XUnit](https://github.com/xunit/xunit)



## Documentação da API

#### Envia o pedido para fila
Retorna status 200 com mensagem ou 400 com o erro 

```http
  Post /Order
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `kitchenOrder` | `KitchenOrderDto` | **Obrigatório**.|

#### Busca a fila de pedidos
Retorna a lista de pedidos

```http
  GET /Order/Get/Queue
```


#### Busca todos os logs registrados
Retorna todos os logs

```http
  GET /Order/Get/Logs
```



## Autores

- [@Candidato (Pediram anonimato)](https://www.github.com/)


## Etiquetas

Adicione etiquetas de algum lugar, como: [shields.io](https://shields.io/)

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://opensource.org/licenses/)
[![AGPL License](https://img.shields.io/badge/license-AGPL-blue.svg)](http://www.gnu.org/licenses/agpl-3.0)

