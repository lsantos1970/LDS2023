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
             * Se comando for inválido --> throw CommandNotValid
             * 
             * Se path inválido --> throw InvalidPath
             * 
             * Se operação não foi executada com sucesso --> throw OperationError
             * 
             * 
             * view.HandleException(excp)
             * 
             */

            //Se for bem sucedido
            view.ApresentarResultados();
        }
        
     }

}