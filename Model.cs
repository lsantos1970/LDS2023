using System.IO;
using System.Reflection.Metadata;

namespace AnaliseImagens
{
    class Model
    {
        //Atributos
        private List<string> listCmds;
        private View view;

        //Construtor
        public Model(View _view)
        {
            view = _view;
        }

        public List<string> ListarComandos() 
        {

            return listCmds;
        }

        public void ExecutarComando(string commandReceived) {
            /*
             * Se comando for inválido --> create CommandNotValid
             * 
             * CommandNotValid ex = new CommandNotValid()
             * view.HandleException(ex)
             * 
             * Se path inválido --> create InvalidPath
             * 
             * * InvalidPath ex = new InvalidPath()
             * view.HandleException(ex)
             * 
             * Se operação não foi executada com sucesso --> create OperationError
             * OperationError ex = new OperationError()
             * view.HandleException(ex)
             * 
             */

            //Se for bem sucedido
            view.ApresentarResultados();
        }
        
     }

}