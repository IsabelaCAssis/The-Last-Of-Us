using System;

// Criamos uma classe para rodar o jogo
class Program
{
    static void Main()
    {
        Console.WriteLine("--- TESTANDO SISTEMA DE INVENTÁRIO ---");

        // 1. Criamos a mochila
        Mochila minhaMochila = new Mochila();

        // 2. DESAFIO: Configuramos o alerta (se o peso passar de 90%, ele avisa)
        minhaMochila.AlertaMochilaCheia += (mensagem) => {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        };

        // 3. Criamos os itens (Nome, Quantidade, Peso Unitário)
        Item racao = new Item("Ração Militar", 2, 5); // Total 10kg
        Item kitMedico = new Item("Kit Médico", 1, 2); // Total 2kg
        Item chumbo = new Item("Barra de Chumbo", 1, 35); // Total 35kg (Total Geral: 47kg -> >90% de 50kg)

        // 4. Adicionando na mochila
        minhaMochila.AdicionarItem(racao);
        minhaMochila.AdicionarItem(kitMedico);
        
        Console.WriteLine("Adicionando item pesado para testar o alerta...");
        minhaMochila.AdicionarItem(chumbo);

        // 5. Mostrando o resultado final
        Console.WriteLine($"\nPeso total na mochila: {minhaMochila.PesoAtual}kg / 50kg");
    
        // ... (código anterior)

        // Vamos ver o que tem dentro!
        minhaMochila.ExibirInventario();

        // Teste de uso:
        Console.WriteLine("\nUsando 1 Ração Militar...");
        minhaMochila.UsarItem("Ração Militar");

        // Ver como ficou após o uso
        minhaMochila.ExibirInventario();
        }
}
