namespace Boliche
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine(">>>>> Placar de Boliche <<<<<");
            var quadros = Placar.LeituraQuadros();
            
            Thread.Sleep(2000);
            try
            {
                Console.WriteLine($"Pontuacao final: {String.Join("|", Placar.Soma(quadros))}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro - Abortando cálculo do placar: {e.Message}");
            }
        }
    }
}
