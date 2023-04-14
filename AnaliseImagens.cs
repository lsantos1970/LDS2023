namespace AnaliseImagens
{
    public static class ExitCodes
    {
        public const int SUCCESS = 0;
        public const int ERROR_NO_COMMAND = 1;
        public const int ERROR_INVALID_COMMAND = 2;
        public const int ERROR_INVALID_IMAGE = 3;
        public const int ERROR_OPERATION_NOT_SUCCESSFUL = 4;
    }

    class AnaliseImagens
    {
 
        //Iniciar o programa
        static void Main(string[] args)
        {
            AnaliseImagens app = new AnaliseImagens();
            Controller controller = new Controller();

        }
    }
}
