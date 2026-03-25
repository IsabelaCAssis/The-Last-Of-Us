# The-Last-Of-Us
*The Last of Us - Sistem de Inventário*

Contexto: Em um jogo pós-apocalíptico, o jogador precisa gerenciar recursos escassos. Você vai criar o sistema de itens e mochila.

Objetivo: **Criar uma classe Item encapsulada e uma classe Mochila que gerencie esses itens com validação.**

Especificações:
Classe Item:
Atributos privados: string nome, int quantidade, int pesoUnitario.
Propriedades públicas (get/set) com validação: Nome não pode ser vazio, Quantidade não pode ser negativa, PesoUnitario não pode ser zero ou negativo.
Método double PesoTotal()que calcula quantidade * pesoUnitario.

Classe Mochila:
Atributo privado: List<Item> itens.
Método bool AdicionarItem(Item novoItem): Se o item já existe (mesmo nome), aumenta a quantidade (desafio: respeitar limite de peso ou slots? Crie um limite fictício).
Método bool UsarItem(string nomeItem): Diminui a quantidade em 1. Se chegar a zero, remove da lista.
Propriedade double PesoAtual(get) que soma o peso total de todos os itens.

Desafio: Implementar um evento que alerta quando a mochila está quase cheia (acima de 90% da capacidade).
