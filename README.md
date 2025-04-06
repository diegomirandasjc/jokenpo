# 🧠 Jokenpô Extensível – Clássico e 15 Movimentos

Este projeto implementa o tradicional Jokenpô (Pedra, Papel e Tesoura), mas com uma proposta moderna e extensível: é possível configurar facilmente novas regras de jogo, como as versões com 5, 7 ou até 15 movimentos, tudo sem alterar o código, apenas atualizando a configuração.

---

## 🎮 Como funciona o jogo

### 🪨 Jokenpô Clássico

O jogo clássico segue estas regras:

| Jogada | Vence       |
|--------|-------------|
| PEDRA  | TESOURA     |
| PAPEL  | PEDRA       |
| TESOURA| PAPEL       |

E é isso que o sistema executa por padrão!

---

### 🔁 Extensível via configuração

Graças ao design *config-driven*, você pode adicionar novos movimentos (como "FOGO", "DRAGÃO", "ESPONJA"...) sem tocar no código fonte.

Você só precisa editar o `appsettings.json`, como neste exemplo:

```json
{
    "Moves": [
        {
            "Name": "PEDRA",
            "Defeats": [
                { "Target": "TESOURA", "Action": "esmaga" },
                { "Target": "LAGARTO", "Action": "esmaga" }
            ]
        },
        {
            "Name": "PAPEL",
            "Defeats": [
                { "Target": "PEDRA", "Action": "cobre" },
                { "Target": "SPOCK", "Action": "desaprova" }
            ]
        }
    ]
}
```

Você pode inserir quantas jogadas quiser, incluindo o modo com 15 movimentos como no popular *Rock Paper Scissors 15*, com derrotas circulares configuráveis.

---

## 🧱 Arquitetura do Projeto

O sistema foi desenvolvido usando *Clean Architecture* com múltiplos projetos organizados por responsabilidade:

```
Jokenpo/
├── Domain/
│   ├── Models/           → Modelos puros como `Move`, `DefeatRule`
│   └── Services/         → Regras como `GameRuleService`
├── Application/
│   └── UseCases/         → Orquestra casos de uso (`PlayGameUseCase`)
├── Infrastructure/
│   ├── Config/           → Carrega as regras do appsettings
│   └── IoC/              → Injeção de dependência
├── Api/
│   └── Api/              → API REST usando ASP.NET Core
├── Tests/                → Testes unitários com xUnit
```

---

## 🚀 Executando o Projeto

### Restaurar e compilar:

```bash
dotnet restore
dotnet build
```

### Executar a API:

```bash
cd Api/Api
dotnet run
```

### Acessar Swagger:

[http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 📮 Endpoint REST

### POST `/game/jogar`

Exemplo de requisição:

```json
{
    "player1": "TESOURA",
    "player2": "PAPEL"
}
```

Resposta:

```json
{
    "resultado": "TESOURA corta PAPEL — Jogador 1 venceu!"
}
```

---

## 🧪 Testes Automatizados

Execute os testes com:

```bash
dotnet test
```

Os testes cobrem:

- Lógica de vitória (`GameRuleService`)
- Casos de uso (`PlayGameUseCase`)

---

## 🧠 Por que essa arquitetura?

| Conceito            | Vantagem                              |
|---------------------|---------------------------------------|
| Clean Architecture  | Separação de responsabilidades        |
| Config-Driven       | Muda regras sem alterar código        |
| Testável            | Cobertura de lógica pura com xUnit    |
| Extensível          | Suporta novas jogadas facilmente      |
| Modular por projeto | Fácil de manter e escalar            |
