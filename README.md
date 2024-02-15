# DeliveryMan

O DeliveryMan é uma aplicação para gerenciamento de entregadores, com endpoints que possibilitam criar, listar e autenticar entregadores. O foco desta API é estudar o uso de filtros, middlewares e handlers em Web API (bem como o uso de autenticação por token através do JWT - além de fazer tratamento de erro através de atributos sejam eles customizados ou não)

## Instalação

Para instalar o DeliveryMan, siga os seguintes passos:

1. Clone o repositório do GitHub:
```bash
git clone https://github.com/tauanyfeitosa/AdaTech.Delivery
```


2. Certifique-se de ter o ambiente configurado conforme as instruções do projeto.

## Como Usar
Para usar o AdaTech.ProcessadorTarefas, siga estas etapas:

1. Inicie a aplicação: Abra a aplicação em uma IDE de sua preferência!

2. Acesse a interface do usuário em um navegador ou utilize a API para enviar tarefas para processamento (detalhes específicos sobre como interagir com a aplicação). Caso esteja utilizando Visual Studio, basta iniciar a aplicação que ela abrirá no navegador.

Os endpoints disponíveis são:

- **GET /api/DeliveryMen**: Retorna todos os entregadores cadastrados.
- **POST /api/DeliveryMen**: Cria um novo entregador.
- **GET /api/DeliveryMen/byCPF**: Retorna um entregador específico pelo CPF.
- **POST /api/DeliveryMen/testMiddleware**: Testa o middleware de autorização (apenas para usuários autorizados).
- **GET /api/DeliveryMen/login**: Autentica um entregador e gera um token JWT.

Certifique-se de incluir as credenciais necessárias nos headers das requisições, especialmente para endpoints que requerem autorização.

## Swagger - O que é? Como funciona?

Swagger é uma ferramenta de interface para descrever, produzir, consumir e visualizar serviços da Web RESTful. Ele especifica um formato padrão para APIs REST, o que facilita a compreensão e o uso dos endpoints por desenvolvedores e usuários finais.

No DeliveryMan API, utilizei o Swagger para fornecer uma documentação interativa da API. Através do Swagger UI, é possível visualizar todos os endpoints disponíveis, seus métodos HTTP, parâmetros necessários e os formatos de resposta esperados. Além disso é possível testar o uso do JWT em conjunto com filtros.

### Como usar um endpoint

Para usar um endpoint do ProcessadorTarefas API via Swagger UI, siga estes passos:

1. Navegue até o endpoint desejado na documentação do Swagger.
2. Clique no método do endpoint para expandir os detalhes.
3. Se o método requer parâmetros, eles serão listados na seção `Parameters`. Caso não haja parâmetros, como no endpoint `/api/Processamento/iniciar`, você pode simplesmente executar o endpoint diretamente.
4. Clique no botão `Try it out` para ativar a funcionalidade de teste.
5. Se necessário, insira os parâmetros requeridos.
6. Clique no botão `Execute` para fazer uma chamada ao endpoint.

ATENÇÃO: Caso o endpoint tenha um cadeado ao lado, ele requer o uso do JWT, seu JWT dura 30 minutos e não fica salvo no sistema - basta clicar no cadeado e colocar seu código. Não o perca ou terá que gerar outro!!!

## Autenticação JWT

A autenticação é feita através de JWT (JSON Web Token). O endpoint `/api/DeliveryMen/login` retorna um token de autenticação válido por 30 minutos, que deve ser incluído nos headers das requisições posteriores para acesso aos endpoints protegidos.

## Contribuição

Se deseja contribuir com o projeto, por favor, siga estas etapas:

1. Faça um fork do projeto.
2. Crie sua branch de feature (`git checkout -b feature/MinhaFeature`).
3. Faça commit de suas alterações (`git commit -am 'Adicionar uma nova feature'`).
4. Faça push para a branch (`git push origin feature/MinhaFeature`).
5. Crie um novo Pull Request.

## Licença

Este projeto está licenciado sob a [MIT License](https://opensource.org/licenses/MIT).

## Agradecimentos
- Agradeço grandemente ao meu parceiro Victor por me apoiar nessa jornada e sempre me incentivar a continuar tentando! Há três meses eu não sabia como imprimir algo no Console do Visual Studio ou como depurar uma aplicação Console. Hoje, não sei muitas coisas também... mas a lista das coisas que sei não vai parar de aumentar se eu sempre estiver tentando!!!

## Contato

Mande-me um email se precisar: [tauanysanttos13@gmail.com](mailto:tauanysanttos13@gmail.com)
