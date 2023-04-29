using AnaliseImagens;

namespace AnaliseImagens
{
    class View
    {

        /*
         * O evento OnInstructionsNeeded pode ser respondido por delegados do tipo InstructionsHandler, ou seja, pode ser 
         * respondido por qualquer método que tenha a mesma assignatura que o delegado definido. 
         * Quando o evento OnInstructionsNeeded é lançado, delegados que tenham subscrito a esse evento vão receber uma lista de string
         * por referência que podem modificar
         */
        public delegate void InstructionsHandler(ref List<string> commands);
        public event InstructionsHandler OnInstructionsNeeded;

        //Construtor
        public View() {}

        /*
         *  Quando este método é chamado, lança um evento OnInstructionsNeeded
         */
        public void ApresentarInstrucoes()
        {

            List<string> availableCommands = new List<string>();
            OnInstructionsNeeded(ref availableCommands);

            Console.WriteLine("Comandos disponíveis:");
            foreach (string command in availableCommands)
            {
                Console.WriteLine($"- {command}");
            }
        }

        /*
         * Imprime um prompt que solicita ao utilizador para inserir o comando. Esse prompt pode ser precedido de uma mensagem
         * de erro.
        */
        public void ImprimirPromptInserirInput(string msg)
        {
            Console.WriteLine(msg + "Introduza um comando. Para sair, pressione 'E':");
        }

        /*
        * Mensagem de erro quando a operação não foi executada com sucesso e término do programa com código 
        * ERROR_OPERATION_NOT_SUCCESSFUL
        */
        public void ImprimirMensagemErro(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(ExitCodes.ERROR_OPERATION_NOT_SUCCESSFUL);
        }


        /*
         * Mensagem de despedida quando utilizador solicita término do programa e saída com código SUCCESS
         */ 
        public void ImprimirMensagemDespedida()
        {
            Console.WriteLine("A terminar sessão, até breve!");
            Environment.Exit(ExitCodes.SUCCESS);
        }

        /*
         * Este método subscreve a um evento que é lançado quando os resultados estão prontos. Quando isso ocorre, 
         * recebe os resultados como argumento e imprime-os
         */
        public void ApresentarResultados (object sender, AnalysisResultsEventArgs e)
        {
            ColorPercentages results = e.Results;
            Console.WriteLine("Resultados:");
            Console.WriteLine($"Red: {results.RedPercentage}%");
            Console.WriteLine($"Green: {results.GreenPercentage}%");
            Console.WriteLine($"Blue: {results.BluePercentage}%");

            Environment.Exit(ExitCodes.SUCCESS);
        }
    }
}