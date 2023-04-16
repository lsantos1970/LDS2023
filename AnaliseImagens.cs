namespace AnaliseImagens
{
    public static class ExitCodes
    {
        public const int SUCCESS = 0;
        public const int ERROR_OPERATION_NOT_SUCCESSFUL = 1;
    }

    class AnaliseImagens
    {
 
        //Iniciar o programa
        static void Main(string[] args)
        {
            AnaliseImagens app = new AnaliseImagens();
            Controller controller = new Controller();
            controller.IniciarPrograma();

        }
    }
}
