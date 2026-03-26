using System;
using System.Collections.Generic;
using System.Linq; // Permite usar o .Sum() para somar pesos rapidamente

public class Mochila
{
    // A lista que guarda nossos objetos do tipo Item
    private List<Item> _itens = new List<Item>();
    private double _capacidadeMaxima = 50.0;

    // O EVENTO: Funciona como um sinal de rádio que envia uma mensagem (string)
    public event Action<string>? AlertaMochilaCheia;

    // PROPRIEDADE: Calcula o peso de tudo o que está lá dentro em tempo real
    public double PesoAtual => _itens.Sum(i => i.PesoTotal());

    public bool AdicionarItem(Item novoItem)
    {
        // Regra 1: Se o peso do novo item + o que já tem passar de 50kg, não entra.
        if (PesoAtual + novoItem.PesoTotal() > _capacidadeMaxima)
        {
            return false;
        }

        // Regra 2: Se o item já existe, só aumenta a quantidade
        var itemExistente = _itens.FirstOrDefault(i => i.Nome == novoItem.Nome);
        if (itemExistente != null)
        {
            itemExistente.Quantidade += novoItem.Quantidade;
        }
        else
        {
            _itens.Add(novoItem);
        }

        // DESAFIO: Se atingir 90% da capacidade (45kg), dispara o alerta
        if (PesoAtual >= _capacidadeMaxima * 0.9)
        {
            AlertaMochilaCheia?.Invoke($"⚠️ CUIDADO: Mochila quase cheia! Peso: {PesoAtual}kg");
        }

        return true;
    }

    public bool UsarItem(string nomeItem)
    {
        var item = _itens.FirstOrDefault(i => i.Nome == nomeItem);
        
        if (item != null)
        {
            item.Quantidade--;
            // Se acabar o estoque, removemos o item da lista
            if (item.Quantidade <= 0) _itens.Remove(item);
            return true;
        }
        return false;
    }
public void ExibirInventario()
{
    Console.WriteLine("\n========== INVENTÁRIO ==========");
    if (_itens.Count == 0)
    {
        Console.WriteLine("A mochila está vazia...");
    }
    else
    {
        foreach (var item in _itens)
        {
            // Mostramos Nome, Quantidade e o Peso Total daquele "lote"
            Console.WriteLine($"- {item.Nome}: {item.Quantidade}x | Peso: {item.PesoTotal()}kg");
        }
    }
    Console.WriteLine("================================");
    Console.WriteLine($"Capacidade: {PesoAtual}kg / 50kg");
}
}