using System;
using System.Collections.Generic;
using System.Linq;

public class Mochila
{
    private List<Item> _itens = new List<Item>();
    private double _capacidadeMaxima = 50.0; // Limite de peso fictício

    // Evento que avisa quando a mochila está > 90%
    public event Action<string> AlertaMochilaCheia;

    public double PesoAtual => _itens.Sum(i => i.PesoTotal());

    public bool AdicionarItem(Item novoItem)
    {
        // Verificar se cabe na mochila
        if (PesoAtual + novoItem.PesoTotal() > _capacidadeMaxima) return false;

        // Verificar se o item já existe (mesmo nome)
        var itemExistente = _itens.FirstOrDefault(i => i.Nome == novoItem.Nome);

        if (itemExistente != null)
        {
            itemExistente.Quantidade += novoItem.Quantidade;
        }
        else
        {
            _itens.Add(novoItem);
        }

        // Checar o limite de 90% para disparar o alerta
        VerificarCapacidade();
        return true;
    }

    private void VerificarCapacidade()
    {
        if (PesoAtual >= _capacidadeMaxima * 0.9)
        {
            // Dispara o alerta se houver alguém "ouvindo"
            AlertaMochilaCheia?.Invoke($"AVISO: Mochila quase cheia! ({PesoAtual}/{_capacidadeMaxima}kg)");
        }
    }

    public bool UsarItem(string nomeItem)
    {
        var item = _itens.FirstOrDefault(i => i.Nome == nomeItem);
        if (item == null) return false;

        item.Quantidade--;
        if (item.Quantidade <= 0) _itens.Remove(item);
        
        return true;
    }
}
