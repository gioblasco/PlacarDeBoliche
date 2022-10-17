namespace Boliche
{
    public static class Placar
    {
        public static IList<IList<string>> LeituraQuadros() {
            Console.WriteLine("Insira as pontuacoes de cada frame por linha e cada jogada deve ser separada por |");

            var quadros = new List<IList<string>>();
            for (int i = 0; i < 10; i++)
            {
                var leituraQuadro = Console.ReadLine();
                quadros.Add(leituraQuadro.Split("|"));
            }

            return quadros;
        }

        public static IList<int> Soma(IList<IList<string>> quadros)
        {
            Console.WriteLine("Calculando pontuacao final...");

            if (quadros.Count != 10)
            {
                throw new ArgumentException("Uma partida deve ter 10 quadros");
            }

            var pontuacaoFinal = new List<int>();
            var pontuacaoQuadro = 0;
            for (int index = 0; index < quadros.Count; index++)
            {
                pontuacaoQuadro += PegaPontuacaoQuadro(quadros[index]);
                pontuacaoQuadro += PegaPontuacaoExtra(quadros, index);
                pontuacaoFinal.Add(pontuacaoQuadro);
            }

            return pontuacaoFinal;  
        }

        private static int PegaPontuacaoQuadro(IList<string> quadroAtual)
        {
            int pontuacaoTotal = 0;
            for (int quadroIndex = 0; quadroIndex < quadroAtual.Count; quadroIndex++)
            {
                pontuacaoTotal += ConverteSimbolo(quadroAtual, quadroIndex);
            }

            return pontuacaoTotal;
        }

        private static int ConverteSimbolo(IList<string> quadro, int indexInterno)
        {
            switch(quadro[indexInterno])
            {
                case "-":
                    return 0;
                case "/":
                    return 10 - ConverteSimbolo(quadro, indexInterno - 1);
                case "X":
                    return 10;
                default:
                    if (int.TryParse(quadro[indexInterno], out var number))
                    {
                        return number;
                    }
                    throw new FormatException($"Valor inserido ({quadro[indexInterno]}) não pode ser somado");
            }
        }

        private static int PegaPontuacaoExtra(IList<IList<string>> quadros, int indexQuadroAtual)
        {
            var quadroAtual = quadros[indexQuadroAtual];
            if (quadroAtual.Count == 1 && quadroAtual.Contains("X"))
            {
                var proximoQuadro = quadros[indexQuadroAtual + 1];
                if (proximoQuadro.Count > 1 || indexQuadroAtual + 2 > 9)
                {
                    return PegaPontuacaoQuadro(proximoQuadro.Take(2).ToList());
                }

                var proximoProximoQuadro = quadros[indexQuadroAtual + 2];
                return PegaPontuacaoQuadro(proximoQuadro.Take(1).ToList()) + PegaPontuacaoQuadro(proximoProximoQuadro.Take(1).ToList());
            }
            
            if (quadroAtual.Count == 2 && quadroAtual.Contains("/"))
            {
                var proximoQuadro = quadros[indexQuadroAtual + 1];
                return PegaPontuacaoQuadro(proximoQuadro.Take(1).ToList());
            }

            return 0;
        }
    }
}
