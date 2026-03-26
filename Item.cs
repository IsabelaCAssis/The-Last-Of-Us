public class Item
{
    private string _nome;
    private int _quantidade;
    private int _pesoUnitario;

    public string Nome
    {
        get => _nome;
        set {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Nome não pode estar vazio.");
            _nome = value; 
        }
    }

    public int Quantidade
    {
        get => _quantidade;
        set{
            if (value < 0) _quantidade;
            else _quantidade = value;
        }
    }           

    public int PesoUnitario
    {
        get => _pesoUnitario;
        set{
            if (value <= 0) throw new ArgumentException("Peso deve ser maior que zero.");
            _pesoUnitario = value;
        }
    }

    // Calcula o peso total deste "lote" de itens
    public double PesoTotal() => Quantidade * PesoUnitario;

    public Item(string nome, int qtd, int peso)
    {
        Nome = nome;
        Quantidade = qtd;
        PesoUnitario = peso;
    }
}